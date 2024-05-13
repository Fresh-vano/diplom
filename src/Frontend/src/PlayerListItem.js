import React from 'react';
import { Typography, Avatar, Box } from '@mui/material';

const PlayerListItem = ({ player }) => {
  return (
    <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', padding: 2 }}>
      <Box sx={{ display: 'flex', alignItems: 'center', width: '30%'}}>
        <Avatar src={player.flag} sx={{ width: 40, height: 40, marginRight: 2 }} alt={`Flag of ${player.country}`} />
        <Typography>{player.name}</Typography>
      </Box>
      <Typography sx={{ width: '10%', textAlign: 'center' }}>{player.country}</Typography>
      <Typography sx={{ width: '15%', textAlign: 'center' }}>{player.hltvRating}</Typography>
      <Typography sx={{ width: '15%', textAlign: 'center' }}>{player.hltvRating2}</Typography>
      <Box sx={{ width: '30%', textAlign: 'center', display: 'flex', alignItems: 'center', justifyContent: 'flex-start' }}>
        <Avatar src={player.teamLogo} sx={{ width: 24, height: 24, marginRight: 1, marginLeft:3 }} alt={player.team} />
        <Typography>{player.team}</Typography>
      </Box>
    </Box>
  );
};

export default PlayerListItem;
