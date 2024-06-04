package Excel

import (
	"fmt"
	"path/filepath"
	"regexp"
	"strings"
	"time"

	Analyzer "github.com/Fresh-vano/CS2-Parser/analyzer"
	"github.com/xuri/excelize/v2"
)

type Export struct {
	Workbook     *Workbook
	Demo         *Analyzer.Demo
	PlayersSheet *PlayersSheet
	TeamsSheet   *TeamsSheet
}

func (ex *Export) IniExport(demo *Analyzer.Demo) {
	ex.Workbook = NewWorkbook()
	ex.Demo = demo
	ex.PlayersSheet = &PlayersSheet{
		Demo:     demo,
		Workbook: ex.Workbook,
	}
}

func (ex *Export) Generate() {
	ex.Workbook.AddSheet(ex.PlayersSheet.GetName())
	ex.Workbook.AddRowToSheet(ex.PlayersSheet.GetName(), ex.PlayersSheet.GetColumnNames())
	ex.PlayersSheet.Generate()
	style, _ := ex.Workbook.Workbook.NewStyle(&excelize.Style{NumFmt: 22})
	dateStr := ex.Demo.Date.Format("02.01.06 15:04")
	cell := "A2"
	ex.Workbook.Workbook.SetCellValue(ex.PlayersSheet.GetName(), cell, dateStr)
	ex.Workbook.Workbook.SetCellStyle(ex.PlayersSheet.GetName(), cell, cell, style)

	ex.TeamsSheet = ex.TeamsSheet.NewTeamsSheet(ex.Workbook)
	ex.Workbook.AddSheet(ex.TeamsSheet.GetName())
	ex.TeamsSheet.AddDemo(*ex.Demo)
	ex.TeamsSheet.Workbook.AddRowToSheet(ex.TeamsSheet.GetName(), ex.TeamsSheet.GetColumnNames())
	ex.TeamsSheet.Generate()
}

func (ex *Export) Save(path string) {
	ex.Workbook.Workbook.DeleteSheet("Sheet1")
	ex.Workbook.Write(path)
}

func NewExport(demo *Analyzer.Demo) *Export {
	export := &Export{}
	export.IniExport(demo)
	export.Generate()
	return export
}

func (ex *Export) ExportToFile(path string) {
	reg, _ := regexp.Compile(`^\W+|\W+$`)

	cleanTeam1Name := reg.ReplaceAllString(strings.ToUpper(ex.Demo.Team1.Name), "")
	cleanTeam2Name := reg.ReplaceAllString(strings.ToUpper(ex.Demo.Team2.Name), "")

	dir := filepath.Dir(path)
	currentTime := time.Now()
	dateString := currentTime.Format("2006_01_02_15_04_05")
	filePath := fmt.Sprintf("%s-vs-%s-%s-%s.xlsx", cleanTeam1Name, cleanTeam2Name, ex.Demo.Parser.Header().MapName, dateString)
	exportFilePath := filepath.Join(dir, filePath)
	ex.Save(exportFilePath)

	fmt.Println("Файл сохранен")
}
