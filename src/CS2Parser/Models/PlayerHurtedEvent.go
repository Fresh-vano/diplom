package Models

import (
	common "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/common"
	events "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/events"
)

// PlayerHurtedEvent represents an event related to a player being hurt in a Counter-Strike game.
type PlayerHurtedEvent struct {
	BaseEvent
	HurtedSteamId   uint64
	AttackerSteamId uint64
	AttackerSide    common.Team
	ArmorDamage     int
	HealthDamage    int
	HitGroup        events.HitGroup
	Weapon          *common.Equipment
	RoundNumber     int
}
