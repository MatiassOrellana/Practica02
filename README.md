# Practica02
Backend: rama del "master"
1) cargue esta rama primero en un proyecto de visual studio o rider
2) cambiar la conexion de base de datos utilizado en microsoft sql server al suyo
ubicado en el archivo appsettings.json en "connctionStrings"
3) haga las migraciones con el comando
	* Dotnet ef migrations add NombreMigraciones -o RutaMigraciones
	* Dotnet ef database update
4) Antes de ejecutarlo cargue el endpont, ubicado dentro del proyecto de backend
en la carpeta de endponits y dentro de esa carpeta está el archivo, lo carga
en postman
5) 

Frontend: rama del "masterfront"
1) cargue esta rama en otro proyecto puede usar visual studio o web storm
2) antes de ejecutarlo, inicie el backend
