package Models

// ClutchEvent represents an event related to a clutch situation in a Counter-Strike game.
type ClutchEvent struct {
	BaseEvent
	OpponentCount int
	HasWon        bool
	RoundNumber   int
}
