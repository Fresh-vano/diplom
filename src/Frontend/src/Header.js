import React, { useState } from 'react';
import { AppBar, Toolbar, Typography, Button, Box, FormControl, Select, MenuItem, Menu, IconButton, Link } from '@mui/material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';

const Header = () => {
  const [lang, setLang] = useState('ru');
  const [anchorEl, setAnchorEl] = useState(null);
  const [openMenu, setOpenMenu] = useState('');
  const [menuHoverTimer, setMenuHoverTimer] = useState(null);

  const handleMenu = (event, menuId) => {
    clearTimeout(menuHoverTimer);
    setAnchorEl(event.currentTarget);
    setOpenMenu(menuId);
  };

  const handleClose = () => {
    if (menuHoverTimer) {
      clearTimeout(menuHoverTimer);
    }
    setMenuHoverTimer(setTimeout(() => {
      setAnchorEl(null);
      setOpenMenu('');
    }, 100));
  };

  const handleMenuEnter = () => {
    clearTimeout(menuHoverTimer); 
  };

  const handleChangeLang = (event) => {
    setLang(event.target.value);
  };

  return (
    <AppBar position="relative" sx={{ background: '#22262c', color: '#fff', width:'100%' }}>
      <Toolbar>
        <Typography variant="h6" sx={{  display: { xs: 'none', sm: 'block' } }}>
          Логотип
        </Typography>
        <Box sx={{ flexGrow: 1, display: 'flex', justifyContent: 'space-around' }}>
          <div>
            <Button color="inherit" onMouseEnter={(e) => handleMenu(e, 'matches')}>
              Матчи
            </Button>
            <Menu
              id="matches-menu"
              anchorEl={anchorEl}
              open={openMenu === 'matches'}
              onClose={handleClose}
              MenuListProps={{ onMouseEnter: handleMenuEnter, onMouseLeave: handleClose }}
            >
              <MenuItem onClick={handleClose} component={Link} href="/matches/current">Будущие и текущие</MenuItem>
              <MenuItem onClick={handleClose} component={Link} href="/matches/finished">Завершенные</MenuItem>
            </Menu>
          </div>
          <div>
            <Button color="inherit" onMouseEnter={(e) => handleMenu(e, 'tournaments')}>
              Турниры
            </Button>
            <Menu
              id="tournaments-menu"
              anchorEl={anchorEl}
              open={openMenu === 'tournaments'}
              onClose={handleClose}
              MenuListProps={{ onMouseEnter: handleMenuEnter, onMouseLeave: handleClose }}
            >
              <MenuItem onClick={handleClose} component={Link} href="/tournaments/current">
                <Typography style={{ textDecoration: 'none', color: 'inherit' }}>
                  Будущие и текущие
                </Typography>
              </MenuItem>
              <MenuItem onClick={handleClose} component={Link} href="/tournaments/finished">
                  <Typography  style={{ textDecoration: 'none', color: 'inherit' }}>
                    Завершенные
                  </Typography>  
              </MenuItem>
            </Menu>
          </div>

          <Button color="inherit" component={Link} href="/players">Игроки</Button>
          <Button color="inherit" component={Link} href="/teams">Команды</Button>
          <div>
            <Button color="inherit" onMouseEnter={(e) => handleMenu(e, 'compare')}>
                Инструменты
            </Button>
            <Menu
                id="compare-menu"
                anchorEl={anchorEl}
                open={openMenu === 'compare'}
                onClose={handleClose}
                MenuListProps={{ onMouseEnter: handleMenuEnter, onMouseLeave: handleClose }}
            >
                <MenuItem onClick={handleClose}>Сравнение команд</MenuItem>
                <MenuItem onClick={handleClose}>Сравнение игроков</MenuItem>
            </Menu>
          </div>

        </Box>
        <FormControl size="small" sx={{ m: 1, minWidth: 80 }}>
          <Select
            value={lang}
            onChange={handleChangeLang}
            displayEmpty
            inputProps={{ 'aria-label': 'Without label' }}
            IconComponent={ExpandMoreIcon}
            sx={{ color: '#fff', borderColor: '#444' }}
          >
            <MenuItem value="ru">RU</MenuItem>
            <MenuItem value="en">EN</MenuItem>
          </Select>
        </FormControl>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
