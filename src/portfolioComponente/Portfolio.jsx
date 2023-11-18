import React, { useEffect, useState } from 'react';
import "./Portfolio.css";
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TableCol,TablePagination, Paper, List, ListItem, ListItemText} from '@mui/material';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import PerfilImage from "../Images/Perfil.jpeg";
import CorreoLogo from "../Images/LogoCorreo.jpg";
import UbicacionLogo from "../Images/LogoUbicacion.png";

function Porfolio(){
    
    //const data y set data
    const [perfil, setPerfil] = useState([]);

    useEffect(() => {
        const fetchPerfil = async () => {
          try {
            // Realizar la llamada a la API
            const response = await fetch('https://localhost:7161/api/Profile', {
                method: 'GET',
                headers: {
                  'Content-Type': 'application/json',
                  'Access-Control-Allow-Origin': '*', // Puedes ajustar esto según tus necesidades de seguridad
                },
              })
    
            // Verificar si la respuesta es exitosa (código de estado 200)
            if (response.ok) {
              // Convertir la respuesta a formato JSON
              const result = await response.json();
    
              // Actualizar el estado con los datos de la API
              setPerfil(result);
            } else {
              console.error('Error al obtener datos de la API');
            }
          } catch (error) {
            console.error('Error de red:', error);
          }
        };
    
        // Llamar a la función fetchData
        fetchPerfil();
      }, []);


    return(
        <div style={{ margin: '40px'}}>

            <TableContainer component={Paper} >
   
                {perfil.map(({ id, nombre, apellido, correo, pais, ciudad, descripcion, frameworks, pasatiempos}) => (
                    <Table key={id}>
                        <TableHead>
                            <TableRow>
                                <TableCell>
                                <div>
                                    <h1>
                                    <img src={PerfilImage} alt="PerfilImagen" id="perfilFoto" style={{ marginRight: '10px', width: '60px', borderRadius: '50%'}}/> 
                                     {nombre} {apellido}
                                    </h1>
                                </div>
                                </TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>
                                    <h2>
                                        <img src={CorreoLogo} alt="CorreoImagen" id="CorreoFoto" style={{ marginRight: '20px', width: '50px'}}/> 
                                        {correo}
                                    </h2>
                                </TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>
                                    <h2>
                                        <img src={UbicacionLogo} alt="UbicacionImagen" id="UbicacionFoto" style={{ marginRight: '20px', width: '50px'}}/> 
                                        {ciudad}, {pais}
                                    </h2>
                                </TableCell>
                            </TableRow>
                        
                        </TableHead>
                        <TableBody>

                            <TableRow>
                                <TableCell><h2>Informacion Personal: </h2>{descripcion}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>
                                    <h2>Frameworks: 
                                        <ListItemText
                                        secondary={
                                            <List style={{marginLeft: '10px'}}>
                                            {frameworks.map(({ framework, nivel, anio }, index) => (
                                                <ListItem key={index}>
                                                    <ListItemText>
                                                        <h3>{framework}, {nivel}</h3>
                                                        {anio}
                                                    </ListItemText>
                                                </ListItem>
                                            ))}
                                            </List>
                                        }
                                        />
                                    </h2>    
                                    <h2>Pasatiempos:       
                                        <ListItemText
                                        secondary={
                                            <List style={{marginLeft: '10px'}}>
                                            {pasatiempos.map(({ pasatiempo, descripcion }, index) => (
                                                <ListItem key={index}>
                                                    <ListItemText>
                                                        <h3>{pasatiempo}</h3>
                                                        {descripcion}
                                                        
                                                    </ListItemText>
                                                </ListItem>
                                            ))}
                                            </List>
                                        }
                                        />
                                    </h2>
                                </TableCell>
                            </TableRow>

                        </TableBody>
                    </Table>
                ))}
   
            </TableContainer>
        </div>
    );

}
export default Porfolio;