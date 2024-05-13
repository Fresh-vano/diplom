package Models

import (
	"github.com/golang/geo/r3"
	common "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/common"
)

type WeaponFireEvent struct {
	Seconds           float64
	ShooterSteamID    uint64
	ShooterName       string
	ShooterSide       common.Team
	Weapon            *common.Equipment
	RoundNumber       int
	ShooterVelocity   r3.Vector
	ShooterPos        r3.Vector
	ShooterAnglePitch float32
	ShooterAngleYaw   float32
}
