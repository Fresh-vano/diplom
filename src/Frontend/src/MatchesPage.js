import React, { useState, useEffect } from 'react';
import MiddleContent from './MiddleTabsContent';
import MatchesList from './MatchesList';

const MatchesPage = ({tab}) => {
    const [tabValue, setTabValue] = useState('upcoming');
  
    useEffect(() => {
      setTabValue(tab || 'upcoming');
    }, [tab]);
  
    const handleChange = (event, newValue) => {
      setTabValue(newValue);
    };

  const matchesExample = [
        { time: "Завершен", teams: ["Elevate", "Party Astronauts"], score: "1 - 0", tournament: "ESL Challenger League" },
        { time: "Завершен", teams: ["Party Astronauts", "Elevate"], score: "1 - 0", tournament: "ESL Challenger League" },
        { time: "Завершен", teams: ["Imperial", "ODDIK"], score: "2 - 0", tournament: "RES Regional Series" }
  ];

  return (
    <MiddleContent 
    title="Результаты матчей Counter-Strike 2" 
    tabValue={tabValue} 
    handleChange={handleChange}
  >
    <MatchesList matches={matchesExample}/>
  </MiddleContent>
);
};

export default MatchesPage;
