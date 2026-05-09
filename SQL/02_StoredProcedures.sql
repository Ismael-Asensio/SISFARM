/*
  SISFARM - Script 02: Stored Procedures
  Todos los SPs consolidados y ordenados por entidad.
  Fix: ActualizarEmpleado ahora recibe @DNI como parámetro.
  Fix: NuevoEnvio con tipos correctos.
*/
USE Pharmacy
GO

-- ===================== LISTADOS =====================

CREATE OR ALTER PROC ListClientJ AS SELECT * FROM ClienteJuridico
GO
CREATE OR ALTER PROC ListClientN AS SELECT * FROM ClienteNatural
GO
CREATE OR ALTER PROC ListCompra AS
BEGIN
    SELECT C.IdCompra, C.FechaCompra, C.IdDist, DC.CodProd, DC.CantC,
           DC.PrecioC, C.SubtC AS SubCompra, C.TotalC AS TotalCompra
    FROM Compras C INNER JOIN DetCompras DC ON C.IdCompra = DC.IdCompra
END
GO
CREATE OR ALTER PROC ListProd AS SELECT * FROM Productos WHERE EstadoP = 1
GO
CREATE OR ALTER PROC ListProdIn AS SELECT * FROM Productos WHERE EstadoP = 0
GO
CREATE OR ALTER PROC ListVent AS
BEGIN
    SELECT V.FechaV AS Fecha, V.IdCliente, V.VendedorId, DV.CodProd,
           DV.CantV, DV.SubtP AS Subtotal, V.TotalV AS Total
    FROM Ventas V INNER JOIN DetVentas DV ON V.IdVenta = DV.IdVenta
END
GO
CREATE OR ALTER PROC ListEmp AS SELECT * FROM Empleados
GO
CREATE OR ALTER PROC ListSupp AS SELECT * FROM Proveedores
GO
CREATE OR ALTER PROC ListCA AS SELECT * FROM Cont_Asesor
GO
CREATE OR ALTER PROC ListEnv AS SELECT * FROM Envios WHERE EstadoEnv = 1
GO
CREATE OR ALTER PROC ListEnvIn AS SELECT * FROM Envios WHERE EstadoEnv = 0
GO
CREATE OR ALTER PROC ListSuc AS SELECT * FROM Sucursales WHERE EstadoSuc = 1
GO
CREATE OR ALTER PROC ListSucIn AS SELECT * FROM Sucursales WHERE EstadoSuc = 0
GO
CREATE OR ALTER PROC ListDep AS SELECT * FROM Departamento WHERE EstadoDep = 1
GO

-- ===================== INSERCIONES =====================

CREATE OR ALTER PROCEDURE NClientNat
    @Dir NVARCHAR(70), @Tel NVARCHAR(8), @Cd NVARCHAR(5),
    @PN NVARCHAR(15), @SN NVARCHAR(15), @PA NVARCHAR(15), @SA NVARCHAR(15), @TPC CHAR(1)
AS BEGIN
    SET NOCOUNT ON
    DECLARE @IdCliente INT
    INSERT INTO Clientes(DirC, TelC, EstadoC, CodDep) VALUES(@Dir, @Tel, 1, @Cd)
    SET @IdCliente = SCOPE_IDENTITY()
    INSERT INTO ClienteNatural(PNCN, SNCN, PACN, SACN, TipoC, IdCliente) VALUES(@PN, @SN, @PA, @SA, @TPC, @IdCliente)
END
GO

CREATE OR ALTER PROCEDURE NClientJur
    @Dir NVARCHAR(70), @Tel NVARCHAR(8), @Cd NVARCHAR(5),
    @PN NVARCHAR(25), @SN NVARCHAR(25), @PA NVARCHAR(25), @SA NVARCHAR(25), @Cargo NVARCHAR(25)
AS BEGIN
    SET NOCOUNT ON
    DECLARE @IdCliente INT
    INSERT INTO Clientes(DirC, TelC, EstadoC, CodDep) VALUES(@Dir, @Tel, 1, @Cd)
    SET @IdCliente = SCOPE_IDENTITY()
    INSERT INTO ClienteJuridico(PNCJur, SNCJur, PACJur, SACJur, CargoCJur, IdCliente) VALUES(@PN, @SN, @PA, @SA, @Cargo, @IdCliente)
END
GO

CREATE OR ALTER PROCEDURE NuevoEmpleado
    @DNI CHAR(15), @PN VARCHAR(25), @SN VARCHAR(25), @PA VARCHAR(25), @SA VARCHAR(25),
    @Tel CHAR(8), @idDep CHAR(5), @idSuc CHAR(5), @Cargo VARCHAR(25)
AS BEGIN
    SET NOCOUNT ON
    IF EXISTS (SELECT 1 FROM Departamento WHERE IdDep = @idDep)
    AND EXISTS (SELECT 1 FROM Sucursales WHERE IdSuc = @idSuc)
    BEGIN
        INSERT INTO Empleados VALUES(@DNI, @PN, @SN, @PA, @SA, @Tel, @idDep, @idSuc, @Cargo)
    END
    ELSE PRINT 'Departamento o Sucursal no válidos'
END
GO

CREATE OR ALTER PROCEDURE NuevosProveedores
    @RUC CHAR(5), @NP NVARCHAR(35), @Dir NVARCHAR(80), @Tel CHAR(8)
AS BEGIN
    SET NOCOUNT ON
    IF @RUC = '' OR @NP = '' OR @Dir = '' OR @Tel = '' BEGIN PRINT 'No podemos tener registros en blanco' RETURN END
    INSERT INTO Proveedores VALUES(@RUC, @NP, @Dir, @Tel)
END
GO

CREATE OR ALTER PROCEDURE NuevosContactos
    @PN NVARCHAR(15), @SN NVARCHAR(15), @PA NVARCHAR(15), @SA NVARCHAR(15),
    @Dir NVARCHAR(70), @Tel CHAR(8), @Mail NVARCHAR(45), @RUC CHAR(5)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE RUC = @RUC) BEGIN PRINT 'Proveedor no existe' RETURN END
    INSERT INTO Cont_Asesor VALUES(@RUC, @PN, @SN, @PA, @SA, @Dir, @Tel, @Mail, @RUC)
END
GO

CREATE OR ALTER PROCEDURE NuevoEnvio
    @Origen NVARCHAR(70), @Destinatario VARCHAR(15), @DNI CHAR(15)
AS BEGIN
    SET NOCOUNT ON
    IF @Origen = '' OR @Destinatario = '' OR @DNI = '' BEGIN PRINT 'No podemos tener registros en blanco' RETURN END
    INSERT INTO Envios(Origen, Destinatario, DNI, EstadoEnv) VALUES(@Origen, @Destinatario, @DNI, 1)
END
GO

CREATE OR ALTER PROCEDURE NuevoProducto
    @NP VARCHAR(45), @Desc VARCHAR(50), @PP FLOAT, @Exist INT, @FE NVARCHAR(10), @RUC NVARCHAR(5)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE RUC = @RUC) BEGIN PRINT 'Proveedor no existe' RETURN END
    INSERT INTO Productos(NombreProd, DescProd, PrecioP, ExistP, EstadoP, R_Receta, FechaElab, FechaVenc, IdDist)
    VALUES(@NP, @Desc, @PP, @Exist, 1, 0, @FE, DATEADD(YEAR, 2, @FE), @RUC)
END
GO

-- ===================== ACTUALIZACIONES =====================

CREATE OR ALTER PROCEDURE ActualizarProducto
    @NP NVARCHAR(45), @Desc NVARCHAR(50), @PP FLOAT, @Exist INT, @FE NVARCHAR(10), @IDP INT
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Productos WHERE CodProd = @IDP AND EstadoP = 1) BEGIN PRINT 'Producto no encontrado' RETURN END
    UPDATE Productos SET NombreProd=@NP, DescProd=@Desc, PrecioP=@PP, ExistP=@Exist, FechaElab=@FE WHERE CodProd=@IDP AND EstadoP=1
END
GO

-- FIX: Ahora recibe @DNI como parámetro para el WHERE (antes se autorreferenciaba y nunca funcionaba)
CREATE OR ALTER PROCEDURE ActualizarEmpleado
    @DNI CHAR(15), @PN VARCHAR(25), @SN VARCHAR(25), @PA VARCHAR(25), @SA VARCHAR(25),
    @Tel CHAR(8), @idDep CHAR(5), @idSuc CHAR(5), @Cargo VARCHAR(25)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Departamento WHERE IdDep = @idDep) BEGIN PRINT 'Departamento no existe' RETURN END
    IF NOT EXISTS (SELECT 1 FROM Sucursales WHERE IdSuc = @idSuc) BEGIN PRINT 'Sucursal no existe' RETURN END
    UPDATE Empleados SET PNEmp=@PN, SNEmp=@SN, PAEmp=@PA, SAEmp=@SA, TelEmp=@Tel, IdDep=@idDep, IdSuc=@idSuc, CargoEmp=@Cargo
    WHERE DNI=@DNI
END
GO

CREATE OR ALTER PROCEDURE ActClienteNat
    @Dir NVARCHAR(70), @Tel CHAR(8), @Cd CHAR(5),
    @PN NVARCHAR(15), @SN NVARCHAR(15), @PA NVARCHAR(15), @SA NVARCHAR(15), @TPC CHAR(1)
AS BEGIN
    SET NOCOUNT ON
    UPDATE ClienteNatural SET PNCN=@PN, SNCN=@SN, PACN=@PA, SACN=@SA, TipoC=@TPC WHERE PNCN=@PN AND PACN=@PA
END
GO

CREATE OR ALTER PROCEDURE ActClienteJur
    @Dir NVARCHAR(70), @Tel CHAR(8), @Cd CHAR(5),
    @PN NVARCHAR(25), @SN NVARCHAR(25), @PA NVARCHAR(25), @SA NVARCHAR(25), @Cargo NVARCHAR(25)
AS BEGIN
    SET NOCOUNT ON
    UPDATE ClienteJuridico SET PNCJur=@PN, SNCJur=@SN, PACJur=@PA, SACJur=@SA, CargoCJur=@Cargo WHERE PNCJur=@PN AND PACJur=@PA
END
GO

CREATE OR ALTER PROCEDURE ActualizarProveedores
    @RUC CHAR(5), @NP NVARCHAR(35), @Dir NVARCHAR(80), @Tel CHAR(8)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE RUC=@RUC) BEGIN PRINT 'Proveedor no existe' RETURN END
    UPDATE Proveedores SET Nombreprov=@NP, DirProv=@Dir, TelP=@Tel WHERE RUC=@RUC
END
GO

CREATE OR ALTER PROCEDURE ActualizarContactos
    @IdC CHAR(4), @PN NVARCHAR(15), @SN NVARCHAR(15), @PA NVARCHAR(15), @SA NVARCHAR(15),
    @Dir NVARCHAR(70), @Tel CHAR(8), @Mail NVARCHAR(45), @RUC CHAR(5)
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE RUC=@RUC) BEGIN PRINT 'Proveedor no existe' RETURN END
    UPDATE Cont_Asesor SET PNC=@PN, SNC=@SN, PAC=@PA, SAC=@SA, DirCont=@Dir, TelCont=@Tel, MailCont=@Mail, IdDist=@RUC WHERE IdCont=@IdC
END
GO

CREATE OR ALTER PROCEDURE CambiarEstadoEnvio @IdEnvio INT
AS BEGIN
    SET NOCOUNT ON
    UPDATE Envios SET EstadoEnv=1 WHERE IdEnvio=@IdEnvio
END
GO

-- ===================== DAR DE BAJA =====================

CREATE OR ALTER PROCEDURE DarBProducto @CodP INT
AS BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT 1 FROM Productos WHERE CodProd=@CodP) BEGIN PRINT 'Producto no encontrado' RETURN END
    UPDATE Productos SET EstadoP=0 WHERE CodProd=@CodP
END
GO

CREATE OR ALTER PROCEDURE DarBSuc @IDS CHAR(5)
AS BEGIN
    SET NOCOUNT ON
    UPDATE Sucursales SET EstadoSuc=0 WHERE IdSuc=@IDS
END
GO

CREATE OR ALTER PROCEDURE DarBEnv @IDS INT
AS BEGIN
    SET NOCOUNT ON
    UPDATE Envios SET EstadoEnv=0 WHERE IdEnvio=@IDS
END
GO

CREATE OR ALTER PROCEDURE CamRec @IDS INT
AS BEGIN
    SET NOCOUNT ON
    UPDATE Productos SET R_Receta=1 WHERE CodProd=@IDS AND R_Receta=0
END
GO
