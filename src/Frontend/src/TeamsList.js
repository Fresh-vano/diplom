import { Typography } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import TeamTile from "./TeamTitle";

const teamData = {
    name: "Sangal",
    logoUrl: "https://files.bo3.gg/uploads/team/36/image/400x400-bc8a5b82c58e600b24bb566961ed43e8.png",
    players: [
        {
            id: 1,
            name: "Player 1",
            imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",

            countryColor: '#f00' // Example color code for Turkey
        },
        {
            id: 2,
            name: "Player 1",
            imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
            countryColor: '#f00' // Example color code for Turkey
        },
        {
            id: 3,
            name: "Player 1",
            imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
            countryColor: '#f00' // Example color code for Turkey
        },
        {
            id: 4,
            name: "Player 1",
            imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
            countryColor: '#f00' // Example color code for Turkey
        },
        {
            id: 5,
            name: "Player 1",
            imageUrl: "https://files.bo3.gg/uploads/player/32578/image/400x400-767e12fb9d8ffe1a10414d96b7c7a8fa.webp",
            countryColor: '#f00' // Example color code for Turkey
        },
        // Additional players...
    ]
};

const TeamsList = ({ teams }) => {
    return (
      <Box>
        {teams.map((team, index) => (
          <TeamTile team={teamData} />
        ))}
      </Box>
    );
  };

  export default TeamsList;