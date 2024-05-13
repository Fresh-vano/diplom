import React from 'react';
import { useParams } from 'react-router-dom';
import MiddleContent from './MiddleContent';
import Block from './Block';
import MatchesList from './MatchesList';
import { Typography } from '@mui/material';
import MapPulStatsTable from './MapPulStatsTable';

const TeamPage = () => {
    const { team } = useParams();
    const matches = [
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
        { time: "12:00", teams: ["Team1", "Team2"], score: "0 - 2", tournament: "Day 1" },
    
      ]
  return (
    <MiddleContent sx={{maxWidth: '1400px'}} title={"FaZe"} avatarSize={76} avatar={"https://files.bo3.gg/uploads/team/791/image/150x150-b6d8b2032e9c8176cbf12a1fa966404d.webp"}>
        <Block>
            <MapPulStatsTable />
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

export default TeamPage;
