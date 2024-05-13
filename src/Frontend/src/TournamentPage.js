import React, { useState } from 'react';
import { Box, Typography, Tab, Tabs, Paper } from '@mui/material';
import MiddleContent from './MiddleContent';
import TournamentOverview from './TournamentOverview';
import MatchesList from './MatchesList';
import TeamsList from './TeamsList';
import Block from './Block';

const TournamentPage = ({ tournamentData }) => {
    const [value, setValue] = useState(0);

    const handleChange = (event, newValue) => {
      setValue(newValue);
    };
  return (
    <MiddleContent title={tournamentData.name} subtitle={tournamentData.dates} avatar={<></>} matchInfo={<TournamentOverview data={tournamentData} />}>
        <Block title={'КОМАНДЫ-УЧАСТНИКИ'}>
            <TeamsList teams={tournamentData.teams} />
        </Block>
        <Block title={'РЕЗУЛЬТАТЫ'}>
            <MatchesList matches={tournamentData.matches} />
        </Block>
        
        

        
    </MiddleContent>
  );
};

function TabPanel(props) {
    const { children, value, index, ...other } = props;
  
    return (
      <div
        role="tabpanel"
        hidden={value !== index}
        id={`tabpanel-${index}`}
        aria-labelledby={`tab-${index}`}
        {...other}
      >
        {value === index && (
          <Box sx={{ p: 3 }}>
            {children}
          </Box>
        )}
      </div>
    );
  }

export default TournamentPage;