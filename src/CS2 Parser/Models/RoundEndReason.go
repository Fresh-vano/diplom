package Models

type RoundEndReason int

const (
	TargetBombed RoundEndReason = iota + 1
	VIPEscaped
	VIPKilled
	TerroristsEscaped
	CTStoppedEscape
	TerroristsStopped
	BombDefused
	CTWin
	TerroristWin
	Draw
	HostagesRescued
	TargetSaved
	HostagesNotRescued
	TerroristsNotEscaped
	VIPNotEscaped
	GameStart
	TerroristsSurrender
	CTSurrender
)
