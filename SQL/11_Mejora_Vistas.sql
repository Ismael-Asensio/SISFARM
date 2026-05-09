USE Pharmacy
GO

IF OBJECT_ID('ListVent') IS NOT NULL
BEGIN
    EXEC('
    ALTER PROC [dbo].[ListVent]
        @Offset INT = 0,
        @Fetch INT = 100
    AS
    BEGIN
        SELECT 
            V.IdVenta,
            V.FechaV AS Feha,
            ISNULL(CN.PNCN + '' '' + CN.PACN, CJ.PNCJur + '' '' + CJ.PACJur) AS Cliente,
            E.PNEmp + '' '' + E.PAEmp AS Vendedor,
            P.NombreProd AS Producto,
            DV.CantV,
            DV.SubtP AS Subtotal,
            V.TotalV AS Total
        FROM Ventas V
        INNER JOIN DetVentas DV ON V.IdVenta = DV.IdVenta
        INNER JOIN Productos P ON DV.CodProd = P.CodProd
        INNER JOIN Vendedores VD ON V.VendedorId = VD.VendedorId
        INNER JOIN Empleados E ON VD.DNI = E.DNI
        LEFT JOIN ClienteNatural CN ON V.IdCliente = CN.IdCliente
        LEFT JOIN ClienteJuridico CJ ON V.IdCliente = CJ.IdCliente
        ORDER BY V.IdVenta DESC
        OFFSET @Offset ROWS FETCH NEXT @Fetch ROWS ONLY;
    END');
END
GO

IF OBJECT_ID('ListCompra') IS NOT NULL
BEGIN
    EXEC('
    ALTER PROC [dbo].[ListCompra]
        @Offset INT = 0,
        @Fetch INT = 100
    AS
    BEGIN
        SELECT 
            C.IdCompra,
            C.FechaCompra,
            Pr.Nombreprov AS Proveedor,
            P.NombreProd AS Producto,
            DC.CantC,
            DC.PrecioC,
            C.SubtC AS SubCompra,
            C.TotalC AS TotalCompra
        FROM Compras C
        INNER JOIN DetCompras DC ON C.IdCompra = DC.IdCompra
        INNER JOIN Productos P ON DC.CodProd = P.CodProd
        INNER JOIN Proveedores Pr ON C.IdDist = Pr.RUC
        ORDER BY C.IdCompra DESC
        OFFSET @Offset ROWS FETCH NEXT @Fetch ROWS ONLY;
    END');
END
GO
