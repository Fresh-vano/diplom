import React from 'react';
import { Paper, Typography, Box } from '@mui/material';

const TypographyRow = ({ label, value, highlight = false }) => {
    return (
      <Box sx={{
        display: 'flex',
        justifyContent: 'space-between',
        p: '8px 0',
        borderRadius: highlight ? '4px' : '0',
      }}>
        <Typography variant="subtitle1" sx={{ fontWeight: 'bold', overflow:'hidden', marginRight:2 }}>
          {label}
        </Typography>
        <Typography variant="subtitle1" sx={{ textOverflow:'ellipsis', overflow:'hidden', whiteSpace:'nowrap', }}>
          {value}
        </Typography>
      </Box>
    );
  };

export default TypographyRow;