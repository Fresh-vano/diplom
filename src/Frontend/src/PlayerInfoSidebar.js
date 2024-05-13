import React from 'react';
import { Box, Typography, List, ListItem, ListItemText, Avatar } from '@mui/material';
import TypographyRow from './TypographyRow';

const PlayerInfoSidebar = () => {
    const playerInfo = {
        photo: "https://files.bo3.gg/uploads/player/17541/image/06b4affaf1548cc8f9540711541ac63a.png",
        name: "Simple",
        team: "Natus Vincere",
        country: "Ukraine",
        region: "Europe",
        age: 26,
        birthDate: "Окт 02, 1997",
        status: "Active"
    };
    
  return (
    <Box sx={{display:'flex', flexDirection:'column', height:'100%'}}>

    <Box sx={{display:'flex', flexDirection:'column', margin:'96px 0 0 0', height:'100%'}}>
        <Box sx={{ maxWidth:400, color:'#fff', backgroundColor: '#22262c', boxSizing: 'border-box', display: 'inline-block', verticalAlign: 'top', width: '100%', padding: '10px 16px', }}>
            <Avatar src={playerInfo.photo} sx={{ width: 290, height: 360, borderRadius:'5px', marginRight: 2 }} />
            <Typography sx={{lineHeight:'22px', fontSize:'1.125rem', fontWeight:500, marginTop:'10px'}}>{playerInfo.name}</Typography>
        </Box>
    </Box>
    <Box sx={{display:'flex', flexDirection:'column', margin:'20px 0', height:'100%'}}>

        <Box sx={{ maxWidth:400, color:'#fff', backgroundColor: '#22262c', boxSizing: 'border-box', display: 'inline-block', verticalAlign: 'top', width: '100%', padding: '10px 16px', }}>
            <TypographyRow label={"Команда"} value={playerInfo.team}/>
            <TypographyRow label={"Страна"} value={playerInfo.country}/>
            <TypographyRow label={"Регион"} value={playerInfo.region}/>
            <TypographyRow label={"Возраст"} value={playerInfo.age}/>
            <TypographyRow label={"Дата рождения"} value={playerInfo.birthDate}/>
            <TypographyRow label={"Статус"} value={playerInfo.status}/>
        </Box>
    </Box>
    </Box>


  );
};

export default PlayerInfoSidebar;
