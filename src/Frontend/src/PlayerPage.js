import React from 'react';
import { useParams } from 'react-router-dom';
import MiddleContent from './MiddleContent';
import Block from './Block';
import PlayerInfoSidebar from './PlayerInfoSidebar';
import MapStatsTable from './MapStatsTable';
import MatchesList from './MatchesList';
import { Typography } from '@mui/material';

const PlayerPage = () => {
    const { player } = useParams();

    const matches = [
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
    
      ]
  return (
    <MiddleContent sx={{maxWidth: '1100px'}} matchInfo={<PlayerInfoSidebar/>}>
        <Block>
            <MapStatsTable />
        </Block>
        <Block>
            <Typography variant='h5' sx={{ fontSize: '1.125rem', fontWeight: 500, textTransform: 'uppercase', margin: '10px 0', color: '#ffffff' }}>
                Последние матчи
            </Typography>
            <MatchesList matches={matches} />
        </Block>
    </MiddleContent>
  );
};

export default PlayerPage;
