import { Avatar, Box } from '@mui/material';
import React from 'react';
import TypographyRow from './TypographyRow';

const TournamentOverview = ({ data }) => {
  return (
    <Box sx={{display:'flex', flexDirection:'column', height:'100%'}}>
    <Box sx={{display:'flex', flexDirection:'column', margin:'190px 0', height:'100%'}}>

        <Box sx={{ maxWidth:400, color:'#fff', backgroundColor: '#22262c', boxSizing: 'border-box', display: 'inline-block', verticalAlign: 'top', width: '100%', padding: '10px 16px', }}>
        <TypographyRow label="Prize Pool" value={`$${data.prizePool}`} />
        <TypographyRow label="Dates" value={data.dates} />
        <TypographyRow label="Type" value={data.type} />
        <TypographyRow label="Tier" value={data.tier} />
        <TypographyRow label="Country" value={data.country || '—'} />
        <TypographyRow label="Region" value={data.region} highlight />
        <TypographyRow label="Teams" value={data.teams.length} />
        <TypographyRow label="Series" value={data.series} />
        </Box>
    </Box>
    </Box>
  );
};

export default TournamentOverview;
