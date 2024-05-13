import React from 'react';
import { Box, Card, Grid, Link, Typography } from '@mui/material';
import PlayerListItem from './PlayerListItem'; // Make sure to import PlayerListItem
import MiddleContent from './MiddleContent';

const PlayersPage = () => {
    const players = [
        {
          id: 1,
          name: "s1mple",
          flag: "https://example.com/flags/ua.png",
          country: "Ukraine",
          hltvRating: "1.32",
          hltvRating2: "1.30",
          team: "Natus Vincere"
        },
        {
          id: 2,
          name: "device",
          flag: "https://example.com/flags/dk.png",
          country: "Denmark",
          hltvRating: "1.25",
          hltvRating2: "1.22",
          team: "Astralis"
        },
        {
          id: 3,
          name: "NiKo",
          flag: "https://example.com/flags/ba.png",
          country: "Bosnia and Herzegovina",
          hltvRating: "1.18",
          hltvRating2: "1.15",
          team: "G2 Esports"
        }
      ];

      
  return (
    <MiddleContent title={"Список команд Counter-Strike 2"}>
      <Grid container sx={{  backgroundColor:'#313840', borderTopLeftRadius:'5px', borderTopRightRadius:'5px' }}>
        <Grid item xs={12}>
          <Box sx={{ display: 'flex', justifyContent: 'space-between', color:'#a5afbb', textAlign:'center'}}>
            <Typography variant="subtitle1" sx={{ width: '30%' }}>Игрок</Typography>
            <Typography variant="subtitle1" sx={{ width: '10%' }}>Страна</Typography>
            <Typography variant="subtitle1" sx={{ width: '15%' }}>HLTV</Typography>
            <Typography variant="subtitle1" sx={{ width: '15%' }}>HLTV 2.0</Typography>
            <Typography variant="subtitle1" sx={{ width: '30%' }}>Команда</Typography>
          </Box>
        </Grid>
      </Grid>
      <Grid container sx={{display:'flex', flexDirection:'column'}}>
      {players.map((player, index) => (
                <Card key={index} variant="outlined" component={Link} href="/players/123" sx={{
                  textDecoration: 'none', color: 'inherit',
                  backgroundColor: '#313840', 
                  color: 'white', 
                  borderRadius: '0',
                  '&:hover': {
                    backgroundColor: 'rgba(77, 88, 100, 0.6)',
                    cursor: 'pointer',
                  },
                  '&:last-child': {
                    padding:0
                  }
                }}>
                  <PlayerListItem key={player.id} player={player} />
                </Card>
              ))}  
        </Grid>
    </MiddleContent>
  );
};

export default PlayersPage;
