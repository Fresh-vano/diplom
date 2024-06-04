package Models

import (
	"math"
)

type Team struct {
	Name                  string
	Score                 int
	ScoreFirstHalf        int
	ScoreSecondHalf       int
	Players               []*Player
	WinMatchCount         int
	RoundCount            int
	WinRoundCtCount       int
	LostRoundCtCount      int
	WinRoundTCount        int
	LostRoundTCount       int
	WinPistolRoundCount   int
	WinEcoRoundCount      int
	WinSemiEcoRoundCount  int
	WinForceBuyRoundCount int
	BombPlantedOnACount   int
	BombPlantedOnBCount   int
	UtilityBuy            int
	UtilityUse            int
}

func (t *Team) WinCount() int {
	return t.WinMatchCount
}

func (t *Team) LostCount() int {
	return 1 - t.WinMatchCount
}

func (t *Team) WinRoundCount() int {
	return t.Score
}

func (t *Team) LostRoundCount() int {
	return t.RoundCount - t.Score
}

func (t *Team) EntryHoldKillCount() int {
	count := 0
	for _, player := range t.Players {
		count += len(player.EntryHoldKills)
	}
	return count
}

func (t *Team) EntryKillCount() int {
	count := 0
	for _, player := range t.Players {
		count += len(player.EntryKills)
	}
	return count
}

func (t *Team) EntryHoldKillWonCount() int {
	count := 0
	for _, player := range t.Players {
		for _, entryHoldKill := range player.EntryHoldKills {
			if entryHoldKill.HasWon {
				count++
			}
		}
	}
	return count
}

func (t *Team) EntryHoldKillLossCount() int {
	count := 0
	for _, player := range t.Players {
		for _, entryHoldKill := range player.EntryHoldKills {
			if !entryHoldKill.HasWon {
				count++
			}
		}
	}
	return count
}

func (t *Team) RatioEntryHoldKill() float64 {
	total := t.EntryHoldKillCount()
	won := t.EntryHoldKillWonCount()
	loss := t.EntryHoldKillLossCount()

	var percent float64
	if won == 0 {
		return percent
	}

	if loss == 0 {
		return 100.0
	}

	percent = float64(won) / float64(total) * 100.0
	return math.Round(percent)
}

func (t *Team) EntryKillWonCount() int {
	count := 0
	for _, player := range t.Players {
		for _, entryKill := range player.EntryKills {
			if entryKill.HasWon {
				count++
			}
		}
	}
	return count
}

func (t *Team) EntryKillLossCount() int {
	count := 0
	for _, player := range t.Players {
		for _, entryKill := range player.EntryKills {
			if !entryKill.HasWon {
				count++
			}
		}
	}
	return count
}

func (t *Team) FlashbangThrownCount() int {
	count := 0
	for _, player := range t.Players {
		if player.TeamName == t.Name {
			count += player.FlashbangThrownCount
		}
	}
	return count
}

func (t *Team) HeGrenadeThrownCount() int {
	count := 0
	for _, player := range t.Players {
		if player.TeamName == t.Name {
			count += player.HeGrenadeThrownCount
		}
	}
	return count
}

func (t *Team) SmokeThrownCount() int {
	count := 0
	for _, player := range t.Players {
		if player.TeamName == t.Name {
			count += player.SmokeThrownCount
		}
	}
	return count
}

func (t *Team) MolotovThrownCount() int {
	count := 0
	for _, player := range t.Players {
		if player.TeamName == t.Name {
			count += player.MolotovThrownCount
		}
	}
	return count
}

func (t *Team) IncendiaryThrownCount() int {
	count := 0
	for _, player := range t.Players {
		if player.TeamName == t.Name {
			count += player.IncendiaryThrownCount
		}
	}
	return count
}

func (t *Team) DecoyThrownCount() int {
	count := 0
	for _, player := range t.Players {
		if player.TeamName == t.Name {
			count += player.DecoyThrownCount
		}
	}
	return count
}

func (t *Team) TradeKillCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.TradeKillCount
	}
	return count
}

func (t *Team) TradeDeathCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.TradeDeathCount
	}
	return count
}

func (t *Team) RatioEntryKill() float64 {
	entryKillCount := t.EntryKillCount()
	entryKillWin := t.EntryKillWonCount()
	entryKillLoss := t.EntryKillLossCount()

	var entryKillPercent float64
	if entryKillWin == 0 {
		return entryKillPercent
	}

	if entryKillLoss == 0 {
		return 100.0
	}

	entryKillPercent = float64(entryKillWin) / float64(entryKillCount) * 100.0
	return math.Round(entryKillPercent)
}

func (t *Team) KillCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.KillCount
	}
	return count
}

func (t *Team) AssistCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.AssistCount
	}
	return count
}

func (t *Team) DeathCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.DeathCount
	}
	return count
}

func (t *Team) BombPlantedCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.BombPlantedCount
	}
	return count
}

func (t *Team) BombDefusedCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.BombDefusedCount
	}
	return count
}

func (t *Team) BombExplodedCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.BombExplodedCount
	}
	return count
}

func (t *Team) FiveKillCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.FiveKillCount
	}
	return count
}

func (t *Team) FourKillCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.FourKillCount
	}
	return count
}

func (t *Team) ThreeKillCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.ThreeKillCount
	}
	return count
}

func (t *Team) TwoKillCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.TwoKillCount
	}
	return count
}

func (t *Team) OneKillCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.OneKillCount
	}
	return count
}

func (t *Team) JumpKillCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.JumpKillCount
	}
	return count
}

func (t *Team) CrouchKillCount() int {
	count := 0
	for _, player := range t.Players {
		count += player.CrouchKillCount
	}
	return count
}
