/*
  =====================================================
  SISFARM - Script Completo de Base de Datos
  Sistema de Farmacia - Nicaragua
  =====================================================
  USUARIO PARA INICIAR SESION:
    Usuario:  admin
    Password: Admin123*
    Rol:      sysadmin (acceso total)
  =====================================================
*/

USE master
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Pharmacy')
    DROP DATABASE Pharmacy
GO

CREATE DATABASE Pharmacy
GO

USE Pharmacy
GO

-- =====================================================
-- TABLAS DE CATALOGOS
-- =====================================================

CREATE TABLE Departamento(
    IdDep CHAR(5) PRIMARY KEY NOT NULL, 
    NombreDep NVARCHAR(20) NOT NULL,
    EstadoDep BIT DEFAULT 1 NOT NULL
)
GO

CREATE TABLE Sucursales(
    IdSuc CHAR(5) PRIMARY KEY NOT NULL,
    NombreSuc NVARCHAR(15) NOT NULL,
    DirSuc NVARCHAR(20) NOT NULL,
    EstadoSuc BIT DEFAULT 1 NOT NULL,
    Id_dept CHAR(5) FOREIGN KEY REFERENCES Departamento(IdDep) NOT NULL
)
GO

-- =====================================================
-- TABLAS DE CLIENTES
-- =====================================================

CREATE TABLE Clientes(
    IdCliente INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    DirC NVARCHAR(70) NOT NULL,
    TelC CHAR(8) CHECK(TelC LIKE '[2578][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    EstadoC BIT DEFAULT 1 NOT NULL,
    CodDep CHAR(5) FOREIGN KEY REFERENCES Departamento(IdDep) NOT NULL
)
GO

CREATE TABLE ClienteNatural(
    IDCN INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    PNCN NVARCHAR(15) NOT NULL, SNCN NVARCHAR(15),
    PACN NVARCHAR(15) NOT NULL, SACN NVARCHAR(15),
    TipoC CHAR(1) CHECK(TipoC IN ('A','R')),
    IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente) NOT NULL
)
GO

CREATE TABLE ClienteJuridico(
    IDCJ INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    PNCJur NVARCHAR(25) NOT NULL, SNCJur NVARCHAR(25),
    PACJur NVARCHAR(25) NOT NULL, SACJur NVARCHAR(25),
    CargoCJur NVARCHAR(25) NOT NULL,
    IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente) NOT NULL
)
GO

-- =====================================================
-- TABLAS DE PROVEEDORES Y CONTACTOS
-- =====================================================

CREATE TABLE Proveedores(
    RUC CHAR(5) PRIMARY KEY NOT NULL,
    Nombreprov NVARCHAR(35) NOT NULL,
    DirProv NVARCHAR(80) NOT NULL,
    TelP CHAR(8) CHECK(TelP LIKE '[2578][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
)
GO

CREATE TABLE Cont_Asesor(
    IdCont CHAR(4) PRIMARY KEY NOT NULL,
    PNC NVARCHAR(15) NOT NULL, SNC NVARCHAR(15),
    PAC NVARCHAR(15) NOT NULL, SAC NVARCHAR(15),
    DirCont NVARCHAR(70) NOT NULL,
    TelCont CHAR(8) CHECK(TelCont LIKE '[2578][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    MailCont NVARCHAR(45),
    IdDist CHAR(5) FOREIGN KEY REFERENCES Proveedores(RUC) NOT NULL
)
GO

-- =====================================================
-- TABLAS DE PRODUCTOS
-- =====================================================

CREATE TABLE Productos(
    CodProd INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    NombreProd NVARCHAR(45) NOT NULL,
    DescProd NVARCHAR(50) NOT NULL,
    PrecioP FLOAT NOT NULL CHECK (PrecioP > 0),
    ExistP INT NOT NULL CHECK (ExistP >= 0),
    EstadoP BIT DEFAULT 1 NOT NULL,
    R_Receta BIT DEFAULT 0 NOT NULL,
    FechaElab DATE NOT NULL,
    FechaVenc DATE NOT NULL,
    IdDist CHAR(5) FOREIGN KEY REFERENCES Proveedores(RUC) NOT NULL
)
GO

-- =====================================================
-- TABLAS DE EMPLEADOS Y VENDEDORES
-- =====================================================

CREATE TABLE Empleados(
    DNI CHAR(15) PRIMARY KEY NOT NULL,
    PNEmp NVARCHAR(25) NOT NULL, SNEmp NVARCHAR(25),
    PAEmp NVARCHAR(25) NOT NULL, SAEmp NVARCHAR(25),
    TelEmp CHAR(8) CHECK(TelEmp LIKE '[2578][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    IdDep CHAR(5) FOREIGN KEY REFERENCES Departamento(IdDep),
    IdSuc CHAR(5) FOREIGN KEY REFERENCES Sucursales(IdSuc) NOT NULL,
    CargoEmp NVARCHAR(25) NOT NULL
)
GO

CREATE TABLE Vendedores(
    VendedorId INT IDENTITY(1,1) PRIMARY KEY CLUSTERED,
    DNI CHAR(15) FOREIGN KEY REFERENCES Empleados(DNI) NOT NULL,
    ValidFrom DATETIME2(2) GENERATED ALWAYS AS ROW START,
    ValidTo DATETIME2(2) GENERATED ALWAYS AS ROW END,
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.VentasHistory))
GO

-- =====================================================
-- TABLAS DE COMPRAS
-- =====================================================

CREATE TABLE Compras(
    IdCompra INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    FechaCompra DATE NOT NULL,
    IdDist CHAR(5) FOREIGN KEY REFERENCES Proveedores(RUC) NOT NULL,
    SubtC MONEY CHECK (SubtC >= 0),
    TotalC MONEY CHECK (TotalC >= 0)
)
GO

CREATE TABLE DetCompras(
    IdCompra INT FOREIGN KEY REFERENCES Compras(IdCompra) NOT NULL,
    CodProd INT FOREIGN KEY REFERENCES Productos(CodProd) NOT NULL,
    CantC INT NOT NULL CHECK (CantC > 0),
    PrecioC FLOAT NOT NULL CHECK (PrecioC > 0),
    SubtC MONEY CHECK (SubtC >= 0),
    PRIMARY KEY(IdCompra, CodProd)
)
GO

-- =====================================================
-- TABLAS DE VENTAS
-- =====================================================

CREATE TABLE Ventas(
    IdVenta INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    FechaV DATETIME DEFAULT GETDATE() NOT NULL,
    IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente) NOT NULL,
    TotalV FLOAT CHECK (TotalV > 0),
    VendedorId INT FOREIGN KEY REFERENCES Vendedores(VendedorId)
)
GO

CREATE TABLE DetVentas(
    IdVenta INT FOREIGN KEY REFERENCES Ventas(IdVenta) NOT NULL,
    CodProd INT FOREIGN KEY REFERENCES Productos(CodProd) NOT NULL,
    CantV INT NOT NULL CHECK (CantV > 0),
    SubtP FLOAT CHECK (SubtP >= 0),
    PRIMARY KEY(IdVenta, CodProd)
)
GO

-- =====================================================
-- TABLAS DE ENVIOS
-- =====================================================

CREATE TABLE Envios(
    IdEnvio INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Origen NVARCHAR(70) NOT NULL,
    Destinatario INT FOREIGN KEY REFERENCES Clientes(IdCliente) NOT NULL,
    DNI CHAR(15) FOREIGN KEY REFERENCES Empleados(DNI) NOT NULL,
    EstadoEnv BIT DEFAULT 1
)
GO

PRINT '>> Tablas creadas exitosamente.'
GO

-- =====================================================
-- FUNCIONES
-- =====================================================

CREATE FUNCTION CSubtDC (@PC MONEY, @CDC INT) RETURNS MONEY
AS BEGIN RETURN @PC * @CDC END
GO

CREATE FUNCTION SubtotalProd (@CP INT, @cv INT) RETURNS MONEY
AS BEGIN
    DECLARE @stp MONEY
    SELECT @stp = PrecioP * @cv FROM Productos WHERE CodProd = @CP
    RETURN @stp
END
GO

-- =====================================================
-- STORED PROCEDURES - LISTADOS
-- =====================================================

CREATE PROC ListClientJ AS SELECT * FROM ClienteJuridico
GO
CREATE PROC ListClientN AS SELECT * FROM ClienteNatural
GO
CREATE PROC ListCompra AS
    SELECT C.IdCompra, C.FechaCompra, C.IdDist, DC.CodProd, DC.CantC,
           DC.PrecioC, C.SubtC AS SubCompra, C.TotalC AS TotalCompra
    FROM Compras C INNER JOIN DetCompras DC ON C.IdCompra = DC.IdCompra
GO
CREATE PROC ListProd AS SELECT * FROM Productos WHERE EstadoP = 1
GO
CREATE PROC ListProdIn AS SELECT * FROM Productos WHERE EstadoP = 0
GO
CREATE PROC ListVent AS
    SELECT V.FechaV AS Fecha, V.IdCliente, V.VendedorId, DV.CodProd,
           DV.CantV, DV.SubtP AS Subtotal, V.TotalV AS Total
    FROM Ventas V INNER JOIN DetVentas DV ON V.IdVenta = DV.IdVenta
GO
CREATE PROC ListEmp AS SELECT * FROM Empleados
GO
CREATE PROC ListSupp AS SELECT * FROM Proveedores
GO
CREATE PROC ListCA AS SELECT * FROM Cont_Asesor
GO
CREATE PROC ListEnv AS SELECT * FROM Envios WHERE EstadoEnv = 1
GO
CREATE PROC ListEnvIn AS SELECT * FROM Envios WHERE EstadoEnv = 0
GO
CREATE PROC ListSuc AS SELECT * FROM Sucursales WHERE EstadoSuc = 1
GO
CREATE PROC ListSucIn AS SELECT * FROM Sucursales WHERE EstadoSuc = 0
GO
CREATE PROC ListDep AS SELECT * FROM Departamento WHERE EstadoDep = 1
GO

PRINT '>> Procedimientos de listado creados.'
GO

-- =====================================================
-- STORED PROCEDURES - INSERCIONES
-- =====================================================

CREATE PROCEDURE NClientNat
    @Dir NVARCHAR(70), @Tel NVARCHAR(8), @Cd NVARCHAR(5),
    @PN NVARCHAR(15), @SN NVARCHAR(15), @PA NVARCHAR(15), @SA NVARCHAR(15), @TPC CHAR(1)
AS BEGIN
    SET NOCOUNT ON
    DECLARE @IdCliente INT
    INSERT INTO Clientes(DirC, TelC, EstadoC, CodDep) VALUES(@Dir, @Tel, 1, @Cd)
    SET @IdCliente = SCOPE_IDENTITY()
    INSERT INTO ClienteNatural(PNCN, SNCN, PACN, SACN, TipoC, IdCliente)
    VALUES(@PN, @SN, @PA, @SA, @TPC, @IdCliente)
END
GO

CREATE PROCEDURE NClientJur
    @Dir NVARCHAR(70), @Tel NVARCHAR(8), @Cd NVARCHAR(5),
    @PN NVARCHAR(25), @SN NVARCHAR(25), @PA NVARCHAR(25), @SA NVARCHAR(25), @Cargo NVARCHAR(25)
AS BEGIN
    SET NOCOUNT ON
    DECLARE @IdCliente INT
    INSERT INTO Clientes(DirC, TelC, EstadoC, CodDep) VALUES(@Dir, @Tel, 1, @Cd)
    SET @IdCliente = SCOPE_IDENTITY()
    INSERT INTO ClienteJuridico(PNCJur, SNCJur, PACJur, SACJur, CargoCJur, IdCliente)
    VALUES(@PN, @SN, @PA, @SA, @Cargo, @IdCliente)
END
GO

CREATE PROCEDURE NuevoEmpleado
    @DNI CHAR(15), @PN VARCHAR(25), @SN VARCHAR(25), @PA VARCHAR(25), @SA VARCHAR(25),
    @Tel CHAR(8), @idDep CHAR(5), @idSuc CHAR(5), @Cargo VARCHAR(25)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Departamento WHERE IdDep=@idDep)
    OR NOT EXISTS (SELECT 1 FROM Sucursales WHERE IdSuc=@idSuc)
    BEGIN PRINT 'Departamento o Sucursal no validos' RETURN END
    INSERT INTO Empleados VALUES(@DNI, @PN, @SN, @PA, @SA, @Tel, @idDep, @idSuc, @Cargo)
END
GO

CREATE PROCEDURE NuevosProveedores
    @RUC CHAR(5), @NP NVARCHAR(35), @Dir NVARCHAR(80), @Tel CHAR(8)
AS BEGIN
    SET NOCOUNT ON
    IF @RUC='' OR @NP='' OR @Dir='' OR @Tel=''
    BEGIN PRINT 'No podemos tener registros en blanco' RETURN END
    INSERT INTO Proveedores VALUES(@RUC, @NP, @Dir, @Tel)
END
GO

CREATE PROCEDURE NuevosContactos
    @PN NVARCHAR(15), @SN NVARCHAR(15), @PA NVARCHAR(15), @SA NVARCHAR(15),
    @Dir NVARCHAR(70), @Tel CHAR(8), @Mail NVARCHAR(45), @RUC CHAR(5)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE RUC=@RUC)
    BEGIN PRINT 'Proveedor no existe' RETURN END
    INSERT INTO Cont_Asesor VALUES(@RUC, @PN, @SN, @PA, @SA, @Dir, @Tel, @Mail, @RUC)
END
GO

CREATE PROCEDURE NuevoEnvio
    @Origen NVARCHAR(70), @Destinatario VARCHAR(15), @DNI CHAR(15)
AS BEGIN
    SET NOCOUNT ON
    IF @Origen='' OR @Destinatario='' OR @DNI=''
    BEGIN PRINT 'No podemos tener registros en blanco' RETURN END
    INSERT INTO Envios(Origen, Destinatario, DNI, EstadoEnv) VALUES(@Origen, @Destinatario, @DNI, 1)
END
GO

CREATE PROCEDURE NuevoProducto
    @NP VARCHAR(45), @Desc VARCHAR(50), @PP FLOAT, @Exist INT, @FE NVARCHAR(10), @RUC NVARCHAR(5)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE RUC=@RUC)
    BEGIN PRINT 'Proveedor no existe' RETURN END
    INSERT INTO Productos(NombreProd, DescProd, PrecioP, ExistP, EstadoP, R_Receta, FechaElab, FechaVenc, IdDist)
    VALUES(@NP, @Desc, @PP, @Exist, 1, 0, @FE, DATEADD(YEAR, 2, CAST(@FE AS DATE)), @RUC)
END
GO

PRINT '>> Procedimientos de insercion creados.'
GO

-- =====================================================
-- STORED PROCEDURES - ACTUALIZACIONES
-- =====================================================

CREATE PROCEDURE ActualizarProducto
    @NP NVARCHAR(45), @Desc NVARCHAR(50), @PP FLOAT, @Exist INT, @FE NVARCHAR(10), @IDP INT
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Productos WHERE CodProd=@IDP AND EstadoP=1)
    BEGIN PRINT 'Producto no encontrado o inactivo' RETURN END
    UPDATE Productos SET NombreProd=@NP, DescProd=@Desc, PrecioP=@PP, ExistP=@Exist, FechaElab=@FE
    WHERE CodProd=@IDP AND EstadoP=1
END
GO

-- FIX: Ahora recibe @DNI como parametro (antes nunca funcionaba el WHERE)
CREATE PROCEDURE ActualizarEmpleado
    @DNI CHAR(15), @PN VARCHAR(25), @SN VARCHAR(25), @PA VARCHAR(25), @SA VARCHAR(25),
    @Tel CHAR(8), @idDep CHAR(5), @idSuc CHAR(5), @Cargo VARCHAR(25)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Departamento WHERE IdDep=@idDep)
    BEGIN PRINT 'Departamento no existe' RETURN END
    IF NOT EXISTS (SELECT 1 FROM Sucursales WHERE IdSuc=@idSuc)
    BEGIN PRINT 'Sucursal no existe' RETURN END
    UPDATE Empleados SET PNEmp=@PN, SNEmp=@SN, PAEmp=@PA, SAEmp=@SA,
        TelEmp=@Tel, IdDep=@idDep, IdSuc=@idSuc, CargoEmp=@Cargo
    WHERE DNI=@DNI
END
GO

CREATE PROCEDURE ActClienteNat
    @Dir NVARCHAR(70), @Tel CHAR(8), @Cd CHAR(5),
    @PN NVARCHAR(15), @SN NVARCHAR(15), @PA NVARCHAR(15), @SA NVARCHAR(15), @TPC CHAR(1)
AS BEGIN
    SET NOCOUNT ON
    UPDATE ClienteNatural SET PNCN=@PN, SNCN=@SN, PACN=@PA, SACN=@SA, TipoC=@TPC
    WHERE PNCN=@PN AND PACN=@PA
END
GO

CREATE PROCEDURE ActClienteJur
    @Dir NVARCHAR(70), @Tel CHAR(8), @Cd CHAR(5),
    @PN NVARCHAR(25), @SN NVARCHAR(25), @PA NVARCHAR(25), @SA NVARCHAR(25), @Cargo NVARCHAR(25)
AS BEGIN
    SET NOCOUNT ON
    UPDATE ClienteJuridico SET PNCJur=@PN, SNCJur=@SN, PACJur=@PA, SACJur=@SA, CargoCJur=@Cargo
    WHERE PNCJur=@PN AND PACJur=@PA
END
GO

CREATE PROCEDURE ActualizarProveedores
    @RUC CHAR(5), @NP NVARCHAR(35), @Dir NVARCHAR(80), @Tel CHAR(8)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE RUC=@RUC)
    BEGIN PRINT 'Proveedor no existe' RETURN END
    UPDATE Proveedores SET Nombreprov=@NP, DirProv=@Dir, TelP=@Tel WHERE RUC=@RUC
END
GO

CREATE PROCEDURE ActualizarContactos
    @IdC CHAR(4), @PN NVARCHAR(15), @SN NVARCHAR(15), @PA NVARCHAR(15), @SA NVARCHAR(15),
    @Dir NVARCHAR(70), @Tel CHAR(8), @Mail NVARCHAR(45), @RUC CHAR(5)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE RUC=@RUC)
    BEGIN PRINT 'Proveedor no existe' RETURN END
    UPDATE Cont_Asesor SET PNC=@PN, SNC=@SN, PAC=@PA, SAC=@SA,
        DirCont=@Dir, TelCont=@Tel, MailCont=@Mail, IdDist=@RUC
    WHERE IdCont=@IdC
END
GO

CREATE PROCEDURE CambiarEstadoEnvio @IdEnvio INT
AS BEGIN
    SET NOCOUNT ON
    UPDATE Envios SET EstadoEnv=1 WHERE IdEnvio=@IdEnvio
END
GO

PRINT '>> Procedimientos de actualizacion creados.'
GO

-- =====================================================
-- STORED PROCEDURES - DAR DE BAJA
-- =====================================================

CREATE PROCEDURE DarBProducto @CodP INT
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Productos WHERE CodProd=@CodP)
    BEGIN PRINT 'Producto no encontrado' RETURN END
    UPDATE Productos SET EstadoP=0 WHERE CodProd=@CodP
END
GO

CREATE PROCEDURE DarBSuc @IDS CHAR(5)
AS BEGIN SET NOCOUNT ON
    UPDATE Sucursales SET EstadoSuc=0 WHERE IdSuc=@IDS
END
GO

CREATE PROCEDURE DarBEnv @IDS INT
AS BEGIN SET NOCOUNT ON
    UPDATE Envios SET EstadoEnv=0 WHERE IdEnvio=@IDS
END
GO

CREATE PROCEDURE CamRec @IDS INT
AS BEGIN SET NOCOUNT ON
    UPDATE Productos SET R_Receta=1 WHERE CodProd=@IDS AND R_Receta=0
END
GO

PRINT '>> Procedimientos de baja creados.'
GO

-- =====================================================
-- STORED PROCEDURES - GESTION DE COMPRAS Y VENTAS
-- =====================================================

CREATE PROCEDURE GestionDeCompras
    @NR VARCHAR(5), @cc INT, @CP VARCHAR(10), @pc FLOAT
AS BEGIN
    SET NOCOUNT ON
    BEGIN TRANSACTION
    BEGIN TRY
        DECLARE @IdCompra INT
        INSERT INTO Compras(FechaCompra, IdDist, SubtC, TotalC) VALUES(GETDATE(), @NR, 0, 0)
        SET @IdCompra = SCOPE_IDENTITY()
        INSERT INTO DetCompras VALUES(@IdCompra, @CP, @cc, @pc, dbo.CSubtDC(@pc, @cc))
        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
        PRINT 'Error en gestion de compras: ' + ERROR_MESSAGE()
    END CATCH
END
GO

CREATE PROCEDURE NuevoDetVenta @IDV INT, @CP INT, @cv INT
AS BEGIN
    SET NOCOUNT ON
    DECLARE @Existencia INT
    SELECT @Existencia = ExistP FROM Productos WHERE CodProd = @CP
    IF @Existencia IS NULL BEGIN PRINT 'Producto no registrado' RETURN END
    IF @cv <= 0 OR @cv > @Existencia BEGIN PRINT 'Cantidad invalida o excede existencia' RETURN END
    INSERT INTO DetVentas(IdVenta, CodProd, CantV, SubtP)
    VALUES(@IDV, @CP, @cv, dbo.SubtotalProd(@CP, @cv))
END
GO

CREATE PROCEDURE GestionarVentas @IDC INT, @VID INT, @CP INT, @cv INT
AS BEGIN
    SET NOCOUNT ON
    DECLARE @IdVenta INT
    BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO Ventas(FechaV, IdCliente, TotalV, VendedorId)
        VALUES(GETDATE(), @IDC, 1, @VID)
        SET @IdVenta = SCOPE_IDENTITY()
        IF @IdVenta IS NOT NULL
        BEGIN
            EXEC NuevoDetVenta @IdVenta, @CP, @cv
            COMMIT
        END
        ELSE BEGIN ROLLBACK PRINT 'No se pudo obtener ID de venta' END
    END TRY
    BEGIN CATCH
        ROLLBACK
        PRINT 'Error al gestionar venta: ' + ERROR_MESSAGE()
    END CATCH
END
GO

PRINT '>> Procedimientos de gestion creados.'
GO

-- =====================================================
-- TRIGGERS
-- =====================================================

CREATE TRIGGER ActualizarInv ON DetCompras AFTER INSERT
AS BEGIN
    SET NOCOUNT ON
    UPDATE P SET ExistP = ExistP + I.CantC,
        PrecioP = CASE WHEN I.PrecioC > P.PrecioP THEN I.PrecioC * 1.08 ELSE P.PrecioP END
    FROM Productos P JOIN inserted I ON P.CodProd = I.CodProd

    UPDATE DC SET SubtC = DC.CantC * DC.PrecioC
    FROM DetCompras DC JOIN inserted I ON DC.IdCompra = I.IdCompra AND DC.CodProd = I.CodProd

    UPDATE C SET TotalC = (SELECT SUM(SubtC) FROM DetCompras WHERE IdCompra = I.IdCompra) * 1.15
    FROM Compras C JOIN inserted I ON C.IdCompra = I.IdCompra
END
GO

CREATE TRIGGER ActualizarInvPostV ON DetVentas AFTER INSERT
AS BEGIN
    SET NOCOUNT ON
    UPDATE P SET ExistP = ExistP - I.CantV
    FROM Productos P JOIN inserted I ON P.CodProd = I.CodProd
END
GO

CREATE TRIGGER ActualizarV ON DetVentas AFTER INSERT
AS BEGIN
    SET NOCOUNT ON
    UPDATE V SET TotalV = (SELECT SUM(SubtP) FROM DetVentas WHERE IdVenta = V.IdVenta) * 1.15
    FROM Ventas V JOIN inserted I ON V.IdVenta = I.IdVenta
END
GO

PRINT '>> Triggers creados.'
GO

-- =====================================================
-- DATOS INICIALES - DEPARTAMENTOS DE NICARAGUA
-- =====================================================

INSERT INTO Departamento VALUES
('001','Managua',1), ('002','Masaya',1), ('003','Madriz',1),
('004','Matagalpa',1), ('005','Nueva Segovia',1), ('006','Rio San Juan',1),
('007','Rivas',1), ('008','Leon',1), ('009','Jinotega',1),
('010','Granada',1), ('011','Esteli',1), ('012','Chontales',1),
('013','Chinandega',1), ('014','Carazo',1), ('015','Boaco',1),
('016','RACCN',1), ('017','RACCS',1)
GO

-- Sucursal inicial
INSERT INTO Sucursales VALUES('S001', 'Central', 'Managua Centro', 1, '001')
GO

PRINT '>> Datos iniciales insertados.'
GO

-- =====================================================
-- SEGURIDAD - LOGINS Y USUARIOS
-- =====================================================
-- USUARIO PRINCIPAL PARA INICIAR SESION:
--   Usuario:  admin
--   Password: Admin123*
--   Rol:      sysadmin (acceso completo)
-- =====================================================

USE master
GO

-- Login administrador principal
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'admin')
    DROP LOGIN [admin]
GO
CREATE LOGIN [admin] WITH PASSWORD = 'Admin123*', DEFAULT_DATABASE = Pharmacy
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [admin]
GO

-- Login gerente (acceso limitado)
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'gerente')
    DROP LOGIN [gerente]
GO
CREATE LOGIN [gerente] WITH PASSWORD = 'Gerente123*', DEFAULT_DATABASE = Pharmacy
GO
ALTER SERVER ROLE [processadmin] ADD MEMBER [gerente]
GO

-- Usuarios de base de datos
USE Pharmacy
GO

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'gerente')
    CREATE USER [gerente] FOR LOGIN [gerente]
GO
ALTER ROLE [db_datareader] ADD MEMBER [gerente]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [gerente]
GO
GRANT EXECUTE TO [gerente]
GO

PRINT '>> Seguridad configurada exitosamente.'
PRINT ''
PRINT '============================================='
PRINT '  CREDENCIALES PARA INICIAR SESION:'
PRINT '  Usuario:  admin'
PRINT '  Password: Admin123*'
PRINT '  Rol:      Administrador (acceso total)'
PRINT '============================================='
PRINT '  Usuario:  gerente'
PRINT '  Password: Gerente123*'
PRINT '  Rol:      Gerente (acceso limitado)'
PRINT '============================================='
GO
