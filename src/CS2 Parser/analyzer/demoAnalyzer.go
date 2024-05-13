package Analyzer

import (
	"math"
	"time"

	dem "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs"
	common "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/common"
	events "github.com/markus-wa/demoinfocs-golang/v4/pkg/demoinfocs/events"

	Models "github.com/Fresh-vano/CS2-Parser/Models"
)

type Demo struct {
	Parser              dem.Parser
	Players             []*Models.Player
	Rounds              []Models.Round
	Team1               *Models.Team
	Team2               *Models.Team
	CurrentRound        Models.Round
	IsFirstKillOccurred bool
	IsFirstShotOccured  bool
	PlayerInClutch1     *Models.Player
	PlayerInClutch2     *Models.Player
	CurrentClutch       *Models.ClutchEvent
	IsMatchStarted      bool
	IsFreezetime        bool
	KillsThisRound      map[*common.Player]int
	TimeStartKill       map[*events.PlayerHurt]float64
	Kills               []Models.KillEvent
	PlayersHurted       []*Models.PlayerHurtedEvent
	WeaponFired         []Models.WeaponFireEvent
	Date                time.Time
}

const (
	ESEA_ASSIST_THRESHOLD = 50
)

// HTLV rating variables http://www.hltv.org/?pageid=242&eventid=0
const (
	AverageKPR float64 = 0.679 // average kills per round
	AverageSPR float64 = 0.317 // average survived rounds per round
	AverageRMK float64 = 1.277 // average value calculated from rounds with multiple kills
)

// HTLV2 rating variables https://flashed.gg/posts/reverse-engineering-hltv-rating/
const (
	HLTV2KASTMod         float64 = 0.0073  // KAST modifier
	HLTV2KPRMod          float64 = 0.3591  // KPR modifier
	HLTV2DPRMod          float64 = -0.5329 // DPR modifier
	HLTV2ImpactMod       float64 = 0.2372  // Impact modifier
	HLTV2ImpactKPRMod    float64 = 2.13    // Impact KPR modifier
	HLTV2ImpactAPRMod    float64 = 0.42    // Impact AssistPerRound modifier
	HLTV2ImpactOffsetMod float64 = -0.41   // Impact base modifier
	HLTV2ADRMod          float64 = 0.0032  // ADR modifier
	HLTV2OffsetMod       float64 = 0.1587  // HLTV2 base modifier
)

func (d *Demo) ProcessPlayersRating() {
	for _, player := range d.Players {
		player.ComputeStats(d.Rounds)

		player.RatingHltv = ComputeHltvOrgRating(len(d.Rounds), player.KillCount, player.DeathCount, []int{
			player.OneKillCount, player.TwoKillCount, player.ThreeKillCount, player.FourKillCount, player.FiveKillCount,
		})

		player.RatingHltv2 = d.ComputeHltv2OrgRating(player)
	}
}

func ComputeHltvOrgRating(roundCount, kills, deaths int, nKills []int) float64 {
	// Kills/Rounds/AverageKPR
	killRating := float64(kills) / float64(roundCount) / AverageKPR
	// (Rounds-Deaths)/Rounds/AverageSPR
	survivalRating := float64(roundCount-deaths) / float64(roundCount) / AverageSPR
	// (1K + 4*2K + 9*3K + 16*4K + 25*5K)/Rounds/AverageRMK
	roundsWithMultipleKillsRating :=
		(float64(nKills[0]) + 4*float64(nKills[1]) + 9*float64(nKills[2]) + 16*float64(nKills[3]) + 25*float64(nKills[4])) /
			float64(roundCount) / AverageRMK

	return math.Round((killRating+0.7*survivalRating+roundsWithMultipleKillsRating)/2.7*1000) / 1000
}

func (d *Demo) ComputeHltv2OrgRating(player *Models.Player) float64 {
	// KAST
	KAST := 0.0
	KASTrounds := 0
	for round := 0; round < len(d.Rounds); round++ {
		if player.HasEventInRound(round) {
			KASTrounds++
		}
	}
	KAST = HLTV2KASTMod * (float64(KASTrounds) / float64(len(d.Rounds)) * 100.0)

	// KPR
	KPR := HLTV2KPRMod * player.KillPerRound()

	// DPR
	DPR := HLTV2DPRMod * player.DeathPerRound()

	// ADR
	ADR := HLTV2ADRMod * player.AverageHealthDamage()

	// Impact
	Impact := HLTV2ImpactMod * (HLTV2ImpactKPRMod*player.KillPerRound() + HLTV2ImpactAPRMod*player.AssistPerRound() +
		HLTV2ImpactOffsetMod)

	// HLTV2
	HLTV2 := KAST + KPR + DPR + Impact + ADR + HLTV2OffsetMod

	return math.Round(HLTV2*1000) / 1000
}

func (d *Demo) ComputeEseaRws() {
	totalDamageWinner := 0
	playerDamages := make(map[uint64]int)

	for _, e := range d.CurrentRound.PlayersHurted {
		if e.AttackerSide == d.CurrentRound.WinnerSide {
			if _, exists := playerDamages[e.AttackerSteamId]; !exists {
				playerDamages[e.AttackerSteamId] = e.HealthDamage
			} else {
				playerDamages[e.AttackerSteamId] += e.HealthDamage
			}

			totalDamageWinner += e.HealthDamage
		}
	}

	for _, player := range d.Players {
		if player.TeamName == d.CurrentRound.WinnerName && player.IsConnected {
			switch d.CurrentRound.EndReason {
			case events.RoundEndReasonCTWin, events.RoundEndReasonTerroristsWin:
				if totalDamageWinner > 0 {
					if damage, exists := playerDamages[player.SteamId]; exists {
						player.EseaRwsPointCount += float64(damage) / float64(totalDamageWinner) * 100
					}
				}
			case events.RoundEndReasonBombDefused, events.RoundEndReasonTargetBombed:
				if d.CurrentRound.BombDefused != (events.BombDefused{}) && d.CurrentRound.BombDefused.Player.SteamID64 == player.SteamId {
					player.EseaRwsPointCount += 30
				}
				if d.CurrentRound.BombPlanted != (events.BombPlanted{}) && d.CurrentRound.BombPlanted.Player.SteamID64 == player.SteamId {
					player.EseaRwsPointCount += 30
				}
				if totalDamageWinner > 0 {
					if damage, exists := playerDamages[player.SteamId]; exists {
						player.EseaRwsPointCount += float64(damage) / float64(totalDamageWinner) * 70
					}
				}
			}

		}

		if player.RoundPlayedCount > 0 {
			player.EseaRws = math.Floor(player.EseaRwsPointCount/float64(player.RoundPlayedCount)*1000) / 1000
		}
	}
}

func (d *Demo) findPlayerBySteamID(steamID uint64) *Models.Player {
	for _, player := range d.Players {
		if player.SteamId == steamID {
			return player
		}
	}
	return nil
}

func (d *Demo) ProcessTradeKill(killEvent Models.KillEvent) {
	lastKilledEvent := Models.KillEvent{}

	for _, k := range d.CurrentRound.Kills {
		if k.KillerSteamID == killEvent.KilledSteamID {
			lastKilledEvent = k
		}
	}

	if lastKilledEvent.KillerSteamID != 0 && d.Parser.CurrentTime().Seconds()-lastKilledEvent.Seconds <= 4 {
		killEvent.IsTradeKill = true

		killer := d.findPlayerBySteamID(killEvent.KillerSteamID)
		if killer != nil {
			killer.TradeKillCount++
		}

		killed := d.findPlayerBySteamID(killEvent.KilledSteamID)
		if killed != nil {
			killed.TradeDeathCount++
		}
	}
}

// ProcessOpenAndEntryKills обрабатывает событие убийства для определения открытых и входных убийств
func (d *Demo) ProcessOpenAndEntryKills(killEvent Models.KillEvent) {
	if killEvent.KillerSteamID == 0 || d.IsFirstKillOccurred {
		return
	}

	killed := d.findPlayerBySteamID(killEvent.KilledSteamID)
	if killed == nil {
		return
	}

	killer := d.findPlayerBySteamID(killEvent.KillerSteamID)
	if killer == nil {
		return
	}

	if killEvent.KillerSide == common.TeamTerrorists {
		// Это входное убийство
		killer.HasEntryKill = true
		killed.HasEntryKill = true
		entryKillEvent := Models.EntryKillEvent{
			RoundNumber:   d.CurrentRound.Number,
			KilledSteamId: killed.SteamId,
			KilledName:    killed.Name,
			KilledSide:    killEvent.KilledSide,
			KillerSteamId: killer.SteamId,
			KillerName:    killer.Name,
			KillerSide:    killEvent.KillerSide,
			Weapon:        killEvent.Weapon,
		}
		d.CurrentRound.EntryKillEvent = entryKillEvent
		killerEvent := d.CurrentRound.EntryKillEvent
		killerEvent.HasWon = true
		killer.EntryKills = append(killer.EntryKills, killerEvent)
		killedEvent := d.CurrentRound.EntryKillEvent
		killedEvent.HasWon = false
		killed.EntryKills = append(killed.EntryKills, killedEvent)
	} else {
		// CT сделал убийство, это входное убийство при удержании
		killer.HasEntryHoldKill = true
		killed.HasEntryHoldKill = true
		entryHoldKillEvent := Models.EntryHoldKillEvent{
			RoundNumber:   d.CurrentRound.Number,
			KilledSteamId: killed.SteamId,
			KilledName:    killed.Name,
			KilledSide:    killEvent.KilledSide,
			KillerSteamId: killer.SteamId,
			KillerName:    killer.Name,
			KillerSide:    killEvent.KillerSide,
			Weapon:        killEvent.Weapon,
		}
		d.CurrentRound.EntryHoldKillEvent = entryHoldKillEvent
		killerEvent := d.CurrentRound.EntryHoldKillEvent
		killerEvent.HasWon = true
		killer.EntryHoldKills = append(killer.EntryHoldKills, killerEvent)
		killedEvent := d.CurrentRound.EntryHoldKillEvent
		killedEvent.HasWon = false
		killed.EntryHoldKills = append(killed.EntryHoldKills, killedEvent)
	}

	d.IsFirstKillOccurred = true
}

// CheckForSpecialClutchEnd проверяет, завершился ли клатч особым образом (победой бомбы)
func (d *Demo) CheckForSpecialClutchEnd() {
	if d.PlayerInClutch1 == nil {
		return
	}

	pl := d.findPlayerBySteamID(d.PlayerInClutch1.SteamId)
	if pl == nil {
		return
	}

	// 1vX
	if d.PlayerInClutch2 == nil {
		if pl.Team == common.TeamTerrorists && d.CurrentRound.WinnerSide == common.TeamTerrorists ||
			pl.Team == common.TeamCounterTerrorists && d.CurrentRound.WinnerSide == common.TeamCounterTerrorists {
			d.PlayerInClutch1.Clutches[len(d.PlayerInClutch1.Clutches)-1].HasWon = true
		}
	} else if d.PlayerInClutch2 != nil {
		// 1V1
		switch d.CurrentRound.WinnerSide {
		case common.TeamCounterTerrorists:
			if pl.Team == common.TeamCounterTerrorists {
				// CT won
				d.PlayerInClutch1.Clutches[len(d.PlayerInClutch1.Clutches)-1].HasWon = true
			} else {
				// T won
				d.PlayerInClutch2.Clutches[len(d.PlayerInClutch2.Clutches)-1].HasWon = true
			}
		case common.TeamTerrorists:
			if pl.Team == common.TeamTerrorists {
				// T won
				d.PlayerInClutch1.Clutches[len(d.PlayerInClutch1.Clutches)-1].HasWon = true
			} else {
				// CT won
				d.PlayerInClutch2.Clutches[len(d.PlayerInClutch2.Clutches)-1].HasWon = true
			}
		}
	}
}

// UpdateKillsCount обновляет счетчики убийств для каждого игрока, текущего раунда и демонстрации
func (d *Demo) UpdateKillsCount() {
	for player, kills := range d.KillsThisRound {
		// Находим игрока по SteamID
		targetPlayer := d.findPlayerBySteamID(player.SteamID64)
		if targetPlayer == nil {
			continue
		}

		// Обновляем счетчик убийств игрока
		switch kills {
		case 1:
			targetPlayer.OneKillCount++
		case 2:
			targetPlayer.TwoKillCount++
		case 3:
			targetPlayer.ThreeKillCount++
		case 4:
			targetPlayer.FourKillCount++
		case 5:
			targetPlayer.FiveKillCount++
		}
	}
	d.CurrentRound.KillCount = len(d.KillsThisRound)
}

// HandlePlayerHurted обрабатывает событие, когда игрок получает урон
func (d *Demo) HandlePlayerHurted(e *events.PlayerHurt) {
	if !d.IsMatchStarted || e.Player == nil || e.Weapon == nil {
		return
	}

	// Возможно, бот в демонстрациях MM
	hurted := d.findPlayerBySteamID(e.Player.SteamID64)
	weapon := e.Weapon
	if hurted == nil || weapon == nil {
		return
	}

	var attacker *Models.Player
	// Атакующий может быть равен nil (урон от мира)
	if e.Attacker != nil {
		attacker = d.findPlayerBySteamID(e.Attacker.SteamID64)
	}

	if attacker != nil && weapon.Class() != common.EqClassGrenade && weapon.Class() != common.EqClassEquipment && weapon.Class() != common.EqClassUnknown {
		attacker.HitCount++

		// Помимо увеличения счетчика попаданий, вы можете выполнить другие действия по вашему выбору.

		// Пример: Записать время начала атаки (если это первая атака между атакующим и атакуемым)
		if _, exists := d.TimeStartKill[e]; !exists {
			d.TimeStartKill[e] = d.Parser.CurrentTime().Seconds()
		}
	}

	playerHurtedEvent := Models.PlayerHurtedEvent{}
	if e.Attacker != nil {
		playerHurtedEvent.AttackerSteamId = attacker.SteamId
		playerHurtedEvent.AttackerSide = e.Attacker.TeamState.Team()
	}
	playerHurtedEvent.HurtedSteamId = hurted.SteamId
	playerHurtedEvent.ArmorDamage = e.ArmorDamage
	playerHurtedEvent.HealthDamage = min(e.Player.Health(), e.HealthDamage) // Минимум между HP и уроном здоровью, чтобы избежать отрицательных значений.
	playerHurtedEvent.HitGroup = e.HitGroup
	playerHurtedEvent.Weapon = weapon
	playerHurtedEvent.RoundNumber = d.CurrentRound.Number

	d.PlayersHurted = append(d.PlayersHurted, &playerHurtedEvent)
	if attacker != nil {
		attacker.PlayersHurted = append(attacker.PlayersHurted, &playerHurtedEvent)
	}
	hurted.PlayersHurted = append(hurted.PlayersHurted, &playerHurtedEvent)
	d.CurrentRound.PlayersHurted = append(d.CurrentRound.PlayersHurted, playerHurtedEvent)
}

// min возвращает минимальное из двух целых чисел
func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}

// ProcessClutches проверяет, есть ли ситуация в стиле "клач", и, если да, добавляет "клач" игроку
func (d *Demo) ProcessClutches() {
	terroristAliveCount := 0
	counterTerroristAliveCount := 0

	if d.CurrentRound.Number == 52 {
		return
	}
	// Подсчет живых игроков для каждой команды
	for _, participant := range d.Parser.GameState().Participants().All() {
		if participant.TeamState != nil {
			switch participant.TeamState.Team() {
			case common.TeamTerrorists:
				if participant.IsAlive() {
					terroristAliveCount++
				}
			case common.TeamCounterTerrorists:
				if participant.IsAlive() {
					counterTerroristAliveCount++
				}
			}
		}
	}

	// Первое обнаружение ситуации 1vX, где террорист в "клаче"
	if d.PlayerInClutch1 == nil && terroristAliveCount == 1 {
		// Установка количества оппонентов в "клаче" для террориста
		for _, pl := range d.Parser.GameState().Participants().All() {
			if pl.Team == common.TeamTerrorists && pl.IsAlive() {
				playerInClutch1 := d.findPlayerBySteamID(pl.SteamID64)
				if playerInClutch1 != nil {
					playerInClutch1.Clutches = append(playerInClutch1.Clutches, Models.ClutchEvent{
						RoundNumber:   d.CurrentRound.Number,
						OpponentCount: counterTerroristAliveCount,
					})
					d.PlayerInClutch1 = playerInClutch1
					return
				}
			}
		}
	}

	// Первое обнаружение ситуации 1vX, где CT в "клаче"
	if d.PlayerInClutch1 == nil && counterTerroristAliveCount == 1 {
		// Установка количества оппонентов в "клаче" для CT
		for _, pl := range d.Parser.GameState().Participants().All() {
			if pl.Team == common.TeamTerrorists && pl.IsAlive() {
				playerInClutch1 := d.findPlayerBySteamID(pl.SteamID64)
				if playerInClutch1 != nil {
					playerInClutch1.Clutches = append(playerInClutch1.Clutches, Models.ClutchEvent{
						RoundNumber:   d.CurrentRound.Number,
						OpponentCount: terroristAliveCount,
					})
					d.PlayerInClutch1 = playerInClutch1
					return
				}
			}
		}
	}

	// Обнаружение ситуации 1v1
	if counterTerroristAliveCount == 1 && terroristAliveCount == 1 && d.PlayerInClutch1 != nil {
		// Найти игрока 1
		player1Team := common.TeamCounterTerrorists
		if d.PlayerInClutch1.TeamName == "Terrorist" {
			player1Team = common.TeamTerrorists
		}
		var player1 *Models.Player

		if player1Team == common.TeamCounterTerrorists {
			player1 = d.FindAlivePlayerInTeam(d.Parser.GameState().TeamCounterTerrorists().ClanName())
		} else {
			player1 = d.FindAlivePlayerInTeam(d.Parser.GameState().TeamTerrorists().ClanName())
		}

		// Найти игрока 2
		player2Team := common.TeamCounterTerrorists
		if player1Team == common.TeamCounterTerrorists {
			player2Team = common.TeamTerrorists
		}

		var player2 *Models.Player

		if player2Team == common.TeamCounterTerrorists {
			player2 = d.FindAlivePlayerInTeam(d.Parser.GameState().TeamCounterTerrorists().ClanName())
		} else {
			player2 = d.FindAlivePlayerInTeam(d.Parser.GameState().TeamTerrorists().ClanName())
		}

		if player1 != nil && player2 != nil {
			player2.Clutches = append(player2.Clutches, Models.ClutchEvent{
				RoundNumber:   d.CurrentRound.Number,
				OpponentCount: 1,
			})
		}
	}
}

// FindAlivePlayerInTeam ищет живого игрока в указанной команде (по имени команды)
func (d *Demo) FindAlivePlayerInTeam(teamName string) *Models.Player {
	for _, player := range d.Players {
		if player.TeamName == teamName && player.IsAlive {
			return player
		}
	}
	return nil // Если живой игрок не найден
}

// HandlePlayerKilled обрабатывает события, когда игрок убит
func (d *Demo) HandlePlayerKilled(e *events.Kill) {
	// Проверка условий для обработки события
	if !d.IsMatchStarted || d.IsFreezetime || e.Victim == nil {
		return
	}

	if e.Killer == e.Victim {
		return
	}

	// Поиск убитого игрока
	var killed *Models.Player
	for _, player := range d.Players {
		if player.SteamId == e.Victim.SteamID64 {
			killed = player
			break
		}
	}

	// Поиск оружия
	var weapon = e.Weapon

	// Поиск убийцы и помощника
	var killer, assister *Models.Player

	killEvent := Models.KillEvent{
		Weapon:           weapon,
		KilledSide:       e.Victim.TeamState.Team(),
		KilledSteamID:    e.Victim.SteamID64,
		KilledName:       e.Victim.Name,
		KilledTeam:       e.Victim.TeamState.ClanName(),
		VictimIsBlinded:  e.Victim.FlashDuration > 0,
		RoundNumber:      d.CurrentRound.Number,
		IsHeadshot:       e.IsHeadshot,
		IsAssisterFlash:  e.AssistedFlash,
		TimeDeathSeconds: d.Parser.CurrentTime().Seconds() - d.CurrentRound.FreezetimeEndSecond,
		Seconds:          d.Parser.CurrentTime().Seconds(),
	}

	killed.IsAlive = false
	killed.TimeDeathRounds[d.CurrentRound.Number] = killEvent.TimeDeathSeconds

	if e.Killer != nil {
		killEvent.KillerTeam = e.Killer.TeamState.ClanName()
		killEvent.KillerSteamID = e.Killer.SteamID64
		killEvent.KillerName = e.Killer.Name
		killEvent.KillerSide = e.Killer.TeamState.Team()
		killEvent.KillerIsBlinded = e.Killer.FlashDuration > 0
		killEvent.IsKillerCrouching = e.Killer.IsDucking()

		for _, player := range d.Players {
			if player.SteamId == e.Killer.SteamID64 {
				killer = player
				break
			}
		}
	} else {
		// Самоубийство, возможно, из-за промаха в прыжке с верхнего уровня B на поезде :)
		killed.SuicideCount++
	}

	if killer != nil {
		// Добавление убийства только в текущем раунде, если это не TK / самоубийство
		if e.Killer.Team != e.Victim.Team {
			if _, exists := d.KillsThisRound[e.Killer]; !exists {
				d.KillsThisRound[e.Killer] = 0
			}
			d.KillsThisRound[e.Killer]++
		}

		if e.ThroughSmoke {
			killer.KillThroughSmoke++
		}

		d.ProcessTradeKill(killEvent)
	}
	if e.Assister != nil {
		damagesPerPlayer := make(map[uint64]int)
		if e.Killer != nil {
			for _, hurtedEvent := range d.CurrentRound.PlayersHurted {
				if hurtedEvent.HurtedSteamId == e.Victim.SteamID64 && hurtedEvent.AttackerSteamId != e.Killer.SteamID64 {
					if val, exists := damagesPerPlayer[hurtedEvent.AttackerSteamId]; exists {
						damagesPerPlayer[hurtedEvent.AttackerSteamId] = val + hurtedEvent.HealthDamage
					} else {
						damagesPerPlayer[hurtedEvent.AttackerSteamId] = hurtedEvent.HealthDamage
					}
				}
			}
		} else {
			for _, player := range d.Players {
				if player.SteamId == e.Assister.SteamID64 {
					assister = player
					break
				}
			}
		}

		if len(damagesPerPlayer) > 0 {
			var higherDamageDone int
			var higherDamagePlayerID uint64
			for playerID, damage := range damagesPerPlayer {
				if damage > higherDamageDone {
					higherDamageDone = damage
					higherDamagePlayerID = playerID
				}
			}

			if higherDamageDone > ESEA_ASSIST_THRESHOLD {
				for _, player := range d.Players {
					if player.SteamId == higherDamagePlayerID {
						assister = player
						break
					}
				}
			}
		}
	}

	if e.Killer != nil && e.Victim != nil {
		for _, smoke := range d.CurrentRound.SmokeStarted {
			if d.Parser.CurrentTime().Seconds() > smoke.Seconds+18 {
				continue
			}
		}
	}

	if assister != nil {
		killEvent.AssisterSteamID = assister.SteamId
		killEvent.AssisterName = assister.Name
		killEvent.AssisterSide = assister.Side
		killEvent.AssisterTeam = assister.TeamName
		assister.Assists = append(assister.Assists, killEvent)
	}

	d.Kills = append(d.Kills, killEvent)
	d.CurrentRound.Kills = append(d.CurrentRound.Kills, killEvent)
	if killer != nil {
		killer.Kills = append(killer.Kills, killEvent)
	}
	killed.Deaths = append(killed.Deaths, killEvent)

	if killer != nil && killed != nil {
		if e.Killer.Health() <= 25 {
			killer.Rage++
		}

		var recentHurtedEvent *Models.PlayerHurtedEvent
		for _, hurtedEvent := range d.CurrentRound.PlayersHurted {
			if hurtedEvent.HurtedSteamId == killed.SteamId && hurtedEvent.Seconds >= d.Parser.CurrentTime().Seconds()-4 {
				if recentHurtedEvent == nil || hurtedEvent.Seconds > recentHurtedEvent.Seconds {
					recentHurtedEvent = &hurtedEvent
				}
			}
		}

		if recentHurtedEvent != nil {
			killer.TimeKill = append(killer.TimeKill, d.Parser.CurrentTime().Seconds()-recentHurtedEvent.Seconds)
		}
	}

	d.ProcessOpenAndEntryKills(killEvent)
	d.ProcessClutches()
	d.ProcessPlayersRating()
}

func (d *Demo) HandleRoundEnd(e events.RoundEnd) {
	if !d.Parser.GameState().IsMatchStarted() /*|| d.Parser.GameState().IsFreezetimePeriod()*/ {
		return
	}

	d.CurrentRound.EndSecond = d.Parser.CurrentTime().Seconds()
	d.CurrentRound.Duration = d.CurrentRound.EndSecond - d.CurrentRound.Second
	d.CurrentRound.EndReason = e.Reason
	d.CurrentRound.WinnerSide = e.Winner
	if e.WinnerState != nil {
		d.CurrentRound.WinnerName = e.WinnerState.ClanName()
	}

	for _, player := range d.Players {
		if player.HasEntryKill && player.Side == e.Winner {
			player.EntryKills[len(player.EntryKills)-1].HasWonRound = true
		}
	}

	for _, player := range d.Players {
		if player.HasEntryHoldKill && player.Side == e.Winner {
			player.EntryHoldKills[len(player.EntryHoldKills)-1].HasWonRound = true
		}
	}

	d.ComputeEseaRws()
}

func (d *Demo) HandleWeaponFired(e events.WeaponFire) {
	if !d.IsMatchStarted || e.Shooter == nil || e.Weapon == nil {
		return
	}

	if !d.IsFirstShotOccured {
		d.IsFreezetime = false
		d.IsFirstShotOccured = true

		for _, pl := range d.Parser.GameState().Participants().All() {
			player := d.findPlayerBySteamID(pl.SteamID64)
			if player != nil {
				//player.EquipementValueRounds[d.CurrentRound.Number] = pl.EquipmentValueCurrent()
			}
		}

		// equipValueCt := d.Parser.GameState().TeamCounterTerrorists().RoundStartEquipmentValue()
		// equipValueT := d.Parser.GameState().TeamTerrorists().FreezeTimeEndEquipmentValue()
		startMoneyCt := d.CalcEquipValue(common.TeamCounterTerrorists)
		startMoneyT := d.CalcEquipValue(common.TeamTerrorists)
		equipValueCt := d.Parser.GameState().TeamCounterTerrorists().CurrentEquipmentValue()
		equipValueT := d.Parser.GameState().TeamTerrorists().CurrentEquipmentValue()

		if startMoneyCt == 4000 && startMoneyT == 4000 {
			d.CurrentRound.Type = Models.PISTOL_ROUND
			d.CurrentRound.SideTrouble = d.Parser.GameState().TeamTerrorists().Team()
			d.CurrentRound.TeamTroubleName = d.Parser.GameState().TeamTerrorists().ClanName()
		} else {
			diffPercent := math.Abs(math.Round((float64(equipValueCt-equipValueT)/float64((equipValueCt+equipValueT)/2)*100)*100) / 100)
			if diffPercent >= 90 {
				d.CurrentRound.Type = Models.ECO
			} else if diffPercent >= 75 && diffPercent < 90 {
				d.CurrentRound.Type = Models.SEMI_ECO
			} else if diffPercent >= 50 && diffPercent < 75 {
				d.CurrentRound.Type = Models.FORCE_BUY
			} else {
				d.CurrentRound.Type = Models.NORMAL
			}

			if d.CurrentRound.Type != Models.NORMAL {
				d.CurrentRound.SideTrouble = d.GetSideWithHigherEquipValue(equipValueCt, equipValueT)
				d.CurrentRound.TeamTroubleName = d.GetTeamBySide(d.CurrentRound.SideTrouble).ClanName()
			}
		}
	}

	shooter := d.findPlayerBySteamID(e.Shooter.SteamID64)
	weapon := e.Weapon
	if shooter == nil || weapon == nil {
		return
	}

	if weapon.Class() != common.EqClassGrenade && weapon.Class() != common.EqClassEquipment && weapon.Class() != common.EqClassUnknown {
		shooter.ShotCount++
	}

	shoot := Models.WeaponFireEvent{
		Seconds:           d.Parser.CurrentTime().Seconds(),
		ShooterSteamID:    shooter.SteamId,
		ShooterName:       shooter.Name,
		Weapon:            weapon,
		RoundNumber:       d.CurrentRound.Number,
		ShooterSide:       e.Shooter.TeamState.Team(),
		ShooterPos:        e.Shooter.Position(),
		ShooterAnglePitch: e.Shooter.ViewDirectionY(),
		ShooterAngleYaw:   e.Shooter.ViewDirectionX(),
	}

	if e.Weapon.Class() == common.EqClassGrenade {
		d.CurrentRound.WeaponFired = append(d.CurrentRound.WeaponFired, shoot)
		if e.Shooter.TeamState.ClanName() == d.Team1.Name {
			d.Team1.UtilityUse++
		} else {
			d.Team2.UtilityUse++
		}
	}

	switch e.Weapon.Type {
	case common.EqIncendiary:
		shooter.IncendiaryThrownCount++
		//d.LastNadeTypeThrown = append(d.LastNadeTypeThrown, EquipmentElementIncendiary)
	case common.EqMolotov:
		//d.LastNadeTypeThrown = append(d.LastNadeTypeThrown, EquipmentElementMolotov)
		shooter.MolotovThrownCount++
	case common.EqDecoy:
		shooter.DecoyThrownCount++
	case common.EqFlash:
		shooter.FlashbangThrownCount++
		//d.PlayersFlashQueue = append(d.PlayersFlashQueue, shooter)
	case common.EqHE:
		shooter.HeGrenadeThrownCount++
	case common.EqSmoke:
		shooter.SmokeThrownCount++
	}

	d.WeaponFired = append(d.WeaponFired, shoot)

	if e.Shooter.SteamID64 == 0 {
		return
	}

	// switch e.Weapon.Type {
	// case  common.EqIncendiary, common.EqMolotov:
	// 	d.LastPlayersThrownMolotov = append(d.LastPlayersThrownMolotov, d.FindPlayerBySteamID(e.Shooter.SteamID64))
	// 	if !AnalyzePlayersPosition {
	// 		return
	// 	}
	// 	fallthrough
	// case common.EqDecoy, common.EqFlash, common.EqHE, common.EqSmoke:
	// 	positionPoint := Models.PositionPoint{
	// 		Position:             e.Shooter.Position,
	// 		PlayerSteamId: e.Shooter.SteamID64,
	// 		PlayerName:    e.Shooter.Name,
	// 		Team:          e.Shooter.Team,
	// 		Event:         shoot,
	// 		RoundNumber:   d.CurrentRound.Number,
	// 	}
	// 	d.PositionPoints = append(d.PositionPoints, positionPoint)
	// }
}

func (d *Demo) CalcEquipValue(side common.Team) int {
	var equipValue int
	for _, participant := range d.Parser.GameState().Participants().All() {
		if participant.Team == side {
			equipValue += participant.Money() + participant.MoneySpentThisRound()
		}
	}
	return equipValue
}

func (d *Demo) GetSideWithHigherEquipValue(equipValueCt int, equipValueT int) common.Team {
	if equipValueCt > equipValueT {
		return common.TeamTerrorists
	}
	return common.TeamCounterTerrorists
}

func (d *Demo) GetTeamBySide(team common.Team) *common.TeamState {
	if team == common.TeamCounterTerrorists {
		return d.Parser.GameState().TeamCounterTerrorists()
	}
	return d.Parser.GameState().TeamTerrorists()
}
