package Models

import "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/events"

type SmokeStart struct {
	BaseEvent
	events.SmokeStart
}
