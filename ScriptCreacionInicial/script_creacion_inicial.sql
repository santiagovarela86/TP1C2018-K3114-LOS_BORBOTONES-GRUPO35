CREATE SCHEMA LOS_BORBOTONES AUTHORIZATION gdHotel2018

CREATE TABLE LOS_BORBOTONES.Rol (

	idRol	INT			IDENTITY(1,1)	NOT NULL,
	Nombre	VARCHAR(45) 				NOT NULL,
	Activo	BIT							NOT NULL,
	PRIMARY KEY(idRol)

)

CREATE TABLE LOS_BORBOTONES.Funcionalidad (

	idFuncionalidad	INT			IDENTITY(1,1)	NOT NULL,
	Descripcion 	VARCHAR(45)					NOT NULL,
	PRIMARY KEY (idFuncionalidad)

)

CREATE TABLE LOS_BORBOTONES.Funcionalidad_X_Rol (

	idFuncionalidad	INT			NOT NULL,
	idRol			INT			NOT NULL,
	PRIMARY KEY (idFuncionalidad, idRol),
	FOREIGN KEY (idFuncionalidad) REFERENCES Funcionalidad (idFuncionalidad),
	FOREIGN KEY (idRol) REFERENCES Rol (idRol),
)

GO

INSERT INTO LOS_BORBOTONES.Rol (Nombre, Activo)
VALUES ('Administrador', 1), ('Recepcionista', 1), ('Guest', 1);

INSERT INTO LOS_BORBOTONES.Funcionalidad (Descripcion)
VALUES ('ABMRoles'), ('ABMReservas'), ('ABMUsuarios'), ('ABMClientes'), ('ABMHoteles'),
('ABMHabitaciones'), ('ABMRegímenesEstadía'), ('ABMEstadías'), ('ModificarUsuarios');

