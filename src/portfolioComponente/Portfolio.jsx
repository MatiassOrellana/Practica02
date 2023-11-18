import React, { useEffect, useState } from 'react';
//import "Porfolio.css";
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow,TablePagination, Paper, List, ListItem, ListItemText} from '@mui/material';
import { ThemeProvider, createTheme } from '@mui/material/styles';

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
        <div>
            <h1>Mi Perfil:</h1>
            <h2 id = "Titulo">
            {perfil.map(({ id, nombre, apellido}) => (
                
                <li key={id}>{nombre} {apellido}</li>
                
            ))}
            </h2>
            <h2 id = "Correo">
            {perfil.map(({ id, correo}) => (
                
                <li key={id}>{correo}</li>
                
            ))}
            </h2>
            <h2 id = "Ubicacion">
            {perfil.map(({ id, pais, ciudad}) => (
                
                <li key={id}>{ciudad}, {pais}</li>
                
            ))}
            </h2>
            <h2 id = "Descripcion">
            {perfil.map(({ id, descripcion}) => (
                
                <li key={id}>{descripcion}</li>
                
            ))}
            </h2>
            <Paper>
                <List>
                    {perfil.map(({ id, frameworks}) => (
                    <ListItem key={id}>
                        <ListItemText
                        secondary={
                            <List>
                              {frameworks.map(({ framework, nivel, anio }, index) => (
                                <ListItem key={index}>
                                  <ListItemText
                                    primary={`Framework: ${framework}, Nivel: ${nivel}`}
                                    secondary={`Año: ${anio}`}
                                  />
                                </ListItem>
                              ))}
                            </List>
                          }
                        />
                    </ListItem>
                    ))}
                </List>
            </Paper>
            <Paper>
                <List>
                    {perfil.map(({ id, pasatiempos}) => (
                    <ListItem key={id}>
                        <ListItemText
                        secondary={
                            <List>
                              {pasatiempos.map(({pasatiempo, descripcion}, index) => (
                                <ListItem key={index}>
                                  <ListItemText
                                    primary={`Pasatiempo: ${pasatiempo}`}
                                    secondary={`Descripción: ${descripcion}`}
                                  />
                                </ListItem>
                              ))}
                            </List>
                          }
                        />
                    </ListItem>
                    ))}
                </List>
            </Paper>

        </div>
    );

}
export default Porfolio;