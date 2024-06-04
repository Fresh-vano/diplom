package Models

import (
	"gorm.io/gorm"
)

type TeamSheetRow struct {
	gorm.Model
	MapID                 int
	TeamId                int
	Name                  string `gorm:-`
	KillCount             int
	DeathCount            int
	AssistCount           int
	RoundCount            int
	RoundWonCount         int
	RoundLostCount        int
	RoundWonAsCtCount     int
	RoundLostAsCtCount    int
	RoundWonAsTerroCount  int
	RoundLostAsTerroCount int
	PistolRoundWonCount   int
	PistolRoundCount      int
	EcoRoundWonCount      int
	EcoRoundCount         int
	SemiEcoRoundWonCount  int
	SemiEcoRoundCount     int
	ForceBuyRoundWonCount int
	ForceBuyRoundCount    int
	BombPlantedCount      int
	BombDefusedCount      int
	BombExplodedCount     int
	BombPlantedOnACount   int
	BombPlantedOnBCount   int
	FiveKillCount         int
	FourKillCount         int
	ThreeKillCount        int
	TwoKillCount          int
	OneKillCount          int
	TradeKillCount        int
	TradeDeathCount       int
	JumpKillCount         int
	CrouchKillCount       int
	FlashbangCount        int
	HeGrenadeCount        int
	SmokeCount            int
	MolotovCount          int
	IncendiaryCount       int
	DecoyCount            int
	WinFourVSFive         int
	WinFourVSFivePercent  float64
	AllFourVSFiveRounds   int
	WinFiveVSFour         int
	WinFiveVSFourPercent  float64
	AllFiveVSFourRounds   int
	FlashKills            int
	FlashTeamKills        int
	UtilityBuy            int
	UtilityUse            int
}
