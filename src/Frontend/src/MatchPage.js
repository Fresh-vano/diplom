import React from 'react';
import { Box } from '@mui/material';
import MatchOverview from './MatchOverview';
import MatchInfoSidebar from './MatchInfoSidebar';
import { useParams } from 'react-router-dom';
import MiddleContent from './MiddleContent';
import Block from './Block';
import PlayerStats from './PlayerStats';

const teamStats = {
    teamName: "Limitless",
    teamLogo: "https://example.com/path_to_team_logo.jpg",
    players: [
        {
            name: "DooM",
            avatar: "https://example.com/path_to_avatar_doom.jpg",
            kills: 19,
            deaths: 20,
            assists: 5,
            plusMinus: -1,
            score: 92,
            rounds: "2:7",
            rating: 6.2,
            pd: "10",
            mk: "3",
            vsX: "1",
            roundScore: "12/18",
            form: 3
          },
      {
        name: "DooM",
        avatar: "https://example.com/path_to_avatar_doom.jpg",
        kills: 19,
        deaths: 20,
        assists: 5,
        plusMinus: -1,
        score: 92,
        rounds: "2:7",
        rating: 6.2,
        pd: "10",
        mk: "3",
        vsX: "1",
        roundScore: "12/18",
        form: 12
      },
      {
        name: "Mellow",
        avatar: "https://example.com/path_to_avatar_mellow.jpg",
        kills: 25,
        deaths: 15,
        assists: 10,
        plusMinus: 10,
        score: 110,
        rounds: "5:2",
        rating: 8.5,
        pd: "20",
        mk: "5",
        vsX: "2",
        roundScore: "15/10",
        form:-13
      },
      {
        name: "Blaze",
        avatar: "https://example.com/path_to_avatar_blaze.jpg",
        kills: 17,
        deaths: 18,
        assists: 7,
        plusMinus: -1,
        score: 88,
        rounds: "3:7",
        rating: 7.1,
        pd: "15",
        mk: "4",
        vsX: "1",
        roundScore: "10/12",
        form: 3
      },
      {
        name: "Spark",
        avatar: "https://example.com/path_to_avatar_spark.jpg",
        kills: 22,
        deaths: 12,
        assists: 9,
        plusMinus: 10,
        score: 105,
        rounds: "7:3",
        rating: 2.0,
        pd: "18",
        mk: "6",
        vsX: "3",
        roundScore: "17/8",
        form: -2
      }
    ]
  };
  
  

const MatchPage = ({ matchDetails, matchInfo }) => {
    const { matchId } = useParams();
    console.log(matchId);
  return (
    <MiddleContent sx={{maxWidth: '1100px'}} matchInfo={<MatchInfoSidebar matchInfo={matchInfo} />}>
        <Block>
            <MatchOverview matchDetails={matchDetails} />
        </Block>
        <Block>
            <PlayerStats teamName={teamStats.teamName} players={teamStats.players}/>
            <PlayerStats teamName={teamStats.teamName} players={teamStats.players}/>
        </Block>
    </MiddleContent>
  );
};

export default MatchPage;
