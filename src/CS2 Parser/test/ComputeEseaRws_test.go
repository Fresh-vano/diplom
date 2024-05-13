package test

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"math"
	"path/filepath"
	"strconv"
	"testing"

	"github.com/Fresh-vano/CS2-Parser/Models"
	Analyzer "github.com/Fresh-vano/CS2-Parser/analyzer"
	"github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/common"
	events "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/events"
)

func TestComputeEseaRws(t *testing.T) {
	for roundNumber := 1; roundNumber <= 11; roundNumber++ {
		t.Run(fmt.Sprintf("Round_%d", roundNumber), func(t *testing.T) {
			currentRoundPath := filepath.Join("testdata", fmt.Sprintf("currentRound_round_%d.json", roundNumber))
			playerBeforePath := filepath.Join("testdata", fmt.Sprintf("player_round_%d.json", roundNumber))
			playerAfterExpectedPath := filepath.Join("testdata", fmt.Sprintf("playerAfter_round_%d.json", roundNumber))

			currentRound := loadTestDataFromJSON[*TestRound](t, currentRoundPath)
			playerBefore := loadTestDataFromJSON[[]*TestPlayer](t, playerBeforePath)
			playerAfterExpected := loadTestDataFromJSON[[]*TestPlayer](t, playerAfterExpectedPath)

			demo := Analyzer.Demo{}
			demo.CurrentRound = *convertTestRoundToRound(currentRound)
			for _, player := range playerBefore {
				demo.Players = append(demo.Players, convertTestPlayerToPlayer(player))
			}

			// Вычисляем EseaRws
			demo.ComputeEseaRws()

			// Сравнение результатов
			for _, player := range demo.Players {
				expectedPlayer := findPlayerBySteamID(playerAfterExpected, player.SteamId)
				if expectedPlayer == nil {
					t.Errorf("Expected player with SteamID %d not found", player.SteamId)
					continue
				}
				if math.Abs(player.EseaRws-expectedPlayer.EseaRws) > 0.01 {
					t.Errorf("Round %d: Player SteamID %d EseaRws expected %f, got %f", roundNumber, player.SteamId, expectedPlayer.EseaRws, player.EseaRws)
				}
			}
		})
	}
}

func TestComputeEseaRws1(t *testing.T) {
	currentRound := loadTestDataFromJSON[*TestRound](t, filepath.Join("testdata", "currentRound_round_1.json"))
	playerBefore := loadTestDataFromJSON[[]*TestPlayer](t, filepath.Join("testdata", "player_round_1.json"))
	playerAfterExpected := loadTestDataFromJSON[[]*TestPlayer](t, filepath.Join("testdata", "playerAfter_round_1.json"))

	demo := Analyzer.Demo{}
	demo.CurrentRound = *convertTestRoundToRound(currentRound)
	for _, player := range playerBefore {
		demo.Players = append(demo.Players, convertTestPlayerToPlayer(player))
	}

	// Вычисляем EseaRws
	demo.ComputeEseaRws()

	// Сравнение результатов
	for _, player := range demo.Players {
		expectedPlayer := findPlayerBySteamID(playerAfterExpected, player.SteamId)
		if math.Abs(player.EseaRws-expectedPlayer.EseaRws) > 0.01 {
			t.Errorf("Player SteamID %d EseaRws expected %f, got %f", player.SteamId, expectedPlayer.EseaRws, player.EseaRws)
		}
	}
}

func TestComputeEseaRws2(t *testing.T) {
	currentRound := loadTestDataFromJSON[*TestRound](t, filepath.Join("testdata", "currentRound_round_11.json"))
	playerBefore := loadTestDataFromJSON[[]*TestPlayer](t, filepath.Join("testdata", "player_round_11.json"))
	playerAfterExpected := loadTestDataFromJSON[[]*TestPlayer](t, filepath.Join("testdata", "playerAfter_round_11.json"))

	demo := Analyzer.Demo{}
	demo.CurrentRound = *convertTestRoundToRound(currentRound)
	for _, player := range playerBefore {
		demo.Players = append(demo.Players, convertTestPlayerToPlayer(player))
	}

	// Вычисляем EseaRws
	demo.ComputeEseaRws()

	// Сравнение результатов
	for _, player := range demo.Players {
		expectedPlayer := findPlayerBySteamID(playerAfterExpected, player.SteamId)
		if math.Abs(player.EseaRws-expectedPlayer.EseaRws) > 0.001 {
			t.Errorf("Player SteamID %d EseaRws expected %f, got %f", player.SteamId, expectedPlayer.EseaRws, player.EseaRws)
		}
	}
}

type TestRound struct {
	WinnerSide    string             `json:"winner_side"`
	WinnerName    string             `json:"winner_name"`
	EndReason     string             `json:"end_reason"`
	PlayersHurted []TestPlayerHurted `json:"players_hurted"`
	BombDefused   *TestBombDefused   `json:"bomb_defused,omitempty"`
	BombPlanted   *TestBombPlanted   `json:"bomb_planted,omitempty"`
}

type TestPlayer struct {
	SteamId           string `json:"steamid"`
	TeamName          string `json:"team_name"`
	IsConnected       bool
	RoundPlayedCount  int     `json:"round_count"`
	EseaRwsPointCount float64 `json:"esea_rws_point_count"`
	EseaRws           float64 `json:"esea_rws,omitempty"`
}

type TestPlayerHurted struct {
	AttackerSteamId string `json:"attacker_steamid"`
	HealthDamage    int    `json:"health_damage"`
	AttackerSide    string `json:"attacker_side"`
}

type TestBombDefused struct {
	Player string `json:"defuser_steamid"`
}

type TestBombPlanted struct {
	Player string `json:"planter_steamid"`
}

func convertTestRoundToRound(tr *TestRound) *Models.Round {
	event := (&Models.Round{})
	for _, ph := range tr.PlayersHurted {
		event.PlayersHurted = append(event.PlayersHurted, *convertTestPlayerHurtedToPlayerHurted(&ph))
	}
	event.BombDefused = *convertTestBombDefusedToBombDefused(tr.BombDefused)
	event.BombPlanted = *convertTestBombPlantedToBombPlanted(tr.BombPlanted)
	if tr.WinnerSide == "CT" {
		event.WinnerSide = common.TeamCounterTerrorists
	} else if tr.WinnerSide == "T" {
		event.WinnerSide = common.TeamTerrorists
	}

	if tr.EndReason == "Counter-Terrorists win" {
		event.EndReason = events.RoundEndReasonCTWin
	} else if tr.EndReason == "Terrorists win" {
		event.EndReason = events.RoundEndReasonTerroristsWin
	} else if tr.EndReason == "Bomb defused" {
		event.EndReason = events.RoundEndReasonBombDefused
	} else if tr.EndReason == "Bomb exploded" {
		event.EndReason = events.RoundEndReasonTargetBombed
	}

	event.WinnerName = tr.WinnerName
	return event
}

func convertTestPlayerToPlayer(tp *TestPlayer) *Models.Player {
	player := &Models.Player{
		TeamName:          tp.TeamName,
		IsConnected:       true,
		RoundPlayedCount:  tp.RoundPlayedCount,
		EseaRwsPointCount: tp.EseaRwsPointCount,
		EseaRws:           tp.EseaRws,
	}
	player.SteamId, _ = strconv.ParseUint(tp.SteamId, 10, 64)
	return player
}

func convertTestPlayerHurtedToPlayerHurted(tph *TestPlayerHurted) *Models.PlayerHurtedEvent {
	event := &Models.PlayerHurtedEvent{
		HealthDamage: tph.HealthDamage,
	}
	event.AttackerSteamId, _ = strconv.ParseUint(tph.AttackerSteamId, 10, 64)

	if tph.AttackerSide == "CT" {
		event.AttackerSide = common.TeamCounterTerrorists
	} else if tph.AttackerSide == "T" {
		event.AttackerSide = common.TeamTerrorists
	}
	return event
}

func convertTestBombDefusedToBombDefused(tbd *TestBombDefused) *events.BombDefused {
	if tbd == nil {
		return &events.BombDefused{}
	}

	player := common.Player{}
	player.SteamID64, _ = strconv.ParseUint(tbd.Player, 10, 64)

	return &events.BombDefused{
		BombEvent: events.BombEvent{
			Player: &player,
		},
	}
}

func convertTestBombPlantedToBombPlanted(tbp *TestBombPlanted) *events.BombPlanted {
	if tbp == nil {
		return &events.BombPlanted{}
	}

	player := common.Player{}
	player.SteamID64, _ = strconv.ParseUint(tbp.Player, 10, 64)

	return &events.BombPlanted{
		BombEvent: events.BombEvent{
			Player: &player,
		},
	}
}

// Загрузка данных из JSON-файла
func loadTestDataFromJSON[T any](t *testing.T, filePath string) T {
	var data T
	bytes, err := ioutil.ReadFile(filePath)
	if err != nil {
		t.Fatalf("Failed to read file: %s, error: %v", filePath, err)
	}
	if err := json.Unmarshal(bytes, &data); err != nil {
		t.Fatalf("Failed to unmarshal JSON: %v", err)
	}
	return data
}

// FindPlayerBySteamID ищет игрока по его SteamID
func findPlayerBySteamID(players []*TestPlayer, steamID uint64) *Models.Player {
	for _, player := range players {
		ID, _ := strconv.ParseUint(player.SteamId, 10, 64)
		if ID == steamID {
			return convertTestPlayerToPlayer(player)
		}
	}
	return nil // Игрок не найден
}
