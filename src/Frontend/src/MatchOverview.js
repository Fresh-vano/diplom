import React from 'react';
import { Box, Typography, Avatar, Paper, Table, TableBody, TableCell, TableContainer, TableRow, Grid, Card, CardContent, CardHeader, Chip } from '@mui/material';
import KeyboardArrowLeftIcon from '@mui/icons-material/KeyboardArrowLeft';
import './MatchOverview.css';
import AssessmentIcon from '@mui/icons-material/Assessment';

const MatchOverview = ({ matchDetails }) => {
  return (
    <Box>
        <Box sx={{display:'flex', flexDirection:'row', alignItems:'center', margin:'10px 0'}}>
            <Avatar src={matchDetails.tournament_logo} sx={{ width: 18, height: 18, marginRight: 1 }} />
            <Typography variant="p" color="#a5afbb">{`${matchDetails.tournament}`}</Typography>
            <KeyboardArrowLeftIcon sx={{color:"#a5afbb", transform:'scale(-1, -1)'}}/>
            <Typography variant="p" color="#a5afbb">{`${matchDetails.stage}`}</Typography>
        </Box>


        <Grid container sx={{display:'flex', flexDirection:'column'}}>
        <Card sx={{
          backgroundColor: '#313840', 
          color: 'white', 
          borderRadius: '5px',
        }}>
          <CardContent sx={{ display: 'flex', justifyContent: 'space-between', alignItems:'center' }}>
            <Box sx={{textAlign: 'left' }}>
              <Typography variant="body1">{matchDetails.dateTime}</Typography>
            </Box>
            <Box sx={{ textAlign: 'center', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
              <Typography variant="h6" sx={{textAlign:'right'}}>{matchDetails.team1}</Typography>
              <Avatar src={matchDetails.tournament_logo} sx={{ width: 36, height: 36, marginLeft: 2 }} />
              <Box sx={{width:'112px', height:'34px'}}>
                <Box className="score-trapezoid" sx={{width:'68px', height:'34px'}}>
                    <Typography variant="p" sx={{ display:'inline-block', position:'relative', fontSize:'1.35rem', lineHeight:'34px', fontWeight: '500', color: matchDetails.team1Score > matchDetails.team2Score ? '#fff' : '#a5afbb' }}>{matchDetails.team1Score}</Typography>
                    <Typography variant="p" sx={{ display:'inline-block', position:'relative',color: '#a5afbb', lineHeight:'34px', fontSize:'1.5rem', margin:'0 2px'}}>-</Typography>
                    <Typography variant="p" sx={{ display:'inline-block', position:'relative',fontSize:'1.35rem', lineHeight:'34px',fontWeight: '500', color: matchDetails.team2Score > matchDetails.team1Score ? '#fff' : '#a5afbb' }}>{matchDetails.team2Score}</Typography>
                </Box>
              </Box>
              <Avatar src={matchDetails.tournament_logo} sx={{ width: 36, height: 36, marginRight: 2 }} />
              <Typography variant="h6"  sx={{textAlign:'left'}}>
              {matchDetails.team2}
                </Typography>
            </Box>
            <Box sx={{textAlign: 'left', display:'flex', flexDirection:'row' }}>
                <AssessmentIcon sx={{marginRight:1 }}/>
                <Typography variant="body1" >{matchDetails.parseStatus}</Typography>
            </Box>
          </CardContent>
        </Card>
    </Grid>
    </Box>
  );
};

export default MatchOverview;
