import React from 'react';
import { Card, CardContent, Typography, Avatar, Box, Stack } from '@mui/material';

const TeamTile = ({ team }) => {
    return (
        <Card sx={{
            display: 'flex',
            backgroundColor: '#313840',
            alignItems: 'center',
            padding: '8px',
            margin: '8px',
            borderRadius: '10px'
        }}>
            <Avatar 
                src={team.logoUrl}
                alt={team.name}
                sx={{ width: 56, height: 56, marginRight: 2 }}
            />
            <Typography variant="h6" color="white" sx={{ flexGrow: 1, margin: '0 10px' }}>
                {team.name}
            </Typography>
            <Stack direction="row" spacing={1}>
                {team.players.map(player => (
                    <Avatar 
                        key={player.id}
                        src={player.imageUrl}
                        alt={player.name}
                        sx={{ width: 40, height: 40, border: `2px solid ${player.countryColor}` }}
                    />
                ))}
            </Stack>
        </Card>
    );
};

export default TeamTile;
