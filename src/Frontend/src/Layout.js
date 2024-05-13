import React from 'react';
import { Box, Container, Typography, CssBaseline } from '@mui/material';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import Footer from './Footer';

const theme = createTheme();

const Layout = ({ children }) => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Box sx={{
        display: 'flex',
        flexDirection: 'column',
        minHeight: '100vh',
      }}>
        <Box component="main" className='layout' sx={{ flexGrow: 1 }}>
          {children}
        </Box>
        <Footer/>
      </Box>
    </ThemeProvider>
  );
};

export default Layout;