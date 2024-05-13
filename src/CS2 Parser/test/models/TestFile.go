package test_models

import (
	"fmt"
	"math"
	"strconv"

	Models "github.com/Fresh-vano/CS2-Parser/Models"
	excelize "github.com/xuri/excelize/v2"
)

type TestFile struct {
	Teams   map[string]*Models.TeamSheetRow
	Players map[string]*Models.PlayerSheetRow
}

func (t *TestFile) Init() *TestFile {
	return &TestFile{
		Teams:   make(map[string]*Models.TeamSheetRow),
		Players: make(map[string]*Models.PlayerSheetRow),
	}
}

func (t *TestFile) OpenExcel(filePath string) error {
	f, err := excelize.OpenFile(filePath)
	if err != nil {
		return fmt.Errorf("Ошибка открытия excel файла: %v", err)
	}
	t.readPlayerSheetRows(f)
	t.readTeamSheetRows(f)
	return err
}

func (t *TestFile) readPlayerSheetRows(f *excelize.File) {
	rows, err := f.GetRows("Players")
	if err != nil {
		fmt.Errorf("В файле нет страницы Players: %v", err)
		return
	}
	for rowIndex, row := range rows {
		if rowIndex == 0 {
			continue
		}
		if rowIndex > 10 {
			break
		}

		if len(row) != 84 {
			fmt.Errorf("У одного из игроков неверное число метрик!")
			return
		}

		// Закоменчены те параметры, которые не участвуют и не влияют при расчетах

		player := new(Models.PlayerSheetRow)

		player.Team = row[1]
		player.Name = row[2]
		player.Match, _ = strconv.Atoi(row[3])
		player.Kills, _ = strconv.Atoi(row[4])
		player.Assists, _ = strconv.Atoi(row[5])
		player.Deaths, _ = strconv.Atoi(row[6])
		player.KD, _ = strconv.ParseFloat(row[7], 64)
		player.HS, _ = strconv.Atoi(row[8])
		player.HSPercent, _ = strconv.ParseFloat(row[9], 64)
		player.Rounds, _ = strconv.Atoi(row[10])
		//player.RWS, _ = strconv.ParseFloat(row[11], 64)
		player.KAST, _ = strconv.ParseFloat(row[12], 64)
		player.KAST = math.Round(player.KAST*1000) / 1000
		// player.Rating, _ = strconv.ParseFloat(row[13], 64)
		player.Rating2, _ = strconv.ParseFloat(row[14], 64)
		// player.ATDs, _ = strconv.ParseFloat(row[15], 64)
		player.FiveKill, _ = strconv.Atoi(row[16])
		player.FourKill, _ = strconv.Atoi(row[17])
		player.ThreeKill, _ = strconv.Atoi(row[18])
		player.TwoKill, _ = strconv.Atoi(row[19])
		player.OneKill, _ = strconv.Atoi(row[20])
		player.TradeKill, _ = strconv.Atoi(row[21])
		// player.TradeDeath, _ = strconv.Atoi(row[22])
		// player.TeamKill, _ = strconv.Atoi(row[23])
		// player.JumpKill, _ = strconv.Atoi(row[24])
		// player.CrouchKill, _ = strconv.Atoi(row[25])
		// player.BombPlanted, _ = strconv.Atoi(row[26])
		// player.BombDefused, _ = strconv.Atoi(row[27])
		// player.BombExploded, _ = strconv.Atoi(row[28])
		// player.MVP, _ = strconv.Atoi(row[29])
		// player.Score, _ = strconv.Atoi(row[30])
		// player.Clutch, _ = strconv.Atoi(row[31])
		// player.ClutchWon, _ = strconv.Atoi(row[32])
		// player.ClutchLost, _ = strconv.Atoi(row[33])
		// player.ClutchWonPercent, _ = strconv.ParseFloat(row[34], 64)
		// player.OneVOne, _ = strconv.Atoi(row[35])
		// player.OneVOneWon, _ = strconv.Atoi(row[36])
		// player.OneVOneLost, _ = strconv.Atoi(row[37])
		// player.OneVOneWonPercent, _ = strconv.ParseFloat(row[38], 64)
		// player.OneVTwo, _ = strconv.Atoi(row[39])
		// player.OneVTwoWon, _ = strconv.Atoi(row[40])
		// player.OneVTwoLost, _ = strconv.Atoi(row[41])
		// player.OneVTwoWonPercent, _ = strconv.ParseFloat(row[42], 64)
		// player.OneVThree, _ = strconv.Atoi(row[43])
		// player.OneVThreeWon, _ = strconv.Atoi(row[44])
		// player.OneVThreeLost, _ = strconv.Atoi(row[45])
		// player.OneVThreeWonPercent, _ = strconv.ParseFloat(row[46], 64)
		// player.OneVFour, _ = strconv.Atoi(row[47])
		// player.OneVFourWon, _ = strconv.Atoi(row[48])
		// player.OneVFourLost, _ = strconv.Atoi(row[49])
		// player.OneVFourWonPercent, _ = strconv.ParseFloat(row[50], 64)
		// player.OneVFive, _ = strconv.Atoi(row[51])
		// player.OneVFiveWon, _ = strconv.Atoi(row[52])
		// player.OneVFiveLost, _ = strconv.Atoi(row[53])
		// player.OneVFiveWonPercent, _ = strconv.ParseFloat(row[54], 64)
		player.EntryKill, _ = strconv.Atoi(row[55])
		player.EntryKillWin, _ = strconv.Atoi(row[56])
		// player.EntryKillLost, _ = strconv.Atoi(row[57])
		// player.EntryKillWinPercent, _ = strconv.ParseFloat(row[58], 64)
		player.EntryHoldKill, _ = strconv.Atoi(row[59])
		player.EntryHoldKillWin, _ = strconv.Atoi(row[60])
		// player.EntryHoldKillLost, _ = strconv.Atoi(row[61])
		// player.EntryHoldKillWinPercent, _ = strconv.ParseFloat(row[62], 64)
		player.KPR, _ = strconv.ParseFloat(row[63], 64)
		player.APR, _ = strconv.ParseFloat(row[64], 64)
		player.DPR, _ = strconv.ParseFloat(row[65], 64)
		player.ADR, _ = strconv.ParseFloat(row[66], 64)
		player.TDH, _ = strconv.Atoi(row[67])
		player.TDA, _ = strconv.Atoi(row[68])
		// player.Flashbang, _ = strconv.Atoi(row[69])
		// player.Smoke, _ = strconv.Atoi(row[70])
		// player.HE, _ = strconv.Atoi(row[71])
		// player.Decoy, _ = strconv.Atoi(row[72])
		// player.Molotov, _ = strconv.Atoi(row[73])
		// player.Incendiary, _ = strconv.Atoi(row[74])
		// player.RankMax, _ = strconv.Atoi(row[75])
		// player.VAC, _ = strconv.ParseBool(row[76])
		// player.OW, _ = strconv.ParseBool(row[77])
		player.SurvivedRounds, _ = strconv.Atoi(row[78])
		//player.Hits, _ = strconv.Atoi(row[79])
		//player.Shots, _ = strconv.Atoi(row[80])
		//player.KillThroughSmoke, _ = strconv.Atoi(row[81])
		//player.AverageTimeToKill, _ = strconv.ParseFloat(row[82], 64)
		//player.Rage, _ = strconv.Atoi(row[83])

		t.Players[player.Name] = player
	}
}

// readTeamSheetRows метод для считывания данных о командах из Excel.
func (t *TestFile) readTeamSheetRows(f *excelize.File) {
	rows, err := f.GetRows("Teams")
	if err != nil {
		fmt.Errorf("В файле нет страницы Teams: %v", err)
		return
	}
	for rowIndex, row := range rows {
		if rowIndex == 0 {
			continue
		}
		if rowIndex > 2 {
			break
		}

		if len(row) != 52 {
			fmt.Errorf("У одной из команд неверное число метрик!")
			return
		}

		team := new(Models.TeamSheetRow)
		team.Name = row[0]
		// team.MatchCount, _ = strconv.Atoi(row[1])
		// team.WonCount, _ = strconv.Atoi(row[2])
		// team.LostCount, _ = strconv.Atoi(row[3])
		// team.KillCount, _ = strconv.Atoi(row[4])
		// team.DeathCount, _ = strconv.Atoi(row[5])
		// team.AssistCount, _ = strconv.Atoi(row[6])
		team.RoundCount, _ = strconv.Atoi(row[7])
		team.RoundWonCount, _ = strconv.Atoi(row[8])
		team.RoundLostCount, _ = strconv.Atoi(row[9])
		team.RoundWonAsCtCount, _ = strconv.Atoi(row[10])
		team.RoundLostAsCtCount, _ = strconv.Atoi(row[11])
		team.RoundWonAsTerroCount, _ = strconv.Atoi(row[12])
		team.RoundLostAsTerroCount, _ = strconv.Atoi(row[13])
		team.PistolRoundWonCount, _ = strconv.Atoi(row[14])
		team.PistolRoundCount, _ = strconv.Atoi(row[15])
		team.EcoRoundWonCount, _ = strconv.Atoi(row[16])
		team.EcoRoundCount, _ = strconv.Atoi(row[17])
		team.SemiEcoRoundWonCount, _ = strconv.Atoi(row[18])
		team.SemiEcoRoundCount, _ = strconv.Atoi(row[19])
		team.ForceBuyRoundWonCount, _ = strconv.Atoi(row[20])
		team.ForceBuyRoundCount, _ = strconv.Atoi(row[21])
		// team.BombPlantedCount, _ = strconv.Atoi(row[22])
		// team.BombDefusedCount, _ = strconv.Atoi(row[23])
		// team.BombExplodedCount, _ = strconv.Atoi(row[24])
		// team.BombPlantedOnACount, _ = strconv.Atoi(row[25])
		// team.BombPlantedOnBCount, _ = strconv.Atoi(row[26])
		// team.FiveKillCount, _ = strconv.Atoi(row[27])
		// team.FourKillCount, _ = strconv.Atoi(row[28])
		// team.ThreeKillCount, _ = strconv.Atoi(row[29])
		// team.TwoKillCount, _ = strconv.Atoi(row[30])
		// team.OneKillCount, _ = strconv.Atoi(row[31])
		// team.TradeKillCount, _ = strconv.Atoi(row[32])
		// team.TradeDeathCount, _ = strconv.Atoi(row[33])
		// team.JumpKillCount, _ = strconv.Atoi(row[34])
		// team.CrouchKillCount, _ = strconv.Atoi(row[35])
		// team.FlashbangCount, _ = strconv.Atoi(row[36])
		// team.HeGrenadeCount, _ = strconv.Atoi(row[37])
		// team.SmokeCount, _ = strconv.Atoi(row[38])
		// team.MolotovCount, _ = strconv.Atoi(row[39])
		// team.IncendiaryCount, _ = strconv.Atoi(row[40])
		// team.DecoyCount, _ = strconv.Atoi(row[41])

		// TODO: временно отключен, так как устранена проблема
		// team.WinFourVSFive, _ = strconv.Atoi(row[42])
		// team.WinFourVSFivePercent, _ = strconv.ParseFloat(row[43], 64)
		// team.WinFourVSFivePercent = math.Round(team.WinFourVSFivePercent*1000) / 1000
		// team.AllFourVSFiveRounds, _ = strconv.Atoi(row[44])
		// team.WinFiveVSFour, _ = strconv.Atoi(row[45])
		// team.WinFiveVSFourPercent, _ = strconv.ParseFloat(row[46], 64)
		// team.WinFourVSFivePercent = math.Round(team.WinFourVSFivePercent*1000) / 1000
		// team.AllFiveVSFourRounds, _ = strconv.Atoi(row[47])
		// team.FlashKills, _ = strconv.Atoi(row[48])
		// team.FlashTeamKills, _ = strconv.Atoi(row[49])

		// team.UtilityBuy, _ = strconv.Atoi(row[50])
		// team.UtilityUse, _ = strconv.Atoi(row[51])

		t.Teams[team.Name] = team

	}
}
