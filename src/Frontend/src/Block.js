import { Typography } from "@mui/material";
import { Box } from "@mui/system";

const Block = ({title, children}) => {
    return (
        <Box sx={{ color:'#fff', backgroundColor: '#22262c', boxSizing: 'border-box', display: 'inline-block', verticalAlign: 'top', width: '100%', margin:2, padding: '10px 16px' }}>
            {title ? 
            <Typography variant="h6" sx={{
                        color: '#cbd5e4',
                        fontWeight: '500',
                        overflow: 'ellipsis',
                        fontSize: '1 rem',
                        lineHeight:'20px',
                        margin:'20px 0'
                }}>
                    {title}
                </Typography>
            :
            <></>
            }
            <Box>
                {children}
            </Box>
        </Box>
    )
}

export default Block;