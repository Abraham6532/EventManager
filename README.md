# EventManager 360

## Requisitos previos

Antes de configurar y ejecutar el proyecto, asegúrate de cumplir con los siguientes requisitos:

### Visual Studio 2022
Debes tener instalado **Visual Studio 2022** con las siguientes características habilitadas:

- Compatibilidad con **.NET Framework 4.8**
- Bibliotecas portables
- Plantillas de proyecto y elementos de .NET

### Paquete MySQL Data
Instala el paquete **MySQL.Data** a través del Administrador de Paquetes NuGet en Visual Studio. Este paquete es necesario para establecer la conexión con la base de datos MySQL.

---

## Configuración de la cadena de conexión

En el archivo `web.config`, agrega la siguiente cadena de conexión para MySQL:

```xml
<connectionStrings>
  <add name="MySqlConnection"
       connectionString="server=127.0.0.1;uid=root;pwd=Mysql123#;database=eventManager;"
       providerName="MySql.Data.MySqlClient" />
</connectionStrings>
```
## Base de Datos MySQL

Crea una base de datos MySQL con las tablas requeridas en el orden indicado más adelante.

### Crear base de datos
```sql
CREATE DATABASE eventManager;
SHOW DATABASES;
USE eventManager;
CREATE TABLE Roles (
    idRol INT NOT NULL AUTO_INCREMENT, 
    nombre VARCHAR(100) NOT NULL UNIQUE,
    PRIMARY KEY(idRol)
);

CREATE TABLE Usuarios (
    idUsuario INT NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    correo VARCHAR(100) NOT NULL UNIQUE,
    idRol INT NOT NULL,
    PRIMARY KEY(idUsuario),
    FOREIGN KEY(idRol) REFERENCES Roles (idRol)
);

CREATE TABLE Eventos (
    idEvento INT NOT NULL AUTO_INCREMENT,
    titulo VARCHAR(100) NOT NULL,
    descripcion VARCHAR(300),
    lugar VARCHAR(150) NOT NULL,
    fecha DATETIME NOT NULL,
    UsuarioId INT NOT NULL,
    PRIMARY KEY(idEvento),
    FOREIGN KEY(UsuarioId) REFERENCES Usuarios (idUsuario)
);

INSERT INTO Roles (nombre) VALUES ('Administrador'), ('Organizador'), ('Asistente');
SELECT * FROM Roles;

INSERT INTO Usuarios (nombre, correo, idRol) VALUES ('Jose Antonio', 'JoseA24@gmail.com', 1);
SELECT * FROM Usuarios;
```
## Instrucciones para el inicio de sesión
El inicio de sesión está configurado con las siguientes credenciales estáticas para fines de demostración:

Correo: abraham@gmail.com

Contraseña: qwerty123

Cuando el usuario ingresa estas credenciales, se redirige a la página de eventos. Si las credenciales son incorrectas, el usuario es redirigido al formulario de inicio de sesión.
