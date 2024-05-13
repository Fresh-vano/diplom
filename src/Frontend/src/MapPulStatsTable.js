import React from 'react';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography, Box, Paper, Avatar } from '@mui/material';

const ProgressBar = ({ value, max, color }) => (
  <Box sx={{maxWidth:'130px', width: '100%', height: 20, backgroundColor: '#ddd' }}>
    <Box sx={{ width: `${(value / max) * 100}%`, height: '100%', backgroundColor: color }} />
  </Box>
);

const MapPulStatsTable = () => {
  const mapStats = [
    { name: 'Mirage', winPercent: 79, recentMaps: ['W', 'W', 'W', 'W', 'L'], plays: 14, kpr: 1.00, dpr: 92, img:'https://bo3.gg/img/maps/backgrounds/mirage.webp' },
    { name: 'Nuke', winPercent: 68, recentMaps: ['L', 'W', 'L', 'W', 'L'], plays: 31, kpr: 0.70, dpr: 79, img:'https://bo3.gg/img/maps/backgrounds/nuke.webp' },
    { name: 'Inferno', winPercent: 64, recentMaps: ['L', 'L', 'W', 'W', 'L'], plays: 11, kpr: 0.68, dpr: 83, img:'https://bo3.gg/img/maps/backgrounds/inferno.webp' },
    { name: 'Ancient', winPercent: 59, recentMaps: ['L', 'W', 'L', 'L', 'L'], plays: 17, kpr: 0.61, dpr: 66, img:'https://bo3.gg/img/maps/backgrounds/ancient.webp' },
    { name: 'Vertigo', winPercent: 57, recentMaps: ['W', 'W', 'W', 'L', 'L'], plays: 7, kpr: 0.48, dpr: 64, img:'https://bo3.gg/img/maps/backgrounds/vertigo.webp' },
    { name: 'Overpass', winPercent: 55, recentMaps: ['W', 'W', 'W', 'W', 'L'], plays: 11, kpr: 0.62, dpr: 39, img:'https://bo3.gg/img/maps/backgrounds/overpass.webp' },
    { name: 'Anubis', winPercent: 50, recentMaps: ['L', 'L', 'W', 'W', 'L'], plays: 10, kpr: 0.43, dpr: 57, img:'https://bo3.gg/img/maps/backgrounds/anubis.webp' }
  ];

  const getColor = (rating) => rating > 65 ? '#76c7c0' : rating > 50 ? '#db9d66' : '#f18686';

  return (
    <>
      <Typography variant="h6" sx={{ fontSize: '1.125rem', fontWeight: 500, textTransform: 'uppercase', margin: '10px 0', color: '#ffffff' }}>
        Карты за последние 6 месяцев
      </Typography>
      <TableContainer component={Paper} sx={{ backgroundColor: '#313840', borderRadius: '5px', marginBottom: '20px' }}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Карта</TableCell>
              <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Процент побед</TableCell>
              <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Kоличество</TableCell>
              <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Последние 5 карт</TableCell>
              <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Убийств за раунд</TableCell>
              <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Урон за раунд</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {mapStats.map((map, index) => (
              <TableRow key={index} sx={{
                '&:hover': {
                  backgroundColor: 'rgba(77, 88, 100, 0.6)',
                  cursor: 'pointer',
                }
              }}>
                <TableCell component="th" scope="row">
                    <Box sx={{ display: 'flex', flexDirection: 'row', alignItems: 'center' }}>
                        <Avatar src={map.img} sx={{ width: 64, height: 34, marginRight: 1, borderRadius: '0px' }} alt={map.name} />
                        <Typography variant="subtitle1" sx={{ color: '#a5afbb' }}>{map.name}</Typography>
                    </Box>
                </TableCell>
                <TableCell>
                <Box sx={{ display: 'flex', flexDirection: 'row', alignItems: 'center',justifyContent:'space-around' }}>
                  <Typography sx={{fontWeight:700, fontSize:'1rem', color:'#fff'}}>{map.winPercent}%</Typography>
                  <ProgressBar value={map.winPercent} max={100} color={getColor(map.winPercent)} />
                </Box>
                </TableCell>
                <TableCell sx={{ color: '#a5afbb' }}>
                  {map.plays}
                </TableCell>
                <TableCell>
                  {map.recentMaps.map((icon, i) => (
                    <Box key={i} component="span" sx={{display: 'inline-block', borderRadius:'50%', width: 20, height: 20, backgroundColor: icon === 'W' ? '#75c87e' : '#f18686', margin: '0 2px', lineHeight:'20px', textAlign:'center', fontWeight:700}}>{icon}</Box>
                  ))}
                </TableCell>
                <TableCell>
                    <Box sx={{ display: 'flex', flexDirection: 'row', alignItems: 'center',justifyContent:'space-around' }}>
                        <Typography sx={{ color: '#a5afbb' }}>{map.kpr}</Typography>
                    <ProgressBar value={map.kpr} max={1.5} color="#70a1ff" />
                    </Box>
                </TableCell>
                <TableCell>
                    <Box sx={{ display: 'flex', flexDirection: 'row', alignItems: 'center',justifyContent:'space-around' }}>
                        <Typography sx={{ color: '#a5afbb' }}>{map.dpr}</Typography>
                        <ProgressBar value={map.dpr} max={100} color="#ffbe76" />
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

export default MapPulStatsTable;
