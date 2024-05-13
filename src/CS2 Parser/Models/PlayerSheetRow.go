package Models

import (
	"gorm.io/gorm"
)

type PlayerSheetRow struct {
	gorm.Model
	MapID                   int
	TeamId                  int
	Team                    string `gorm:-`
	Name                    string `gorm:-`
	Match                   int    `gorm:-`
	Kills                   int
	Assists                 int
	Deaths                  int
	KD                      float64
	HS                      int
	HSPercent               float64
	Rounds                  int
	RWS                     float64
	KAST                    float64
	Rating                  float64
	Rating2                 float64
	ATDs                    float64
	FiveKill                int
	FourKill                int
	ThreeKill               int
	TwoKill                 int
	OneKill                 int
	TradeKill               int
	TradeDeath              int
	TeamKill                int
	JumpKill                int
	CrouchKill              int
	BombPlanted             int
	BombDefused             int
	BombExploded            int
	MVP                     int
	Score                   int
	Clutch                  int
	ClutchWon               int
	ClutchLost              int
	ClutchWonPercent        float64
	OneVOne                 int
	OneVOneWon              int
	OneVOneLost             int
	OneVOneWonPercent       float64
	OneVTwo                 int
	OneVTwoWon              int
	OneVTwoLost             int
	OneVTwoWonPercent       float64
	OneVThree               int
	OneVThreeWon            int
	OneVThreeLost           int
	OneVThreeWonPercent     float64
	OneVFour                int
	OneVFourWon             int
	OneVFourLost            int
	OneVFourWonPercent      float64
	OneVFive                int
	OneVFiveWon             int
	OneVFiveLost            int
	OneVFiveWonPercent      float64
	EntryKill               int
	EntryKillWin            int
	EntryKillLost           int
	EntryKillWinPercent     float64
	EntryHoldKill           int
	EntryHoldKillWin        int
	EntryHoldKillLost       int
	EntryHoldKillWinPercent float64
	KPR                     float64
	APR                     float64
	DPR                     float64
	ADR                     float64
	TDH                     int
	TDA                     int
	Flashbang               int
	Smoke                   int
	HE                      int
	Decoy                   int
	Molotov                 int
	Incendiary              int
	RankMax                 int
	VAC                     bool
	OW                      bool
	SurvivedRounds          int
	Hits                    int
	Shots                   int
	KillThroughSmoke        int
	AverageTimeToKill       float64
	Rage                    int
}
