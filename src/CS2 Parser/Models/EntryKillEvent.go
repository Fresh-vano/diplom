package Models

import (
	common "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/common"
)

// EntryKillEvent represents an event related to an entry kill in a Counter-Strike game.
type EntryKillEvent struct {
	BaseEvent
	RoundNumber   int
	KillerSteamId uint64
	KillerName    string
	KillerSide    common.Team
	KilledSteamId uint64
	KilledName    string
	KilledSide    common.Team
	Weapon        *common.Equipment
	HasWon        bool
	HasWonRound   bool
}
