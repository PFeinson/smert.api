import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import Link from '@mui/material/Link';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import { createUser } from '../../services/UserService';

const registrationPageComponent = (props)=>
{
    const submitHandler = (event) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

        let params = 
        {
            userName:     data.get('username'),
            emailAddress: data.get('email'),
            password:     data.get('password'),
            firstName:    data.get('firstName'),
            lastName:     data.get('lastName')
        };
        createUser(params, true);
    };

    return(
    <Container component="main" maxWidth="xs">
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
            <Typography component="h1" variant="h5">Sign up</Typography>
            <Box component="form" noValidate onSubmit={submitHandler} sx={{ mt: 3 }}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={6}>
                        <TextField
                            autoComplete="given-name"
                            name="firstName"
                            required
                            fullWidth
                            id="firstName"
                            label="First Name"
                            autoFocus
                        />
                    </Grid> 
                    <Grid item xs={12} sm={6}>
                    <TextField
                        required
                        fullWidth
                        id="lastName"
                        label="Last Name"
                        name="lastName"
                        autoComplete="family-name"
                    />
                    </Grid> 
                    <Grid item xs={12}>
                        <TextField
                            required
                            fullWidth
                            id="username"
                            label="Username"
                            name="username"
                            autoComplete="username"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            required
                            fullWidth
                            id="email"
                            label="Email Address"
                            name="email"
                            autoComplete="email"
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            required
                            fullWidth
                            name="password"
                            label="Password"
                            type="password"
                            id="password"
                            autoComplete="new-password"
                        />
                    </Grid>
                </Grid>
                <Button type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
                    Sign Up
                </Button>
                <Grid container justifyContent="flex-end">
                    <Grid item>
                        <Link href="/login" variant="body2">Already have an account? Sign in</Link>
                    </Grid>
                </Grid>
            </Box>
        </Box>
    </Container>
    );
};

export default registrationPageComponent;