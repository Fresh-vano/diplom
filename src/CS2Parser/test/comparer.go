package test

import (
	"testing"

	"github.com/Fresh-vano/CS2-Parser/Models"
	test_models "github.com/Fresh-vano/CS2-Parser/test/models"
	"github.com/google/go-cmp/cmp"
)

func CompareTeams(t *testing.T, expected, actual *Models.TeamSheetRow) {
	if diff := cmp.Diff(expected, actual); diff != "" {
		t.Errorf("Teams do not match (-expected +got):\n%s", diff)
	}
}

func ComparePlayers(t *testing.T, expected, actual *Models.PlayerSheetRow) {
	if diff := cmp.Diff(expected, actual); diff != "" {
		t.Errorf("Players do not match (-expected +got):\n%s", diff)
	}
}

func CompareTestFiles(t *testing.T, file1, file2 *test_models.TestFile) {
	if len(file1.Teams) != len(file2.Teams) {
		t.Errorf("Number of teams do not match. \nExpected: %d, \ngot: %d", len(file1.Teams), len(file2.Teams))
	}

	for teamName, teamRow1 := range file1.Teams {
		teamRow2, ok := file2.Teams[teamName]
		if !ok {
			t.Errorf("Team %s is missing in the second file", teamName)
			continue
		}
		CompareTeams(t, teamRow1, teamRow2)
	}

	if len(file1.Players) != len(file2.Players) {
		t.Errorf("Number of players do not match. Expected: %d, got: %d", len(file1.Players), len(file2.Players))
	}

	for playerName, playerRow1 := range file1.Players {
		playerRow2, ok := file2.Players[playerName]
		if !ok {
			t.Errorf("Player %s is missing in the second file", playerName)
			continue
		}
		ComparePlayers(t, playerRow1, playerRow2)
	}
}

func Contains(s []string, e string) bool {
	for _, a := range s {
		if a == e {
			return true
		}
	}
	return false
}
