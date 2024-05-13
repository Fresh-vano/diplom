import React, { useState, useEffect } from 'react';
import { Box, Tab, Tabs, Typography, Card, CardContent, Grid, Divider, Chip, Avatar, Link } from '@mui/material';

const MatchesList = ({ matches }) => {
    return (
    <>
      <Grid container sx={{  backgroundColor:'#313840', borderTopLeftRadius:'5px', borderTopRightRadius:'5px' }}>
        <Grid item xs={12}>
          <Box sx={{ display: 'flex', justifyContent: 'space-between', color:'#a5afbb', textAlign:'center'}}>
            <Typography variant="subtitle1" sx={{ width: '20%' }}>Дата</Typography>
            <Typography variant="subtitle1" sx={{ width: '55%' }}>Матч</Typography>
            <Typography variant="subtitle1" sx={{ width: '25%' }}>Турнир</Typography>
          </Box>
        </Grid>
      </Grid>
      <Grid container sx={{display:'flex', flexDirection:'column'}}>
      {matches.map((item, index) => (
        <Card key={index} variant="outlined" component={Link} href="/matches/123" sx={{
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
          <CardContent sx={{ display: 'flex', justifyContent: 'space-between', alignItems:'center' }}>
            <Box sx={{ width: '20%', textAlign: 'left' }}>
              <Typography variant="body1">{item.time}</Typography>
            </Box>
            <Box sx={{ width: '55%', textAlign: 'center', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
              <Typography variant="body1" sx={{width:'40%', textAlign:'right'}}>
                {item.teams[0]}
              </Typography>
                <Chip label={item.score} size="small" sx={{ margin: '0 8px', color: 'white', backgroundColor: '#434a54' }} />
              <Typography variant="body1"  sx={{width:'40%', textAlign:'left'}}>
              {item.teams[1]}
                </Typography>
            </Box>
            <Box sx={{ width: '25%', textAlign: 'left', display:'flex', alignItems:'center', justifyContent:'flex-start' }}>
              <Avatar src={item.tournament_logo} sx={{ width: 36, height: 36, marginRight: 2 }} />
              <Typography variant="body2">{item.tournament}</Typography>
            </Box>
          </CardContent>
        </Card>
      ))}
    </Grid>
    </>
)};

export default MatchesList;