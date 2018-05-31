---------------------------------------------- Creacion del Modelo de Datos --------------------------------------------------------------------
USE GD1C2018
GO

--------------------------------------------- Eliminacion de Tablas ----------------------------------------------------------------------------
IF OBJECT_ID('LOS_BORBOTONES.Inconsistencias','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Inconsistencias;
GO

IF OBJECT_ID('LOS_BORBOTONES.Funcionalidad_X_Rol','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Funcionalidad_X_Rol;
GO

IF OBJECT_ID('LOS_BORBOTONES.Rol_X_Usuario','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Rol_X_Usuario;
GO

IF OBJECT_ID('LOS_BORBOTONES.Rol','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Rol;
GO

IF OBJECT_ID('LOS_BORBOTONES.Funcionalidad','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Funcionalidad;
GO

IF OBJECT_ID('LOS_BORBOTONES.Estadia_X_Consumible','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Estadia_X_Consumible;
GO

IF OBJECT_ID('LOS_BORBOTONES.Consumible','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Consumible;
GO

IF OBJECT_ID('LOS_BORBOTONES.EstadoReserva','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.EstadoReserva;
GO

IF OBJECT_ID('LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente;
GO

IF OBJECT_ID('LOS_BORBOTONES.Reserva','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Reserva;
GO

IF OBJECT_ID('LOS_BORBOTONES.Estadia','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Estadia;
GO

IF OBJECT_ID('LOS_BORBOTONES.ItemFactura') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.ItemFactura;
GO
	
IF OBJECT_ID('LOS_BORBOTONES.Factura','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Factura;
GO

IF OBJECT_ID('LOS_BORBOTONES.Hotel_X_Usuario','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Hotel_X_Usuario;
GO

IF OBJECT_ID('LOS_BORBOTONES.CierreTemporal','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.CierreTemporal;
GO
	
IF OBJECT_ID('LOS_BORBOTONES.Regimen','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Regimen;
GO

IF OBJECT_ID('LOS_BORBOTONES.TipoHabitacion','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.TipoHabitacion;
GO

IF OBJECT_ID('LOS_BORBOTONES.Habitacion','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Habitacion;
GO

IF OBJECT_ID('LOS_BORBOTONES.Hotel','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Hotel;
GO
	
IF OBJECT_ID('LOS_BORBOTONES.Categoria','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Categoria;
GO	

IF OBJECT_ID('LOS_BORBOTONES.Cliente','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Cliente;
GO

IF OBJECT_ID('LOS_BORBOTONES.Usuario','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Usuario;
GO
	
IF OBJECT_ID('LOS_BORBOTONES.Direccion','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Direccion;
GO

IF OBJECT_ID('LOS_BORBOTONES.Identidad','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Identidad;
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------- Eliminacion de schema LOS_BORBOTONES --------------------------------------------------------------------------
IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'LOS_BORBOTONES')
    DROP SCHEMA LOS_BORBOTONES;
GO
	
--Creación Inicial del Esquema
CREATE SCHEMA LOS_BORBOTONES AUTHORIZATION gdHotel2018;
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------Tablas---------------------------------------------------------------------------------------------------------
--Creación Tabla Rol
CREATE TABLE LOS_BORBOTONES.Rol (

	idRol	INT			IDENTITY(1,1)	NOT NULL		UNIQUE,
	Nombre	VARCHAR(45) 				NOT NULL,
	Activo	BIT							NOT NULL,
)
GO

--Creación Tabla Funcionalidad
CREATE TABLE LOS_BORBOTONES.Funcionalidad (

	idFuncionalidad	INT			IDENTITY(1,1)	NOT NULL,
	Descripcion 	VARCHAR(45)					NOT NULL,
)
GO

--Creación Tabla Asociación Funcionalidad - Rol
CREATE TABLE LOS_BORBOTONES.Funcionalidad_X_Rol (

	idFuncionalidad	INT			NOT NULL,
	idRol			INT			NOT NULL,		
)
GO

--Creacion Tabla Identidad 
CREATE TABLE LOS_BORBOTONES.Identidad (

	idIdentidad				INT				IDENTITY(1,1)		NOT NULL,
	TipoIdentidad			VARCHAR(45)		DEFAULT 'Cliente',
	Nombre					NVARCHAR(255),
	Apellido				NVARCHAR(255),
	TipoDocumento			VARCHAR(45)		DEFAULT 'Pasaporte',
	NumeroDocumento			VARCHAR(45),
	Mail					NVARCHAR(255),
	FechaNacimiento			DATETIME,
	Nacionalidad			NVARCHAR(255),
	Telefono				VARCHAR(45)		DEFAULT 0,
)
GO

--Creacion Tabla Direccion
CREATE TABLE LOS_BORBOTONES.Direccion (

	idDireccion		INT				IDENTITY(1,1)				NOT NULL,
	Pais			VARCHAR(45)		DEFAULT 0,
	Ciudad			NVARCHAR(255),
	Calle			NVARCHAR(255),
	NumeroCalle		NUMERIC(18,0),
	Piso			NVARCHAR(50),
	Depto			NVARCHAR(50),
	idIdentidad		INT				NOT NULL,	
)
GO

--Creacion Tabla Usuario 
CREATE TABLE LOS_BORBOTONES.Usuario (

	idUsuario				INT			IDENTITY(1,1)	NOT NULL,
	Username				VARCHAR(45),
	Pasword					VARCHAR(45),
	IntentosFallidosLogin	VARCHAR(45),
	Activo					BIT,
	idIdentidad				INT			NOT NULL,
)
GO

--Creacion Tabla Asociacion Rol - Usuario
CREATE TABLE LOS_BORBOTONES.Rol_X_Usuario (

	idRol			INT			NOT NULL,
	idUsuario		INT			NOT NULL,	
)
GO

--Creacion Tabla Cliente
CREATE TABLE LOS_BORBOTONES.Cliente (

	idCliente		INT				IDENTITY(1,1)	NOT NULL,
	Activo			BIT,
	idIdentidad		INT				NOT NULL,
)
GO

--Creacion Tabla Categoria
CREATE TABLE LOS_BORBOTONES.Categoria (

	idCategoria			INT		IDENTITY(1,1)	NOT NULL,
	Estrellas			NUMERIC(18,0),
	RecargaEstrellas	NUMERIC(18,0)
)
GO

--Creacion Tabla Hotel
CREATE TABLE LOS_BORBOTONES.Hotel (

	idHotel					INT					IDENTITY(1,1)		  NOT NULL	UNIQUE,  --indice no cluster
	Nombre					NVARCHAR(255),
	Mail					NVARCHAR(255),
	Telefono				VARCHAR(45),
	FechaInicioActividades	DATETIME,
	idCategoria				INT					NOT NULL,
	idDireccion				INT					NOT NULL,
)
GO

--Creacion Tabla Asociacion Hotel - Usuario
CREATE TABLE LOS_BORBOTONES.Hotel_X_Usuario (

	idHotel			INT			NOT NULL,
	idUsuario		INT			NOT NULL,
)
GO

--Creacion Tabla CierreTemporal
CREATE TABLE LOS_BORBOTONES.CierreTemporal (

	idEstadoHotel	INT				NOT NULL,
	FechaInicio		VARCHAR(45),
	FechaFin		VARCHAR(45),
	Descripcion		VARCHAR(45),
	idHotel			INT				NOT NULL,	
)
GO

--Creacion Tabla Regimen
CREATE TABLE LOS_BORBOTONES.Regimen (
	
	idRegimen		INT				IDENTITY(1,1)	NOT NULL,
	Codigo			VARCHAR(45),		
	Descripcion		NVARCHAR(255),
	Precio			NUMERIC(18,2),
	Estado			VARCHAR(45),
	idHotel			INT				NOT NULL,
)
GO

--Creacion Tabla TipoHabitacion
CREATE TABLE LOS_BORBOTONES.TipoHabitacion (

	idTipoHabitacion	INT				IDENTITY(1,1)	NOT NULL,
	Codigo				VARCHAR(45),
	Descripcion			VARCHAR(45),
	Porcentual			VARCHAR(45),	
)
GO

--Creacion Tabla Habitacion
CREATE TABLE LOS_BORBOTONES.Habitacion (

	idHabitacion		INT				IDENTITY(1,1)	NOT NULL,
	Aciva				BIT,
	Numero				NUMERIC(18,0),
	Piso				NUMERIC(18,0),
	Ubicacion			NVARCHAR(50),
	idHotel				INT				NOT NULL,
	idTipoHabitacion	INT				NOT NULL,	
)
GO

--Creacion Tabla Estadia
CREATE TABLE LOS_BORBOTONES.Estadia (

	idEstadia		INT			IDENTITY(1,1)	NOT NULL		UNIQUE,
	FechaEntrada	DATETIME,
	FechaSalida		DATETIME,
	Facturada		BIT			DEFAULT 1,
	DiasAlojados	INT,
	idUsuarioIn		INT			NOT NULL,
	idUsuarioOut	INT			NOT NULL,
		
)
GO

--Creacion Tabla Reserva
CREATE TABLE LOS_BORBOTONES.Reserva (

	idReserva		INT				IDENTITY(1000,1)	NOT NULL	UNIQUE,
	CodigoReserva	NUMERIC(18,0),
	FechaCreacion	DATETIME,
	FechaDesde		DATETIME,
	FechaHasta		DATETIME,
	DiasAlojados	NUMERIC(18,0),
	idHotel			INT				NOT NULL,
	idEstadia		INT				NOT NULL,
	idRegimen		INT				NOT NULL,
	idCliente		INT				NOT NULL,

)
GO

--Creacion Tabla Asociacion Reserva - Habitacion - Cliente
CREATE TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente (

	idReserva		INT		NOT NULL,
	idHabitacion	INT		NOT NULL,
	idCliente		INT		NOT NULL,
)
GO

--Creacion Tabla Factura
CREATE TABLE LOS_BORBOTONES.Factura (

	idFactura			INT			NOT NULL,
	NumeroFactura		NUMERIC(18,0),
	FechaFacturacion	DATETIME,
	Total				NUMERIC(18,2),
	Puntos				INT,
	TipoPago			VARCHAR(45),
	idEstadia			INT				NOT NULL,
	idReserva			INT				NOT NULL,
)
GO

--Creacion Tabla Consumible
CREATE TABLE LOS_BORBOTONES.Consumible (

	idConsumible		INT				IDENTITY(1,1)	NOT NULL,
	Codigo				NUMERIC(18,0),
	Descripcion			NVARCHAR(255),
	Precio				NUMERIC(18,2),
)
GO

--Creacion Tabla ItemFactura
CREATE TABLE LOS_BORBOTONES.ItemFactura (

		idItemFactura		INT				IDENTITY(1,1)	NOT NULL,
		Cantidad			NUMERIC(18,0),
		Monto				NUMERIC(18,2),
		FechaCreacion		DATETIME		DEFAULT GETDATE(),
		idFactura			INT				NOT NULL,
		idConsumible		INT				NOT NULL,		
)
GO

--Creacion Tabla Asociacion Estadia - Consumible
CREATE TABLE LOS_BORBOTONES.Estadia_X_Consumible (

	idEstadia		INT		NOT NULL,
	idConsumible	INT		NOT NULL,
)
GO

--Creacion Tabla EstadoReserva
CREATE TABLE LOS_BORBOTONES.EstadoReserva (

	idEstado		INT			IDENTITY(1,1)	NOT NULL,
	TipoEstado		VARCHAR(45),
	Fecha			VARCHAR(45),
	Descripcion		VARCHAR(45),
	idUsuario		INT			NOT NULL,
	idReserva		INT			NOT NULL,
)
GO

--------------------------------------------- Creacion de constraint PK para la base de datos ----------------------------------------------------------------------------------------
-- Tabla Rol
ALTER TABLE LOS_BORBOTONES.Rol
ADD CONSTRAINT PK_Rol_idRol PRIMARY KEY (idRol)

-- Tabla Funcionalidad
ALTER TABLE LOS_BORBOTONES.Funcionalidad
ADD CONSTRAINT PK_Funcionalidad_idFuncionalidad PRIMARY KEY (idFuncionalidad)

-- Tabla Identidad
ALTER TABLE LOS_BORBOTONES.Identidad
ADD CONSTRAINT PK_Identidad_idIdentidad PRIMARY KEY (idIdentidad)

-- Tabla Direccion
ALTER TABLE LOS_BORBOTONES.Direccion
ADD CONSTRAINT PK_Direccion_idDireccion PRIMARY KEY (idDireccion)

-- Tabla Usuario
ALTER TABLE LOS_BORBOTONES.Usuario
ADD CONSTRAINT PK_Usuario_idUsuario PRIMARY KEY (idUsuario)

-- Tabla Cliente
ALTER TABLE LOS_BORBOTONES.Cliente
ADD CONSTRAINT PK_Cliente_idCliente PRIMARY KEY (idCliente)

-- Tabla Categoria
ALTER TABLE LOS_BORBOTONES.Categoria
ADD CONSTRAINT PK_Categoria_idCategoria PRIMARY KEY (idCategoria)

-- Tabla Hotel
ALTER TABLE LOS_BORBOTONES.Hotel
ADD CONSTRAINT PK_Hotel_idHotel PRIMARY KEY (idHotel)

-- Tabla CierreTemporal
ALTER TABLE LOS_BORBOTONES.CierreTemporal
ADD CONSTRAINT PK_CierreTemporal_idEstadoHotel PRIMARY KEY (idEstadoHotel)

-- Tabla Regimen
ALTER TABLE LOS_BORBOTONES.Regimen
ADD CONSTRAINT PK_Regimen_idRegimen PRIMARY KEY (idRegimen)

-- Tabla TipoHabitacion
ALTER TABLE LOS_BORBOTONES.TipoHabitacion
ADD CONSTRAINT PK_TipoHabitacion_idTipoHabitacion PRIMARY KEY (idTipoHabitacion)

-- Tabla Habitacion
ALTER TABLE LOS_BORBOTONES.Habitacion
ADD CONSTRAINT PK_Habitacion_idHabitacion PRIMARY KEY (idHabitacion)

-- Tabla Estadia
ALTER TABLE LOS_BORBOTONES.Estadia
ADD CONSTRAINT PK_Estadia_idEstadia PRIMARY KEY (idEstadia)

-- Tabla Reserva
ALTER TABLE LOS_BORBOTONES.Reserva
ADD CONSTRAINT PK_Reserva_idReserva PRIMARY KEY (idReserva)

-- Tabla Reserva
ALTER TABLE LOS_BORBOTONES.Factura
ADD CONSTRAINT PK_Factura_idFactura PRIMARY KEY (idFactura)

-- Tabla Consumible
ALTER TABLE LOS_BORBOTONES.Consumible
ADD CONSTRAINT PK_Consumible_idConsumible PRIMARY KEY (idConsumible)

-- Tabla ItemFactura
ALTER TABLE LOS_BORBOTONES.ItemFactura
ADD CONSTRAINT PK_ItemFactura_idItemFactura PRIMARY KEY (idItemFactura)

-- Tabla EstadoReserva
ALTER TABLE LOS_BORBOTONES.EstadoReserva
ADD CONSTRAINT PK_EstadoReserva_idEstado PRIMARY KEY (idEstado)

---------------------------------------------------------- Creacion de constraint FK para la base de datos ---------------------------------------------------------------------------

-- Tabla Funcionalidad_X_Rol 
ALTER TABLE LOS_BORBOTONES.Funcionalidad_X_Rol
ADD CONSTRAINT FK_Funcionalidad_Rol FOREIGN KEY(idFuncionalidad) REFERENCES LOS_BORBOTONES.Funcionalidad(idFuncionalidad) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.Funcionalidad_X_Rol
ADD CONSTRAINT FK_Rol_Funcionalidad FOREIGN KEY(idRol) REFERENCES LOS_BORBOTONES.Rol(idRol) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla Direccion
ALTER TABLE LOS_BORBOTONES.Direccion
ADD CONSTRAINT FK_Identidad_Direccion FOREIGN KEY(idIdentidad) REFERENCES LOS_BORBOTONES.Identidad(idIdentidad) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla Usuario
ALTER TABLE LOS_BORBOTONES.Usuario
ADD CONSTRAINT FK_Identidad_Usuario FOREIGN KEY(idIdentidad) REFERENCES LOS_BORBOTONES.Identidad(idIdentidad) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla Rol_X_Usuario
ALTER TABLE LOS_BORBOTONES.Rol_X_Usuario
ADD CONSTRAINT FK_Rol_Usuario FOREIGN KEY(idRol) REFERENCES LOS_BORBOTONES.Rol(idRol) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.Rol_X_Usuario
ADD CONSTRAINT FK_Usuario_Rol FOREIGN KEY(idUsuario) REFERENCES LOS_BORBOTONES.Usuario(idUsuario) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla Cliente
ALTER TABLE LOS_BORBOTONES.Cliente
ADD CONSTRAINT FK_Identidad_Cliente FOREIGN KEY(idIdentidad) REFERENCES LOS_BORBOTONES.Identidad(idIdentidad) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla Hotel
ALTER TABLE LOS_BORBOTONES.Hotel
ADD CONSTRAINT FK_Hotel_Categoria FOREIGN KEY(idCategoria) REFERENCES LOS_BORBOTONES.Categoria(idCategoria) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.Hotel
ADD CONSTRAINT FK_Hotel_Direccion FOREIGN KEY(idDireccion) REFERENCES LOS_BORBOTONES.Direccion(idDireccion) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla Hotel_X_Usuario
ALTER TABLE LOS_BORBOTONES.Hotel_X_Usuario
ADD CONSTRAINT FK_Hotel_Usuario FOREIGN KEY(idHotel) REFERENCES LOS_BORBOTONES.Hotel(idHotel) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.Hotel_X_Usuario
ADD CONSTRAINT FK_Usuario_Hotel FOREIGN KEY(idUsuario) REFERENCES LOS_BORBOTONES.Usuario(idUsuario)

-- Tabla CierreTemporal
ALTER TABLE LOS_BORBOTONES.CierreTemporal
ADD CONSTRAINT FK_CierreTemporal_Hotel FOREIGN KEY(idHotel) REFERENCES LOS_BORBOTONES.Hotel(idHotel) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla Regimen
ALTER TABLE LOS_BORBOTONES.Regimen
ADD CONSTRAINT FK_Regimen_Hotel FOREIGN KEY(idHotel) REFERENCES LOS_BORBOTONES.Hotel(idHotel) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla Habitacion
ALTER TABLE LOS_BORBOTONES.Habitacion
ADD CONSTRAINT FK_Hotel_Habitacion FOREIGN KEY(idHotel) REFERENCES LOS_BORBOTONES.Hotel(idHotel) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.Habitacion
ADD CONSTRAINT FK_Hotel_TipoHabitacion FOREIGN KEY(idTipoHabitacion) REFERENCES LOS_BORBOTONES.TipoHabitacion(idTipoHabitacion) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla Estadia
ALTER TABLE LOS_BORBOTONES.Estadia
ADD CONSTRAINT FK_Usuario_CheckIn FOREIGN KEY(idUsuarioIn) REFERENCES LOS_BORBOTONES.Usuario(idUsuario)

ALTER TABLE LOS_BORBOTONES.Estadia
ADD CONSTRAINT FK_Usuario_CheckOut FOREIGN KEY(idUsuarioOut) REFERENCES LOS_BORBOTONES.Usuario(idUsuario)

-- Tabla Reserva
ALTER TABLE LOS_BORBOTONES.Reserva
ADD CONSTRAINT FK_Estadia_Reserva FOREIGN KEY(idEstadia) REFERENCES LOS_BORBOTONES.Estadia(idEstadia) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.Reserva
ADD CONSTRAINT FK_Regimen_Reserva FOREIGN KEY(idRegimen) REFERENCES LOS_BORBOTONES.Regimen(idRegimen) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.Reserva
ADD CONSTRAINT FK_Cliente_Reserva FOREIGN KEY(idCliente) REFERENCES LOS_BORBOTONES.Cliente(idCliente)

-- Tabla  Reserva_X_Habitacion_X_Cliente 
ALTER TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente
ADD CONSTRAINT FK_Reserva_Habitacion_Cliente FOREIGN KEY(idReserva) REFERENCES LOS_BORBOTONES.Reserva(idReserva) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente
ADD CONSTRAINT FK_Habitacion_X_Cliente_X_Reserva FOREIGN KEY(idHabitacion) REFERENCES LOS_BORBOTONES.Habitacion(idHabitacion)

ALTER TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente
ADD CONSTRAINT FK_Cliente_X_Habitacion_Reserva FOREIGN KEY(idCliente) REFERENCES LOS_BORBOTONES.Cliente(idCliente)

-- Tabla Factura
ALTER TABLE LOS_BORBOTONES.Factura
ADD CONSTRAINT FK_Estadia_Factura FOREIGN KEY(idEstadia) REFERENCES LOS_BORBOTONES.Estadia(idEstadia) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.Factura
ADD CONSTRAINT FK_Reserva_Factura FOREIGN KEY(idReserva) REFERENCES LOS_BORBOTONES.Reserva(idReserva)

-- Tabla ItemFactura
ALTER TABLE LOS_BORBOTONES.ItemFactura
ADD CONSTRAINT FK_ItemFactura_Factura FOREIGN KEY(idFactura) REFERENCES LOS_BORBOTONES.Factura(idFactura) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.ItemFactura
ADD CONSTRAINT FK_itemFactura_Consumible FOREIGN KEY(idConsumible) REFERENCES LOS_BORBOTONES.Consumible(idConsumible) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla Estadia_X_Consumible 
ALTER TABLE LOS_BORBOTONES.Estadia_X_Consumible
ADD CONSTRAINT FK_Estadia_Consumible FOREIGN KEY(idEstadia) REFERENCES LOS_BORBOTONES.Estadia(idEstadia) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.Estadia_X_Consumible
ADD CONSTRAINT FK_Consumible_Estadia FOREIGN KEY(idConsumible) REFERENCES LOS_BORBOTONES.Consumible(idConsumible) ON DELETE CASCADE ON UPDATE CASCADE

-- Tabla EstadoReserva
ALTER TABLE LOS_BORBOTONES.EstadoReserva
ADD CONSTRAINT FK_Usuario_EstadoReserva FOREIGN KEY(idUsuario) REFERENCES LOS_BORBOTONES.Usuario(idUsuario) ON DELETE CASCADE ON UPDATE CASCADE

ALTER TABLE LOS_BORBOTONES.EstadoReserva
ADD CONSTRAINT FK_Reserva_EstadoReserva FOREIGN KEY(idReserva) REFERENCES LOS_BORBOTONES.Reserva(idReserva)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Creacion Procedimiento Migracion Tabla Maestra

SELECT * INTO LOS_BORBOTONES.Inconsistencias FROM gd_esquema.Maestra WHERE 1 = 2; --se guardan en una tabla las inconsistencias

CREATE INDEX IDX_DIRECCION01 ON LOS_BORBOTONES.Direccion (Calle); --se crea indice a la tabla Direccion, el campo Calle
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga de  Roles Iniciales

INSERT INTO LOS_BORBOTONES.Rol (Nombre, Activo)
VALUES ('Administrador', 1), ('Recepcionista', 1), ('Guest', 1), ('RolDummy', 0);
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga de  Funcionalidades

INSERT INTO LOS_BORBOTONES.Funcionalidad (Descripcion)
VALUES ('ABMRol'), ('ABMReserva'), ('ABMUsuario'), ('ABMCliente'), ('ABMHotel'),
('ABMHabitacion'), ('ABMRégimenEstadía'), ('RegistrarEstadía'), ('RegistrarConsumible'), ('FacturarEstadía'), ('GenerarListadoEstadistico');
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Asociación Inicial Roles Funcionalidad

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMRol'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMUsuario'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMCliente'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMHotel'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMHabitacion'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMRégimenEstadía'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMReserva'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMReserva'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Guest'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'RegistrarEstadía'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Estos últimos tres permisos no están validados (inferimos los roles asociados a la funcionalidad)

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'RegistrarConsumible'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'FacturarEstadía'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'GenerarListadoEstadistico'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO
----------------------------------------------------------------------------- EN DESARROLLO ------------------------------------------------------------
-- MIGRACION Identidad 

SET IDENTITY_INSERT LOS_BORBOTONES.Identidad ON

INSERT INTO LOS_BORBOTONES.Identidad(Nombre, Apellido, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
	    SELECT  DISTINCT	Cliente_Nombre, Cliente_Apellido, Cliente_Pasaporte_Nro,  Cliente_Mail, Cliente_Fecha_Nac, Cliente_Nacionalidad
		FROM gd_esquema.Maestra
		WHERE Cliente_Nombre IS NOT NULL
		ORDER BY Cliente_Nombre;
		
SET IDENTITY_INSERT LOS_BORBOTONES.Identidad OFF
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
-- MIGRACION Direccion

INSERT INTO LOS_BORBOTONES.Direccion(Ciudad, Calle, NumeroCalle, Piso, Depto)
(	SELECT	DISTINCT NULL, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso, Cliente_Depto
	FROM gd_esquema.Maestra
	WHERE Cliente_Dom_Calle IS NOT NULL

UNION ALL
	SELECT	Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, NULL, NULL
	FROM gd_esquema.Maestra
	WHERE  Hotel_Calle IS NOT NULL
)	
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- MIGRACION Categoria

INSERT INTO LOS_BORBOTONES.Categoria(Estrellas, RecargaEstrellas) --tabla DER
		SELECT  Hotel_CantEstrella, Hotel_Recarga_Estrella
		FROM gd_esquema.Maestra

GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- MIGRACION Regimen

INSERT INTO LOS_BORBOTONES.Regimen(Descripcion, Precio, Estado)
		SELECT  Regimen_Descripcion, Regimen_Precio, 1
		FROM gd_esquema.maestra;

GO

--Habitacion

INSERT INTO LOS_BORBOTONES.Habitacion(Numero, Piso, Ubicacion) 
		SELECT m.Habitacion_Numero, m.Habitacion_Piso, m.Habitacion_Frente
		FROM gd_esquema.maestra m
		WHERE m.Habitacion_Numero IS NOT NULL;

GO
--TipoHabitacion 

INSERT INTO LOS_BORBOTONES.TipoHabitacion(Codigo, Descripcion, Porcentual) 
		SELECT m.Habitacion_Tipo_Codigo, m.Habitacion_Tipo_Descripcion, m.Habitacion_Tipo_Porcentual
		FROM gd_esquema.maestra m
		WHERE m.Habitacion_Tipo_Codigo IS NOT NULL;

GO

--Reserva

INSERT INTO LOS_BORBOTONES.Reserva(CodigoReserva, FechaCreacion, DiasAlojados) 
		SELECT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches
		FROM gd_esquema.maestra m
		WHERE m.Reserva_Codigo IS NOT NULL;
	
GO

--Estadia

INSERT INTO LOS_BORBOTONES.Estadia(FechaEntrada, DiasAlojados) 
		SELECT m.Estadia_Fecha_Inicio, m.Estadia_Cant_Noches
		FROM gd_esquema.maestra m;

GO

--Consumible

INSERT INTO LOS_BORBOTONES.Consumible(Codigo, Descripcion, Precio)
		SELECT m.Consumible_Codigo, m.Consumible_Descripcion, m.Consumible_Precio
		FROM gd_esquema.maestra m;

GO

--ItemFactura

INSERT INTO LOS_BORBOTONES.ItemFactura(Cantidad, Monto)
		SELECT m.Item_Factura_Cantidad, m.Item_Factura_Monto
		FROM gd_esquema.maestra m;

GO

--Factura

INSERT INTO LOS_BORBOTONES.Factura(NumeroFactura, FechaFacturacion, Total)
		SELECT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total
		FROM gd_esquema.maestra m
		WHERE m.Factura_Nro IS NOT NULL;

GO








		