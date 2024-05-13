package Models

type RoundType int

const (
	ECO RoundType = iota
	SEMI_ECO
	NORMAL
	FORCE_BUY
	PISTOL_ROUND
)
