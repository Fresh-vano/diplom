package test

import (
	"fmt"
	"os"
	"path/filepath"
	"strings"
	"testing"

	"github.com/Fresh-vano/CS2-Parser/Excel"
	"github.com/Fresh-vano/CS2-Parser/Models"
	Analyzer "github.com/Fresh-vano/CS2-Parser/analyzer"
	test_models "github.com/Fresh-vano/CS2-Parser/test/models"
)

func runMatchTest(t *testing.T, demFilePath, expectedExcelPath string) {
	demo := &Analyzer.Demo{Team1: &Models.Team{}, Team2: &Models.Team{}}
	err := Analyzer.AnalyzeDemo(demFilePath, demo)
	if err != nil {
		t.Logf("Ошибка при анализе dem файла: %+v", err)
	}

	exportFilePath := demFilePath + "_test.xlsx"
	exporter := Excel.NewExport(demo)
	exporter.Save(exportFilePath)

	expectedExcel := (&test_models.TestFile{}).Init()
	expectedExcel.OpenExcel(expectedExcelPath)

	currentExcel := (&test_models.TestFile{}).Init()
	currentExcel.OpenExcel(exportFilePath)

	CompareTestFiles(t, expectedExcel, currentExcel)
}

func compareMatchRounds(t *testing.T, demFilePath string, expectedRounds int) {
	demo := (&Analyzer.Demo{
		Team1: (&Models.Team{}),
		Team2: (&Models.Team{}),
	})

	if strings.Contains(demFilePath, "-p1.dem") {
		i := 1
		for {
			newPath := strings.Replace(demFilePath, "-p1.dem", fmt.Sprintf("-p%d.dem", i), 1)
			if _, err := os.Stat(newPath); err == nil {
				t.Logf("Анализируем файл: %s\n", newPath)

				err = Analyzer.AnalyzeDemo(newPath, demo)

				if err != nil {
					t.Logf("Ошибка при анализе dem файла: %s\n", newPath)
				}

				i++
			} else {
				break
			}
		}
	}

	if len(demo.Rounds) != expectedRounds {
		t.Errorf("Expected %d rounds, got %d", expectedRounds, len(demo.Rounds))
	}
}

func TestMatch1(t *testing.T) {
	demFilePath := filepath.Join("testdata", "esl-challenger-atlanta-2023-europe-closed-qualifier", "movistar-riders-vs-apeks-m1-inferno.dem")
	expectedExcelPath := filepath.Join("testdata", "esl-challenger-atlanta-2023-europe-closed-qualifier", "movistar-riders-vs-apeks-m1-inferno.xlsx")
	runMatchTest(t, demFilePath, expectedExcelPath)
}

func TestRoundPart(t *testing.T) {
	demFilePath := filepath.Join("testdata", "thunderpick-world-2023", "heroic-vs-virtus-pro-m2-overpass-p1.dem")
	compareMatchRounds(t, demFilePath, 23)
}

func TestMatch2(t *testing.T) {
	demFilePath := filepath.Join("testdata", "cs-asia-championships-2023", "astralis-vs-mouz-m2-mirage.dem")
	expectedExcelPath := filepath.Join("testdata", "cs-asia-championships-2023", "astralis-vs-mouz-m2-mirage.xlsx")
	runMatchTest(t, demFilePath, expectedExcelPath)
}

func TestMatch3(t *testing.T) {
	demFilePath := filepath.Join("testdata", "cs-asia-championships-2023", "mouz-vs-faze-m1-mirage.dem")
	expectedExcelPath := filepath.Join("testdata", "cs-asia-championships-2023", "mouz-vs-faze-m1-mirage.xlsx")
	runMatchTest(t, demFilePath, expectedExcelPath)
}

func TestMatch4(t *testing.T) {
	demFilePath := filepath.Join("testdata", "esl-impact-league-season-4-finals", "nigma-galaxy-vs-navi-javelins-m2-nuke.dem")
	expectedExcelPath := filepath.Join("testdata", "esl-impact-league-season-4-finals", "nigma-galaxy-vs-navi-javelins-m2-nuke.xlsx")
	runMatchTest(t, demFilePath, expectedExcelPath)
}

// func Test_blast_premier_fall_final_2023(t *testing.T) {
// 	var tests = []struct {
// 		demFilePath       string
// 		expectedExcelPath string
// 	}{
// 		{
// 			demFilePath:       filepath.Join("testdata", "blast-premier-fall-final-2023", "vitality-vs-cloud9-m1-mirage.dem"),
// 			expectedExcelPath: filepath.Join("testdata", "blast-premier-fall-final-2023", "vitality-vs-cloud9-m1-mirage.xlsx"),
// 		},
// 		{
// 			demFilePath:       filepath.Join("testdata", "blast-premier-fall-final-2023", "vitality-vs-cloud9-m2-nuke.dem"),
// 			expectedExcelPath: filepath.Join("testdata", "blast-premier-fall-final-2023", "vitality-vs-cloud9-m2-nuke.xlsx"),
// 		},
// 		{
// 			demFilePath:       filepath.Join("testdata", "blast-premier-fall-final-2023", "vitality-vs-cloud9-m3-inferno.dem"),
// 			expectedExcelPath: filepath.Join("testdata", "blast-premier-fall-final-2023", "vitality-vs-cloud9-m3-inferno.xlsx"),
// 		},
// 		{
// 			demFilePath:       filepath.Join("testdata", "blast-premier-fall-final-2023", "vitality-vs-complexity-m2-nuke.dem"),
// 			expectedExcelPath: filepath.Join("testdata", "blast-premier-fall-final-2023", "vitality-vs-complexity-m2-nuke.xlsx"),
// 		},
// 		{
// 			demFilePath:       filepath.Join("testdata", "blast-premier-fall-final-2023", "faze-vs-cloud9-m3-anubis.dem"),
// 			expectedExcelPath: filepath.Join("testdata", "blast-premier-fall-final-2023", "faze-vs-cloud9-m3-anubis.xlsx"),
// 		},
// 	}

// 	for _, tt := range tests {
// 		t.Run(tt.demFilePath, func(t *testing.T) {
// 			runMatchTest(t, tt.demFilePath, tt.expectedExcelPath)
// 		})
// 	}
// }

func TestRound_thunderpick_world_2023(t *testing.T) {
	var tests = []struct {
		demFilePath       string
		expectedExcelPath string
		round             int
	}{
		{
			demFilePath: filepath.Join("testdata", "thunderpick-world-2023", "heroic-vs-virtus-pro-m2-overpass-p1.dem"),
			round:       23,
		},
		{
			demFilePath: filepath.Join("testdata", "thunderpick-world-2023", "monte-vs-virtus-pro-m2-anubis-p1.dem"),
			round:       21,
		},
	}

	for _, tt := range tests {
		t.Run(tt.demFilePath, func(t *testing.T) {
			compareMatchRounds(t, tt.demFilePath, tt.round)
		})
	}
}

func TestMatch_iem_sydney_2023(t *testing.T) {
	var tests = []struct {
		demFilePath       string
		expectedExcelPath string
	}{
		{
			demFilePath:       filepath.Join("testdata", "iem-sydney-2023", "faze-vs-gamerlegion-nuke.dem"),
			expectedExcelPath: filepath.Join("testdata", "iem-sydney-2023", "faze-vs-gamerlegion-nuke.xlsx"),
		},
	}

	for _, tt := range tests {
		t.Run(tt.demFilePath, func(t *testing.T) {
			runMatchTest(t, tt.demFilePath, tt.expectedExcelPath)
		})
	}
}
