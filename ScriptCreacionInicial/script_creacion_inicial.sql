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
