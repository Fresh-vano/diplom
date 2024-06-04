package Analyzer

import (
	"fmt"
	"os"

	Models "github.com/Fresh-vano/CS2-Parser/Models"
	dem "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs"

	"github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/common"
	events "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/events"
)

func AnalyzeDemo(demoPath string, demo *Demo) error {
	f, err := os.Open(demoPath)
	if err != nil {
		return err
	}
	defer f.Close()
	p := dem.NewParser(f)
	defer p.Close()
	wasEndPanel := false
	IsLastRoundHalf := false

	p.RegisterEventHandler(func(e events.DataTablesParsed) {
		fmt.Println("Считал заголовок")
		demo.Parser = p
		if len(demo.Rounds) == 0 {
			demo.TimeStartKill = make(map[*events.PlayerHurt]float64)
		}
		if demo.CurrentRound.Number-1 < len(demo.Rounds) && demo.CurrentRound.Number > 0 {
			demo.Rounds = append(demo.Rounds[:demo.CurrentRound.Number-1], demo.Rounds[demo.CurrentRound.Number:]...)
		}
	})

	p.RegisterEventHandler(func(e events.WeaponFire) {
		demo.HandleWeaponFired(e)
	})

	p.RegisterEventHandler(func(e events.RoundFreezetimeChanged) {
		demo.IsFreezetime = e.NewIsFreezetime
		if !e.NewIsFreezetime {
			demo.CurrentRound.FreezetimeEndSecond = demo.Parser.CurrentTime().Seconds()

			for _, player := range demo.Parser.GameState().Participants().All() {
				if player.Team == common.TeamSpectators || player.Team == common.TeamUnassigned {
					continue
				}

				var utilityCounter *int
				if player.TeamState.ClanName() == demo.Team1.Name {
					utilityCounter = &demo.Team1.UtilityBuy
				} else if player.TeamState.ClanName() == demo.Team2.Name {
					utilityCounter = &demo.Team2.UtilityBuy
				} else {
					continue
				}

				for _, weapon := range player.Weapons() {
					if weapon.Class() == common.EqClassGrenade {
						(*utilityCounter)++
					}
				}
			}
		}
	})

	p.RegisterEventHandler(func(e events.RoundStart) {
		fmt.Printf("РАУНД %d\n", demo.Parser.GameState().TotalRoundsPlayed()+1)

		demo.CurrentRound = Models.Round{
			Number: demo.Parser.GameState().TotalRoundsPlayed() + 1,
		}

		demo.PlayerInClutch1 = new(Models.Player)
		demo.PlayerInClutch2 = new(Models.Player)

		demo.IsFirstKillOccurred = false
		demo.IsFirstShotOccured = false

		demo.KillsThisRound = make(map[*common.Player]int)

		gameState := demo.Parser.GameState()
		ctName := gameState.TeamCounterTerrorists().ClanName()
		tName := gameState.TeamTerrorists().ClanName()

		if demo.CurrentRound.Number == 1 && len(demo.Rounds) == 0 {
			demo.Team1.Name = ctName
			demo.Team2.Name = tName
			for _, demoPlayer := range demo.Players {
				for _, teamPlayer := range demo.Parser.GameState().TeamTerrorists().Members() {
					if demoPlayer.SteamId == teamPlayer.SteamID64 {
						demoPlayer.Team = demo.Parser.GameState().TeamTerrorists().Team()
						demoPlayer.Side = common.TeamTerrorists
						if tName != "" {
							demoPlayer.TeamName = tName
						}
					}
				}
				for _, teamPlayer := range demo.Parser.GameState().TeamCounterTerrorists().Members() {
					if demoPlayer.SteamId == teamPlayer.SteamID64 {
						demoPlayer.Team = demo.Parser.GameState().TeamCounterTerrorists().Team()
						demoPlayer.Side = common.TeamCounterTerrorists
						if ctName != "" {
							demoPlayer.TeamName = ctName
						}
					}
				}
			}
		}

	})

	p.RegisterEventHandler(func(e events.Kill) {
		demo.HandlePlayerKilled(&e)
	})

	p.RegisterEventHandler(func(e events.PlayerHurt) {
		demo.HandlePlayerHurted(&e)
	})

	p.RegisterEventHandler(func(e events.RoundEnd) {
		fmt.Println("Конец раунда")
		demo.HandleRoundEnd(e)
		for _, demoPlayer := range demo.Players {
			demoPlayer.RoundPlayedCount++
		}
	})

	p.RegisterEventHandler(func(e events.RoundEndOfficial) {
		fmt.Printf("РАУНД %d ЗАВЕРШЕН\n", demo.Parser.GameState().TotalRoundsPlayed())
		demo.CurrentRound.EndSecondOfficially = demo.Parser.CurrentTime().Seconds()
		demo.UpdateKillsCount()
		demo.ComputeEseaRws()
		demo.Rounds = append(demo.Rounds, demo.CurrentRound)
		demo.KillsThisRound = make(map[*common.Player]int)
		filteredRounds := make([]Models.Round, 0)

		if IsLastRoundHalf {
			IsLastRoundHalf = !IsLastRoundHalf
		}

		for _, round := range demo.Rounds {
			filteredRounds = append(filteredRounds, round)
		}
		if len(demo.Rounds) != len(filteredRounds) {
			for _, players := range demo.Players {
				players.RoundPlayedCount--
			}
		}
		demo.Rounds = filteredRounds
	})

	p.RegisterEventHandler(func(e events.MatchStartedChanged) {
		demo.IsMatchStarted = e.NewIsStarted
	})

	p.RegisterEventHandler(func(e events.AnnouncementLastRoundHalf) {
		IsLastRoundHalf = true
	})

	p.RegisterEventHandler(func(e events.PlayerTeamChange) {
		ctName := demo.Parser.GameState().TeamCounterTerrorists().ClanName()
		tName := demo.Parser.GameState().TeamTerrorists().ClanName()

		for _, player := range demo.Players {
			if player.SteamId == e.Player.SteamID64 && IsLastRoundHalf {
				player.Team = e.NewTeam
				if e.NewTeam == common.TeamCounterTerrorists {
					player.Side = common.TeamCounterTerrorists
					if ctName != "" {
						player.TeamName = demo.Parser.GameState().TeamCounterTerrorists().ClanName()
					}
				} else if e.NewTeam == common.TeamTerrorists {
					player.Side = common.TeamTerrorists
					if tName != "" {
						player.TeamName = demo.Parser.GameState().TeamTerrorists().ClanName()
					}
				}
				break
			}
		}
	})

	p.RegisterEventHandler(func(e events.PlayerDisconnected) {
		for _, player := range demo.Players {
			if player.SteamId == e.Player.SteamID64 {
				//player.IsConnected = e.Player.IsConnected
			}
		}
	})

	p.RegisterEventHandler(func(e events.PlayerConnect) {
		var found *Models.Player
		for _, demoPlayer := range demo.Players {
			if demoPlayer.SteamId == e.Player.SteamID64 {
				demoPlayer.IsConnected = true
				found = demoPlayer
				break
			}
		}
		if found == nil {
			demo.Players = append(demo.Players, &Models.Player{
				SteamId:               e.Player.SteamID64,
				Team:                  e.Player.Team,
				Name:                  e.Player.Name,
				FlashDurationTemp:     e.Player.FlashDuration,
				IsConnected:           e.Player.IsConnected,
				EquipementValueRounds: make(map[int]int),
				RoundsMoneyEarned:     make(map[int]int),
				TimeDeathRounds:       make(map[int]float64),
			})
		}
	})

	p.RegisterEventHandler(func(e events.AnnouncementWinPanelMatch) {
		fmt.Println("Матч завершен")
		wasEndPanel = true

		endMatch(demo)
	})

	err = p.ParseToEnd()
	if err != nil {
		fmt.Println(err)

		return err
	}

	if !wasEndPanel && demo.CurrentRound.Number > len(demo.Rounds) {
		endMatch(demo)
	}

	return err
}

func endMatch(demo *Demo) {
	demo.CurrentRound.EndSecondOfficially = demo.Parser.CurrentTime().Seconds()

	demo.UpdateKillsCount()
	demo.ComputeEseaRws()
	demo.Rounds = append(demo.Rounds, demo.CurrentRound)

	teamCalculate(demo.Team1, demo)
	teamCalculate(demo.Team2, demo)

	for _, player := range demo.Players {
		//player.RoundPlayedCount = len(demo.Rounds)
		if player.TeamName == demo.Team1.Name {
			demo.Team1.Players = append(demo.Team1.Players, player)
		}
		if player.TeamName == demo.Team2.Name {
			demo.Team2.Players = append(demo.Team2.Players, player)
		}
	}
	demo.ProcessPlayersRating()
	demo.ComputeEseaRws()
}

func teamCalculate(team *Models.Team, demo *Demo) {
	// Получаем общее количество сыгранных раундов
	team.RoundCount = demo.Parser.GameState().TotalRoundsPlayed()

	// Сохраняем ссылки на команды для упрощения доступа
	ctTeam := demo.Parser.GameState().TeamCounterTerrorists()
	tTeam := demo.Parser.GameState().TeamTerrorists()

	// Проверяем, к какой команде принадлежит team и устанавливаем соответствующий счет
	switch team.Name {
	case ctTeam.ClanName():
		team.Score = ctTeam.Score()
		if ctTeam.Score() > tTeam.Score() {
			team.WinMatchCount = 1
		}
	case tTeam.ClanName():
		team.Score = tTeam.Score()
		if tTeam.Score() > ctTeam.Score() {
			team.WinMatchCount = 1
		}
	}
}
