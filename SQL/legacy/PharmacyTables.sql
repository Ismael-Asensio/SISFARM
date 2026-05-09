--ventas
--Det_ventas
--compras
--Det_compras
--Distribuidores
--Clientes
--Productos
--Sucursales
--Conductores
--envios
--Usuarios

-----

--Tabla temporal... Vendedores

use master


create database Pharmacy

use Pharmacy


CREATE TABLE Departamento(
IdDep CHAR(5) PRIMARY KEY NOT NULL, 
NombreDep NVARCHAR(20) NOT NULL,
EstadoDep BIT DEFAULT 1 NOT NULL
)


CREATE TABLE Sucursales (
IdSuc CHAR(5) PRIMARY KEY NOT NULL,
NombreSuc NVARCHAR(15) NOT NULL,
DirSuc NVARCHAR(20) NOT NULL,
EstadoSuc BIT DEFAULT 1 NOT NULL,
Id_dept CHAR(5) FOREIGN KEY REFERENCES Departamento(IdDep) NOT NULL
)


CREATE TABLE Clientes(
IdCliente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
DirC NVARCHAR(70) NOT NULL,
TelC CHAR(8) CHECK(TelC LIKE '[2|5|7|8][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
EstadoC BIT DEFAULT 1 NOT NULL,
CodDep CHAR(5) FOREIGN KEY REFERENCES Departamento(IdDep) NOT NULL
)


CREATE TABLE ClienteNatural(
IDCN INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
PNCN NVARCHAR(15) NOT NULL,
SNCN NVARCHAR(15),
PACN NVARCHAR(15) NOT NULL,
SACN NVARCHAR(15),
TipoC CHAR(1) CHECK(TipoC LIKE '[A|R]'),
IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente) NOT NULL
)


CREATE TABLE ClienteJuridico(
IDCJ INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
PNCJur NVARCHAR(25) NOT NULL,
SNCJur NVARCHAR(25),
PACJur NVARCHAR(25) NOT NULL,
SACJur NVARCHAR(25),
CargoCJur NVARCHAR(25) NOT NULL,
IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente) NOT NULL
)


CREATE TABLE Proveedores(
RUC CHAR(5) PRIMARY KEY NOT NULL,
Nombreprov NVARCHAR(35) NOT NULL,
DirProv NVARCHAR(80) NOT NULL,
TelP CHAR(8) CHECK(TelP LIKE '[2|5|7|8][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
)


CREATE TABLE Cont_Asesor(
IdCont CHAR(4) PRIMARY KEY NOT NULL,
PNC NVARCHAR(15) NOT NULL,
SNC NVARCHAR(15),
PAC NVARCHAR(15) NOT NULL,
SAC NVARCHAR(15),
DirCont NVARCHAR(70) NOT NULL,
TelCont CHAR(8) CHECK(TelCont LIKE '[2|5|7|8][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
MailCont NVARCHAR(45),
IdDist CHAR(5) FOREIGN KEY REFERENCES Proveedores(RUC) NOT NULL
)


CREATE TABLE Productos(
CodProd INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
NombreProd NVARCHAR(45) NOT NULL,
DescProd NVARCHAR(50) NOT NULL,
PrecioP FLOAT NOT NULL,
ExistP INT NOT NULL,
EstadoP BIT DEFAULT 1 NOT NULL,
R_Receta BIT DEFAULT 0 NOT NULL,
FechaElab Date not null,
FechaVenc Date not null,
IdDist CHAR(5) FOREIGN KEY REFERENCES Proveedores(RUC) NOT NULL
)


create rule EntP
as
@V>0

sp_bindrule 'EntP','Productos.PrecioP'

create rule Ent
as
@X>=0

sp_bindrule 'Ent','Productos.ExistP'


Create TABLE Compras(
IdCompra INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
FechaCompra DATE NOT NULL,
IdDist CHAR(5) FOREIGN KEY REFERENCES Proveedores(RUC) NOT NULL,
SubtC MONEY,
TotalC MONEY
)

ALTER TABLE Compras
ALTER COLUMN SubtC MONEY;


CREATE TABLE DetCompras(
IdCompra INT FOREIGN KEY REFERENCES Compras(IdCompra) NOT NULL,
CodProd INT FOREIGN KEY REFERENCES Productos(CodProd) NOT NULL,
CantC INT NOT NULL,
PrecioC FLOAT NOT NULL,
SubtC FLOAT,
PRIMARY KEY(IdCompra, CodProd)
)
ALTER TABLE DetCompras
ALTER COLUMN SubtC MONEY;

CREATE TABLE Empleados(
DNI CHAR(15) PRIMARY KEY NOT NULL,
PNEmp NVARCHAR(25) NOT NULL,
SNEmp NVARCHAR(25),
PAEmp NVARCHAR(25) NOT NULL,
SAEmp NVARCHAR(25),
TelEmp CHAR(8) CHECK(TelEmp LIKE '[2|5|7|8][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
IdDep CHAR(5) FOREIGN KEY REFERENCES Departamento(IdDep),
IdSuc CHAR(5) FOREIGN KEY REFERENCES Sucursales(IdSuc) NOT NULL,
CargoEmp NVARCHAR(25) NOT NULL
)


CREATE TABLE Envios(
IdEnvio INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Origen NVARCHAR(70) NOT NULL,
Destinatario INT FOREIGN KEY REFERENCES Clientes(IdCliente) NOT NULL,
DNI CHAR(15) FOREIGN KEY REFERENCES Empleados(DNI) NOT NULL
)

ALTER TABLE Envios ADD EstadoEnv BIT DEFAULT 1


CREATE TABLE Ventas(
IdVenta INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
FechaV DATETIME DEFAULT GETDATE() NOT NULL,
IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente) NOT NULL,
TotalV FLOAT,
 VendedorId INT FOREIGN KEY REFERENCES Vendedores(VendedorId)
)

CREATE TABLE DetVentas(
IdVenta INT FOREIGN KEY REFERENCES Ventas(IdVenta) NOT NULL,
CodProd INT FOREIGN KEY REFERENCES Productos(CodProd) NOT NULL,
CantV INT NOT NULL,
SubtP FLOAT,
PRIMARY KEY(IdVenta, CodProd)
)



CREATE TABLE Vendedores (
    VendedorId INT identity (1,1) PRIMARY KEY CLUSTERED,
    DNI CHAR(15) FOREIGN KEY REFERENCES Empleados(DNI) NOT NULL,
    ValidFrom DATETIME2(2) GENERATED ALWAYS AS ROW START,
    ValidTo DATETIME2(2) GENERATED ALWAYS AS ROW END,
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.VentasHistory));

sp_bindrule 'Ent','Compras.subtc'
sp_bindrule 'Ent','Compras.totalc'
sp_bindrule 'EntP','Ventas.TotalV'
sp_bindrule 'EntP','DetCompras.cantc'
sp_bindrule 'EntP','DetCompras.precioc'
sp_bindrule 'Ent','DetCompras.subtc'

sp_bindrule 'EntP','DetVentas.cantv'
sp_bindrule 'Ent','DetVentas.subtp'


sp_bindrule 'EntP','Compras.SubtC'
sp_bindrule 'EntP','Compras.TotalC'


sp_bindrule 'EntP','DetCompras.PrecioC'
sp_bindrule 'EntP','DetCompras.SubtC'
sp_bindrule 'EntP','DetCompras.CantC'

sp_bindrule 'EntP','DetVentas.Cantv'
sp_bindrule 'EntP','DetVentas.SubtP'




INSERT INTO Departamento
VALUES
('001','Managua',1),
('002','Masaya',1),
('003','Madriz',1),
('004','Matagalpa',1),
('005','Nueva Segovia',1),
('006','Río San Juan',1),
('007','Rivas',1),
('008','León',1),
('009','Jinotega',1),
('010','Granada',1),
('011','Estelí',1),
('012','Chontales',1),
('013','Chinandega',1),
('014','Carazo',1),
('015','Boaco',1),
('016','RAAS',1),
('017','RAAN',1);


sp_addlogin 'ads', '1234'
sp_addsrvrolemember 'ads', 'sysadmin'


sp_addlogin 'Nestor','DaraLove*','Pharmacy'
sp_addsrvrolemember 'Nestor','processadmin'

USE Pharmacy

sp_adduser 'Nestor','Gerente'
sp_addrolemember 'db_datareader','Gerente'
sp_addrolemember 'db_datawriter','Gerente'


sp_addlogin 'Ramon','PaolaLove*','Pharmacy'
sp_addsrvrolemember 'Ramon','sellsadmin'

USE Pharmacy

sp_adduser 'Ramon','Vendedor'
sp_addrolemember 'db_datareader','Vendedor'
sp_addrolemember 'db_datawriter','Vendedor'


