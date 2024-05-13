import React, { useState, useEffect } from 'react';
import { Box, Tab, Tabs, Typography, Card, CardContent, Grid, Divider, Chip, Avatar } from '@mui/material';
import SportsEsportsIcon from '@mui/icons-material/SportsEsports';
import { useParams } from 'react-router-dom';
import MiddleContent from './MiddleTabsContent';
import TournamentsList from './TournamentsList';


const TournamentsPage = ({tab}) => {
  const [tabValue, setTabValue] = useState('upcoming');

  useEffect(() => {
    setTabValue(tab || 'upcoming');
  }, [tab]);

  const handleChange = (event, newValue) => {
    setTabValue(newValue);
  };

  const tournamentsExample = [
    { 
      logo: "/path-to-logo/iem.png", // Укажите правильный путь к логотипу
      name: "IEM Dallas 2024", 
      prize: "$250,000", 
      date: "20d",
      tier: "S",
      teams: [
        { logo: "/path-to-logo/team1.png" },
        { logo: "/path-to-logo/team2.png" },
        { logo: "/path-to-logo/team3.png" }
      ]
    },
    { 
      logo: "/path-to-logo/iem.png", // Укажите правильный путь к логотипу
      name: "IEM Dallas 2024", 
      prize: "$250,000", 
      date: "20d",
      tier: "C",
      teams: [
        { logo: "/path-to-logo/team1.png" },
        { logo: "/path-to-logo/team2.png" },
        { logo: "/path-to-logo/team3.png" }
      ]
    },
    { 
      logo: "/path-to-logo/iem.png", // Укажите правильный путь к логотипу
      name: "IEM Dallas 2024", 
      prize: "$250,000", 
      date: "20d",
      tier: "B",
      teams: [
        { logo: "/path-to-logo/team1.png" },
        { logo: "/path-to-logo/team2.png" },
        { logo: "/path-to-logo/team3.png" }
      ]
    },
    { 
      logo: "/path-to-logo/iem.png", // Укажите правильный путь к логотипу
      name: "IEM Dallas 2024", 
      prize: "$250,000", 
      date: "20d",
      tier: "A",
      teams: [
        { logo: "/path-to-logo/team1.png" },
        { logo: "/path-to-logo/team2.png" },
        { logo: "/path-to-logo/team3.png" }
      ]
    },
    // Добавьте больше турниров
  ];

  return (
    <MiddleContent 
      title="Турниры Counter-Strike 2" 
      tabValue={tabValue} 
      handleChange={handleChange}
    >
      <TournamentsList tournaments={tournamentsExample} />
    </MiddleContent>
  );
};

export default TournamentsPage;