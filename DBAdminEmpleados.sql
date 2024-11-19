CREATE DATABASE EmpleadosDB;
USE EmpleadosDB;

-- Tabla principal de empleados
CREATE TABLE Empleados (
    CedulaEmpleado INT PRIMARY KEY,
    Nombre VARCHAR(25),
    Apellido VARCHAR(25),
    FechaNacimiento DATE,
    AniosTrabajados INT,
    AniosTrabajadosEnPuestosDiferentes INT
);

-- Tabla de teléfonos (un empleado puede tener múltiples teléfonos)
CREATE TABLE TelefonosEmpleado (
    IdTelefono INT PRIMARY KEY IDENTITY,
    CedulaEmpleado INT,
    NumeroTelefono VARCHAR(20),
    FOREIGN KEY (CedulaEmpleado) REFERENCES Empleados(CedulaEmpleado) ON DELETE CASCADE
);

-- Tabla de direcciones (un empleado puede tener múltiples direcciones)
CREATE TABLE DireccionesEmpleado (
    IdDireccion INT PRIMARY KEY IDENTITY,
    CedulaEmpleado INT,
    Calle VARCHAR(50),
    Ciudad VARCHAR(50),
    Numero VARCHAR(10),
    FOREIGN KEY (CedulaEmpleado) REFERENCES Empleados(CedulaEmpleado) ON DELETE CASCADE
);

-- Tabla de puestos desempeñados (un empleado puede tener múltiples puestos)
CREATE TABLE PuestosEmpleado (
    IdPuesto INT PRIMARY KEY IDENTITY,
    CedulaEmpleado INT,
    PuestoDesempenado VARCHAR(50),
    FechaInicio DATE,
    FechaFin DATE,
    FOREIGN KEY (CedulaEmpleado) REFERENCES Empleados(CedulaEmpleado) ON DELETE CASCADE
);

-- Tabla de usuarios para autenticación
CREATE TABLE Usuarios (
    ID INT PRIMARY KEY IDENTITY,
    Usuario VARCHAR(50),
    Clave VARCHAR(100)
);

-- Poblar la tabla Empleados con datos de muestra
INSERT INTO Empleados (CedulaEmpleado, Nombre, Apellido, FechaNacimiento, AniosTrabajados, AniosTrabajadosEnPuestosDiferentes)
VALUES 
(1001, 'Juan', 'Pérez', '1980-05-12', 10, 3),
(1002, 'María', 'Gómez', '1990-11-23', 5, 2),
(1003, 'Luis', 'Ramírez', '1985-08-09', 7, 7),
(1004, 'Ana', 'Sánchez', '1992-04-15', 3, 3),
(1005, 'Pedro', 'Castillo', '1978-01-30', 15, 5),
(1006, 'Rosa', 'Martínez', '1983-07-20', 12, 4),
(1007, 'Javier', 'López', '1995-12-05', 2, 1),
(1008, 'Lucía', 'Fernández', '1987-09-30', 6, 6);

-- Poblar la tabla TelefonosEmpleado
INSERT INTO TelefonosEmpleado (CedulaEmpleado, NumeroTelefono)
VALUES 
(1001, '555-1234'), (1001, '555-5678'), (1002, '555-2345'),
(1003, '555-3456'), (1004, '555-4567'), (1004, '555-6789'),
(1005, '555-7890'), (1006, '555-8901'), (1007, '555-9012'), (1008, '555-0123');

-- Poblar la tabla DireccionesEmpleado
INSERT INTO DireccionesEmpleado (CedulaEmpleado, Calle, Ciudad, Numero)
VALUES 
(1001, 'Calle 10', 'Ciudad A', '101'),
(1002, 'Av. 2', 'Ciudad B', '202'),
(1003, 'Calle 5', 'Ciudad C', '303'),
(1004, 'Calle 15', 'Ciudad A', '404'),
(1005, 'Calle 20', 'Ciudad D', '505'),
(1006, 'Av. 7', 'Ciudad B', '606'),
(1007, 'Calle 30', 'Ciudad E', '707'),
(1008, 'Calle 40', 'Ciudad F', '808');

-- Poblar la tabla PuestosEmpleado
INSERT INTO PuestosEmpleado (CedulaEmpleado, PuestoDesempenado, FechaInicio, FechaFin)
VALUES 
(1001, 'Supervisor', '2010-01-01', '2015-12-31'),
(1001, 'Operador1', '2016-01-01', '2020-12-31'),
(1002, 'Mensajero', '2015-05-01', '2021-04-30'),
(1003, 'Operador2', '2013-07-15', '2019-06-30'),
(1004, 'Supervisor', '2012-03-20', '2017-02-28'),
(1004, 'Operador1', '2017-03-01', '2022-05-31'),
(1005, 'Mensajero', '2008-09-12', '2018-10-11'),
(1006, 'Operador2', '2014-04-05', '2021-08-20'),
(1007, 'Supervisor', '2019-01-01', '2023-01-31'),
(1008, 'Operador1', '2016-09-15', '2020-07-15');

INSERT INTO Usuarios (Usuario, Clave)
VALUES ('Admin', '1234');

Select * from Empleados;
Select * from TelefonosEmpleado;
Select * from DireccionesEmpleado;
Select * from PuestosEmpleado;
Select * from Usuarios;
