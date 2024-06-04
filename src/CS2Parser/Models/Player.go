package Models

import (
	"math"

	"github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/common"
)

type Player struct {
	OneKillCount          int
	TwoKillCount          int
	ThreeKillCount        int
	FourKillCount         int
	FiveKillCount         int
	HeadshotCount         int
	AssistCount           int
	DeathCount            int
	KillCount             int
	CrouchKillCount       int
	JumpKillCount         int
	TeamKillCount         int
	KillThroughSmoke      int
	RoundMvpCount         int
	BombPlantedCount      int
	BombDefusedCount      int
	BombExplodedCount     int
	Score                 int
	IsControllingBot      bool
	IsAlive               bool
	IsConnected           bool
	Side                  common.Team
	TeamName              string
	SteamId               uint64
	Name                  string
	HasEntryKill          bool
	HasEntryHoldKill      bool
	RatingHltv            float64
	RatingHltv2           float64
	Kast                  float64
	Rage                  int
	EseaRwsPointCount     float64
	EseaRws               float64
	ShotCount             int
	HitCount              int
	HasBomb               bool
	IsVacBanned           bool
	IsOverwatchBanned     bool
	RankNumberOld         int
	RankNumberNew         int
	WinCount              int
	TradeKillCount        int
	TradeDeathCount       int
	FlashbangThrownCount  int
	SmokeThrownCount      int
	HeGrenadeThrownCount  int
	MolotovThrownCount    int
	IncendiaryThrownCount int
	DecoyThrownCount      int
	RoundPlayedCount      int
	SuicideCount          int
	FlashDurationTemp     float32
	EquipementValueRounds map[int]int
	RoundsMoneyEarned     map[int]int
	TimeDeathRounds       map[int]float64
	Kills                 []KillEvent
	Deaths                []KillEvent
	Assists               []KillEvent
	EntryKills            []EntryKillEvent
	EntryHoldKills        []EntryHoldKillEvent
	PlayersHurted         []*PlayerHurtedEvent
	Clutches              []ClutchEvent
	TimeKill              []float64
	Team                  common.Team
}

func (p *Player) KillDeathRatio() float64 {
	if p.DeathCount != 0 {
		return math.Round((float64(p.KillCount)/float64(p.DeathCount))*100) / 100
	}
	return 0
}

func (p *Player) Accuracy() float64 {
	if p.ShotCount != 0 {
		return math.Round((float64(p.HitCount)/float64(p.ShotCount)*100)*100) / 100
	}
	return 0
}

func (p *Player) EntryKillWonCount() int {
	output := 0
	for _, entryKillEvent := range p.EntryKills {
		if entryKillEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) EntryKillLossCount() int {
	output := 0
	for _, entryKillEvent := range p.EntryKills {
		if !entryKillEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) EntryHoldKillWonCount() int {
	output := 0
	for _, entryHoldKillEvent := range p.EntryHoldKills {
		if entryHoldKillEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) EntryHoldKillLossCount() int {
	output := 0
	for _, entryHoldKillEvent := range p.EntryHoldKills {
		if !entryHoldKillEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) ClutchCount() int {
	return len(p.Clutches)
}

func (p *Player) ClutchLostCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if !clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) ClutchWonCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V1WonCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 1 && clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V2WonCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 2 && clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V3WonCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 3 && clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V4WonCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 4 && clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V5WonCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 5 && clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V1LossCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 1 && !clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V2LossCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 2 && !clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V3LossCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 3 && !clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V4LossCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 4 && !clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V5LossCount() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 5 && !clutchEvent.HasWon {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V1Count() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 1 {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V2Count() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 2 {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V3Count() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 3 {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V4Count() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 4 {
			output++
		}
	}
	return output
}

func (p *Player) Clutch1V5Count() int {
	output := 0
	for _, clutchEvent := range p.Clutches {
		if clutchEvent.OpponentCount == 5 {
			output++
		}
	}
	return output
}

func (p *Player) ClutchWonPercent() float64 {
	if p.ClutchCount() != 0 {
		return math.Round((float64(p.ClutchWonCount()*100)/float64(p.ClutchCount()))*100) / 100
	}
	return 0
}

func (p *Player) Clutch1V1WonPercent() float64 {
	if p.Clutch1V1Count() != 0 {
		return math.Round((float64(p.Clutch1V1WonCount()*100)/float64(p.Clutch1V1Count()))*100) / 100
	}
	return 0
}

func (p *Player) Clutch1V2WonPercent() float64 {
	if p.Clutch1V2Count() != 0 {
		return math.Round((float64(p.Clutch1V2WonCount()*100)/float64(p.Clutch1V2Count()))*100) / 100
	}
	return 0
}

func (p *Player) Clutch1V3WonPercent() float64 {
	if p.Clutch1V3Count() != 0 {
		return math.Round((float64(p.Clutch1V3WonCount()*100)/float64(p.Clutch1V3Count()))*100) / 100
	}
	return 0
}

func (p *Player) Clutch1V4WonPercent() float64 {
	if p.Clutch1V4Count() != 0 {
		return math.Round((float64(p.Clutch1V4WonCount()*100)/float64(p.Clutch1V4Count()))*100) / 100
	}
	return 0
}

func (p *Player) Clutch1V5WonPercent() float64 {
	if p.Clutch1V5Count() != 0 {
		return math.Round((float64(p.Clutch1V5WonCount()*100)/float64(p.Clutch1V5Count()))*100) / 100
	}
	return 0
}

func (p *Player) TotalDamageHealthCount() int {
	totalDamage := 0

	for _, playerHurtedEvent := range p.PlayersHurted {
		if playerHurtedEvent != nil && playerHurtedEvent.AttackerSteamId == p.SteamId {
			totalDamage += playerHurtedEvent.HealthDamage
		}
	}

	return totalDamage
}

func (p *Player) TotalDamageArmorCount() int {
	totalDamage := 0

	for _, playerHurtedEvent := range p.PlayersHurted {
		if playerHurtedEvent != nil && playerHurtedEvent.AttackerSteamId == p.SteamId {
			totalDamage += playerHurtedEvent.ArmorDamage
		}
	}

	return totalDamage
}

func (p *Player) TotalDamageHealthReceivedCount() int {
	totalDamage := 0

	for _, playerHurtedEvent := range p.PlayersHurted {
		if playerHurtedEvent != nil && playerHurtedEvent.HurtedSteamId == p.SteamId {
			totalDamage += playerHurtedEvent.HealthDamage
		}
	}

	return totalDamage
}

func (p *Player) TotalDamageArmorReceivedCount() int {
	totalDamage := 0

	for _, playerHurtedEvent := range p.PlayersHurted {
		if playerHurtedEvent != nil && playerHurtedEvent.HurtedSteamId == p.SteamId {
			totalDamage += playerHurtedEvent.ArmorDamage
		}
	}

	return totalDamage
}

func (p *Player) AverageHealthDamage() float64 {
	total := 0.0
	if len(p.PlayersHurted) > 0 {
		for _, playerHurtedEvent := range p.PlayersHurted {
			if playerHurtedEvent != nil && playerHurtedEvent.AttackerSteamId == p.SteamId {
				total += float64(playerHurtedEvent.HealthDamage)
			}
		}

		if math.Abs(total) < 0.1 {
			return total
		}
	}

	if p.RoundPlayedCount > 0 {
		total = math.Round(total/float64(p.RoundPlayedCount)*100) / 100
	}

	return total
}

func (p *Player) HeadshotPercent() float64 {
	headshotPercent := 0.0
	if p.HeadshotCount <= 0 {
		return headshotPercent
	}

	if p.KillCount > 0 {
		headshotPercent = float64(p.HeadshotCount) * 100 / float64(p.KillCount)
	}

	return math.Round(headshotPercent*100) / 100
}

func (p *Player) RatioEntryKill() float64 {
	entryKillCount := len(p.EntryKills)
	entryKillWin := p.EntryKillWonCount()
	entryKillLoss := p.EntryKillLossCount()

	entryKillPercent := 0.0
	if entryKillWin == 0 {
		return entryKillPercent
	}

	if entryKillLoss == 0 {
		return 100
	}

	entryKillPercent = float64(entryKillWin) / float64(entryKillCount) * 100
	return math.Round(entryKillPercent)
}

func (p *Player) RatioEntryHoldKill() float64 {
	entryHoldKillCount := len(p.EntryHoldKills)
	entryHoldKillWin := p.EntryHoldKillWonCount()
	entryHoldKillLoss := p.EntryHoldKillLossCount()

	entryHoldKillPercent := 0.0
	if entryHoldKillWin == 0 {
		return entryHoldKillPercent
	}

	if entryHoldKillLoss == 0 {
		return 100
	}

	entryHoldKillPercent = float64(entryHoldKillWin) / float64(entryHoldKillCount) * 100
	return math.Round(entryHoldKillPercent)
}

func (p *Player) KillPerRound() float64 {
	if p.RoundPlayedCount > 0 {
		return math.Round(float64(p.KillCount)/float64(p.RoundPlayedCount)*100) / 100
	}
	return 0
}

func (p *Player) AssistPerRound() float64 {
	if p.RoundPlayedCount > 0 {
		return math.Round(float64(p.AssistCount)/float64(p.RoundPlayedCount)*100) / 100
	}
	return 0
}

func (p *Player) DeathPerRound() float64 {
	if p.RoundPlayedCount > 0 {
		return math.Round(float64(p.DeathCount)/float64(p.RoundPlayedCount)*100) / 100
	}
	return 0
}

func (p *Player) TotalTimeDeath() float64 {
	totalTimeDeath := 0.0
	for _, value := range p.TimeDeathRounds {
		totalTimeDeath += value
	}
	return totalTimeDeath
}

func (p *Player) AverageTimeDeath() float64 {
	if p.RoundPlayedCount > 0 {
		return math.Round(p.TotalTimeDeath()/float64(p.RoundPlayedCount)*100) / 100
	}
	return 0
}

func (p *Player) ComputeStats(rounds []Round) {
	var teamKillCount, killCount, headshotCount, crouchKillCount, jumpKillCount, assistCount, deathCount int

	for _, kill := range p.Kills {
		if kill.KilledSide == kill.KillerSide {
			teamKillCount++
		} else {
			killCount++
			if kill.IsHeadshot {
				headshotCount++
			}
			if kill.IsKillerCrouching {
				crouchKillCount++
			}
			if kill.KillerVelocity.Z > 0 {
				jumpKillCount++
			}
		}
	}

	assistCount = len(p.Assists)
	deathCount = len(p.Deaths) + p.SuicideCount

	p.TeamKillCount = teamKillCount
	p.KillCount = killCount - teamKillCount - p.SuicideCount
	p.HeadshotCount = headshotCount
	p.CrouchKillCount = crouchKillCount
	p.JumpKillCount = jumpKillCount
	p.AssistCount = assistCount
	p.DeathCount = deathCount
	p.Kast = p.ComputeKast(rounds)
}

func (p *Player) ComputeKast(rounds []Round) float64 {
	if len(rounds) == 0 {
		return 0
	}

	eventCount := 0
	for _, round := range rounds {
		hasKill := false
		for _, kill := range p.Kills {
			if kill.RoundNumber == round.Number {
				hasKill = true
				break
			}
		}

		hasAssist := false
		for _, assist := range p.Assists {
			if assist.RoundNumber == round.Number {
				hasAssist = true
				break
			}
		}

		hasTradeDeath := false
		for _, death := range p.Deaths {
			if death.RoundNumber == round.Number && death.IsTradeKill {
				hasTradeDeath = true
				break
			}
		}

		hasSurvived := true
		for _, death := range p.Deaths {
			if death.RoundNumber == round.Number {
				hasSurvived = false
				break
			}
		}

		if hasKill || hasAssist || hasTradeDeath || hasSurvived {
			eventCount++
		}
	}

	kast := float64(eventCount) / float64(len(rounds)) * 100

	return kast
}

func (p *Player) HasEventInRound(round int) bool {
	hasKill := false
	hasAssist := false
	hasTradeDeath := false
	hasSurvived := true

	for _, kill := range p.Kills {
		if kill.RoundNumber == round {
			hasKill = true
			break
		}
	}

	for _, assist := range p.Assists {
		if assist.RoundNumber == round {
			hasAssist = true
			break
		}
	}

	for _, death := range p.Deaths {
		if death.RoundNumber == round && death.IsTradeKill {
			hasTradeDeath = true
			break
		}
		if death.RoundNumber == round {
			hasSurvived = false
		}
	}

	return hasKill || hasAssist || hasTradeDeath || hasSurvived
}

func (p *Player) AverageTimeKill() float64 {
	if len(p.TimeKill) == 0 {
		return 0
	}

	sum := 0.0
	for _, time := range p.TimeKill {
		sum += time
	}

	return math.Round(sum/float64(len(p.TimeKill))*100) / 100
}
