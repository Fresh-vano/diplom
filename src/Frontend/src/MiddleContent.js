import React from 'react';
import { Box, Typography, Tabs, Tab, Divider, Avatar } from '@mui/material';

const MiddleContent = ({ title, subtitle, avatar, children, sx, matchInfo, avatarSize }) => {
    return (
        <Box sx={{display:'flex', flexDirection:'row', justifyContent:'center'}}>
            <Box sx={{ width: '100%', maxWidth: '1000px', padding: '0 24px', marginBottom: '64px', ...sx }}>
                <Box sx={{display:'flex', flexDirection:'row', alignItems:'center', margin:'40px 0'}}>
                    {avatar ? 
                        <Avatar src={avatar} sx={{ width: avatarSize ? avatarSize : 56, height: avatarSize ? avatarSize : 56, marginRight: 2 }} />
                    :
                        <></>
                    }
                    <Box sx={{display:'flex', flexDirection:'column'}}>
                        {title ?
                        <Typography variant="h1" sx={{
                            margin: '20px 0',
                            color: '#cbd5e4',
                            fontWeight: '500',
                            overflow: 'ellipsis',
                            fontSize: '1.5rem'
                        }}>
                            {title}
                        </Typography>
                        :
                        <></>
                        }
                        {subtitle ? 
                        <Typography variant="h1" sx={{
                            color: '#fff',
                            fontWeight: '500',
                            overflow: 'ellipsis',
                            fontSize: '1rem',
                            lineHeight:'27px'
                        }}>
                            {subtitle}
                        </Typography>
                        :
                        <></>    
                        }
                    </Box>
                </Box>
                {children}
            </Box>
            {matchInfo ?
            <>
                {matchInfo}
            </>
            : 
            <></>
            }
        </Box>
    );
};

export default MiddleContent;
