import * as React from 'react';
import { Box, Container, Typography, Link } from '@mui/material';

const Footer = () => {
  return (
    <Box component="footer" sx={{ bgcolor: '#22262c', py: 3, mt: 'auto' }}>
      <Container maxWidth="lg">
        <Typography variant="h6" color="white">Logo</Typography>
        <Typography variant="subtitle1" color="white" component="div">
          © 2024 Company Name
        </Typography>
      </Container>
    </Box>
  );
};

export default Footer;
