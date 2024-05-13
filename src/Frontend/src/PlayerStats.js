import React from 'react';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Avatar, Typography, Box } from '@mui/material';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import KeyboardDoubleArrowUpIcon from '@mui/icons-material/KeyboardDoubleArrowUp';
import KeyboardDoubleArrowDownIcon from '@mui/icons-material/KeyboardDoubleArrowDown';

const PlayerStats = ({ teamName, teamLogo, players }) => {
  const headerStyle = { width: '8%', color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' };

  const getRatingStyle = (rating) => {
    return {
      borderRadius:'10px',
      fontWeight:700,
      padding: '5px',
      background: rating >= 7 ? '#75c87e' : rating >= 5 ? '#db9d66' : '#f18686',
      color:'#22262c'
    };
  };
  
  const getFormIcon = (change) => {
    if (change > 5) {
      return <KeyboardDoubleArrowUpIcon sx={{ color: '#75c87e', marginLeft:'2px'  }}/>; 
    } else if (change < 5) {
      return <KeyboardDoubleArrowDownIcon sx={{ color: '#f18686', marginLeft:'2px' }}/>; 
    } else if (change > 0) {
      return <KeyboardArrowUpIcon sx={{ color: '#75c87e', marginLeft:'2px'  }}/>;
    } else if (change <= 0) {
      return <KeyboardArrowDownIcon sx={{ color: '#f18686', marginLeft:'2px' }}/>;
    }
  };
  

  return (
    <>
      <Typography sx={{ fontSize: '0.75rem', fontWeight: 500, lineHeight: '12px', textTransform: 'uppercase', margin: '10px 0', color: '#ffffff' }}>
        Результаты {teamName}
      </Typography>
      <TableContainer component={Paper} sx={{ backgroundColor: '#313840', borderRadius: '5px', marginBottom: '20px' }}>
        <Table sx={{ minWidth: 650 }}>
          <TableHead>
            <TableRow>
              <TableCell sx={{ width: '20%', color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Игрок</TableCell>
              <TableCell align="center" sx={headerStyle}>У</TableCell>
              <TableCell align="center" sx={headerStyle}>С</TableCell>
              <TableCell align="center" sx={headerStyle}>П</TableCell>
              <TableCell align="center" sx={headerStyle}>+/-</TableCell>
              <TableCell align="center" sx={headerStyle}>СУ</TableCell>
              <TableCell align="center" sx={headerStyle}>ПД</TableCell>
              <TableCell align="center" sx={headerStyle}>МК</TableCell>
              <TableCell align="center" sx={headerStyle}>1vsX</TableCell>
              <TableCell align="center" sx={headerStyle}>Рейтинг</TableCell>
              <TableCell align="center" sx={headerStyle}>Форма</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {players.map((player) => (
              <TableRow key={player.name} hover sx={{ '&:hover': { backgroundColor: 'rgba(77, 88, 100, 0.6)' }}}>
                <TableCell component="th" scope="row">
                  <Box sx={{ display: 'flex', alignItems: 'center', color: '#a5afbb' }}>
                    <Avatar src={player.avatar} sx={{ width: 24, height: 24, marginRight: 2 }} alt={player.name} />
                    {player.name}
                  </Box>
                </TableCell>
                <TableCell sx={{color: '#a5afbb'}} align="center">{player.kills}</TableCell>
                <TableCell sx={{color: '#a5afbb'}} align="center">{player.deaths}</TableCell>
                <TableCell sx={{color: '#a5afbb'}} align="center">{player.assists}</TableCell>
                <TableCell sx={{ color: player.kills - player.deaths > 0 ? '#75c87e' :'#f18686' }} align="center">{player.kills - player.deaths}</TableCell>
                <TableCell sx={{color: '#a5afbb'}} align="center">{player.su}</TableCell>
                <TableCell sx={{color: '#a5afbb'}} align="center">{player.pd}</TableCell>
                <TableCell sx={{color: '#a5afbb'}} align="center">{player.mk}</TableCell>
                <TableCell sx={{color: '#a5afbb'}} align="center">{player.vsX}</TableCell>
                <TableCell align="center">
                  <Box sx={getRatingStyle(player.rating)}>
                    {player.rating}
                  </Box>
                </TableCell>
                <TableCell align="center" sx={{ color: '#cbd5e4', fontWeight:500, lineHeight:'20px' }}>
                  <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
                    {player.form}
                    {getFormIcon(player.form)}
                  </Box>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </>
  );
};

export default PlayerStats;
