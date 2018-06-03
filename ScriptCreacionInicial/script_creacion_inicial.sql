---------------------------------------------- Creacion del Modelo de Datos --------------------------------------------------------------------
USE GD1C2018
GO

---------------------------------------------- Eliminacion de Tablas ----------------------------------------------------------------------------
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

---------------------------------------------------------------------- Eliminacion de schema LOS_BORBOTONES --------------------------------------------------------------------------
IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'LOS_BORBOTONES')
    DROP SCHEMA LOS_BORBOTONES;
GO
	
--Creación Inicial del Esquema
CREATE SCHEMA LOS_BORBOTONES AUTHORIZATION gdHotel2018;
GO

-----------------------------------------------------------------------Creacion Tablas---------------------------------------------------------------------------------------------------------
--Tabla Rol
CREATE TABLE LOS_BORBOTONES.Rol (

	idRol	INT			IDENTITY(1,1)	NOT NULL		UNIQUE,
	Nombre	VARCHAR(45) 				NOT NULL,
	Activo	BIT							NOT NULL,
)
GO

-- Tabla Funcionalidad
CREATE TABLE LOS_BORBOTONES.Funcionalidad (

	idFuncionalidad	INT			IDENTITY(1,1)	NOT NULL,
	Descripcion 	VARCHAR(45)					NOT NULL,
)
GO

--Tabla Asociación Funcionalidad - Rol
CREATE TABLE LOS_BORBOTONES.Funcionalidad_X_Rol (

	idFuncionalidad	INT			NOT NULL,
	idRol			INT			NOT NULL,		
)
GO

--Tabla Identidad 
CREATE TABLE LOS_BORBOTONES.Identidad (

	idIdentidad				INT				IDENTITY(1,1)		NOT NULL,
	TipoIdentidad			VARCHAR(45),		
	Nombre					NVARCHAR(255),
	Apellido				NVARCHAR(255),
	TipoDocumento			VARCHAR(45),
	NumeroDocumento			VARCHAR(45),
	Mail					NVARCHAR(255),
	FechaNacimiento			DATETIME,
	Nacionalidad			NVARCHAR(255),
	Telefono				VARCHAR(45)		DEFAULT 0,
)
GO

--Tabla Direccion
CREATE TABLE LOS_BORBOTONES.Direccion (

	idDireccion		INT				IDENTITY(1,1)				NOT NULL,
	Pais			VARCHAR(45)		DEFAULT 'Argentina',
	Ciudad			NVARCHAR(255),
	Calle			NVARCHAR(255),
	NumeroCalle		INT,
	Piso			INT,
	Depto			NVARCHAR(50),
	idIdentidad		INT,	--se quito la especificacion not null
)
GO

--Tabla Usuario 
CREATE TABLE LOS_BORBOTONES.Usuario (

	idUsuario				INT			IDENTITY(1,1)	NOT NULL,
	Username				VARCHAR(45),
	Password				VARCHAR(45),
	IntentosFallidosLogin	INT			DEFAULT 0,
	Activo					BIT			DEFAULT 1,
	idIdentidad				INT			NOT NULL,
)
GO

--Tabla Asociacion Rol - Usuario
CREATE TABLE LOS_BORBOTONES.Rol_X_Usuario (

	idRol			INT			NOT NULL,
	idUsuario		INT			NOT NULL,	
)
GO

--Tabla Cliente
CREATE TABLE LOS_BORBOTONES.Cliente (

	idCliente		INT				IDENTITY(1,1)	NOT NULL,
	Activo			BIT,
	idIdentidad		INT				NOT NULL,
)
GO

--Tabla Categoria
CREATE TABLE LOS_BORBOTONES.Categoria (

	idCategoria			INT		IDENTITY(1,1)	NOT NULL,
	Estrellas			INT,
	RecargaEstrellas	NUMERIC(18,2)
)
GO

-- Tabla Hotel
CREATE TABLE LOS_BORBOTONES.Hotel (

	idHotel					INT					IDENTITY(1,1)		  NOT NULL	UNIQUE, 
	Nombre					NVARCHAR(255),
	Mail					NVARCHAR(255),
	Telefono				VARCHAR(45),
	FechaInicioActividades	DATETIME,
	idCategoria				INT					NOT NULL,
	idDireccion				INT					NOT NULL,
)
GO

--Tabla Asociacion Hotel - Usuario
CREATE TABLE LOS_BORBOTONES.Hotel_X_Usuario (

	idHotel			INT			NOT NULL,
	idUsuario		INT			NOT NULL,
)
GO

--Tabla CierreTemporal
CREATE TABLE LOS_BORBOTONES.CierreTemporal (

	idEstadoHotel	INT				IDENTITY(1,1)	NOT NULL,
	FechaInicio		VARCHAR(45),
	FechaFin		VARCHAR(45),
	Descripcion		VARCHAR(45),
	idHotel			INT				NOT NULL,	
)
GO

--Tabla Regimen
CREATE TABLE LOS_BORBOTONES.Regimen (
	
	idRegimen		INT				IDENTITY(1,1)	NOT NULL,
	Codigo			VARCHAR(45)		DEFAULT 'RC117',		
	Descripcion		NVARCHAR(255),
	Precio			NUMERIC(18,2),
	Estado			VARCHAR(45),
	idHotel			INT				NOT NULL,
)
GO

--Tabla TipoHabitacion
CREATE TABLE LOS_BORBOTONES.TipoHabitacion (

	idTipoHabitacion	INT				IDENTITY(1,1)	NOT NULL,
	Codigo				VARCHAR(45),
	Descripcion			VARCHAR(45),
	Porcentual			VARCHAR(45),	
)
GO

--Tabla Habitacion
CREATE TABLE LOS_BORBOTONES.Habitacion (

	idHabitacion		INT				IDENTITY(1,1)	NOT NULL,
	Activa				BIT				DEFAULT 1,
	Numero				NUMERIC(18,0),
	Piso				NUMERIC(18,0),
	Ubicacion			NVARCHAR(50),
	idHotel				INT				NOT NULL,
	idTipoHabitacion	INT				NOT NULL,	
)
GO

-- Tabla Estadia
CREATE TABLE LOS_BORBOTONES.Estadia (

	idEstadia		INT			IDENTITY(1,1)	NOT NULL		UNIQUE,
	FechaEntrada	DATETIME,
	FechaSalida		DATETIME,
	Facturada		BIT			DEFAULT 1,
	idUsuarioIn		INT			NOT NULL,
	idUsuarioOut	INT			NOT NULL,
		
)
GO

-- Tabla Reserva
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

-- Tabla Asociacion Reserva - Habitacion - Cliente
CREATE TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente (

	idReserva		INT		NOT NULL,
	idHabitacion	INT		NOT NULL,
	idCliente		INT		NOT NULL,
)
GO

-- Tabla Factura
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

-- Tabla Consumible
CREATE TABLE LOS_BORBOTONES.Consumible (

	idConsumible		INT				IDENTITY(1,1)	NOT NULL,
	Codigo				NUMERIC(18,0),
	Descripcion			NVARCHAR(255),
	Precio				NUMERIC(18,2),
)
GO

-- Tabla ItemFactura
CREATE TABLE LOS_BORBOTONES.ItemFactura (

		idItemFactura		INT				IDENTITY(1,1)	NOT NULL,
		Cantidad			NUMERIC(18,0),
		Monto				NUMERIC(18,2),
		FechaCreacion		DATETIME		DEFAULT GETDATE(),
		idFactura			INT				NOT NULL,
		idConsumible		INT				NOT NULL,		
)
GO

-- Tabla Asociacion Estadia - Consumible
CREATE TABLE LOS_BORBOTONES.Estadia_X_Consumible (

	idEstadia		INT,
	idConsumible	INT		NOT NULL,
)
GO

-- Tabla EstadoReserva
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
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Carga Usuarios en la tabla Identidad
INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, TipoDocumento, NumeroDocumento, Mail)
	   VALUES('Usuario', 'admin', 'DNI', '30213210',  'admin@frba_utn.com')
GO

INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, TipoDocumento, NumeroDocumento, Mail)
	   VALUES('Usuario', 'guest', 'DNI', '33417682',  'soporte2@frba_utn.com')
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- defini solo Usuarios admin y guest, por ahora
INSERT INTO LOS_BORBOTONES.Usuario (Username,Password, idIdentidad)
	VALUES ('admin','1234', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE Nombre like 'admin' and TipoIdentidad = 'Usuario'));
GO

INSERT INTO LOS_BORBOTONES.Usuario (Username,Password, idIdentidad)
	VALUES ('guest','01', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE nombre like 'guest' and TipoIdentidad = 'Usuario'));
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga Rol_X_Usuario
INSERT INTO LOS_BORBOTONES.Rol_X_Usuario (idRol, idUsuario)
VALUES ((SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'administrador'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'admin'));
GO

INSERT INTO LOS_BORBOTONES.Rol_X_Usuario (idRol, idUsuario)
VALUES ((SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'guest'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'guest'));
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- MIGRACION Identidad

INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, Apellido, TipoDocumento, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
	   SELECT  DISTINCT	'Cliente', Cliente_Nombre, Cliente_Apellido, 'Pasaporte', Cliente_Pasaporte_Nro,  Cliente_Mail, Cliente_Fecha_Nac, Cliente_Nacionalidad
		FROM gd_esquema.Maestra
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
-- MIGRACION Direccion 

INSERT INTO LOS_BORBOTONES.Direccion(Ciudad, Calle, NumeroCalle, Piso, Depto, idIdentidad)
(
	SELECT	DISTINCT  NULL, m.Cliente_Dom_Calle, m.Cliente_Nro_Calle, m.Cliente_Piso, m.Cliente_Depto, i.idIdentidad
	FROM gd_esquema.Maestra m, LOS_BORBOTONES.Identidad i
	WHERE i.NumeroDocumento = m.Cliente_Pasaporte_Nro

UNION ALL 
	SELECT	DISTINCT Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, NULL, NULL, NULL
	FROM gd_esquema.Maestra 
)	
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- MIGRACION Categoria 

INSERT INTO LOS_BORBOTONES.Categoria(Estrellas, RecargaEstrellas) 
		SELECT  Hotel_CantEstrella, Hotel_Recarga_Estrella
		FROM gd_esquema.Maestra
		GROUP BY Hotel_CantEstrella, Hotel_Recarga_Estrella

GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Migracion y Carga de Hotel
--Se define como FechaInicioActividades, la fecha actual y como Nombre del Hotel Calle+NroCalle
 
 INSERT INTO LOS_BORBOTONES.Hotel (idCategoria, Nombre, FechaInicioActividades, idDireccion)
	  SELECT c.idCategoria, CONCAT(d.Calle, d.NumeroCalle) AS Nombre, GETDATE(), d.idDireccion 
	  FROM LOS_BORBOTONES.Categoria c
	  JOIN  gd_esquema.Maestra m ON m.Hotel_CantEstrella = c.Estrellas AND m.Hotel_Recarga_Estrella = c.RecargaEstrellas
	  JOIN LOS_BORBOTONES.Direccion d ON m.Hotel_Ciudad = d.Ciudad AND m.Hotel_Calle = d.Calle AND m.Hotel_Nro_Calle = d.NumeroCalle
	  WHERE d.Ciudad IS NOT NULL
	  GROUP BY c.idCategoria, d.idDireccion, CONCAT(d.Calle, d.NumeroCalle)	 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	  
--Carga Hotel_X_Usuario
--definir condicion: a que usuarios le corresponden que hoteles
INSERT INTO LOS_BORBOTONES.Hotel_X_Usuario (idHotel, idUsuario)
VALUES ((SELECT idHotel FROM LOS_BORBOTONES.Hotel WHERE Nombre like '%Alicia%'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'admin'));
GO

INSERT INTO LOS_BORBOTONES.Hotel_X_Usuario (idHotel, idUsuario)
VALUES ((SELECT idHotel FROM LOS_BORBOTONES.Hotel WHERE Nombre like '%Warnes%'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'admin'));
GO

INSERT INTO LOS_BORBOTONES.Hotel_X_Usuario (idHotel, idUsuario)
VALUES ((SELECT idHotel FROM LOS_BORBOTONES.Hotel WHERE Nombre like '%Justo17%'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'admin'));
GO

INSERT INTO LOS_BORBOTONES.Hotel_X_Usuario (idHotel, idUsuario)
VALUES ((SELECT idHotel FROM LOS_BORBOTONES.Hotel WHERE Nombre like '%Quintana%'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'admin'));
GO

INSERT INTO LOS_BORBOTONES.Hotel_X_Usuario (idHotel, idUsuario)
VALUES ((SELECT idHotel FROM LOS_BORBOTONES.Hotel WHERE Nombre like '%Medrano%'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'admin'));
GO

INSERT INTO LOS_BORBOTONES.Hotel_X_Usuario (idHotel, idUsuario)
VALUES ((SELECT idHotel FROM LOS_BORBOTONES.Hotel WHERE Nombre like '%Balcarce%'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'guest'));
GO

INSERT INTO LOS_BORBOTONES.Hotel_X_Usuario (idHotel, idUsuario)
VALUES ((SELECT idHotel FROM LOS_BORBOTONES.Hotel WHERE Nombre like '%Justo14%'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'guest'));
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga CLIENTE
INSERT INTO LOS_BORBOTONES.Cliente(idIdentidad, Activo) 
		SELECT idIdentidad, 1
		FROM LOS_BORBOTONES.Identidad
		WHERE TipoIdentidad = 'Cliente'
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- MIGRACION Regimen
-- en principio se puso como Estado Disponible a todos los regimenes
INSERT INTO LOS_BORBOTONES.Regimen(Descripcion, Precio, Estado, idHotel)
		SELECT  m.Regimen_Descripcion, m.Regimen_Precio, 'Disponible', h.idHotel
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Hotel h
		GROUP BY h.idHotel, m.Regimen_Descripcion, m.Regimen_Precio
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga CierreTemporal
--las fechas estan en el DER como tipo VARCHAR, se quedan asi? o como DATETIME
-- Se define por el momento Descripcion = 'Mantenimiento'
INSERT INTO LOS_BORBOTONES.CierreTemporal(Descripcion, idHotel)
		SELECT  'Mantenimiento', idHotel
		FROM LOS_BORBOTONES.Hotel
		WHERE FechaInicioActividades <= GETDATE() 
		GROUP BY idHotel
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Migracion Estadia
-- Mejorarlo con una funcion
 --El campo Facturada por defecto, inicia en 1

INSERT INTO LOS_BORBOTONES.Estadia(FechaEntrada, FechaSalida, idUsuarioIn, idUsuarioOut) 
		SELECT m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio), 1, 1
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Usuario u
		WHERE m.Estadia_Fecha_Inicio IS NOT NULL AND m.Estadia_Fecha_Inicio < GETDATE()
		GROUP BY  m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio)
GO

INSERT INTO LOS_BORBOTONES.Estadia(FechaEntrada, FechaSalida, idUsuarioIn, idUsuarioOut) 
		SELECT m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio), 2, 2
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Usuario u
		WHERE m.Estadia_Fecha_Inicio IS NOT NULL AND m.Estadia_Fecha_Inicio > GETDATE()
		GROUP BY  m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio)
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Migracion Consumible

INSERT INTO LOS_BORBOTONES.Consumible(Codigo, Descripcion, Precio)
		SELECT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
		FROM gd_esquema.maestra 
		WHERE Consumible_Codigo IS NOT NULL
		GROUP BY Consumible_Codigo, Consumible_Descripcion, Consumible_Precio;
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Asociacion Estadia_X_Consumible
-- mejorarlo cob una funcion
INSERT INTO LOS_BORBOTONES.Estadia_X_Consumible (idEstadia, idConsumible)
VALUES ((SELECT idEstadia FROM LOS_BORBOTONES.Estadia WHERE FechaSalida = CONVERT(datetime, '2017-01-06 00:00:00.000', 121)),(SELECT idConsumible FROM LOS_BORBOTONES.Consumible WHERE Descripcion = 'Agua Mineral'));
GO

INSERT INTO LOS_BORBOTONES.Estadia_X_Consumible (idEstadia, idConsumible)
VALUES ((SELECT idEstadia FROM LOS_BORBOTONES.Estadia WHERE FechaSalida = CONVERT(datetime, '2017-01-06 00:00:00.000', 121)),(SELECT idConsumible FROM LOS_BORBOTONES.Consumible WHERE Descripcion = 'Whisky'));
GO

INSERT INTO LOS_BORBOTONES.Estadia_X_Consumible (idEstadia, idConsumible)
VALUES ((SELECT idEstadia FROM LOS_BORBOTONES.Estadia WHERE FechaSalida = CONVERT(datetime, '2017-08-19 00:00:00.000', 121)),(SELECT idConsumible FROM LOS_BORBOTONES.Consumible WHERE Descripcion = 'Coca Cola'));
GO

INSERT INTO LOS_BORBOTONES.Estadia_X_Consumible (idEstadia, idConsumible)
VALUES ((SELECT idEstadia FROM LOS_BORBOTONES.Estadia WHERE FechaSalida = CONVERT(datetime, '2017-08-19 00:00:00.000', 121)),(SELECT idConsumible FROM LOS_BORBOTONES.Consumible WHERE Descripcion = 'Bonbones'));
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Migracion TipoHabitacion

INSERT INTO LOS_BORBOTONES.TipoHabitacion(Codigo, Descripcion, Porcentual) 
		SELECT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
		FROM gd_esquema.maestra
		WHERE Habitacion_Tipo_Codigo IS NOT NULL
		GROUP BY Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual;

GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Migracion Habitacion

INSERT INTO LOS_BORBOTONES.Habitacion(Numero, Piso, Ubicacion, idHotel, idTipoHabitacion) 
		SELECT m.Habitacion_Numero, m.Habitacion_Piso, m.Habitacion_Frente, h.idHotel, t.idTipoHabitacion
		FROM LOS_BORBOTONES.Hotel h
		JOIN gd_esquema.maestra m ON CONCAT(m.Hotel_Calle, Hotel_Nro_Calle) = h.Nombre
		JOIN LOS_BORBOTONES.TipoHabitacion t ON m.Habitacion_Tipo_Codigo = t.Codigo
		WHERE t.Codigo IS NOT NULL
		GROUP BY m.Habitacion_Numero, m.Habitacion_Piso, m.Habitacion_Frente, h.idHotel, t.idTipoHabitacion
GO
---------------------------------------------------EN DESARROLLO---------------------------------------------------------------------------------------------------------------------------
--Migracion Reserva

SET IDENTITY_INSERT LOS_BORBOTONES.Reserva ON

INSERT INTO LOS_BORBOTONES.Reserva(CodigoReserva, FechaCreacion, DiasAlojados, idHotel, idEstadia, idRegimen, idCliente) 
		SELECT  DISTINCT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches, h.idHotel, e.idEstadia, r.idRegimen, c.idCliente
		FROM LOS_BORBOTONES.Hotel h, gd_esquema.maestra m, LOS_BORBOTONES.Estadia e, LOS_BORBOTONES.Regimen r, LOS_BORBOTONES.Cliente c, LOS_BORBOTONES.Identidad i
		WHERE CONCAT(m.Hotel_Calle, Hotel_Nro_Calle) = h.Nombre
		AND m.Estadia_Cant_Noches = DATEDIFF(DAY, e.FechaEntrada, e.FechaSalida)
		AND m.Regimen_Descripcion = r.Descripcion
		AND m.Cliente_Pasaporte_Nro = i.NumeroDocumento
		AND c.idCliente IS NOT NULL			
		ORDER BY  m.Reserva_Codigo
GO

SET IDENTITY_INSERT LOS_BORBOTONES.Reserva OFF
	

------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Migracion Factura

INSERT INTO LOS_BORBOTONES.Factura(NumeroFactura, FechaFacturacion, Total, e.idEstadia, r.idReserva)
		SELECT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, e.idEstadia, r.idEstadia
		FROM  LOS_BORBOTONES.Estadia e
		JOIN gd_esquema.maestra m ON  m.Estadia_Cant_Noches = DATEDIFF(DAY, e.FechaEntrada, e.FechaSalida)
		JOIN LOS_BORBOTONES.Reserva r ON  m.Reserva_Codigo = r.CodigoReserva
		GROUP BY m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, e.idEstadia, r.idEstadia
GO

--ItemFactura

INSERT INTO LOS_BORBOTONES.ItemFactura(Cantidad, Monto)
		SELECT m.Item_Factura_Cantidad, m.Item_Factura_Monto
		FROM gd_esquema.maestra m;

GO


-----------------------------------


--Carga EstadoReserva

INSERT INTO LOS_BORBOTONES.EstadoReserva (TipoEstado, Fecha, Descripcion, idUsuario, idReserva)
	VALUES ('RC', GETDATE(), 'RESERVA CORRECTA', (SELECT idUsuario FROM LOS_BORBOTONES.Usuario), (SELECT idReserva FROM LOS_BORBOTONES.Reserva));
GO

INSERT INTO LOS_BORBOTONES.EstadoReserva (TipoEstado, Fecha, Descripcion, idUsuario, idReserva)
	VALUES ('RM', GETDATE(), 'RESERVA MODIFICADA', (SELECT idUsuario FROM LOS_BORBOTONES.Usuario), (SELECT idReserva FROM LOS_BORBOTONES.Reserva));
GO

INSERT INTO LOS_BORBOTONES.EstadoReserva (TipoEstado, Fecha, Descripcion, idUsuario, idReserva)
	VALUES ('RCR', GETDATE(),'RESERVA CANCELADA POR RECEPCION', (SELECT idUsuario FROM LOS_BORBOTONES.Usuario), (SELECT idReserva FROM LOS_BORBOTONES.Reserva));
GO

INSERT INTO LOS_BORBOTONES.EstadoReserva (TipoEstado, Fecha, Descripcion, idUsuario, idReserva)
	VALUES ('RCC', GETDATE(), 'RESERVA CANCELADA POR CLIENTE', (SELECT idUsuario FROM LOS_BORBOTONES.Usuario), (SELECT idReserva FROM LOS_BORBOTONES.Reserva));
GO

INSERT INTO LOS_BORBOTONES.EstadoReserva (TipoEstado, Fecha, Descripcion, idUsuario, idReserva)
	VALUES ('RA', GETDATE(), 'RESERVA ABONADA', (SELECT idUsuario FROM LOS_BORBOTONES.Usuario), (SELECT idReserva FROM LOS_BORBOTONES.Reserva));	
GO






		