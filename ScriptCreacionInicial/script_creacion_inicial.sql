USE GD1C2018;
GO

-- Eliminacion de Tablas --
IF OBJECT_ID('LOS_BORBOTONES.Rol','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Rol;

IF OBJECT_ID('LOS_BORBOTONES.Funcionalidad','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Funcionalidad;

IF OBJECT_ID('LOS_BORBOTONES.Funcionalidad_X_Rol','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Funcionalidad_X_Rol;
	
IF OBJECT_ID('LOS_BORBOTONES.Identidad','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Identidad;
	
IF OBJECT_ID('LOS_BORBOTONES.Direccion','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Direccion;
	
IF OBJECT_ID('LOS_BORBOTONES.Usuario','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Usuario;
	
IF OBJECT_ID('LOS_BORBOTONES.Rol_X_Usuario','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Rol_X_Usuario;
	
IF OBJECT_ID('LOS_BORBOTONES.Cliente','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Cliente;
	
IF OBJECT_ID('LOS_BORBOTONES.Categoria','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Categoria;
	
IF OBJECT_ID('LOS_BORBOTONES.Hotel','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Hotel;
	
IF OBJECT_ID('LOS_BORBOTONES.Hotel_X_Usuario','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Hotel_X_Usuario;
	
IF OBJECT_ID('LOS_BORBOTONES.CierreTemporal','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.CierreTemporal;
	
IF OBJECT_ID('LOS_BORBOTONES.Regimen','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Regimen;
	
IF OBJECT_ID('LOS_BORBOTONES.TipoHabitacion','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.TipoHabitacion;

IF OBJECT_ID('LOS_BORBOTONES.Habitacion','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Habitacion;
	
IF OBJECT_ID('LOS_BORBOTONES.Estadia','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Estadia;
	
IF OBJECT_ID('LOS_BORBOTONES.Reserva','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Reserva;
	
IF OBJECT_ID('LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente;
	
IF OBJECT_ID('LOS_BORBOTONES.Factura','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Factura;
	
IF OBJECT_ID('LOS_BORBOTONES.Consumible','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Consumible;
	
IF OBJECT_ID('LOS_BORBOTONES.ItemFactura') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.ItemFactura;
	
IF OBJECT_ID('LOS_BORBOTONES.Estadia_X_Consumible','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.Estadia_X_Consumible;

IF OBJECT_ID('LOS_BORBOTONES.EstadoReserva','U') IS NOT NULL
    DROP TABLE LOS_BORBOTONES.EstadoReserva;
	
-- Eliminacion de schema grupo --	
IF EXISTS (SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'LOS_BORBOTONES')
    DROP SCHEMA LOS_BORBOTONES;
GO
	
--Creación Inicial del Esquema
CREATE SCHEMA LOS_BORBOTONES AUTHORIZATION gdHotel2018

--Creación Tabla Rol
CREATE TABLE LOS_BORBOTONES.Rol (

	idRol	INT			IDENTITY(1,1)	NOT NULL,
	Nombre	VARCHAR(45) 				NOT NULL,
	Activo	BIT							NOT NULL,
	PRIMARY KEY(idRol)
)

--Creación Tabla Funcionalidad
CREATE TABLE LOS_BORBOTONES.Funcionalidad (

	idFuncionalidad	INT			IDENTITY(1,1)	NOT NULL,
	Descripcion 	VARCHAR(45)					NOT NULL,
	PRIMARY KEY (idFuncionalidad)
)

--Creación Tabla Asociación Funcionalidad - Rol
CREATE TABLE LOS_BORBOTONES.Funcionalidad_X_Rol (

	idFuncionalidad	INT			NOT NULL,
	idRol			INT			NOT NULL,
	PRIMARY KEY (idFuncionalidad, idRol),
	FOREIGN KEY (idFuncionalidad) REFERENCES Funcionalidad (idFuncionalidad),
	FOREIGN KEY (idRol) REFERENCES Rol (idRol),
)

--Creacion Tabla Identidad 
CREATE TABLE LOS_BORBOTONES.Identidad (

	idIdentidad				INT				IDENTITY(1,1)	NOT NULL,
	TipoIdentidad			VARCHAR(45)		DEFAULT 'Cliente',
	Nombre					NVARCHAR(255),
	Apellido				NVARCHAR(255),
	TipoDocumento			VARCHAR(45)		DEFAULT 'Pasaporte',
	NumeroDocumento			VARCHAR(45),
	Mail					NVARCHAR(255),
	FechaNacimiento			DATETIME,
	FechaInicioActividades	VARCHAR(45)		GETDATE(),
	Nacionalidad			NVARCHAR(255),
	Telefono				VARCHAR(45)		DEFAULT 0,
	PRIMARY KEY	(idIdentidad)
)

--Creacion Tabla Direccion
CREATE TABLE LOS_BORBOTONES.Direccion (

	idDireccion		INT				IDENTITY(1,1)	NOT NULL,
	Pais			VARCHAR(45)		DEFAULT 0,
	Ciudad			NVARCHAR(255),
	Calle			NVARCHAR(255),
	NumeroCalle		NUMERIC(18,0),
	Piso			NVARCHAR(50),
	Depto			NVARCHAR(50),
	idIdentidad		INT				NOT NULL,
	PRIMARY KEY (idDireccion),
	FOREIGN KEY (idIdentidad) REFERENCES Identidad (idIdentidad)
)

--Creacion Tabla Usuario 
CREATE TABLE LOS_BORBOTONES.Usuario (

	idUsuario				INT			IDENTITY(1,1)	NOT NULL,
	Username				VARCHAR(45),
	Pasword					VARCHAR(45),
	IntentosFallidosLogin	VARCHAR(45),
	Activo					BIT,
	idIdentidad				INT			NOT NULL,
	PRIMARY KEY (idUsuario),
	FOREIGN KEY (idIdentidad) REFERENCES Identidad (idIdentidad)
)

--Creacion Tabla Asociacion Rol - Usuario
CREATE TABLE LOS_BORBOTONES.Rol_X_Usuario (

	idRol			INT			NOT NULL,
	idUsuario		INT			NOT NULL,
	PRIMARY KEY (idRol, idUsuario),
	FOREIGN KEY (idRol) REFERENCES Rol (idRol),
	FOREIGN KEY (idUsuario) REFERENCES Usuario (idUsuario),
)

--Creacion Tabla Cliente
CREATE TABLE LOS_BORBOTONES.Cliente (

	idCliente		INT				IDENTITY(1,1)	NOT NULL,
	Estado			VARCHAR(45),
	idIdentidad		INT				NOT NULL,
	PRIMARY KEY (idCliente),
	FOREIGN KEY (idIdentidad) REFERENCES Identidad (idIdentidad)
)

--Creacion Tabla Categoria
CREATE TABLE LOS_BORBOTONES.Categoria (

	idCategoria			INT		IDENTITY(1,1)			NOT NULL,
	Estrellas			NUMERIC(18,0),
	RecargaEstrellas	NUMERIC(18,0)
	PRIMARY KEY (idCategoria)
)

--Creacion Tabla Hotel
CREATE TABLE LOS_BORBOTONES.Hotel (

	idHotel		INT					IDENTITY(1,1)	NOT NULL	UNIQUE,  --indice no cluster
	Nombre		NVARCHAR(255),
	Mail		NVARCHAR(255),
	Telefono	VARCHAR(45),
	idCategoria	INT					NOT NULL,
	idDireccion	INT					NOT NULL,
	PRIMARY KEY	(idHotel, idCategoria, idDireccion),
	FOREIGN KEY (idCategoria) REFERENCES Categoria (idCategoria),
	FOREIGN KEY (idDireccion) REFERENCES Direccion (idDireccion)
)

--Creacion Tabla Asociacion Hotel - Usuario
CREATE TABLE LOS_BORBOTONES.Hotel_X_Usuario (

	idHotel			INT			NOT NULL,
	idUsuario		INT			NOT NULL,
	PRIMARY KEY (idHotel, idUsuario),
	FOREIGN KEY (idHotel) REFERENCES Hotel (idHotel),
	FOREIGN KEY (idUsuario) REFERENCES Usuario (idUsuario)
)

--Creacion Tabla CierreTemporal
CREATE TABLE LOS_BORBOTONES.CierreTemporal (

	idEstadoHotel	INT				NOT NULL,
	FechaInicio		VARCHAR(45),
	FechaFin		VARCHAR(45),
	Descripcion		VARCHAR(45),
	idHotel			INT				NOT NULL,
	PRIMARY KEY (idEstadoHotel),
	FOREIGN KEY	(idHotel) REFERENCES Hotel (idHotel)
)

--Creacion Tabla Regimen
CREATE TABLE LOS_BORBOTONES.Regimen (
	
	idRegimen		INT				NOT NULL,
	Codigo			VARCHAR(45)		IDENTITY(1111,1),
	Descripcion		NVARCHAR(255),
	Precio			NUMERIC(18,2),
	Estado			VARCHAR(45),
	idHotel			INT				NOT NULL,
	CONSTRAINT CK01 CHECK (Estado IN ('Activo', 'No Activo')),
	PRIMARY KEY (idRegimen),
	FOREIGN KEY (idHotel) REFERENCES Hotel (idHotel)
)

--Creacion Tabla TipoHabitacion
CREATE TABLE LOS_BORBOTONES.TipoHabitacion (

	idTipoHabitacion	INT				NOT NULL,
	Codigo				VARCHAR(45),
	Descripcion			VARCHAR(45),
	Porcentual			VARCHAR(45),	
	PRIMARY KEY (idTipoHabitacion)
)

--Creacion Tabla Habitacion
CREATE TABLE LOS_BORBOTONES.Habitacion (

	idHabitacion		INT				NOT NULL,
	Estado				VARCHAR(45),
	Numero				NUMERIC(18,0),
	Piso				NUMERIC(18,0),
	Frente				NVARCHAR(50),
	idHotel				INT				NOT NULL,
	idTipoHabitacion	INT				NOT NULL,
	CONSTRAINT CK02 CHECK (Estado IN ('Ocupada', 'Libre')),
	PRIMARY KEY (idHabitacion),
	FOREIGN KEY (idHotel) REFERENCES Hotel (idHotel),
	FOREIGN KEY (idTipoHabitacion) REFERENCES TipoHabitacion (idTipoHabitacion)
)

--Creacion Tabla Estadia
CREATE TABLE LOS_BORBOTONES.Estadia (

	idEstadia		INT			NOT NULL,
	FechaEntrada	DATETIME,
	FechaSalida		DATETIME,
	Facturada		BIT			DEFAULT 1,
	DiasAlojados	NUMERIC(18,0),
	idUsuario		INT			NOT NULL,
	PRIMARY KEY	(idEstadia),
	FOREIGN KEY (idUsuario) REFERENCES Usuario (idUsuario)
	--en el DER esta como usuarioCheckIn y usuarioCheckOut
)

--Creacion Tabla Reserva
CREATE TABLE LOS_BORBOTONES.Reserva (

	idReserva		INT				NOT NULL,
	CodigoReserva	NUMERIC(18,0),
	FechaCreacion	DATETIME,
	FechaDesde		DATETIME,
	FechaHasta		DATETIME,
	DiasAlojados	NUMERIC(18,0),
	idHotel			INT				NOT NULL,
	idEstadia		INT				NOT NULL,
	idRegimen		INT				NOT NULL,
	idCliente		INT				NOT NULL,
	PRIMARY KEY (idReserva),
	CONSTRAINT CK03 CHECK (FechaDesde > GETDATE()),
	FOREIGN KEY (idHotel) REFERENCES Hotel (idHotel),
	FOREIGN KEY (idEstadia) REFERENCES Estadia (idEstadia),
	FOREIGN KEY (idRegimen) REFERENCES Regimen (idRegimen),
	FOREIGN KEY (idCliente) REFERENCES Cliente (idCliente),
)

--Creacion Tabla Asociacion Reserva - Habitacion - Cliente
CREATE TABLE LOS_BORBOTONES.Reserva_X_Habitacion_X_Cliente (

	idReserva		INT		NOT NULL,
	idHabitacion	INT		NOT NULL,
	idCliente		INT		NOT NULL,
	PRIMARY KEY (idReserva, idHabitacion, idCliente),
	FOREIGN KEY (idReserva) REFERENCES Reserva (idReserva),
	FOREIGN KEY (idHabitacion) REFERENCES Habitacion (idHabitacion),
	FOREIGN KEY (idCliente) REFERENCES Cliente (idCliente)
)

--Creacion Tabla Factura
CREATE TABLE LOS_BORBOTONES.Factura (

	idFactura			INT				NOT NULL,
	NumeroFactura		NUMERIC(18,0),
	FechaFacturacion	DATETIME,
	Total				NUMERIC(18,2),
	Puntos				INT,
	TipoPago			VARCHAR(45),
	idEstadia			INT				NOT NULL,
	idReserva			INT				NOT NULL,
	PRIMARY KEY (idFactura),
	CONSTRAINT CK04 CHECK (TipoPago IN 'Efectivo', 'Credito', 'Debito'),
	FOREIGN KEY (idEstadia) REFERENCES Estadia (idEstadia),
	FOREIGN KEY (idReserva) REFERENCES Reserva (idReserva),
)

--Creacion Tabla Consumible
CREATE TABLE LOS_BORBOTONES.Consumible (

	idConsumible		INT				NOT NULL,
	Codigo				NUMERIC(18,0),
	Descripcion			NVARCHAR(255),
	Precio				NUMERIC(18,2),
	PRIMARY KEY	(idConsumible)
)

--Creacion Tabla ItemFactura
CREATE TABLE LOS_BORBOTONES.ItemFactura (

		idItemFactura		INT				NOT NULL,
		Cantidad			NUMERIC(18,0),
		Monto				NUMERIC(18,2),
		FechaCreacion		DATETIME		DEFAULT GETDATE(),
		idFactura			INT				NOT NULL,
		idConsumible		INT				NOT NULL,
		PRIMARY KEY (idItemFactura),
		FOREIGN KEY (idFactura) REFERENCES Factura (idFactura),
		FOREIGN KEY (idConsumible) REFERENCES Consumible (idConsumible),
)

--Creacion Tabla Asociacion Estadia - Consumible
CREATE TABLE LOS_BORBOTONES.Estadia_X_Consumible (

	idEstadia		INT		NOT NULL,
	idConsumible	INT		NOT NULL,
	PRIMARY KEY (idEstadia, idConsumible),
	FOREIGN KEY (idEstadia) REFERENCES Estadia (idEstadia),
	FOREIGN KEY (idConsumible) REFERENCES Consumible (idConsumible),
)

--Creacion Tabla EstadoReserva
CREATE TABLE LOS_BORBOTONES.EstadoReserva (

	idEstado		INT			NOT NULL,
	TipoEstado		VARCHAR(45),
	Fecha			VARCHAR(45),
	Descripcion		VARCHAR(45),
	idUsuario		INT			NOT NULL,
	idReserva		INT			NOT NULL,
	PRIMARY KEY (idEstado),
	FOREIGN KEY (idUsuario) REFERENCES Usuario (idUsuario),
	FOREIGN KEY (idReserva) REFERENCES Reserva (idReserva),
)

GO

--Creacion Procedimiento Migracion Tabla Maestra
SELECT * INTO LOS_BORBOTONES.Inconsistencias FROM gd_esquema.Maestra WHERE 1 = 2; --se guardan en una tabla las inconsistencias

CREATE INDEX IDX_DIRECCION01 ON LOS_BORBOTONES.Direccion (Calle); --se crea indice a la tabla Direccion, el campo Calle

--Direccion
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarDireccion --inicio procedimiento
	AS
	BEGIN
		SET NOCOUNT ON;
			INSERT INTO LOS_BORBOTONES.Direccion(Calle, NumeroCalle, Piso, Depto)
				SELECT 	m.Cliente_Dom_Calle AS calle
						,m.Cliente_Nro_Calle
						,m.Cliente_Piso
						,m.Cliente_Depto
				FROM gd_esquema.Maestra m
				WHERE m.Cliente_Dom_Calle IS NOT NULL
				ORDER BY calle;

			INSERT INTO LOS_BORBOTONES.Direccion(Ciudad, Calle, NumeroCalle)
				SELECT	m.Hotel_Ciudad
						,m.Hotel_Calle AS calle
						,m.Hotel_Nro_Calle
				FROM gd_esquema.Maestra m
				WHERE m.Hotel_Calle IS NOT NULL
				ORDER BY calle;

			SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
	END --fin de procedimiento
EXECUTE sp_insertarDireccion;

--Identidad 
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarIdentidad --inicio procedimiento
	AS
	BEGIN
		SET NOCOUNT ON;
			INSERT INTO LOS_BORBOTONES.Identidad(Nombre, Apellido, NumeroDocumento, Mail, FechaNacimiento, Nacionalidad)
				SELECT  m.Cliente_Nombre, m.Cliente_Apellido, m.Cliente_Pasaporte_Nro,  
						m.Cliente_Mail, m.Cliente_Fecha_Nac, m.Cliente_Nacionalidad
				FROM gd_esquema.Maestra m
				WHERE m.Cliente_Nombre IS NOT NULL
				ORDER BY m.Cliente_Nombre;
		
			SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
	END --fin de procedimiento
EXECUTE sp_insertarIdentidad;

--Categoria
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarCategoria --inicio procedimiento
	AS
	BEGIN
		SET NOCOUNT ON;
			INSERT INTO Direccion(Ciudad, Calle, NumeroCalle) --tabla DER
			SELECT d.Hotel_Ciudad, d.Hotel_Calle, d.Hotel_Nro_Calle
			FROM @DireccionesHotel d 
		
			SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
		END --fin de procedimiento
EXECUTE sp_insertarCategoria;

--Regimen
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarRegimen --inicio procedimiento	
	AS
		BEGIN
			SET NOCOUNT ON;
			INSERT INTO LOS_BORBOTONES.Regimen(Descripcion, Precio)
			SELECT  m.Regimen_Descripcion, m.Regimen_Precio
			FROM gd_esquema.maestra m
			WHERE m.Regimen_Precio IS NOT NULL;
		
			SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
		END --fin de procedimiento
EXECUTE sp_insertarRegimen;

--Habitacion
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarHabitacion --inicio procedimiento
	AS
		BEGIN
			SET NOCOUNT ON;
			INSERT INTO LOS_BORBOTONES.Habitacion(Numero, Piso, Frente) 
			SELECT m.Habitacion_Numero, m.Habitacion_Piso, m.Habitacion_Frente
			FROM gd_esquema.maestra m
			WHERE m.Habitacion_Numero IS NOT NULL;
		
			SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
		END --fin de procedimiento
EXECUTE sp_insertarHabitacion;

--TipoHabitacion
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarTipoHabitacion --inicio procedimiento
	AS
		BEGIN
			SET NOCOUNT ON;
			INSERT INTO TipoHabitacion(Codigo, Descripcion, Porcentual) 
			SELECT m.Habitacion_Tipo_Codigo, m.Habitacion_Tipo_Descripcion, m.Habitacion_Tipo_Porcentual
			FROM gd_esquema.maestra m
			WHERE m.Habitacion_Tipo_Codigo IS NOT NULL;
		
			SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
		END --fin de procedimiento
EXECUTE sp_insertarTipoHabitacion;

--Reserva
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarReserva --inicio procedimiento
	AS
		BEGIN
			SET NOCOUNT ON;
			INSERT INTO Reserva(CodigoReserva, FechaCreacion, DiasAlojados) 
			SELECT m.Reserva_Codigo, m.Reserva_Fecha_Inicio, m.Reserva_Cant_Noches
			FROM gd_esquema.maestra m
			WHERE m.Reserva_Codigo IS NOT NULL;
		
			SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
		END --fin de procedimiento
EXECUTE sp_insertarReserva;

--Estadia
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarEstadia --inicio procedimiento
	AS
		BEGIN
			SET NOCOUNT ON;
			INSERT INTO Estadia(FechaEntrada, DiasAlojados) 
			SELECT m.Estadia_Fecha_Inicio, m.Estadia_Cant_Noches
			FROM gd_esquema.maestra m;
		
		SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
		END --fin de procedimiento
EXECUTE sp_insertarEstadia;

--Consumible
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarConsumible --inicio procedimiento
	AS
		BEGIN
			SET NOCOUNT ON;
			INSERT INTO Consumible(Codigo, Descripcion, Precio)
			SELECT m.Consumible_Codigo, m.Consumible_Descripcion, m.Consumible_Precio
			FROM gd_esquema.maestra m;
		
			SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
	END --fin de procedimiento
EXECUTE sp_insertarConsumible;

--ItemFactura
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarItemFactura --inicio procedimiento
	AS
		BEGIN
			SET NOCOUNT ON;
			INSERT INTO ItemFactura(Cantidad, Monto)
			SELECT m.Item_Factura_Cantidad, m.Item_Factura_Monto
			FROM gd_esquema.maestra m;
			
			SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
		END --fin de procedimiento
EXECUTE sp_insertarItemFactura;

--Factura
CREATE PROCEDURE LOS_BORBOTONES.sp_insertarFactura --inicio procedimiento	
	AS
		BEGIN
			SET NOCOUNT ON;
			INSERT INTO Factura(NumeroFactura, FechaFacturacion, Total)
			SELECT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total
			FROM gd_esquema.maestra m
			WHERE m.Factura_Nro IS NOT NULL;
		
			SELECT @@ROWCOUNT; --devuelve la cantidad de filas afectadas
		END --fin de procedimiento
EXECUTE sp_insertarFactura;

--FALTA CREAR LAS FOREIGN KEYS DE LS TABLAS QUE SOLO SON DE INDICES: 

--Reserva_X_Habitacion_X_Cliente
--Rol_X_Usuario
--Estadia_X_Consumible
--Hotel_X_Usuario
--Cliente
--CierreTemporal
--Usuario
--EstadoReserva


--Alta Roles Iniciales
INSERT INTO LOS_BORBOTONES.Rol (Nombre, Activo)
VALUES ('Administrador', 1), ('Recepcionista', 1), ('Guest', 1), ('RolDummy', 0);

--Alta Funcionalidades
INSERT INTO LOS_BORBOTONES.Funcionalidad (Descripcion)
VALUES ('ABMRol'), ('ABMReserva'), ('ABMUsuario'), ('ABMCliente'), ('ABMHotel'),
('ABMHabitacion'), ('ABMRégimenEstadía'), ('RegistrarEstadía'), ('RegistrarConsumible'), ('FacturarEstadía'), ('GenerarListadoEstadistico');

--Asociación Inicial Roles Funcionalidad
INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMRol'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMUsuario'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMCliente'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMHotel'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMHabitacion'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMRégimenEstadía'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Administrador'));

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMReserva'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'ABMReserva'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Guest'));

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'RegistrarEstadía'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));

--Estos últimos tres permisos no están validados (inferimos los roles asociados a la funcionalidad)
INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'RegistrarConsumible'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'FacturarEstadía'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));

INSERT INTO LOS_BORBOTONES.Funcionalidad_X_Rol (idFuncionalidad, idRol)
VALUES ((SELECT idFuncionalidad FROM LOS_BORBOTONES.Funcionalidad WHERE Descripcion = 'GenerarListadoEstadistico'),(SELECT idRol FROM LOS_BORBOTONES.Rol WHERE Nombre = 'Recepcionista'));



		