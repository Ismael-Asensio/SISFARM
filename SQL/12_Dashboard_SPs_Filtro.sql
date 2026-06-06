/*
  SISFARM - Stored Procedures con Filtro de Fechas para Dashboard
  Ejecutar en SSMS sobre la BD Pharmacy
*/
USE Pharmacy
GO

-- ============================================================
-- Resumen KPIs filtrado por rango de fechas
-- ============================================================
CREATE OR ALTER PROCEDURE sp_Dashboard_Resumen_Filtro
    @FechaInicio DATE,
    @FechaFin    DATE
AS BEGIN
    SET NOCOUNT ON
    SELECT
        (SELECT COUNT(*) FROM Productos WHERE EstadoP = 1)  AS TotalProductos,
        (SELECT COUNT(*) FROM Clientes  WHERE EstadoC = 1)  AS TotalClientes,
        (SELECT ISNULL(SUM(TotalV), 0) FROM Ventas
            WHERE CAST(FechaV       AS DATE) BETWEEN @FechaInicio AND @FechaFin) AS VentasMes,
        (SELECT ISNULL(SUM(TotalC), 0) FROM Compras
            WHERE CAST(FechaCompra  AS DATE) BETWEEN @FechaInicio AND @FechaFin) AS ComprasMes,
        (SELECT COUNT(*) FROM Ventas
            WHERE CAST(FechaV       AS DATE) BETWEEN @FechaInicio AND @FechaFin) AS CantVentasMes,
        (SELECT COUNT(*) FROM Compras
            WHERE CAST(FechaCompra  AS DATE) BETWEEN @FechaInicio AND @FechaFin) AS CantComprasMes
END
GO

-- ============================================================
-- Ventas por mes filtradas (para gráfico de barras y tendencia)
-- ============================================================
CREATE OR ALTER PROCEDURE sp_Dashboard_VentasPorMes_Filtro
    @FechaInicio DATE,
    @FechaFin    DATE
AS BEGIN
    SET NOCOUNT ON

    ;WITH CTE_Ventas AS (
        SELECT
            FORMAT(FechaV, 'yyyy-MM')                       AS Mes,
            COUNT(DISTINCT IdVenta)                         AS CantVentas,
            CAST(ISNULL(SUM(TotalV), 0) AS DECIMAL(18,2))  AS TotalVentas
        FROM Ventas
        WHERE CAST(FechaV AS DATE) BETWEEN @FechaInicio AND @FechaFin
        GROUP BY FORMAT(FechaV, 'yyyy-MM')
    ),
    CTE_Compras AS (
        SELECT
            FORMAT(FechaCompra, 'yyyy-MM')                  AS Mes,
            CAST(ISNULL(SUM(TotalC), 0) AS DECIMAL(18,2))  AS TotalCompras
        FROM Compras
        WHERE CAST(FechaCompra AS DATE) BETWEEN @FechaInicio AND @FechaFin
        GROUP BY FORMAT(FechaCompra, 'yyyy-MM')
    )
    SELECT
        ISNULL(V.Mes, C.Mes)                    AS Mes,
        ISNULL(V.CantVentas, 0)                 AS CantVentas,
        ISNULL(V.TotalVentas,  0)               AS TotalVentas,
        ISNULL(C.TotalCompras, 0)               AS TotalCompras
    FROM CTE_Ventas V
    FULL OUTER JOIN CTE_Compras C ON V.Mes = C.Mes
    ORDER BY Mes ASC
END
GO

-- ============================================================
-- Top 10 productos más vendidos filtrado por fecha
-- ============================================================
CREATE OR ALTER PROCEDURE sp_Dashboard_TopProductos_Filtro
    @FechaInicio DATE,
    @FechaFin    DATE
AS BEGIN
    SET NOCOUNT ON
    SELECT TOP 10
        P.CodProd,
        P.NombreProd                                    AS Producto,
        SUM(DV.CantV)                                   AS CantidadVendida,
        CAST(SUM(DV.SubtP) AS DECIMAL(18,2))            AS TotalGenerado
    FROM DetVentas DV
    INNER JOIN Ventas   V ON DV.IdVenta  = V.IdVenta
    INNER JOIN Productos P ON DV.CodProd = P.CodProd
    WHERE CAST(V.FechaV AS DATE) BETWEEN @FechaInicio AND @FechaFin
    GROUP BY P.CodProd, P.NombreProd
    ORDER BY CantidadVendida DESC
END
GO

PRINT '>> SPs de Dashboard con filtro de fechas creados exitosamente.'
GO
