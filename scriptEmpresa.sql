create database Empresa;

use Empresa;

--Roles: Catálogo de perfiles y permisos.
create table Roles(
	IDRol INT IDENTITY(1,1) PRIMARY KEY,
	NombreRol varchar(20) NOT NULL,
	PermisoGet int not null,
	PermisoPOST int not null,
	PermisoPUT int not null,
	PermisoDelete int not null
)

--Tabla Empleados: Entidad principal de usuarios.
create table Empleados (
    IDEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    CorreoElectronico VARCHAR(100) NOT NULL,
	contrasena VARCHAR(200) NOT NULL
);

--Tabla EmpleadosRoles: Tabla intermedia que gestiona la relación N:M
--(muchos a muchos) entre empleados y sus roles asignados.
create table EmpleadosRoles (
	IDEmpleadoRol INT IDENTITY (1,1) PRIMARY KEY,
	IDRol INT NOT NULL,
	IDEmpleado INT NOT NULL
	FOREIGN KEY (IDRol) REFERENCES Roles(IDRol),
	FOREIGN KEY (IDEmpleado) REFERENCES Empleados(IDEmpleado)
);


--Tabla Log: Tabla de monitoreo de actividad de cada petición realizada
create table Logs (
	IDLog INT IDENTITY (1,1) PRIMARY KEY,
	DescripcionLog VARCHAR(200) NOT NULL,
	IDEmpleadoSolicitante INT NOT NULL,
	FechaSolicitud smalldatetime NOT NULL
	FOREIGN KEY (IDEmpleadoSolicitante) REFERENCES Empleados(IDEmpleado)
);

create table Roles(
	IDRol INT IDENTITY(1,1) PRIMARY KEY,
	NombreRol varchar(20) NOT NULL,
	PermisoGet int not null,
	PermisoPOST int not null,
	PermisoPUT int not null,
	PermisoDelete int not null
)

insert Roles (NombreRol, PermisoGet, PermisoPOST, PermisoPUT, PermisoDelete) values ('Becario',0,0,0,0)