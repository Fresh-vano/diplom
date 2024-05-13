import React from 'react';
import { Box, Typography, List, ListItem, ListItemText } from '@mui/material';
import TypographyRow from './TypographyRow';

const MatchInfoSidebar = ({ matchInfo }) => {
  return (
    <Box sx={{display:'flex', flexDirection:'column', margin:'96px 0', height:'100%'}}>
      <Box sx={{ maxWidth:400, color:'#fff', backgroundColor: '#22262c', boxSizing: 'border-box', display: 'inline-block', verticalAlign: 'top', width: '100%', padding: '10px 16px', }}>
          <TypographyRow label={"Date & Time"} value={matchInfo.dateTime}/>
          <TypographyRow label={"Format"} value={matchInfo.format}/>
          <TypographyRow label={"Tournament"} value={matchInfo.tournament}/>
          <TypographyRow label={"Stage"} value={matchInfo.stage}/>
          <TypographyRow label={"Type"} value={matchInfo.type}/>
          <TypographyRow label={"Region"} value={matchInfo.region}/>
      </Box>
    </Box>
  );
};

export default MatchInfoSidebar;
