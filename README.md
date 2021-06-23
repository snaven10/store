# Prerequisitos para poder compilar el proyecto.
+ [Visual Studio 2019 16.8 o posterior](https://visualstudio.microsoft.com/es/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) con ASP.NET y la carga de trabajo de desarrollo web.
+ [.NET 5.0 SDK o posterior](https://dotnet.microsoft.com/download/dotnet/5.0)
+ En caso que quieras trabajar con el [Visual Studio Code](https://code.visualstudio.com/download) tienes que tener [dotnet](https://dotnet.microsoft.com/download/dotnet/3.1) para poder ejecutar los comandos desde la terminal

##  Ejecucion de migraciones para creación de base de datos
+ 1. Visual Studio ``PM> Update-Database``
+ 2. .NET Core CLI 
``dotnet tool install --global dotnet-ef``
``dotnet ef database update``
### En una PowerShell para desarrolladores o cualquier terminal de tu preferencia   

## Datos del login
+ Usuario: ``admin@gmail.com``
+ Password: ``Admin@123``

## Para poder ejecutar el proyecto tenemos varias opciones.

+ Podemos ejecutarlo desde el visual estudio abriendo previamente el proyecto solucion.
+ Desde la terminal usando el comando ``dotnet run``
