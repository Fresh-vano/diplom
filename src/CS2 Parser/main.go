package main

import (
	"crypto/rand"
	"encoding/hex"
	"fmt"
	"io"
	"log"
	"net/http"
	"os"
	"path/filepath"
	"strconv"

	"github.com/Fresh-vano/CS2-Parser/Export"
	Models "github.com/Fresh-vano/CS2-Parser/Models"
	Analyzer "github.com/Fresh-vano/CS2-Parser/analyzer"
	"gorm.io/driver/postgres"
	"gorm.io/gorm"
)

func main() {
	http.HandleFunc("/upload", uploadFileHandler)
	http.HandleFunc("/analyze", analyzeFileHandler)
	log.Fatal(http.ListenAndServe(":8080", nil))
}

func uploadFileHandler(w http.ResponseWriter, r *http.Request) {
	if r.Method != "POST" {
		http.Error(w, "Only POST method is allowed", http.StatusMethodNotAllowed)
		return
	}

	r.ParseMultipartForm(1024 << 20)
	file, handler, err := r.FormFile("uploadfile")
	if err != nil {
		log.Println("Error Retrieving the File")
		log.Println(err)
		http.Error(w, "Error retrieving the file", http.StatusBadRequest)
		return
	}
	defer file.Close()

	randomBytes := make([]byte, 16)
	rand.Read(randomBytes)
	uniqueFileName := hex.EncodeToString(randomBytes) + filepath.Ext(handler.Filename)

	tempFile, err := os.CreateTemp("uploads", "upload-*"+filepath.Ext(handler.Filename))
	if err != nil {
		log.Println(err)
		http.Error(w, "Failed to create temp file", http.StatusInternalServerError)
		return
	}
	defer tempFile.Close()

	fileBytes, err := io.ReadAll(file)
	if err != nil {
		log.Println(err)
		http.Error(w, "Failed to read file data", http.StatusInternalServerError)
		return
	}
	tempFile.Write(fileBytes)

	fmt.Fprintf(w, "File uploaded successfully: %s", uniqueFileName)
}

func analyzeFileHandler(w http.ResponseWriter, r *http.Request) {
	if r.Method != "POST" {
		http.Error(w, "Only POST method is allowed", http.StatusMethodNotAllowed)
		return
	}

	r.ParseForm()
	tournamentID := r.FormValue("tournament_id")
	stageID := r.FormValue("stage_id")
	team1ID := r.FormValue("team1_id")
	team2ID := r.FormValue("team2_id")
	fileName := r.FormValue("file_name")
	mapId := r.FormValue("map_id")

	dsn := "host=localhost user=postgres password=11111111 dbname=CS2 port=5432 sslmode=disable"
	db, err := gorm.Open(postgres.Open(dsn), &gorm.Config{})
	if err != nil {
		log.Fatalf("Failed to connect to database: %v", err)
	}

	err = analyzeAndSaveToDB(db, tournamentID, stageID, team1ID, team2ID, mapId, fileName)
	if err != nil {
		http.Error(w, "Failed to analyze and save results", http.StatusInternalServerError)
		return
	}

	fmt.Fprintf(w, "Analysis completed for file %s with tournament ID %s, stage ID %s, team1 ID %s, team2 ID %s", fileName, tournamentID, stageID, team1ID, team2ID)
}

func analyzeAndSaveToDB(db *gorm.DB, tournamentID, stageID, team1ID, team2ID, mapId, fileName string) error {
	fullPath := filepath.Join("uploads", fileName)

	demo := &Analyzer.Demo{
		Team1: &Models.Team{},
		Team2: &Models.Team{},
	}

	err := Analyzer.AnalyzeDemo(fullPath, demo)
	if err != nil {
		log.Printf("Error during demo analysis: %v\n", err)
		return err
	}

	mapid, _ := strconv.Atoi(mapId)
	team1id, _ := strconv.Atoi(team1ID)

	playersSheet := Export.PlayersSheet{}
	playersSheet.Demo = demo
	playersData := playersSheet.Generate(mapid, team1id)

	for item := range playersData {
		result := db.Create(item)
		if result.Error != nil {
			log.Printf("Error while saving to database: %v\n", err)
			return err
		}
	}

	var temp = Export.TeamsSheet{}
	teamsSheet := temp.NewTeamsSheet()
	teamsData := teamsSheet.AddDemo(*demo, mapid, team1id)

	for _, item := range teamsData {
		result := db.Create(item)
		if result.Error != nil {
			log.Printf("Error while saving to database: %v\n", err)
			return err
		}
	}

	log.Println("Analysis completed and data saved to database successfully.")
	return nil
}
