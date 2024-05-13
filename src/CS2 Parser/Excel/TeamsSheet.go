package Excel

import (
	"github.com/Fresh-vano/CS2-Parser/Models"
	Analyzer "github.com/Fresh-vano/CS2-Parser/analyzer"
	"github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/common"
)

type TeamsSheet struct {
	Workbook       *Workbook
	Demo           *Analyzer.Demo
	rowPerTeamName map[string]*Models.TeamSheetRow
}

func (t *TeamsSheet) NewTeamsSheet(workbook *Workbook) *TeamsSheet {
	return &TeamsSheet{
		Workbook:       workbook,
		rowPerTeamName: make(map[string]*Models.TeamSheetRow),
	}
}

func (t *TeamsSheet) GetName() string {
	return "Teams"
}

func (t *TeamsSheet) GetColumnNames() []interface{} {
	return []interface{}{
		"Name",
		"Match",
		"Win",
		"Lost",
		"Kills",
		"Deaths",
		"Assists",
		"Rounds",
		"Round win",
		"Round lost",
		"Round CT win",
		"Round CT lost",
		"Round T win",
		"Round T lost",
		"Win pistol round",
		"Pistol round",
		"Win eco round",
		"Eco round",
		"Win semi-eco round",
		"Semi-eco round",
		"Win force-buy round",
		"Force-buy round",
		"Bomb planted",
		"Bomb defused",
		"Bomb exploded",
		"Bomb planted on A",
		"Bomb planted on B",
		"5K",
		"4K",
		"3K",
		"2K",
		"1K",
		"Trade kill",
		"Trade death",
		"Jump kill",
		"Crouch kill",
		"Flash",
		"HE",
		"Smoke",
		"Molotov",
		"Incendiary",
		"Decoy",
		"Win 4vs5",
		"Win 4vs5 %",
		"All 4vs5 rounds",
		"Win 5vs4",
		"Win 5vs4 %",
		"All 5vs4 rounds",
		"Flash kills",
		"Flash team kills",
		"Utility buy",
		"Utility use",
	}
}

func (t *TeamsSheet) AddDemo(demo Analyzer.Demo) {
	t.UpdateTeamStats(demo, *demo.Team1)
	t.UpdateTeamStats(demo, *demo.Team2)
}

func (t *TeamsSheet) UpdateTeamStats(demo Analyzer.Demo, team Models.Team) {
	if _, ok := t.rowPerTeamName[team.Name]; !ok {
		t.rowPerTeamName[team.Name] = &Models.TeamSheetRow{}
	}

	row := t.rowPerTeamName[team.Name]

	//row.KillCount += team.KillCount()
	//row.AssistCount += team.AssistCount()
	//row.DeathCount += team.DeathCount()

	row.RoundCount += len(demo.Rounds)
	row.FiveKillCount += team.FiveKillCount()
	row.FourKillCount += team.FourKillCount()
	row.ThreeKillCount += team.ThreeKillCount()
	row.TwoKillCount += team.TwoKillCount()
	row.OneKillCount += team.OneKillCount()
	row.TradeKillCount += team.TradeKillCount()
	row.TradeDeathCount += team.TradeDeathCount()
	row.JumpKillCount += team.JumpKillCount()
	row.CrouchKillCount += team.CrouchKillCount()
	row.FlashbangCount += team.FlashbangThrownCount()
	row.HeGrenadeCount += team.HeGrenadeThrownCount()
	row.SmokeCount += team.SmokeThrownCount()
	row.DecoyCount += team.DecoyThrownCount()
	row.MolotovCount += team.MolotovThrownCount()
	row.IncendiaryCount += team.IncendiaryThrownCount()
	row.BombPlantedCount += team.BombPlantedCount()
	row.BombDefusedCount += team.BombDefusedCount()
	row.BombExplodedCount += team.BombExplodedCount()
	row.UtilityBuy += team.UtilityBuy
	row.UtilityUse += team.UtilityUse
	// if demo.Winner != nil {
	// 	if demo.Winner.Equals(team) {
	// 		row.WonCount++
	// 	} else {
	// 		row.LostCount++
	// 	}
	// }

	for _, round := range demo.Rounds {
		if round.WinnerName == "" {
			//continue
			if demo.Players[0].Side == round.WinnerSide {
				if demo.Players[0].TeamName == demo.Team1.Name {
					round.WinnerName = demo.Team1.Name
				} else {
					round.WinnerName = demo.Team2.Name
				}
			} else {
				if demo.Players[0].TeamName == demo.Team1.Name {
					round.WinnerName = demo.Team2.Name
				} else {
					round.WinnerName = demo.Team1.Name
				}
			}
		}

		if round.WinnerName == team.Name {
			row.RoundWonCount++
			if round.WinnerSide == common.TeamCounterTerrorists {
				row.RoundWonAsCtCount++
			} else {
				row.RoundWonAsTerroCount++
			}

			if round.SideTrouble != common.TeamSpectators {
				switch round.Type {
				case Models.PISTOL_ROUND:
					row.PistolRoundWonCount++
				case Models.ECO:
					row.EcoRoundWonCount++
				case Models.SEMI_ECO:
					row.SemiEcoRoundWonCount++
				case Models.FORCE_BUY:
					row.ForceBuyRoundWonCount++
				}
			}
		} else {
			row.RoundLostCount++
			if round.WinnerSide == common.TeamCounterTerrorists {
				row.RoundLostAsTerroCount++
			} else {
				row.RoundLostAsCtCount++
			}
		}

		switch round.Type {
		case Models.PISTOL_ROUND:
			row.PistolRoundCount++
		case Models.ECO:
			row.EcoRoundCount++
		case Models.SEMI_ECO:
			row.SemiEcoRoundCount++
		case Models.FORCE_BUY:
			row.ForceBuyRoundCount++
		}

		if len(round.Kills) != 0 {
			if round.Kills[0].KilledTeam == team.Name {
				if round.WinnerName == team.Name {
					row.WinFourVSFive++
				}
				row.AllFourVSFiveRounds++
			} else {
				if round.WinnerName == team.Name {
					row.WinFiveVSFour++
				}
				row.AllFiveVSFourRounds++
			}
		}
	}

	// for _, plantedEvent := range demo.BombPlanted {
	// 	if player := FindPlayerBySteamID(team.Players, plantedEvent.PlanterSteamId); player != nil {
	// 		if plantedEvent.Site == "A" {
	// 			row.BombPlantedOnACount++
	// 		} else {
	// 			row.BombPlantedOnBCount++
	// 		}
	// 	}
	// }

	for _, player := range team.Players {
		row.KillCount += player.KillCount
		row.AssistCount += player.AssistCount
		row.DeathCount += player.DeathCount
	}

	for _, kill := range demo.Kills {
		if kill.KillerTeam == team.Name && kill.VictimIsBlinded {
			if kill.IsAssisterFlash {
				row.FlashTeamKills++
			}
			row.FlashKills++
		}
	}
}

func (t *TeamsSheet) Generate() {
	for teamName, row := range t.rowPerTeamName {
		row.WinFiveVSFourPercent = float64(row.WinFiveVSFour) / float64(row.AllFiveVSFourRounds)
		row.WinFourVSFivePercent = float64(row.WinFourVSFive) / float64(row.AllFourVSFiveRounds)
		cells := []interface{}{
			teamName,
			row.KillCount,
			row.DeathCount,
			row.AssistCount,
			row.RoundCount,
			row.RoundWonCount,
			row.RoundLostCount,
			row.RoundWonAsCtCount,
			row.RoundLostAsCtCount,
			row.RoundWonAsTerroCount,
			row.RoundLostAsTerroCount,
			row.PistolRoundWonCount,
			row.PistolRoundCount,
			row.EcoRoundWonCount,
			row.EcoRoundCount,
			row.SemiEcoRoundWonCount,
			row.SemiEcoRoundCount,
			row.ForceBuyRoundWonCount,
			row.ForceBuyRoundCount,
			row.BombPlantedCount,
			row.BombDefusedCount,
			row.BombExplodedCount,
			row.BombPlantedOnACount,
			row.BombPlantedOnBCount,
			row.FiveKillCount,
			row.FourKillCount,
			row.ThreeKillCount,
			row.TwoKillCount,
			row.OneKillCount,
			row.TradeKillCount,
			row.TradeDeathCount,
			row.JumpKillCount,
			row.CrouchKillCount,
			row.FlashbangCount,
			row.HeGrenadeCount,
			row.SmokeCount,
			row.MolotovCount,
			row.IncendiaryCount,
			row.DecoyCount,
			row.WinFourVSFive,
			row.WinFourVSFivePercent,
			row.AllFourVSFiveRounds,
			row.WinFiveVSFour,
			row.WinFiveVSFourPercent,
			row.AllFiveVSFourRounds,
			row.FlashKills,
			row.FlashTeamKills,
			row.UtilityBuy,
			row.UtilityUse,
		}

		t.Workbook.AddRowToSheet(t.GetName(), cells)
	}
}
