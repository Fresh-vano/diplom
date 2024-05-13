package Export

import (
	"github.com/Fresh-vano/CS2-Parser/Models"
	Analyzer "github.com/Fresh-vano/CS2-Parser/analyzer"
)

type PlayersSheet struct {
	Demo  *Analyzer.Demo
	first bool
}

func (p *PlayersSheet) Generate(MapID, TeamId int) []Models.PlayerSheetRow {
	var playerSheetRows []Models.PlayerSheetRow
	for row, player := range p.Demo.Players {
		if player.KillCount == 0 && player.DeathCount == 0 {
			continue
		}
		row++
		playerSheetRow := Models.PlayerSheetRow{
			TeamId:                  TeamId,
			MapID:                   MapID,
			Team:                    player.TeamName,
			Name:                    player.Name,
			Match:                   1,
			Kills:                   player.KillCount,
			Assists:                 player.AssistCount,
			Deaths:                  player.DeathCount,
			KD:                      float64(player.KillCount) / float64(player.DeathCount),
			HS:                      player.HeadshotCount,
			HSPercent:               player.HeadshotPercent(),
			Rounds:                  player.RoundPlayedCount,
			RWS:                     player.EseaRws,
			KAST:                    player.Kast,
			Rating:                  player.RatingHltv,
			Rating2:                 player.RatingHltv2,
			ATDs:                    player.AverageTimeDeath(),
			FiveKill:                player.FiveKillCount,
			FourKill:                player.FourKillCount,
			ThreeKill:               player.ThreeKillCount,
			TwoKill:                 player.TwoKillCount,
			OneKill:                 player.OneKillCount,
			TradeKill:               player.TradeKillCount,
			TradeDeath:              player.TradeDeathCount,
			TeamKill:                player.TeamKillCount,
			JumpKill:                player.JumpKillCount,
			CrouchKill:              player.CrouchKillCount,
			BombPlanted:             player.BombPlantedCount,
			BombDefused:             player.BombDefusedCount,
			BombExploded:            player.BombExplodedCount,
			MVP:                     player.RoundMvpCount,
			Score:                   player.Score,
			Clutch:                  player.ClutchCount(),
			ClutchWon:               player.ClutchWonCount(),
			ClutchLost:              player.ClutchLostCount(),
			ClutchWonPercent:        player.ClutchWonPercent(),
			OneVOne:                 player.Clutch1V1Count(),
			OneVOneWon:              player.Clutch1V1WonCount(),
			OneVOneLost:             player.Clutch1V1LossCount(),
			OneVOneWonPercent:       player.Clutch1V1WonPercent(),
			OneVTwo:                 player.Clutch1V2Count(),
			OneVTwoWon:              player.Clutch1V2WonCount(),
			OneVTwoLost:             player.Clutch1V2LossCount(),
			OneVTwoWonPercent:       player.Clutch1V2WonPercent(),
			OneVThree:               player.Clutch1V3Count(),
			OneVThreeWon:            player.Clutch1V3WonCount(),
			OneVThreeLost:           player.Clutch1V3LossCount(),
			OneVThreeWonPercent:     player.Clutch1V3WonPercent(),
			OneVFour:                player.Clutch1V4Count(),
			OneVFourWon:             player.Clutch1V4WonCount(),
			OneVFourLost:            player.Clutch1V4LossCount(),
			OneVFourWonPercent:      player.Clutch1V4WonPercent(),
			OneVFive:                player.Clutch1V5Count(),
			OneVFiveWon:             player.Clutch1V5WonCount(),
			OneVFiveLost:            player.Clutch1V5LossCount(),
			OneVFiveWonPercent:      player.Clutch1V5WonPercent(),
			EntryKill:               len(player.EntryKills),
			EntryKillWin:            player.EntryKillWonCount(),
			EntryKillLost:           player.EntryKillLossCount(),
			EntryKillWinPercent:     player.RatioEntryKill(),
			EntryHoldKill:           len(player.EntryHoldKills),
			EntryHoldKillWin:        player.EntryHoldKillWonCount(),
			EntryHoldKillLost:       player.EntryHoldKillLossCount(),
			EntryHoldKillWinPercent: player.RatioEntryHoldKill(),
			KPR:                     player.KillPerRound(),
			APR:                     player.AssistPerRound(),
			DPR:                     player.DeathPerRound(),
			ADR:                     player.AverageHealthDamage(),
			TDH:                     player.TotalDamageHealthCount(),
			TDA:                     player.TotalDamageArmorCount(),
			Flashbang:               player.FlashbangThrownCount,
			Smoke:                   player.SmokeThrownCount,
			HE:                      player.HeGrenadeThrownCount,
			Decoy:                   player.DecoyThrownCount,
			Molotov:                 player.MolotovThrownCount,
			Incendiary:              player.IncendiaryThrownCount,
			RankMax:                 player.RankNumberOld,
			VAC:                     player.IsVacBanned,
			OW:                      player.IsOverwatchBanned,
			SurvivedRounds:          len(p.Demo.Rounds) - player.DeathCount,
			Hits:                    player.HitCount,
			Shots:                   player.ShotCount,
			KillThroughSmoke:        player.KillThroughSmoke,
			AverageTimeToKill:       player.AverageTimeKill(),
			Rage:                    player.Rage,
		}
		playerSheetRows = append(playerSheetRows, playerSheetRow)
	}
	return playerSheetRows
}
