import React from 'react';
import { Box, Typography, Tabs, Tab, Divider } from '@mui/material';

const MiddleTabsContent = ({ title, tabValue, handleChange, children }) => {
    return (
        <Box sx={{ width: '100%', maxWidth: '1000px', margin: '0 auto', padding: '0 24px', marginBottom: '64px' }}>
            <Typography variant="h1" sx={{
                margin: '20px 0',
                color: '#cbd5e4',
                fontWeight: '500',
                overflow: 'ellipsis',
                fontSize: '1.5rem'
            }}>
                {title}
            </Typography>
            <Box sx={{
                backgroundColor: '#22262c',
                boxSizing: 'border-box',
                display: 'inline-block',
                verticalAlign: 'top',
                width: '100%',
                padding: '0 16px 10px 16px'
            }}>
                <Tabs value={tabValue} onChange={handleChange} aria-label="Tournament Tabs" sx={{
                    '.MuiTabs-flexContainer': {
                        justifyContent: 'center',
                        width: '100%'
                    },
                    '.MuiTab-root': {
                        textTransform: 'none',
                        color: '#cbd5e4',
                        borderRadius: '5px',
                        '&:hover': {
                            backgroundColor: '#434a54'
                        },
                    },
                    '.Mui-selected': {
                        color: '#0F8DEB',
                        fontWeight: 'bold',
                    },
                    '.MuiTabs-indicator': {
                        backgroundColor: '#0F8DEB',
                        top: 0,
                        bottom: 'auto',
                        height: '4px'
                    }
                }}>
                    <Tab label="Будущие и текущие" value="current" />
                    <Tab label="Завершенные" value="finished" />
                </Tabs>
                <Divider sx={{ my: 2 }} />
                {children}
            </Box>
        </Box>
    );
};

export default MiddleTabsContent;
