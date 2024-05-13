import React from 'react';
import { Box, Tab, Tabs, Typography, Card, Grid, Chip, Avatar, Link } from '@mui/material';
import SportsEsportsIcon from '@mui/icons-material/SportsEsports';

const getTierStyle = (tier) => {
    switch (tier) {
      case 'S':
        return {
          backgroundColor: 'rgba(235,87,87,.1)',
          color: '#eb5757',
        };
      case 'A':
        return {
          backgroundColor: 'rgba(224,170,90,.1)',
          color: '#e0aa5a',
        };
      case 'B':
        return {
          backgroundColor: 'hsla(28,62%,63%,.1)',
          color: '#db9d66',
        };
      case 'C':
        return {
          backgroundColor: 'rgba(165,175,187,.1)',
          color: '#a5afbb',
        };
      default:
        return {}; 
    }
  };

const TournamentsList = ({ tournaments }) => {
    return (
    <>
      <Grid container sx={{  backgroundColor:'#313840', borderTopLeftRadius:'5px', borderTopRightRadius:'5px' }}>
        <Grid item xs={12}>
          <Box sx={{ display: 'flex', justifyContent: 'space-between', color:'#a5afbb', textAlign:'center'}}>
            <Typography variant="subtitle1" sx={{ width: '40%' }}>Турнир/Приз/Статус</Typography>
            <Typography variant="subtitle1" sx={{ width: '30%' }}>Тип</Typography>
            <Typography variant="subtitle1" sx={{ width: '30%' }}>Участники</Typography>
          </Box>
        </Grid>
      </Grid>
      <Grid container sx={{display:'flex', flexDirection:'column'}}>
      {tournaments.map((tournament, index) => (
        <Grid item key={index}>
          <Card variant="outlined" component={Link} href="/tournaments/123" sx={{ textDecoration: 'none', color: 'inherit', display: 'flex', alignItems: 'center', justifyContent:'space-between', backgroundColor:'#313840', color:'#fff', margin: 0, padding:2,
            '&:hover': {
              backgroundColor: 'rgba(77, 88, 100, 0.6)', // Фон при наведении
              cursor:'pointer',
            },
            }}>
            <Box sx={{display:'flex', flexDirection:'row', alignItems:'center'}}>
              <Avatar src={tournament.logo} sx={{ width: 56, height: 56, marginRight: 2 }} />
              <Box>
                <Typography variant="h6" sx={{ fontWeight: 'bold' }}>{tournament.name}</Typography>
                <Typography variant="body2">{tournament.prize}</Typography>
                <Typography variant="caption">{tournament.date}</Typography>
              </Box>
            </Box>
              <Chip 
                label={tournament.tier + '-Tier'} 
                size="small" 
                sx={{ margin: '4px 0',  ...getTierStyle(tournament.tier) }} 
              />
              <Typography variant="body2" sx={{ display: 'flex', alignItems: 'center', flexWrap:'wrap', maxWidth:'220px', overflow:'hidden', maxHeight:'48px' }}>
                <SportsEsportsIcon sx={{ fontSize: 24, marginRight: 1 }} />
                {tournament.teams.map((team, i) => (
                  <Avatar key={i} src={team.logo} sx={{ width: 24, height: 24, marginRight: 0.5 }} />
                ))}
              </Typography>
          </Card>
        </Grid>
      ))}
    </Grid>
    </>
)};

export default TournamentsList;