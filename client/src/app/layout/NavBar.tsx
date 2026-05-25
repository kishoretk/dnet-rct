import Group from "@mui/icons-material/Group";
import { AppBar, Box, Toolbar, Typography, Container, Button } from "@mui/material";

type Props = {
    openForm: () => void
}

export default function NavBar({ openForm }: Props) {
    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static" sx={{ backgroundImage: "linear-gradient(to right, #024086, #04706b)" }}>
                <Container maxWidth="xl">
                    <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
                        <Box sx={{ display: "flex", gap: 1, alignItems: "center" }}>
                            <Group fontSize="large" />
                            <Typography variant="h6" component="h1" sx={{ fontWeight: 'bold' }}>
                                MyWorks v5.0
                            </Typography>
                        </Box>
                        <Box sx={{ display: "flex", gap: 1, alignItems: "center" }}>
                            <Button color="inherit" sx={{ fontSize: "0.9rem", textTransform: 'uppercase' }}>
                                Tasks
                            </Button>
                            <Button color="inherit" sx={{ fontSize: "0.9rem", textTransform: 'uppercase' }}>
                                Store
                            </Button>
                        </Box>
                        <Button variant="contained" color="primary" size="small" onClick={openForm}>
                            Create Task
                        </Button>
                    </Toolbar>
                </Container>
            </AppBar>
        </Box>
    );
}