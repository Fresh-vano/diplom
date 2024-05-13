import React from 'react';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography, Box, Paper, Avatar } from '@mui/material';

const mapStats = [
    { name: 'Vertigo', rating: 7.6, plays: 1, kpr: 1.00, dpr: 92, img:'https://bo3.gg/img/maps/backgrounds/vertigo.webp' },
    { name: 'Ancient', rating: 6.2, plays: 6, kpr: 0.70, dpr: 79, img:'https://bo3.gg/img/maps/backgrounds/ancient.webp' },
    { name: 'Nuke', rating: 6.1, plays: 2, kpr: 0.68, dpr: 83, img:'https://bo3.gg/img/maps/backgrounds/nuke.webp' },
    { name: 'Anubis', rating: 5.8, plays: 6, kpr: 0.61, dpr: 66, img:'https://bo3.gg/img/maps/backgrounds/anubis.webp' },
    { name: 'Inferno', rating: 5.2, plays: 3, kpr: 0.48, dpr: 64, img:'https://bo3.gg/img/maps/backgrounds/inferno.webp'}
];

const ProgressBar = ({ value, max, color }) => (
    <Box sx={{maxWidth:'112px' , width: '100%', backgroundColor: '#ddd' }}>
        <Box sx={{ width: `${(value / max) * 100}%`, height: 20, backgroundColor: color }} />
    </Box>
);

const MapStatsTable = () => {
    return (
        <>
            <Typography variant='h5' sx={{ fontSize: '1.125rem', fontWeight: 500, textTransform: 'uppercase', margin: '10px 0', color: '#ffffff' }}>
                Сыгранные КАРТЫ ЗА ПОСЛЕДНИЕ 6 МЕСЯЦЕВ
            </Typography>
            <TableContainer component={Paper} sx={{ backgroundColor: '#313840', borderRadius: '5px', marginBottom: '20px' }}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Карта</TableCell>
                            <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Средняя оценка</TableCell>
                            <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Количество</TableCell>
                            <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Убийства за раунд</TableCell>
                            <TableCell sx={{ color: '#a5afbb', fontWeight: 'bold', textTransform: 'uppercase' }}>Урон за раунд</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {mapStats.map((map, index) => (
                            <TableRow key={index} sx={{
                                '&:hover': {
                                    backgroundColor: 'rgba(77, 88, 100, 0.6)',
                                }
                            }}>
                                <TableCell sx={{ color: '#cbd5e4' }} component="th" scope="row">
                                    <Box sx={{ display: 'flex', flexDirection: 'row', alignItems: 'center' }}>
                                        <Avatar src={map.img} sx={{ width: 64, height: 34, marginRight: 1, borderRadius: '0px' }} alt={map.name} />
                                        <Typography variant="subtitle1">{map.name}</Typography>
                                    </Box>
                                </TableCell>
                                <TableCell sx={{ color: '#cbd5e4' }} align="left">
                                    <Box sx={{ display: 'flex', flexDirection: 'row', alignItems: 'center',justifyContent:'space-around' }}>
                                        <Typography variant="body2" sx={{fontWeight:700, fontSize:'1rem', color:'#fff'}}>{map.rating}</Typography>
                                        <ProgressBar value={map.rating} max={10} color="rgb(117, 200, 126)" />
                                    </Box>
                                </TableCell>
                                <TableCell sx={{ color: '#cbd5e4' }} align="left">{map.plays}</TableCell>
                                <TableCell sx={{ color: '#cbd5e4' }} align="left">
                                    <Box sx={{ display: 'flex', flexDirection: 'row', alignItems: 'center',justifyContent:'space-around' }}>
                                        <Typography variant="body2">{map.kpr}</Typography>
                                        <ProgressBar value={map.kpr} max={1} color="rgb(97, 210, 204)" />
                                    </Box>
                                </TableCell>
                                <TableCell sx={{ color: '#cbd5e4' }} align="left">
                                    <Box sx={{ display: 'flex', flexDirection: 'row', alignItems: 'center',justifyContent:'space-around' }}>
                                        <Typography variant="body2">{map.dpr}</Typography>
                                        <ProgressBar value={map.dpr} max={100} color="rgb(219, 157, 102)" />
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

export default MapStatsTable;
