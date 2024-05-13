import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Header from './Header';
import Layout from './Layout';
import MatchesPage from './MatchesPage';
import MatchPage from './MatchPage';
import PlayerPage from './PlayerPage';
import PlayersPage from './PlayersPage';
import TeamPage from './TeamPage';
import TeamsPage from './TeamsPage';
import TournamentPage from './TournamentPage';
import TournamentsPage from './TournamentsPage';

const tournamentData = {
  name: "CCT Season 2 European Series 1",
  dates: "April 21 - May 4, 2024",
  prizePool: "$50,000",
  type: "Online",
  tier: "B-Tier",
  country: "International",
  region: "Europe",
  series: "CCT",
  teams: [
    {
      name: "Sangal",
      logoUrl: "https://files.bo3.gg/uploads/team/36/image/400x400-bc8a5b82c58e600b24bb566961ed43e8.png",
      players: [
          {
              id: 1,
              name: "Player 1",
              imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",

              countryColor: '#f00' // Example color code for Turkey
          },
          {
              id: 2,
              name: "Player 1",
              imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
              countryColor: '#f00' // Example color code for Turkey
          },
          {
              id: 3,
              name: "Player 1",
              imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
              countryColor: '#f00' // Example color code for Turkey
          },
          {
              id: 4,
              name: "Player 1",
              imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
              countryColor: '#f00' // Example color code for Turkey
          },
          {
              id: 5,
              name: "Player 1",
              imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
              countryColor: '#f00' // Example color code for Turkey
          },
          // Additional players...
      ]
  },
  {
    name: "Sangal",
    logoUrl: "https://files.bo3.gg/uploads/team/36/image/400x400-bc8a5b82c58e600b24bb566961ed43e8.png",
    players: [
        {
            id: 1,
            name: "Player 1",
            imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",

            countryColor: '#f00' // Example color code for Turkey
        },
        {
            id: 2,
            name: "Player 1",
            imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
            countryColor: '#f00' // Example color code for Turkey
        },
        {
            id: 3,
            name: "Player 1",
            imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
            countryColor: '#f00' // Example color code for Turkey
        },
        {
            id: 4,
            name: "Player 1",
            imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
            countryColor: '#f00' // Example color code for Turkey
        },
        {
            id: 5,
            name: "Player 1",
            imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
            countryColor: '#f00' // Example color code for Turkey
        },
        // Additional players...
    ]
},
{
  name: "Sangal",
  logoUrl: "https://files.bo3.gg/uploads/team/36/image/400x400-bc8a5b82c58e600b24bb566961ed43e8.png",
  players: [
      {
          id: 1,
          name: "Player 1",
          imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",

          countryColor: '#f00' // Example color code for Turkey
      },
      {
          id: 2,
          name: "Player 1",
          imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
          countryColor: '#f00' // Example color code for Turkey
      },
      {
          id: 3,
          name: "Player 1",
          imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
          countryColor: '#f00' // Example color code for Turkey
      },
      {
          id: 4,
          name: "Player 1",
          imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
          countryColor: '#f00' // Example color code for Turkey
      },
      {
          id: 5,
          name: "Player 1",
          imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
          countryColor: '#f00' // Example color code for Turkey
      },
      // Additional players...
  ]
}
  ],
  matches: [
    { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
    { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
    { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
    { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
    { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
    { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },

  ]
};

const matchDetails = {
    tournament:'CCT Season 2 European Series 1',
    stage:'European Series 1',
    team1: 'Intense',
    team1Score: 13,
    team2: 'RED Canids',
    team2Score: 17,
    dateTime: 'May 09, 23:00',
    parseStatus:'Прогноз',
    players: [
      { name: 'Player 1', avatar: 'path_to_avatar.png', kills: 10, deaths: 5, rating: 1.2 },
      // more players...
    ]
  };

  const matchInfo = {
    dateTime: 'May 09, 23:00',
    format: 'Bo3',
    tournament: 'RES Regional Series 4 LATAM',
    stage: 'Group C / Decider Match',
    type: 'Online',
    region: 'South America'
  };


export default function App() {
  return (
      <Layout>
        <Header />
        <Routes>
          <Route path="/tournaments">
            <Route path="finished" element={<TournamentsPage tab={"finished"}/>} />
            <Route path="current" element={<TournamentsPage tab={"current"}/>} />
            <Route path=":tournamentId" element={<TournamentPage tournamentData={tournamentData}/>} />
          </Route>
          <Route path="/matches">
            <Route path="finished" element={<MatchesPage tab={"finished"}/>} />
            <Route path="current" element={<MatchesPage tab={"current"}/>} />
            <Route path=":matchId" element={<MatchPage matchDetails={matchDetails} matchInfo={matchInfo} />} />
          </Route>
          <Route path="/teams" element={<TeamsPage/>} />
          <Route path="/teams/:team" element={<TeamPage/>} />
          <Route path="/players" element={<PlayersPage/>} />
          <Route path="/players/:player" element={<PlayerPage/>} />
          <Route path="/" element={<></>} />
        </Routes>
      </Layout>
  );
}