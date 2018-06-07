---------------------------------------------- Creacion del Modelo de Datos --------------------------------------------------------------------
USE GD1C2018
GO
---------------------------------------------- DROPEO DE FK CONSTRAINTS ----------------------------------------------

-- Tabla Funcionalidad_X_Rol 
IF OBJECT_ID('LOS_BORBOTONES.FK_Funcionalidad_Rol', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Funcionalidad_X_Rol
	DROP CONSTRAINT FK_Funcionalidad_Rol 
GO

IF OBJECT_ID('LOS_BORBOTONES.FK_Rol_Funcionalidad', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Funcionalidad_X_Rol
	DROP CONSTRAINT FK_Rol_Funcionalidad 
GO

-- Tabla Direccion
IF OBJECT_ID('LOS_BORBOTONES.FK_Identidad_Direccion', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Direccion
	DROP CONSTRAINT FK_Identidad_Direccion 
GO

-- Tabla Usuario
IF OBJECT_ID('LOS_BORBOTONES.FK_Identidad_Usuario', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Usuario
	DROP CONSTRAINT FK_Identidad_Usuario 
GO

-- Tabla Rol_X_Usuario
	IF OBJECT_ID('LOS_BORBOTONES.FK_Rol_Usuario', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Rol_X_Usuario
	DROP CONSTRAINT FK_Rol_Usuario 
GO

IF OBJECT_ID('LOS_BORBOTONES.FK_Usuario_Rol', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Rol_X_Usuario
	DROP CONSTRAINT FK_Usuario_Rol 
GO

-- Tabla Cliente
IF OBJECT_ID('LOS_BORBOTONES.FK_Identidad_Cliente', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Cliente
	DROP CONSTRAINT FK_Identidad_Cliente 
GO

-- Tabla Hotel
IF OBJECT_ID('LOS_BORBOTONES.FK_Hotel_Categoria', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Hotel
	DROP CONSTRAINT FK_Hotel_Categoria 
GO

IF OBJECT_ID('LOS_BORBOTONES.FK_Hotel_Direccion', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Hotel
	DROP CONSTRAINT FK_Hotel_Direccion 
GO

-- Tabla Hotel_X_Usuario
IF OBJECT_ID('LOS_BORBOTONES.FK_Hotel_Usuario', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Hotel_X_Usuario
	DROP CONSTRAINT FK_Hotel_Usuario
GO

IF OBJECT_ID('LOS_BORBOTONES.FK_Usuario_Hotel', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Hotel_X_Usuario
	DROP CONSTRAINT FK_Usuario_Hotel
GO

-- Tabla CierreTemporal
IF OBJECT_ID('LOS_BORBOTONES.FK_CierreTemporal_Hotel', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.CierreTemporal
	DROP CONSTRAINT FK_CierreTemporal_Hotel 
GO

-- Tabla Regimen
IF OBJECT_ID('LOS_BORBOTONES.FK_Regimen_Hotel', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Regimen
	DROP CONSTRAINT FK_Regimen_Hotel 
GO

-- Tabla Habitacion
IF OBJECT_ID('LOS_BORBOTONES.FK_Hotel_Habitacion', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Habitacion
	DROP CONSTRAINT FK_Hotel_Habitacion 
GO

IF OBJECT_ID('LOS_BORBOTONES.FK_Hotel_TipoHabitacion', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Habitacion
	DROP CONSTRAINT FK_Hotel_TipoHabitacion
GO

-- Tabla Estadia
IF OBJECT_ID('LOS_BORBOTONES.FK_Usuario_CheckIn', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Estadia
	DROP CONSTRAINT FK_Usuario_CheckIn 
GO
	
IF OBJECT_ID('LOS_BORBOTONES.FK_Usuario_CheckOut', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Estadia
	DROP CONSTRAINT FK_Usuario_CheckOut
GO
	
-- Tabla Reserva
IF OBJECT_ID('LOS_BORBOTONES.FK_Estadia_Reserva', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Reserva
	DROP CONSTRAINT FK_Estadia_Reserva 
GO
	
IF OBJECT_ID('LOS_BORBOTONES.FK_Regimen_Reserva', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Reserva
	DROP CONSTRAINT FK_Regimen_Reserva 
GO
	
IF OBJECT_ID('LOS_BORBOTONES.FK_Identidad_Reserva', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Reserva
	DROP CONSTRAINT FK_Identidad_Reserva
GO
	
-- Tabla  Reserva_X_Habitacion_X_Cliente 
IF OBJECT_ID('LOS_BORBOTONES.FK_Reserva_Habitacion_Cliente', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente
	DROP CONSTRAINT FK_Reserva_Habitacion_Cliente 
GO
	
IF OBJECT_ID('LOS_BORBOTONES.FK_Habitacion_X_Cliente_X_Reserva', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente
	DROP CONSTRAINT FK_Habitacion_X_Cliente_X_Reserva
GO
	
IF OBJECT_ID('LOS_BORBOTONES.FK_Cliente_X_Habitacion_Reserva', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente
	DROP CONSTRAINT FK_Cliente_X_Habitacion_Reserva 
GO
	
-- Tabla Factura
IF OBJECT_ID('LOS_BORBOTONES.FK_Estadia_Factura', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Factura
	DROP CONSTRAINT FK_Estadia_Factura 
GO
	
IF OBJECT_ID('LOS_BORBOTONES.FK_Reserva_Factura', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Factura
	DROP CONSTRAINT FK_Reserva_Factura 
GO
	
-- Tabla ItemFactura
IF OBJECT_ID('LOS_BORBOTONES.FK_ItemFactura_Factura', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.ItemFactura
	DROP CONSTRAINT FK_ItemFactura_Factura
GO
	
IF OBJECT_ID('LOS_BORBOTONES.FK_itemFactura_Consumible', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.ItemFactura
	DROP CONSTRAINT FK_itemFactura_Consumible 
GO
	
-- Tabla Estadia_X_Consumible 
IF OBJECT_ID('LOS_BORBOTONES.FK_Estadia_Consumible', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Estadia_X_Consumible
	DROP CONSTRAINT FK_Estadia_Consumible 
GO
	
IF OBJECT_ID('LOS_BORBOTONES.FK_Consumible_Estadia', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Estadia_X_Consumible
	DROP CONSTRAINT FK_Consumible_Estadia 
GO
	
-- Tabla EstadoReserva
IF OBJECT_ID('LOS_BORBOTONES.FK_Usuario_EstadoReserva', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.EstadoReserva
	DROP CONSTRAINT FK_Usuario_EstadoReserva 
GO
	
IF OBJECT_ID('LOS_BORBOTONES.FK_Reserva_EstadoReserva', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.EstadoReserva
	DROP CONSTRAINT FK_Reserva_EstadoReserva 
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

IF OBJECT_ID('LOS_BORBOTONES.Reserva','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Reserva;
GO

-- Tabla Temporal ReservaTemporal,  eliminando si existe
IF OBJECT_ID('LOS_BORBOTONES.ReservaTemporal', 'U') IS NOT NULL
DROP TABLE LOS_BORBOTONES.ReservaTemporal;
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
	Username				VARCHAR(255),
	Password				VARCHAR(255),
	IntentosFallidosLogin	INT			DEFAULT 0, --se modifica tipo de dato
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
	Activo			BIT,
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

	idReserva		INT				IDENTITY(0001,1)	NOT NULL	UNIQUE,
	CodigoReserva	NUMERIC(18,0),
	FechaCreacion	DATETIME,
	FechaDesde		DATETIME,
	FechaHasta		DATETIME,
	DiasAlojados	NUMERIC(18,0),
	idHotel			INT				NOT NULL,
	idEstadia		INT				NOT NULL,
	idRegimen		INT				NOT NULL,
	--idCliente		INT				NOT NULL,
	idIdentidad		INT				NOT NULL,
)
GO

-- Tabla Asociacion Reserva - Habitacion - Cliente
CREATE TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente (

	idReserva		INT		UNIQUE 		NOT NULL,
	idHabitacion	INT		NOT NULL,
	idCliente		INT		NOT NULL,
)
GO

-- Tabla Factura
CREATE TABLE LOS_BORBOTONES.Factura (

	idFactura			INT			IDENTITY(00001, 1)		NOT NULL,
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

-- creando la tabla temporal RESERVA
CREATE TABLE LOS_BORBOTONES.ReservaTemporal (
	  Reserva_Codigo  NUMERIC(18,0) IDENTITY(1001, 1) 	UNIQUE 	NOT NULL
	  ,Reserva_Fecha_Inicio DATETIME
      ,Reserva_Cant_Noches NUMERIC(18,0)
	  ,Hotel_Calle NVARCHAR(255)
	  ,Hotel_Nro_Calle NVARCHAR(255)
	  ,Estadia_Fecha_Inicio DATETIME
	  ,Estadia_Cant_Noches INT
      ,Regimen_Descripcion NVARCHAR(255)
      ,Cliente_Pasaporte_Nro VARCHAR(45)
);
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

--Tabla temporal ReservaTemporal
ALTER TABLE LOS_BORBOTONES.ReservaTemporal
ADD CONSTRAINT PK_ReservaTemporal_Reserva_Codigo PRIMARY KEY (Reserva_Codigo)

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
--ADD CONSTRAINT FK_Cliente_Reserva FOREIGN KEY(idCliente) REFERENCES LOS_BORBOTONES.Cliente(idCliente)
ADD CONSTRAINT FK_Identidad_Reserva FOREIGN KEY(idIdentidad) REFERENCES LOS_BORBOTONES.Identidad(idIdentidad)

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

------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
--------------------------------------FIN CREACION----------------------------------------------------
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------
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
('ABMHabitacion'), ('ABMRegimenEstadia'), ('RegistrarEstadia'), ('RegistrarConsumible'), ('FacturarEstadia'), ('GenerarListadoEstadistico');
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
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMRegimenEstadia'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMReserva'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMReserva'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Guest'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'RegistrarEstadia'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Estos últimos tres permisos no están validados (inferimos los roles asociados a la funcionalidad)

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'RegistrarConsumible'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'FacturarEstadia'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'GenerarListadoEstadistico'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Genero Identidad de los Usuarios

INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, Apellido, TipoDocumento, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
	   VALUES('Usuario', 'Jose', 'Perez', 'DNI', '30213210',  'admin@frba_utn.com', '1968-01-09 00:00:00.000', 'ARGENTINO')
GO

INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, Apellido, TipoDocumento, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
	   VALUES('Usuario', 'Alberto', 'Mandinga', 'DNI', '18217283',  'soporte2@frba_utn.com', '1998-05-05 00:00:00.000', 'PERUANO')
GO

INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, Apellido, TipoDocumento, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
	   VALUES('Usuario', 'Carolina', 'Mengoche', 'DNI', '17309573',  'recepcionista@frba_utn.com', '1988-09-11 00:00:00.000', 'COLOMBIANO')
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- La password es 1234 para todos los usuarios
INSERT INTO LOS_BORBOTONES.Usuario (Username,Password, idIdentidad)
	VALUES ('admin','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '30213210' and TipoIdentidad = 'Usuario'));
GO

INSERT INTO LOS_BORBOTONES.Usuario (Username,Password, idIdentidad)
	VALUES ('guest','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '18217283' and TipoIdentidad = 'Usuario'));
GO

INSERT INTO LOS_BORBOTONES.Usuario (Username,Password, idIdentidad)
	VALUES ('recepcionista','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '17309573' and TipoIdentidad = 'Usuario'));
GO

--Carga Rol_X_Usuario
INSERT INTO LOS_BORBOTONES.Rol_X_Usuario (idRol, idUsuario)
	VALUES ((SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'administrador'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'admin'));
GO

INSERT INTO LOS_BORBOTONES.Rol_X_Usuario (idRol, idUsuario)
	VALUES ((SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'guest'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'guest'));
GO

INSERT INTO LOS_BORBOTONES.Rol_X_Usuario (idRol, idUsuario)
	VALUES ((SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'recepcionista'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'recepcionista'));
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
/*
--TEST CASES: Carga de Hoteles con sus habitaciones y reservas
SET IDENTITY_INSERT LOS_BORBOTONES.Direccion ON
INSERT INTO LOS_BORBOTONES.Direccion (idDireccion,Pais,Ciudad,Calle,NumeroCalle)
VALUES (1,'SQL-PAIS','SQL-CIUDAD','SQL-CALLE',123);
GO
SET IDENTITY_INSERT LOS_BORBOTONES.Direccion OFF

SET IDENTITY_INSERT LOS_BORBOTONES.Categoria ON
INSERT INTO LOS_BORBOTONES.Categoria(idCategoria,Estrellas,RecargaEstrellas)
VALUES (1,5,10);
GO
SET IDENTITY_INSERT LOS_BORBOTONES.Categoria OFF

SET IDENTITY_INSERT LOS_BORBOTONES.Hotel ON
INSERT INTO LOS_BORBOTONES.Hotel (idHotel, Nombre,Mail,Telefono,FechaInicioActividades,idCategoria,idDireccion)
VALUES (1,'SQL-NOMBRE','SQL-MAIL','SQL-TELEFONO',GETDATE(),1,1)
GO
SET IDENTITY_INSERT LOS_BORBOTONES.Hotel OFF

SET IDENTITY_INSERT LOS_BORBOTONES.TipoHabitacion ON
INSERT INTO LOS_BORBOTONES.TipoHabitacion(idTipoHabitacion, Codigo,Descripcion,Porcentual)
VALUES (1,'SQL-CODIGO-1','SQL-DESCRIPCION-1','SQL-PORCENTUAL-1')
GO
INSERT INTO LOS_BORBOTONES.TipoHabitacion(idTipoHabitacion, Codigo,Descripcion,Porcentual)
VALUES (2,'SQL-CODIGO-2','SQL-DESCRIPCION-2','SQL-PORCENTUAL-2')
GO
SET IDENTITY_INSERT LOS_BORBOTONES.TipoHabitacion OFF

SET IDENTITY_INSERT LOS_BORBOTONES.Habitacion ON
INSERT INTO LOS_BORBOTONES.Habitacion(idHabitacion, Activa,Numero,Piso,Ubicacion,idHotel,idTipoHabitacion)
VALUES (1,1,11,1,'SQL-UBICACION-HAB-1',1,1)
GO
INSERT INTO LOS_BORBOTONES.Habitacion(idHabitacion, Activa,Numero,Piso,Ubicacion,idHotel,idTipoHabitacion)
VALUES (2,1,12,1,'SQL-UBICACION-HAB-2',1,2)
GO
SET IDENTITY_INSERT LOS_BORBOTONES.Habitacion OFF

SET IDENTITY_INSERT LOS_BORBOTONES.Regimen ON
INSERT INTO LOS_BORBOTONES.Regimen(idRegimen, Codigo,Descripcion,Precio,Estado,idHotel)
VALUES (1,'SQL-CODIGO-REG-1','SQL-DESCRIPCION-REG-1',10,'SQL-ESTADO-REG-1',1)
GO
INSERT INTO LOS_BORBOTONES.Regimen(idRegimen, Codigo,Descripcion,Precio,Estado,idHotel)
VALUES (2,'SQL-CODIGO-REG-2','SQL-DESCRIPCION-REG-2',20,'SQL-ESTADO-REG-2',1)
GO
SET IDENTITY_INSERT LOS_BORBOTONES.Regimen OFF

SET IDENTITY_INSERT LOS_BORBOTONES.Identidad ON
INSERT INTO LOS_BORBOTONES.Identidad(idIdentidad,TipoIdentidad, Nombre, TipoDocumento, NumeroDocumento, Mail)
	   VALUES(3,'SQL-NOMBRE', 'SQL-GUEST', 'SQL-DNI', 'SQL-NUMERO',  'SQL-MAIL')
GO
SET IDENTITY_INSERT LOS_BORBOTONES.Identidad OFF

SET IDENTITY_INSERT LOS_BORBOTONES.Cliente ON
INSERT INTO LOS_BORBOTONES.Cliente(idCliente, Activo,idIdentidad)
VALUES (1,1,3)
GO
SET IDENTITY_INSERT LOS_BORBOTONES.Cliente OFF

SET IDENTITY_INSERT LOS_BORBOTONES.Estadia ON
INSERT INTO LOS_BORBOTONES.Estadia(idEstadia, FechaEntrada,FechaSalida,idUsuarioIn,idUsuarioOut)
VALUES (1,GETDATE(),GETDATE(),1,1);
GO
SET IDENTITY_INSERT LOS_BORBOTONES.Estadia OFF

SET IDENTITY_INSERT LOS_BORBOTONES.Reserva ON
INSERT INTO LOS_BORBOTONES.Reserva(idReserva, CodigoReserva,FechaCreacion,FechaDesde,FechaHasta,DiasAlojados,idHotel,idEstadia,idRegimen,idIdentidad)
VALUES (1,1,GETDATE(),GETDATE(),GETDATE(),1,1,1,1,3);
GO

INSERT INTO LOS_BORBOTONES.Reserva(idReserva, CodigoReserva,FechaCreacion,FechaDesde,FechaHasta,DiasAlojados,idHotel,idEstadia,idRegimen,idIdentidad)
VALUES (2,2,GETDATE(),GETDATE(),GETDATE(),1,1,1,2,3);
GO
SET IDENTITY_INSERT LOS_BORBOTONES.Reserva OFF
*/
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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
	SELECT  NULL, m.Cliente_Dom_Calle, m.Cliente_Nro_Calle, m.Cliente_Piso, m.Cliente_Depto, i.idIdentidad
	FROM gd_esquema.Maestra m, LOS_BORBOTONES.Identidad i
	WHERE i.NumeroDocumento = m.Cliente_Pasaporte_Nro
UNION
	SELECT Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, NULL, NULL, NULL
	FROM gd_esquema.Maestra 
)	
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- MIGRACION Categoria 

INSERT INTO LOS_BORBOTONES.Categoria(Estrellas, RecargaEstrellas) 
		SELECT  DISTINCT Hotel_CantEstrella, Hotel_Recarga_Estrella
		FROM gd_esquema.Maestra
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
--por defecto los clientes aparecen con Activo = 1
INSERT INTO LOS_BORBOTONES.Cliente(idIdentidad, Activo) 
		SELECT DISTINCT idIdentidad, 1
		FROM LOS_BORBOTONES.Identidad
		WHERE TipoIdentidad = 'Cliente'
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- MIGRACION Regimen
-- en principio se puso como Estado Disponible a todos los regimenes y por default codigo = RC117
INSERT INTO LOS_BORBOTONES.Regimen(Descripcion, Precio, Activo, idHotel)
		SELECT  DISTINCT m.Regimen_Descripcion, m.Regimen_Precio, 1, h.idHotel
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Hotel h
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga CierreTemporal
--las fechas estan en el DER como tipo VARCHAR, se quedan asi? o como DATETIME
-- Se define por el momento Descripcion = 'Mantenimiento'
INSERT INTO LOS_BORBOTONES.CierreTemporal(Descripcion, idHotel)
		SELECT  DISTINCT 'Mantenimiento', idHotel
		FROM LOS_BORBOTONES.Hotel
		WHERE FechaInicioActividades <= GETDATE() 
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
		SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
		FROM gd_esquema.maestra 
		WHERE Consumible_Codigo IS NOT NULL
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
		SELECT DISTINCT  Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
		FROM gd_esquema.maestra
		WHERE Habitacion_Tipo_Codigo IS NOT NULL
		--GROUP BY Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual;

GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Migracion Habitacion

INSERT INTO LOS_BORBOTONES.Habitacion(Numero, Piso, Ubicacion, idHotel, idTipoHabitacion) 
		SELECT DISTINCT m.Habitacion_Numero, m.Habitacion_Piso, m.Habitacion_Frente, h.idHotel, t.idTipoHabitacion
		FROM LOS_BORBOTONES.Hotel h
		JOIN gd_esquema.maestra m ON CONCAT(m.Hotel_Calle, m.Hotel_Nro_Calle) = h.Nombre
		JOIN LOS_BORBOTONES.TipoHabitacion t ON m.Habitacion_Tipo_Codigo = t.Codigo
		WHERE t.Codigo IS NOT NULL
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Migracion Reserva
--PARA LA MIGRACION DE LA RESERVA, GENERE UNA TABLA TEMPORAL, PARA TRABAJAR LOS JOIN SOLO CON LOS DATOS ESPECIFICOS DE LA MAESTRA, 

-- TUVE QUE MODIFICAR LA FK ID_CLIENTE_COMPRADOR POR UNA FK A LA TABLA IDENTIDAD, PARA PODER VALIDAR POR NUMERO DE DOCUMENTO Y ASI SIMPLIFICAR Y TRAER VALORES COHERENTES

-- SI ESTAMOS DE ACUERDO, HABRIA QUE MODIFICAR EL DER (LA FK CLIENTE DE LA TABLA RESERVA POR LA FK IDENTIDAD)

 ----------------------------------------------------------------------------------------------------------------------------------------------------------- 

--Migracion Reserva

-- Crear tabla temporal con los valores actuales de la tabla maestra que necesito para reserva y campos para que vincular las fk : hotel, regimen, estadia e identidad

SET IDENTITY_INSERT LOS_BORBOTONES.ReservaTemporal ON
-- insertando los datos actuales de la tabla reservaTemporal
INSERT INTO LOS_BORBOTONES.ReservaTemporal(Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Cant_Noches, Hotel_Calle, Hotel_Nro_Calle, Estadia_Fecha_Inicio, Estadia_Cant_Noches, Regimen_Descripcion, Cliente_Pasaporte_Nro)
SELECT DISTINCT p.Reserva_Codigo, p.Reserva_Fecha_Inicio, p.Reserva_Cant_Noches, p.Hotel_Calle, p.Hotel_Nro_Calle, p.Estadia_Fecha_Inicio, p.Estadia_Cant_Noches, p.Regimen_Descripcion, p.Cliente_Pasaporte_Nro
FROM gd_esquema.Maestra p
WHERE p.Estadia_Fecha_Inicio IS NOT NULL
ORDER BY p.Reserva_Codigo;
GO

-- comprobando
SELECT DISTINCT * FROM LOS_BORBOTONES.ReservaTemporal
ORDER BY Reserva_Codigo
GO

INSERT INTO LOS_BORBOTONES.Reserva(CodigoReserva, FechaCreacion,  DiasAlojados, idHotel, idEstadia, idRegimen, idIdentidad)
SELECT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches, h.idHotel, e.idEstadia, r.idRegimen, i.idIdentidad
FROM  LOS_BORBOTONES.Hotel h 
	INNER JOIN  LOS_BORBOTONES.ReservaTemporal m
		ON CONCAT(m.Hotel_Calle, m.Hotel_Nro_Calle) = h.Nombre  
	INNER JOIN LOS_BORBOTONES.Estadia e
		ON m.Estadia_Fecha_Inicio = e.FechaEntrada AND m.Estadia_Cant_Noches = DATEDIFF(DAY, e.FechaEntrada, e.FechaSalida)
	INNER JOIN LOS_BORBOTONES.Regimen r
		ON m.Regimen_Descripcion = r.Descripcion AND r.idHotel = h.idHotel
	INNER JOIN LOS_BORBOTONES.Identidad i
		ON m.Cliente_Pasaporte_Nro = i.NumeroDocumento
ORDER BY m.Reserva_Codigo
GO								
				

-------------------------------------------------------------------------------------------- ----------------------------------------------------------------------
--Migracion Factura
/*
INSERT INTO LOS_BORBOTONES.Factura(NumeroFactura, FechaFacturacion, Total, e.idEstadia, r.idReserva)
		SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, e.idEstadia, r.idReserva
		FROM  LOS_BORBOTONES.Estadia e
		JOIN gd_esquema.maestra m ON  m.Estadia_Cant_Noches = DATEDIFF(DAY, e.FechaEntrada, e.FechaSalida)
		JOIN LOS_BORBOTONES.Reserva r ON  m.Reserva_Codigo = r.CodigoReserva
		
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


*/



		