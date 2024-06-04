package Models

import (
	"github.com/golang/geo/r3"
	common "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/common"
)

// KillEvent represents an event related to a kill in a Counter-Strike game.
type KillEvent struct {
	Seconds                  float64
	KillerSteamID            uint64
	KilledSteamID            uint64
	AssisterSteamID          uint64
	Weapon                   *common.Equipment
	KillerVelocity           r3.Vector
	KillerSide               common.Team
	KillerTeam               string
	KilledSide               common.Team
	KilledTeam               string
	KillerName               string
	KilledName               string
	AssisterName             string
	AssisterTeam             string
	AssisterSide             common.Team
	RoundNumber              int
	TimeDeathSeconds         float64
	IsKillerCrouching        bool
	KillerIsBlinded          bool
	IsTradeKill              bool
	IsHeadshot               bool
	KillerIsControllingBot   bool
	KilledIsControllingBot   bool
	VictimIsBlinded          bool
	AssisterIsControllingBot bool
	IsAssisterFlash          bool
}

// IsKillerBot checks if the killer is a bot.
func (ke *KillEvent) IsKillerBot() bool {
	return ke.KillerSteamID == 0
}

// IsVictimBot checks if the victim is a bot.
func (ke *KillEvent) IsVictimBot() bool {
	return ke.KilledSteamID == 0
}
