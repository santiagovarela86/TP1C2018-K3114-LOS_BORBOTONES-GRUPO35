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
	
IF OBJECT_ID('LOS_BORBOTONES.FK_Cliente_Reserva', 'F') IS NOT NULL
	ALTER TABLE LOS_BORBOTONES.Reserva
	DROP CONSTRAINT FK_Cliente_Reserva
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

---------------------------------------------- Dropeo de Tablas ----------------------------------------------------------------------------

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

----Tablas Temporales

-- temporalReserva,  
IF OBJECT_ID('LOS_BORBOTONES.temporalReserva', 'U') IS NOT NULL
	DROP TABLE LOS_BORBOTONES.temporalReserva;
GO

-- temporalMontoFactura
IF OBJECT_ID('LOS_BORBOTONES.temporalMontoFactura', 'U') IS NOT NULL
	DROP TABLE LOS_BORBOTONES.temporalMontoFactura;
GO

---------------------------------------------------------------Funciones---------------------------------------------------------------------------------------------------------------
--Funcion getDate()
IF OBJECT_ID('LOS_BORBOTONES.fn_getDate', 'FN') IS NOT NULL
    DROP FUNCTION LOS_BORBOTONES.fn_getDate
GO

-- Nombre del hotel
IF OBJECT_ID('LOS_BORBOTONES.concatenarNombreHotel', 'FN') IS NOT NULL
    DROP FUNCTION LOS_BORBOTONES.concatenarNombreHotel 
GO

--Costo Total por estadia y regimen
IF OBJECT_ID('LOS_BORBOTONES.fn_costoTotalEstadia', 'FN') IS NOT NULL
    DROP FUNCTION LOS_BORBOTONES.fn_costoTotalEstadia
GO

--Puntos por estadia 
IF OBJECT_ID('LOS_BORBOTONES.fn_puntoTotalEstadia', 'FN') IS NOT NULL
    DROP FUNCTION LOS_BORBOTONES.fn_puntoTotalEstadia
GO

--Puntos por consumible 
IF OBJECT_ID('LOS_BORBOTONES.fn_puntoTotalConsumible', 'FN') IS NOT NULL
    DROP FUNCTION LOS_BORBOTONES.fn_puntoTotalConsumible
GO

---------------------------------------------------------------------- Eliminacion de schema LOS_BORBOTONES --------------------------------------------------------------------------

IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'LOS_BORBOTONES')
    DROP SCHEMA LOS_BORBOTONES;
GO
	
--Creación Inicial del Esquema
CREATE SCHEMA LOS_BORBOTONES AUTHORIZATION gdHotel2018;
GO

--------------------------------------FUNCIONES---------------------------------------------------------------------------------------------------------------------------------------

----------------------------------------------- Uso una funcion para obtener la fecha del sistema ya que no hay que usar GETDATE() -------------
----------------------------------------------- La fecha es la misma que en el archivo de configuración de la aplicación -----------------------

CREATE FUNCTION LOS_BORBOTONES.fn_getDate()
RETURNS DATETIME AS
BEGIN
	RETURN '2018-06-01 00:00:00.000'
END
GO

--Funcion para establecer el nombre de hotel

CREATE FUNCTION LOS_BORBOTONES.concatenarNombreHotel 
	( @nombre nvarchar(255), @numero numeric(18,0))

	RETURNS nvarchar(255)

AS

BEGIN

	DECLARE @aux nvarchar(255)

	set @aux = CONVERT(nvarchar(255),@numero) 

	RETURN @nombre+' '+@aux

END
GO

--funcion escalar para calcular el costo por estadia

CREATE FUNCTION LOS_BORBOTONES.fn_costoTotalEstadia(@precioRegimen numeric(18,2), @cantidadDias numeric(18,0))
	RETURNS numeric(18,2)
		AS
			BEGIN
				DECLARE @totalEstadia numeric(18,2)
					SET @totalEstadia = sum(@precioRegimen * @cantidadDias)
				RETURN @totalEstadia
			END
GO

--funcion para calcular puntos por estadia, por cliente y facturacion

CREATE FUNCTION LOS_BORBOTONES.fn_puntoTotalEstadia(@CostoTotalEstadia money)
	RETURNS money
		AS
			BEGIN
				DECLARE @totalPuntoEstadia numeric(18,0)
				DECLARE @pesoPorPunto numeric(18,2)
					SET @pesoPorPunto = 20
					SET @totalPuntoEstadia = @CostoTotalEstadia / @pesoPorPunto
				RETURN @totalPuntoEstadia
			END
GO

--funcion para calcular puntos por consumible, por cliente y facturacion

CREATE FUNCTION LOS_BORBOTONES.fn_puntoTotalConsumible(@CostoTotalConsumible numeric(18,2))
	RETURNS numeric(18,2)
		AS
			BEGIN
				DECLARE @totalPuntoConsumible numeric(18,0)
				DECLARE @pesoPorPunto numeric(18,2)
					SET @pesoPorPunto = 10
					SET @totalPuntoConsumible = @CostoTotalConsumible / @pesoPorPunto
				RETURN @totalPuntoConsumible
			END
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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
	TipoIdentidad			VARCHAR(45)		NOT NULL,		
	Nombre					NVARCHAR(255)	NOT NULL,
	Apellido				NVARCHAR(255)	NOT NULL,
	TipoDocumento			VARCHAR(45)		NOT NULL,
	NumeroDocumento			VARCHAR(45)		NOT NULL,
	Mail					NVARCHAR(255)	NOT NULL, --el mail debe ser unico
	FechaNacimiento			DATETIME		NOT NULL,
	Nacionalidad			NVARCHAR(255),
	Telefono				VARCHAR(45)		DEFAULT 0			NOT NULL,
)
GO

--Tabla Direccion
CREATE TABLE LOS_BORBOTONES.Direccion (

	idDireccion		INT				IDENTITY(1,1)				NOT NULL,
	Pais			VARCHAR(45)		DEFAULT 'Argentina'			NOT NULL,
	Ciudad			NVARCHAR(255),
	Calle			NVARCHAR(255)	NOT NULL,
	NumeroCalle		INT				NOT NULL,
	Piso			INT,
	Depto			NVARCHAR(50),
	idIdentidad		INT,	
)
GO

--Tabla Usuario 
CREATE TABLE LOS_BORBOTONES.Usuario (

	idUsuario				INT				IDENTITY(1,1)	NOT NULL,
	Username				VARCHAR(255)	NOT NULL,
	Password				VARCHAR(255)	NOT NULL,
	IntentosFallidosLogin	INT				DEFAULT 0, 
	Activo					BIT				DEFAULT 1,
	idIdentidad				INT				NOT NULL,
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

	idCliente		INT				IDENTITY(1,1)	NOT NULL, --debido a que se cargaron 3 usuarios en identidad y para establecer una correspondencia entre id identidad y idcliente
	Activo			BIT,
	idIdentidad		INT				NOT NULL,
)
GO

--Tabla Categoria
CREATE TABLE LOS_BORBOTONES.Categoria (

	idCategoria			INT				IDENTITY(1,1)	NOT NULL,
	Estrellas			INT				NOT NULL,
	RecargaEstrellas	NUMERIC(18,2)
)
GO

-- Tabla Hotel
CREATE TABLE LOS_BORBOTONES.Hotel (

	idHotel					INT					IDENTITY(1,1)	NOT NULL	UNIQUE, 
	Nombre					NVARCHAR(255)		NOT NULL,
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
	FechaInicio		DATETIME		NOT NULL,
	FechaFin		DATETIME		NOT NULL,
	Descripcion		VARCHAR(45)		NOT NULL,
	idHotel			INT				NOT NULL,	
)
GO

--Tabla Regimen
CREATE TABLE LOS_BORBOTONES.Regimen (
	
	idRegimen		INT				IDENTITY(1,1)	NOT NULL,
	Codigo			VARCHAR(45)		NOT NULL,		
	Descripcion		NVARCHAR(255),
	Precio			NUMERIC(18,2),
	Activo			BIT,
	idHotel			INT				NOT NULL,
)
GO

--Tabla TipoHabitacion
CREATE TABLE LOS_BORBOTONES.TipoHabitacion (

	idTipoHabitacion	INT				IDENTITY(1,1)	NOT NULL,
	Codigo				VARCHAR(45)		NOT NULL,
	Descripcion			VARCHAR(45)		NOT NULL,
	Porcentual			NUMERIC(18,2)	NOT NULL,	
)
GO

--Tabla Habitacion
CREATE TABLE LOS_BORBOTONES.Habitacion (

	idHabitacion		INT				IDENTITY(1,1)	NOT NULL,
	Activa				BIT				DEFAULT 1,
	Numero				INT	NOT NULL,
	Piso				INT	NOT NULL,
	Ubicacion			NVARCHAR(50)	NOT NULL,
	idHotel				INT				NOT NULL,
	idTipoHabitacion	INT				NOT NULL,	
)
GO

-- Tabla Estadia
CREATE TABLE LOS_BORBOTONES.Estadia (

	idEstadia		INT			IDENTITY(1,1)	NOT NULL	UNIQUE,
	FechaEntrada	DATETIME	NOT NULL,
	FechaSalida		DATETIME	NOT NULL,
	CantidadNoches	NUMERIC(18,0),
	Facturada		BIT			DEFAULT 1,
	idUsuarioIn		INT			NOT NULL,
	idUsuarioOut	INT			NOT NULL,
		
)
GO

-- Tabla Reserva
CREATE TABLE LOS_BORBOTONES.Reserva (

	idReserva		INT				IDENTITY(1,1)	NOT NULL	UNIQUE,
	CodigoReserva	NUMERIC(18,0)	NOT NULL,
	FechaCreacion	DATETIME,
	FechaDesde		DATETIME		NOT NULL,
	FechaHasta		DATETIME		NOT NULL,
	DiasAlojados	NUMERIC(18,0),
	idHotel			INT				NOT NULL,
	idEstadia		INT				NOT NULL,
	idRegimen		INT				NOT NULL,
	idCliente		INT				NOT NULL,
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

	idFactura			INT					IDENTITY(1, 1)		NOT NULL,
	NumeroFactura		NUMERIC(18,0)		NOT NULL,
	FechaFacturacion	DATETIME			NOT NULL,
	Total				NUMERIC(18,2)		NOT NULL,
	Puntos				INT,
	TipoPago			VARCHAR(45),
	idEstadia			INT					NOT NULL,
	idReserva			INT					NOT NULL,
)
GO

-- Tabla Consumible
CREATE TABLE LOS_BORBOTONES.Consumible (

	idConsumible		INT				IDENTITY(1,1)	NOT NULL,
	Codigo				NUMERIC(18,0)	NOT NULL,
	Descripcion			NVARCHAR(255)	NOT NULL,
	Precio				NUMERIC(18,2)	NOT NULL,
)
GO

-- Tabla ItemFactura
CREATE TABLE LOS_BORBOTONES.ItemFactura (

		idItemFactura		INT				IDENTITY(1,1)	NOT NULL,
		Cantidad			NUMERIC(18,0)	NOT NULL,
		Monto				NUMERIC(18,2)	NOT NULL,
		FechaCreacion		DATETIME		DEFAULT LOS_BORBOTONES.fn_getDate(),
		idFactura			INT				NOT NULL,
		idConsumible		INT				NOT NULL,		
)
GO

-- Tabla Asociacion Estadia - Consumible
CREATE TABLE LOS_BORBOTONES.Estadia_X_Consumible (

	idEstadia		INT		NOT NULL,
	idConsumible	INT		NOT NULL,
)
GO

-- Tabla EstadoReserva
CREATE TABLE LOS_BORBOTONES.EstadoReserva (

	idEstado		INT				IDENTITY(1,1)	NOT NULL,
	TipoEstado		VARCHAR(45),
	Fecha			VARCHAR(45)		NOT NULL,
	Descripcion		VARCHAR(45),
	idUsuario		INT				NOT NULL,
	idReserva		INT				NOT NULL,
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

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------FIN CREACION--------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Creacion Procedimiento Migracion Tabla Maestra

CREATE INDEX IDX_DIRECCION01 ON LOS_BORBOTONES.Direccion (Calle); --se crea indice a la tabla Direccion, el campo Calle
CREATE INDEX IDX_IDENTIDAD01 ON LOS_BORBOTONES.Identidad (Mail); -- se crea un indice a la tabla Identidad el campo Mail
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga de  Roles Iniciales

INSERT INTO LOS_BORBOTONES.Rol (Nombre, Activo)
VALUES ('AdminOriginal', 1), ('AdminDelEnunciado', 1), ('Recepcionista', 1), ('Guest', 1), ('RolDummy', 0);
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga de  Funcionalidades

INSERT INTO LOS_BORBOTONES.Funcionalidad (Descripcion)
VALUES ('ABMRol'), ('ABMReserva'), ('ABMUsuario'), ('ABMCliente'), ('ABMHotel'),
('ABMHabitacion'), ('ABMRegimenEstadia'), ('RegistrarEstadia'), ('RegistrarConsumible'), ('FacturarEstadia'), ('GenerarListadoEstadistico');
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Asociación Inicial Roles Funcionalidad
--Permisos del administrador que inferimos segun el enunciado

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMRol'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'AdminOriginal'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMUsuario'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'AdminOriginal'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMHotel'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'AdminOriginal'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMHabitacion'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'AdminOriginal'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMRegimenEstadia'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'AdminOriginal'));
GO

--Permisos del administrador full control que pide el enunciado para la entrega
-------------------------------------------------------------------------------

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
SELECT f.idFuncionalidad, r.idRol
FROM LOS_BORBOTONES.Funcionalidad f
CROSS JOIN LOS_BORBOTONES.Rol r
WHERE r.Nombre = 'AdminDelEnunciado';
GO

--Permisos del recepcionista
-------------------------------------------------------------------------------

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMCliente'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
GO

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMReserva'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));
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

--Permisos del guest
-------------------------------------------------------------------------------

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMReserva'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Guest'));
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Genero Identidad de los Usuarios

INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, Apellido, TipoDocumento, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
	   VALUES('Usuario', 'Jose', 'Perez', 'DNI', '30213210',  'admin2@frba_utn.com', '1968-01-09 00:00:00.000', 'ARGENTINO')
GO

INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, Apellido, TipoDocumento, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
	   VALUES('Usuario', 'Guest', 'Guest', 'DNI', '1',  'guest@frba_utn.com', '1998-05-05 00:00:00.000', 'GUESTa')
GO

INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, Apellido, TipoDocumento, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
	   VALUES('Usuario', 'Carolina', 'Mengoche', 'DNI', '17309573',  'recepcionista@frba_utn.com', '1988-09-11 00:00:00.000', 'COLOMBIANO')
GO

--Identidad del admin del enunciado
INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, Apellido, TipoDocumento, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
	   VALUES('Usuario', 'Pedro', 'Uteniano', 'DNI', '28450395',  'admin@frba_utn.com', '1984-02-07 00:00:00.000', 'ARGENTINO')
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Genero Direccion de los Usuarios

INSERT INTO LOS_BORBOTONES.Direccion (Pais, Ciudad, Calle, NumeroCalle, Piso, Depto, idIdentidad)
	VALUES ('Argentina','Capital Federal', 'Mexico', 645, 23, 'C', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '30213210' and TipoIdentidad = 'Usuario'));
GO

INSERT INTO LOS_BORBOTONES.Direccion (Pais, Ciudad, Calle, NumeroCalle, Piso, Depto, idIdentidad)
	VALUES ('Guest','Guest', 'Guest', 0, 0, '', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '1' and TipoIdentidad = 'Usuario'));
GO

INSERT INTO LOS_BORBOTONES.Direccion (Pais, Ciudad, Calle, NumeroCalle, Piso, Depto, idIdentidad)
	VALUES ('Argentina','Dock Sud', 'Boulevard San Martin', 576, 0, '', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '17309573' and TipoIdentidad = 'Usuario'));
GO

--Inserto direccion del admin uteniano
INSERT INTO LOS_BORBOTONES.Direccion (Pais, Ciudad, Calle, NumeroCalle, Piso, Depto, idIdentidad)
	VALUES ('Argentina','Lugano', 'Mozart', 2300, 0, '', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '28450395' and TipoIdentidad = 'Usuario'));
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- La password es 1234 para todos los usuarios
-- Este es el admin que inferimos por las funcionalidades del enunciado
INSERT INTO LOS_BORBOTONES.Usuario (Username,Password, idIdentidad)
	VALUES ('adminOriginal','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '30213210' and TipoIdentidad = 'Usuario'));
GO

INSERT INTO LOS_BORBOTONES.Usuario (Username,Password, idIdentidad)
	VALUES ('guest','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '1' and TipoIdentidad = 'Usuario'));
GO

INSERT INTO LOS_BORBOTONES.Usuario (Username,Password, idIdentidad)
	VALUES ('recepcionista','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '17309573' and TipoIdentidad = 'Usuario'));
GO

--Este es el usuario administrador que pide el enunciado
INSERT INTO LOS_BORBOTONES.Usuario (Username,Password, idIdentidad)
	VALUES ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', (SELECT idIdentidad FROM LOS_BORBOTONES.Identidad WHERE TipoDocumento = 'DNI' and NumeroDocumento like '28450395' and TipoIdentidad = 'Usuario'));
GO

--Carga Rol_X_Usuario
INSERT INTO LOS_BORBOTONES.Rol_X_Usuario (idRol, idUsuario)
	VALUES ((SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'AdminOriginal'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'adminOriginal'));
GO

INSERT INTO LOS_BORBOTONES.Rol_X_Usuario (idRol, idUsuario)
	VALUES ((SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Guest'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'guest'));
GO

INSERT INTO LOS_BORBOTONES.Rol_X_Usuario (idRol, idUsuario)
	VALUES ((SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'recepcionista'));
GO

INSERT INTO LOS_BORBOTONES.Rol_X_Usuario (idRol, idUsuario)
	VALUES ((SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'AdminDelEnunciado'),(SELECT idUsuario FROM LOS_BORBOTONES.Usuario WHERE Username = 'admin'));
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- MIGRACION Identidad
--telefono quedo por defecto en 0

INSERT INTO LOS_BORBOTONES.Identidad(TipoIdentidad, Nombre, Apellido, TipoDocumento, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
	   SELECT  DISTINCT	'Cliente', Cliente_Nombre, Cliente_Apellido, 'Pasaporte', Cliente_Pasaporte_Nro,  Cliente_Mail, Cliente_Fecha_Nac, Cliente_Nacionalidad
		FROM gd_esquema.Maestra
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	
-- MIGRACION Direccion 
--los que no tienen idIdentidad, son los hoteles

INSERT INTO LOS_BORBOTONES.Direccion(Ciudad, Calle, NumeroCalle, Piso, Depto, idIdentidad)
(
	SELECT  'No Posee', m.Cliente_Dom_Calle, m.Cliente_Nro_Calle, m.Cliente_Piso, m.Cliente_Depto, i.idIdentidad
	FROM gd_esquema.Maestra m, LOS_BORBOTONES.Identidad i
	WHERE i.NumeroDocumento = m.Cliente_Pasaporte_Nro
UNION
	SELECT LTRIM(RTRIM(Hotel_Ciudad)), Hotel_Calle, Hotel_Nro_Calle, NULL, NULL, NULL
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
 
 INSERT INTO LOS_BORBOTONES.Hotel (idCategoria, Nombre, Mail, Telefono, FechaInicioActividades, idDireccion)
	  SELECT c.idCategoria, LOS_BORBOTONES.concatenarNombreHotel(d.Calle, d.NumeroCalle) AS Nombre, 'No Posee', 'No Posee', LOS_BORBOTONES.fn_getDate(), d.idDireccion 
	  FROM LOS_BORBOTONES.Categoria c
	  JOIN  gd_esquema.Maestra m ON m.Hotel_CantEstrella = c.Estrellas AND m.Hotel_Recarga_Estrella = c.RecargaEstrellas
	  JOIN LOS_BORBOTONES.Direccion d ON m.Hotel_Ciudad = d.Ciudad AND m.Hotel_Calle = d.Calle AND m.Hotel_Nro_Calle = d.NumeroCalle
	  WHERE d.Ciudad IS NOT NULL
	  GROUP BY c.idCategoria, d.idDireccion, LOS_BORBOTONES.concatenarNombreHotel(d.Calle, d.NumeroCalle) 
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

INSERT INTO LOS_BORBOTONES.Regimen(Codigo, Descripcion, Precio, Activo, idHotel)
		SELECT  DISTINCT 'RGAI', m.Regimen_Descripcion, m.Regimen_Precio, 1, h.idHotel
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Hotel h
		WHERE  m.Regimen_Descripcion = 'All inclusive'
GO

INSERT INTO LOS_BORBOTONES.Regimen(Codigo, Descripcion, Precio, Activo, idHotel)
		SELECT  DISTINCT 'RGAIM', m.Regimen_Descripcion, m.Regimen_Precio, 1, h.idHotel
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Hotel h
		WHERE  m.Regimen_Descripcion = 'All Inclusive moderado'
GO

INSERT INTO LOS_BORBOTONES.Regimen(Codigo, Descripcion, Precio, Activo, idHotel)
		SELECT  DISTINCT 'RGPC', m.Regimen_Descripcion, m.Regimen_Precio, 1, h.idHotel
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Hotel h
		WHERE  m.Regimen_Descripcion = 'Pension Completa'
GO

INSERT INTO LOS_BORBOTONES.Regimen(Codigo, Descripcion, Precio, Activo, idHotel)
		SELECT  DISTINCT 'RGMP', m.Regimen_Descripcion, m.Regimen_Precio, 1, h.idHotel
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Hotel h
		WHERE  m.Regimen_Descripcion = 'Media Pensión'
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga CierreTemporal
--las fechas estan en el DER como tipo VARCHAR, se quedan asi? o como DATETIME
-- Se define por el momento Descripcion = 'Mantenimiento' y Ampliacion

INSERT INTO LOS_BORBOTONES.CierreTemporal(FechaInicio, FechaFin, Descripcion, idHotel)
		SELECT  DISTINCT convert(datetime, '2016-12-29 00:00:00.000', 121), convert(datetime, '2016-12-31 00:00:00.000', 121) , 'Mantenimiento', idHotel
		FROM LOS_BORBOTONES.Hotel
GO

INSERT INTO LOS_BORBOTONES.CierreTemporal(FechaInicio, FechaFin, Descripcion, idHotel)
		SELECT  DISTINCT convert(datetime, '2021-01-01 00:00:00.000', 121), convert(datetime, '2021-01-05 00:00:00.000', 121) , 'Ampliacion', idHotel
		FROM LOS_BORBOTONES.Hotel
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Migracion Estadia (*)
 --El campo Facturada por defecto, inicia en 1
-- para una misma estadia, habia dos una con fecha entrada y salida NULL, se descartaron los NULL
-- En la tabla maestra esta el campo Estadia_Cant_Noches, que no esta en el DER, se agrega en la creacion de la tabla Estadia. habria que agregarlo al DER

INSERT INTO LOS_BORBOTONES.Estadia(FechaEntrada, FechaSalida, CantidadNoches, idUsuarioIn, idUsuarioOut)
		SELECT m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio), m.Estadia_Cant_Noches, 1, 1
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Usuario u
		WHERE m.Estadia_Fecha_Inicio IS NOT NULL AND m.Estadia_Fecha_Inicio < LOS_BORBOTONES.fn_getDate()
		GROUP BY  m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio), m.Estadia_Cant_Noches
GO

INSERT INTO LOS_BORBOTONES.Estadia(FechaEntrada, FechaSalida, CantidadNoches, idUsuarioIn, idUsuarioOut) 
		SELECT m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio), m.Estadia_Cant_Noches, 2, 2
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Usuario u
		WHERE m.Estadia_Fecha_Inicio IS NOT NULL AND m.Estadia_Fecha_Inicio > LOS_BORBOTONES.fn_getDate()
		GROUP BY  m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio), m.Estadia_Cant_Noches
GO

INSERT INTO LOS_BORBOTONES.Estadia(FechaEntrada, FechaSalida, CantidadNoches, idUsuarioIn, idUsuarioOut) 
		SELECT m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio), m.Estadia_Cant_Noches, 3, 3
		FROM gd_esquema.maestra m, LOS_BORBOTONES.Usuario u
		WHERE m.Estadia_Fecha_Inicio IS NOT NULL AND m.Estadia_Fecha_Inicio = LOS_BORBOTONES.fn_getDate()
		GROUP BY  m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio), m.Estadia_Cant_Noches
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Migracion Consumible

INSERT INTO LOS_BORBOTONES.Consumible(Codigo, Descripcion, Precio)
		SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio
		FROM gd_esquema.maestra 
		WHERE Consumible_Codigo IS NOT NULL
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Migracion TipoHabitacion

INSERT INTO LOS_BORBOTONES.TipoHabitacion(Codigo, Descripcion, Porcentual) 
		SELECT DISTINCT  Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual
		FROM gd_esquema.maestra
		WHERE Habitacion_Tipo_Codigo IS NOT NULL

GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Migracion Habitacion

INSERT INTO LOS_BORBOTONES.Habitacion(Numero, Piso, Ubicacion, idHotel, idTipoHabitacion) 
		SELECT DISTINCT m.Habitacion_Numero, m.Habitacion_Piso, m.Habitacion_Frente, h.idHotel, t.idTipoHabitacion
		FROM LOS_BORBOTONES.Hotel h
		JOIN gd_esquema.maestra m ON LOS_BORBOTONES.concatenarNombreHotel(m.Hotel_Calle, m.Hotel_Nro_Calle) = h.Nombre
		JOIN LOS_BORBOTONES.TipoHabitacion t ON m.Habitacion_Tipo_Codigo = t.Codigo
		WHERE t.Codigo IS NOT NULL
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Migracion Reserva
--PARA LA MIGRACION DE LA RESERVA, GENERE UNA TABLA TEMPORAL, PARA TRABAJAR LOS JOIN SOLO CON LOS DATOS ESPECIFICOS DE LA MAESTRA,  

-- Crear tabla temporal con los valores actuales de la tabla maestra que necesito para reserva y campos para que vincular las fk : hotel, regimen, estadia y cliente

SELECT DISTINCT p.Reserva_Codigo, p.Reserva_Fecha_Inicio, p.Reserva_Cant_Noches, p.Hotel_Calle, p.Hotel_Nro_Calle, p.Estadia_Fecha_Inicio, p.Estadia_Cant_Noches, p.Regimen_Descripcion, p.Cliente_Pasaporte_Nro
INTO LOS_BORBOTONES.temporalReserva
FROM gd_esquema.Maestra p
WHERE p.Estadia_Fecha_Inicio IS NOT NULL
ORDER BY p.Reserva_Codigo;
GO

--Migracion Reserva
INSERT INTO LOS_BORBOTONES.Reserva(CodigoReserva, FechaCreacion, FechaDesde,  FechaHasta, DiasAlojados, idHotel, idEstadia, idRegimen, idCliente)
SELECT m.Reserva_Codigo, LOS_BORBOTONES.fn_getDate(), m.Reserva_Fecha_Inicio, DATEADD(DAY, m.Reserva_Cant_Noches, m.Reserva_Fecha_Inicio), m.Reserva_Cant_Noches, h.idHotel, e.idEstadia, r.idRegimen, c.idCliente
FROM  LOS_BORBOTONES.Hotel h 
	INNER JOIN LOS_BORBOTONES.temporalReserva m
		ON LOS_BORBOTONES.concatenarNombreHotel(m.Hotel_Calle, m.Hotel_Nro_Calle) = h.Nombre  
	INNER JOIN LOS_BORBOTONES.Estadia e
		ON m.Estadia_Fecha_Inicio = e.FechaEntrada AND m.Estadia_Cant_Noches = DATEDIFF(DAY, e.FechaEntrada, e.FechaSalida)
	INNER JOIN LOS_BORBOTONES.Regimen r
		ON m.Regimen_Descripcion = r.Descripcion AND r.idHotel = h.idHotel
	INNER JOIN LOS_BORBOTONES.Identidad i
		ON m.Cliente_Pasaporte_Nro = i.NumeroDocumento
	INNER JOIN LOS_BORBOTONES.Cliente c 
		ON c.idIdentidad  = i.idIdentidad AND c.Activo = 1
ORDER BY m.Reserva_Codigo, c.idCliente
GO								
	
-----------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga Hotel_X_Usuario

INSERT INTO LOS_BORBOTONES.Hotel_X_Usuario(idHotel, idUsuario) 
		SELECT DISTINCT r.idHotel, e.idUsuarioIn
		FROM LOS_BORBOTONES.Reserva r
		JOIN LOS_BORBOTONES.Hotel h  
			ON r.idHotel = h.idHotel
		JOIN LOS_BORBOTONES.Estadia e
			ON r.idEstadia = e.idEstadia
		JOIN LOS_BORBOTONES.Usuario u 	
			ON e.idUsuarioIn =  u.idUsuario	OR e.idUsuarioOut =  u.idUsuario
	ORDER BY r.idHotel, e.idUsuarioIn
GO

------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Migracion Factura (*) trae montototal con importes inconsistentes, se corrige luego de migrar itemFactura
-- se define tipoDePago Efectivo, para los clientes migrados de la tablaMaestra

INSERT INTO LOS_BORBOTONES.Factura(NumeroFactura, FechaFacturacion, Total, TipoPago, e.idEstadia, r.idReserva)
		SELECT DISTINCT  m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, 'Efectivo', e.idEstadia, r.idReserva
		FROM  LOS_BORBOTONES.Estadia e
		JOIN gd_esquema.maestra m 
			ON  m.Estadia_Fecha_Inicio = e.FechaEntrada AND m.Estadia_Cant_Noches = e.CantidadNoches
		JOIN LOS_BORBOTONES.Reserva r 
			ON  m.Reserva_Codigo = r.CodigoReserva AND r.idEstadia = e.idEstadia
			WHERE m.Factura_Nro IS NOT NULL
		ORDER BY  m.Factura_Nro, m.Factura_Fecha, e.idEstadia, r.idReserva
GO
	
--------------------------------------------------------------------------------------------------------------------------------------------------------------
--ItemFactura

INSERT INTO LOS_BORBOTONES.ItemFactura(Cantidad, Monto, FechaCreacion, idFactura, idConsumible)
		SELECT DISTINCT  m.Item_Factura_Monto, m.Item_Factura_Cantidad, f.FechaFacturacion, f.idFactura, c.idConsumible
		FROM LOS_BORBOTONES.Factura f 
		JOIN gd_esquema.maestra m
			ON m.Factura_Nro = f.NumeroFactura
		JOIN LOS_BORBOTONES.Consumible c
			ON m.Consumible_Codigo = c.Codigo
	ORDER BY f.idFactura, f.FechaFacturacion;
	
--Creacion de Tabla Temporal para guardar los importes segun el precio del regimen, cantidad de dias y cantidad de consumibles incluidos en itemFactura.
-- El regimen All inclusive no carga consumibles en el monto total.

SELECT  DISTINCT f.NumeroFactura, r.idReserva, g.Descripcion, sum(c.Precio * i.Cantidad) AS CostoConsumible, LOS_BORBOTONES.fn_costoTotalEstadia(g.Precio, e.CantidadNoches) AS CostoEstadia,
		CASE g.Descripcion WHEN 'All Inclusive' THEN LOS_BORBOTONES.fn_costoTotalEstadia(g.Precio, e.CantidadNoches)
		ELSE sum(c.Precio * i.Cantidad) + LOS_BORBOTONES.fn_costoTotalEstadia(g.Precio, e.CantidadNoches) END "MontoTotal"
  INTO LOS_BORBOTONES.temporalMontoFactura
	FROM  LOS_BORBOTONES.Factura f
		JOIN  LOS_BORBOTONES.Reserva r
			ON  f.idReserva = r.idReserva
		JOIN  LOS_BORBOTONES.Estadia e
			ON   r.idEstadia = e.idEstadia
		JOIN LOS_BORBOTONES.Regimen g
			ON r.idRegimen = g.idRegimen
		JOIN LOS_BORBOTONES.ItemFactura i
			ON f.idFactura = i.idFactura
		JOIN LOS_BORBOTONES.Consumible c
			ON i.idConsumible = c.idConsumible
		WHERE  f.idFactura = i.idFactura
	GROUP BY f.NumeroFactura, r.idReserva, g.Descripcion, g.Precio, e.CantidadNoches	
	
--se corrige el montototal de cada factura, y los puntos obtenidos, de acuerdo al enunciado, teniendo en cuenta algunos campos de itemFactura
	 
UPDATE  t1
SET t1.Total =   t2.MontoTotal,
	t1.Puntos = LOS_BORBOTONES.fn_puntoTotalConsumible(t2.CostoConsumible) + LOS_BORBOTONES.fn_puntoTotalEstadia(t2.CostoEstadia)
FROM  LOS_BORBOTONES.Factura t1
		JOIN  LOS_BORBOTONES.temporalMontoFactura t2
		ON  t1.NumeroFactura = t2.NumeroFactura
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Asociacion Estadia_X_Consumible

INSERT INTO LOS_BORBOTONES.Estadia_X_Consumible(idEstadia, idConsumible) 
		SELECT DISTINCT f.idEstadia, i.idConsumible
		FROM LOS_BORBOTONES.Factura f
		JOIN LOS_BORBOTONES.Estadia e
			ON f.idEstadia = e.idEstadia 
		JOIN LOS_BORBOTONES.ItemFactura i 
			ON f.idFactura = i.idFactura
		JOIN LOS_BORBOTONES.Consumible c
			ON i.idConsumible = c.idConsumible
	ORDER BY f.idEstadia, i.idConsumible
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Asociacion Reserva_X_Habitacion_X_Cliente

INSERT INTO LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente(idReserva, idHabitacion, idCliente) 
		SELECT DISTINCT r.idReserva, a.idHabitacion, c.idCliente
		FROM LOS_BORBOTONES.Reserva r
		JOIN gd_esquema.maestra m
			ON r.CodigoReserva = m.Reserva_Codigo
		JOIN LOS_BORBOTONES.Cliente c
			ON r.idCliente = c.idCliente
		JOIN LOS_BORBOTONES.Hotel h
			ON r.idHotel = h.idHotel 
		JOIN LOS_BORBOTONES.Habitacion a
			ON h.idHotel = a.idHotel AND m.Habitacion_Numero = a.Numero AND m.Habitacion_Piso = a.Piso
		JOIN LOS_BORBOTONES.TipoHabitacion t
			ON a.idTipoHabitacion = t.idTipoHabitacion AND m.Habitacion_Tipo_Codigo = t.Codigo
	ORDER BY a.idHabitacion, r.idReserva,  c.idCliente
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--Carga EstadoReserva

INSERT INTO LOS_BORBOTONES.EstadoReserva(TipoEstado, Fecha, Descripcion, idUsuario, idReserva)
		SELECT DISTINCT 'RC', r.FechaCreacion, 'Reserva Correcta', 1, r.idReserva
		FROM LOS_BORBOTONES.Reserva r
		JOIN LOS_BORBOTONES.Identidad i
			ON i.TipoIdentidad = 'Usuario'
		JOIN LOS_BORBOTONES.Usuario u
			ON i.idIdentidad = u.idUsuario  AND u.Username = 'admin'
		WHERE r.FechaDesde < LOS_BORBOTONES.fn_getDate()
ORDER BY r.idReserva, r.FechaCreacion
GO

INSERT INTO LOS_BORBOTONES.EstadoReserva(TipoEstado, Fecha, Descripcion, idUsuario, idReserva)
		SELECT DISTINCT 'RM', r.FechaCreacion, 'Reserva Modificada', 3, r.idReserva
		FROM LOS_BORBOTONES.Reserva r
		JOIN LOS_BORBOTONES.Identidad i
			ON i.TipoIdentidad = 'Usuario'
		JOIN LOS_BORBOTONES.Usuario u
			ON i.idIdentidad = u.idUsuario  AND u.Username = 'recepcionista'
	WHERE r.FechaDesde BETWEEN r.fechaCreacion AND r.fechaDesde
ORDER BY r.idReserva, r.FechaCreacion
GO

INSERT INTO LOS_BORBOTONES.EstadoReserva(TipoEstado, Fecha, Descripcion, idUsuario, idReserva)
		SELECT DISTINCT 'RCR', r.FechaCreacion, 'Reserva Cancelada por Recepcion', 3 , r.idReserva
		FROM LOS_BORBOTONES.Reserva r
		JOIN LOS_BORBOTONES.Identidad i
			ON i.TipoIdentidad = 'Usuario'
		JOIN LOS_BORBOTONES.Usuario u
			ON i.idIdentidad = u.idUsuario  AND u.Username = 'recepcionista'
		WHERE r.FechaDesde LIKE convert(datetime, '2017-01-01 00:00:00.000', 121)
ORDER BY r.idReserva, r.FechaCreacion
GO

INSERT INTO LOS_BORBOTONES.EstadoReserva(TipoEstado, Fecha, Descripcion, idUsuario, idReserva)
		SELECT DISTINCT 'RCC', r.FechaCreacion, 'Reserva Cancelada por Cliente', 2 , r.idReserva
		FROM LOS_BORBOTONES.Reserva r
		JOIN LOS_BORBOTONES.Identidad i
			ON i.TipoIdentidad = 'Usuario'
		JOIN LOS_BORBOTONES.Usuario u
			ON i.idIdentidad = u.idUsuario AND u.Username = 'guest'
		WHERE CodigoReserva = 77460
ORDER BY r.idReserva, r.FechaCreacion
