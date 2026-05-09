USE Pharmacy
GO

-- 1. Modificar ListProd
IF OBJECT_ID('ListProd') IS NOT NULL
BEGIN
    EXEC('
    ALTER PROC [dbo].[ListProd]
        @Offset INT = 0,
        @Fetch INT = 100
    AS
    BEGIN
        SELECT P.CodProd, P.NombreProd, P.DescProd, Pr.Nombreprov, P.PrecioP, P.ExistP, P.FechaElab, P.FechaVenc
        FROM Productos P
        INNER JOIN Proveedores Pr ON P.IdDist = Pr.RUC
        WHERE P.EstadoP = 1
        ORDER BY P.CodProd
        OFFSET @Offset ROWS FETCH NEXT @Fetch ROWS ONLY;
    END');
END
GO

-- 2. Modificar ListProdIn
IF OBJECT_ID('ListProdIn') IS NOT NULL
BEGIN
    EXEC('
    ALTER PROC [dbo].[ListProdIn]
        @Offset INT = 0,
        @Fetch INT = 100
    AS
    BEGIN
        SELECT P.CodProd, P.NombreProd, P.DescProd, Pr.Nombreprov, P.PrecioP, P.ExistP, P.FechaElab, P.FechaVenc
        FROM Productos P
        INNER JOIN Proveedores Pr ON P.IdDist = Pr.RUC
        WHERE P.EstadoP = 0
        ORDER BY P.CodProd
        OFFSET @Offset ROWS FETCH NEXT @Fetch ROWS ONLY;
    END');
END
GO

-- 3. Modificar ListVent
IF OBJECT_ID('ListVent') IS NOT NULL
BEGIN
    EXEC('
    ALTER PROC [dbo].[ListVent]
        @Offset INT = 0,
        @Fetch INT = 100
    AS
    BEGIN
        SELECT V.FechaV AS Feha, V.IdCliente, V.VendedorId, DV.CodProd, DV.CantV, DV.SubtP AS Subtotal, V.TotalV AS Total
        FROM Ventas V
        INNER JOIN DetVentas DV ON V.IdVenta = DV.IdVenta
        ORDER BY V.IdVenta DESC
        OFFSET @Offset ROWS FETCH NEXT @Fetch ROWS ONLY;
    END');
END
GO

-- 4. Modificar ListCompra
IF OBJECT_ID('ListCompra') IS NOT NULL
BEGIN
    EXEC('
    ALTER PROC [dbo].[ListCompra]
        @Offset INT = 0,
        @Fetch INT = 100
    AS
    BEGIN
        SELECT C.IdCompra, C.FechaCompra, C.IdDist, DC.CodProd, DC.CantC, DC.PrecioC, C.SubtC AS SubCompra, C.TotalC AS TotalCompra
        FROM Compras C
        INNER JOIN DetCompras DC ON C.IdCompra = DC.IdCompra
        ORDER BY C.IdCompra DESC
        OFFSET @Offset ROWS FETCH NEXT @Fetch ROWS ONLY;
    END');
END
GO

-- 5. Stored Procedures de conteo
CREATE OR ALTER PROC CountProd
    @Estado BIT
AS
BEGIN
    SELECT COUNT(*) FROM Productos WHERE EstadoP = @Estado;
END
GO

CREATE OR ALTER PROC CountVent
AS
BEGIN
    SELECT COUNT(*) FROM DetVentas;
END
GO

CREATE OR ALTER PROC CountCompra
AS
BEGIN
    SELECT COUNT(*) FROM DetCompras;
END
GO
