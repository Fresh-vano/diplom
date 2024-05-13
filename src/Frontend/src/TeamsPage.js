import React, { useState, useEffect } from 'react';
import { Box, Tab, Tabs, Typography, Card, CardContent, Grid, Divider, Chip, Avatar, Stack, Link } from '@mui/material';
import MiddleContent from './MiddleContent';

const TeamsPage = () => {
    const teams = [
        {
          id: 1,
          name: "Natus Vincere",
          logo: "https://example.com/logos/navi.png",
          country: "UA",
          players: [
            { id: 101, name: "s1mple", image: "https://example.com/players/s1mple.png" },
            { id: 102, name: "electronic", image: "https://example.com/players/electronic.png" },
            { id: 103, name: "Boombl4", image: "https://example.com/players/boombl4.png" },
            { id: 104, name: "Perfecto", image: "https://example.com/players/perfecto.png" },
            { id: 105, name: "B1t", image: "https://example.com/players/b1t.png" }
          ]
        },
        {
          id: 2,
          name: "FaZe Clan",
          logo: "https://example.com/logos/faze.png",
          country: "US",
          players: [
            { id: 201, name: "broky", image: "https://example.com/players/broky.png" },
            { id: 202, name: "frozen", image: "https://example.com/players/frozen.png" },
            { id: 203, name: "karrigan", image: "https://example.com/players/karrigan.png" },
            { id: 204, name: "rain", image: "https://example.com/players/rain.png" },
            { id: 205, name: "ropz", image: "https://example.com/players/ropz.png" }
          ]
        }
      ];
      

    return (
    <MiddleContent title={"Список команд Counter-Strike 2"}>
      <Grid container sx={{  backgroundColor:'#313840', borderTopLeftRadius:'5px', borderTopRightRadius:'5px' }}>
        <Grid item xs={12}>
          <Box sx={{ display: 'flex', justifyContent: 'space-between', color:'#a5afbb', textAlign:'center'}}>
            <Typography variant="subtitle1" sx={{ width: '50%' }}>Команда</Typography>
            <Typography variant="subtitle1" sx={{ width: '10%' }}>Страна</Typography>
            <Typography variant="subtitle1" sx={{ width: '40%' }}>Игроки</Typography>
          </Box>
        </Grid>
      </Grid>
      <Grid container sx={{display:'flex', flexDirection:'column'}}>
      {teams.map((team, index) => (
        <Card key={index} variant="outlined" component={Link} href="/teams/123" sx={{
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
          <TeamListItem team={team}/>
          </Card>
      ))}
        </Grid>
    </MiddleContent>
)};

const TeamListItem = ({ team }) => {
    return (
        <CardContent sx={{ display: 'flex', justifyContent: 'space-between', alignItems:'center' }}>

        <Box sx={{ display: 'flex', alignItems: 'center', width: '50%' }}>
          <Avatar src={team.logo} sx={{ width: 56, height: 56, m: 1 }} />
          <Typography sx={{ color: 'white' }}>{team.name}</Typography>
        </Box>
        <Typography sx={{ width: '10%', color: 'white', textAlign: 'center' }}>{team.country}</Typography>
        <Stack direction="row" sx={{ width: '40%', overflowX: 'auto', justifyContent:'right' }}>
          {team.players.map(player => (
            <Avatar key={player.id} src={player.image} sx={{ width: 40, height: 40, m: 1 }} title={player.name} />
          ))}
        </Stack>
      </CardContent>
    );
  };  

export default TeamsPage;