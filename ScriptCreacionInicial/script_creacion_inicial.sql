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
	TipoIdentidad			VARCHAR(45),
	Nombre					NVARCHAR(255),
	Apellido				NVARCHAR(255),
	TipoDocumento			VARCHAR(45),
	NumeroDocumento			VARCHAR(45),
	Mail					NVARCHAR(255),
	FechaNacimiento			DATETIME,
	FechaInicioActividades	VARCHAR(45),
	Nacionalidad			NVARCHAR(255),
	Telefono				VARCHAR(45),
	PRIMARY KEY	(idIdentidad)
)

--Creacion Tabla Direccion
CREATE TABLE LOS_BORBOTONES.Direccion (

	idDireccion		INT				IDENTITY(1,1)	NOT NULL,
	Pais			VARCHAR(45),
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
	Estado					VARCHAR(45),
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

	idHotel		INT					IDENTITY(1,1)	NOT NULL	UNIQUE,
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
	Codigo			VARCHAR(45),
	Descripcion		NVARCHAR(255),
	Precio			NUMERIC(18,2),
	Estado			VARCHAR(45),
	idHotel			INT				NOT NULL,
	PRIMARY KEY (idRegimen),
	FOREIGN KEY (idHotel) REFERENCES Hotel (idHotel)
)

--Creacion Tabla TipoHabitacion
CREATE TABLE LOS_BORBOTONES.TipoHabitacion (

	idTipoHabitacion	INT				NOT NULL,
	Codigo				VARCHAR(45),
	Porcentual			VARCHAR(45),
	Descripcion			VARCHAR(45),
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
	PRIMARY KEY (idHabitacion),
	FOREIGN KEY (idHotel) REFERENCES Hotel (idHotel),
	FOREIGN KEY (idTipoHabitacion) REFERENCES TipoHabitacion (idTipoHabitacion)
)

--Creacion Tabla Estadia
CREATE TABLE LOS_BORBOTONES.Estadia (

	idEstadia		INT			NOT NULL,
	FechaEntrada	DATETIME,
	FechaSalida		DATETIME,
	Facturada		BIT,
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
		FechaCreacion		DATETIME,
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
