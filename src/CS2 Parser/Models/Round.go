package Models

import (
	"github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/common"
	events "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/events"
)

type Round struct {
	Number                       int
	Second                       float64
	EndSecond                    float64
	EndSecondOfficially          float64
	Duration                     float64
	FreezetimeEndSecond          float64
	EndReason                    events.RoundEndReason
	EquipmentValueTeamT          int
	EquipmentValueTeamCt         int
	StartMoneyTeamCt             int
	StartMoneyTeamT              int
	WinnerSide                   common.Team
	SideTrouble                  common.Team
	Type                         RoundType
	TeamTroubleName              string
	WinnerName                   string
	TeamCt                       string
	TeamT                        string
	OnekillCount                 int
	TwokillCount                 int
	ThreekillCount               int
	FourkillCount                int
	FivekillCount                int
	KillCount                    int
	JumpKillCount                int
	CrouchKillCount              int
	TradeKillCount               int
	SmokeThrownCount             int
	FlashbangThrownCount         int
	DecoyThrownCount             int
	MolotovThrownCount           int
	IncendiaryThrownCount        int
	HeThrownCount                int
	DamageHealthCount            int
	DamageArmorCount             int
	AverageHealthDamagePerPlayer float64
	BombDefusedCount             int
	BombPlantedCount             int
	BombExplodedCount            int
	BombPlanted                  events.BombPlanted
	BombDefused                  events.BombDefused
	EntryKillEvent               EntryKillEvent
	EntryHoldKillEvent           EntryHoldKillEvent
	WeaponFired                  []WeaponFireEvent
	Kills                        []KillEvent
	SmokeStarted                 []SmokeStart
	PlayersHurted                []PlayerHurtedEvent
}
