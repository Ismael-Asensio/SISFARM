/*
  SISFARM - Stored Procedures para Dashboard/Reportes
  Ejecutar en SSMS sobre la BD Pharmacy
*/
USE Pharmacy
GO

-- Resumen general del sistema
CREATE OR ALTER PROCEDURE sp_Dashboard_Resumen
AS BEGIN
    SET NOCOUNT ON
    SELECT
        (SELECT COUNT(*) FROM Productos WHERE EstadoP = 1) AS TotalProductos,
        (SELECT COUNT(*) FROM Clientes WHERE EstadoC = 1) AS TotalClientes,
        (SELECT COUNT(*) FROM Proveedores) AS TotalProveedores,
        (SELECT COUNT(*) FROM Empleados) AS TotalEmpleados,
        (SELECT ISNULL(SUM(TotalV), 0) FROM Ventas WHERE MONTH(FechaV) = MONTH(GETDATE()) AND YEAR(FechaV) = YEAR(GETDATE())) AS VentasMes,
        (SELECT ISNULL(SUM(TotalC), 0) FROM Compras WHERE MONTH(FechaCompra) = MONTH(GETDATE()) AND YEAR(FechaCompra) = YEAR(GETDATE())) AS ComprasMes,
        (SELECT COUNT(*) FROM Ventas WHERE MONTH(FechaV) = MONTH(GETDATE()) AND YEAR(FechaV) = YEAR(GETDATE())) AS CantVentasMes,
        (SELECT COUNT(*) FROM Compras WHERE MONTH(FechaCompra) = MONTH(GETDATE()) AND YEAR(FechaCompra) = YEAR(GETDATE())) AS CantComprasMes
END
GO

-- Top 10 productos mas vendidos
CREATE OR ALTER PROCEDURE sp_Dashboard_TopProductos
AS BEGIN
    SET NOCOUNT ON
    SELECT TOP 10
        P.CodProd, P.NombreProd AS Producto,
        SUM(DV.CantV) AS CantidadVendida,
        CAST(SUM(DV.SubtP) AS DECIMAL(18,2)) AS TotalGenerado
    FROM DetVentas DV
    INNER JOIN Productos P ON DV.CodProd = P.CodProd
    GROUP BY P.CodProd, P.NombreProd
    ORDER BY CantidadVendida DESC
END
GO

-- Productos con stock bajo (menos de 10 unidades)
CREATE OR ALTER PROCEDURE sp_Dashboard_StockBajo
AS BEGIN
    SET NOCOUNT ON
    SELECT
        P.CodProd, P.NombreProd AS Producto,
        P.ExistP AS Existencia,
        P.FechaVenc AS Vencimiento,
        PR.Nombreprov AS Proveedor
    FROM Productos P
    INNER JOIN Proveedores PR ON P.IdDist = PR.RUC
    WHERE P.EstadoP = 1 AND P.ExistP < 10
    ORDER BY P.ExistP ASC
END
GO

-- Ventas recientes (ultimas 20)
CREATE OR ALTER PROCEDURE sp_Dashboard_VentasRecientes
AS BEGIN
    SET NOCOUNT ON
    SELECT TOP 20
        V.IdVenta, V.FechaV AS Fecha,
        V.IdCliente AS Cliente,
        P.NombreProd AS Producto,
        DV.CantV AS Cantidad,
        CAST(DV.SubtP AS DECIMAL(18,2)) AS Subtotal,
        CAST(V.TotalV AS DECIMAL(18,2)) AS Total
    FROM Ventas V
    INNER JOIN DetVentas DV ON V.IdVenta = DV.IdVenta
    INNER JOIN Productos P ON DV.CodProd = P.CodProd
    ORDER BY V.FechaV DESC
END
GO

-- Compras recientes (ultimas 20)
CREATE OR ALTER PROCEDURE sp_Dashboard_ComprasRecientes
AS BEGIN
    SET NOCOUNT ON
    SELECT TOP 20
        C.IdCompra, C.FechaCompra AS Fecha,
        PR.Nombreprov AS Proveedor,
        P.NombreProd AS Producto,
        DC.CantC AS Cantidad,
        CAST(DC.PrecioC AS DECIMAL(18,2)) AS Precio,
        CAST(C.TotalC AS DECIMAL(18,2)) AS Total
    FROM Compras C
    INNER JOIN DetCompras DC ON C.IdCompra = DC.IdCompra
    INNER JOIN Productos P ON DC.CodProd = P.CodProd
    INNER JOIN Proveedores PR ON C.IdDist = PR.RUC
    ORDER BY C.FechaCompra DESC
END
GO

-- Resumen de ventas por mes (ultimos 12 meses)
CREATE OR ALTER PROCEDURE sp_Dashboard_VentasPorMes
AS BEGIN
    SET NOCOUNT ON
    SELECT
        FORMAT(V.FechaV, 'yyyy-MM') AS Mes,
        COUNT(DISTINCT V.IdVenta) AS CantVentas,
        CAST(ISNULL(SUM(V.TotalV), 0) AS DECIMAL(18,2)) AS TotalVentas
    FROM Ventas V
    WHERE V.FechaV >= DATEADD(MONTH, -12, GETDATE())
    GROUP BY FORMAT(V.FechaV, 'yyyy-MM')
    ORDER BY Mes DESC
END
GO

-- Productos proximos a vencer (90 dias)
CREATE OR ALTER PROCEDURE sp_Dashboard_ProximosVencer
AS BEGIN
    SET NOCOUNT ON
    SELECT
        P.CodProd, P.NombreProd AS Producto,
        P.ExistP AS Existencia,
        P.FechaVenc AS FechaVencimiento,
        DATEDIFF(DAY, GETDATE(), P.FechaVenc) AS DiasRestantes,
        PR.Nombreprov AS Proveedor
    FROM Productos P
    INNER JOIN Proveedores PR ON P.IdDist = PR.RUC
    WHERE P.EstadoP = 1 AND DATEDIFF(DAY, GETDATE(), P.FechaVenc) <= 90
    ORDER BY P.FechaVenc ASC
END
GO

PRINT '>> Stored procedures de Dashboard creados exitosamente.'
GO
