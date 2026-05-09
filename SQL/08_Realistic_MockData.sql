USE Pharmacy
GO

SET NOCOUNT ON;

PRINT 'Limpiando datos de prueba anteriores...'
DELETE FROM DetVentas;
DELETE FROM Ventas;
DBCC CHECKIDENT ('Ventas', RESEED, 0);

DELETE FROM DetCompras;
DELETE FROM Compras;
DBCC CHECKIDENT ('Compras', RESEED, 0);

DELETE FROM Productos WHERE NombreProd LIKE 'Producto_Mock_%' OR NombreProd LIKE 'Prod_%';

PRINT 'Generando 10 Clientes Nuevos...'
DECLARE @c INT = 1;
WHILE @c <= 10
BEGIN
    INSERT INTO Clientes (DirC, TelC, EstadoC, CodDep) VALUES ('Direccion ' + CAST(@c AS VARCHAR), '8000000' + CAST(@c-1 AS VARCHAR), 1, 'MN01');
    DECLARE @IdC INT = SCOPE_IDENTITY();
    IF @c <= 5
        INSERT INTO ClienteNatural (PNCN, PACN, TipoC, IdCliente) VALUES ('Nombre' + CAST(@c AS VARCHAR), 'Ape' + CAST(@c AS VARCHAR), 'A', @IdC);
    ELSE
        INSERT INTO ClienteJuridico (PNCJur, PACJur, CargoCJur, IdCliente) VALUES ('Empresa ' + CAST(@c AS VARCHAR), 'SA', 'Gerente', @IdC);
    SET @c = @c + 1;
END

PRINT 'Generando 10 Vendedores Nuevos...'
DECLARE @v INT = 1;
WHILE @v <= 10
BEGIN
    DECLARE @DNI CHAR(15) = '002-000000-000' + CAST(@v AS VARCHAR);
    IF NOT EXISTS(SELECT 1 FROM Empleados WHERE DNI = @DNI)
    BEGIN
        INSERT INTO Empleados (DNI, PNEmp, PAEmp, IdSuc, CargoEmp) VALUES (@DNI, 'Vend' + CAST(@v AS VARCHAR), 'Ape' + CAST(@v AS VARCHAR), '001  ', 'Vendedor');
        INSERT INTO Vendedores (DNI) VALUES (@DNI);
    END
    SET @v = @v + 1;
END

PRINT 'Generando ~10,000 Productos Reales Farmaceuticos...'
CREATE TABLE #Principios (Nombre NVARCHAR(50));
INSERT INTO #Principios VALUES ('Paracetamol'), ('Ibuprofeno'), ('Amoxicilina'), ('Loratadina'), ('Diclofenaco'), ('Omeprazol'), ('Losartan'), ('Metformina'), ('Azitromicina'), ('Cetirizina'), ('Naproxeno'), ('Aspirina'), ('Ciprofloxacino'), ('Fluconazol'), ('Salbutamol'), ('Dexametasona'), ('Prednisona'), ('Enalapril'), ('Amlodipino'), ('Atorvastatina'), ('Simvastatina'), ('Clonazepam'), ('Alprazolam'), ('Sertralina'), ('Fluoxetina'), ('Tramadol'), ('Ketorolaco'), ('Meloxicam'), ('Clindamicina'), ('Cefalexina'), ('Ceftriaxona'), ('Bismuto'), ('Loperamida'), ('Metoclopramida'), ('Ondansetron'), ('Pantoprazol'), ('Ranitidina'), ('Glibenclamida'), ('Insulina'), ('Levotiroxina'), ('Vitamina C'), ('Complejo B'), ('Hierro'), ('Calcio'), ('Zinc'), ('Acido Folico'), ('Desloratadina'), ('Fexofenadina'), ('Montelukast'), ('Salmeterol');

CREATE TABLE #Marcas (Marca NVARCHAR(50));
INSERT INTO #Marcas VALUES ('Genfar'), ('MK'), ('Bayer'), ('Pfizer'), ('Novartis'), ('Sanofi'), ('GSK'), ('AstraZeneca'), ('Roche'), ('Abbott'), ('Boehringer'), ('Teva'), ('Sandoz'), ('Mylan'), ('Merck'), ('Lilly'), ('Bago'), ('Roemmers'), ('Saval'), ('La Sante');

CREATE TABLE #Presentaciones (Pres NVARCHAR(50));
INSERT INTO #Presentaciones VALUES ('500 mg x 100 Tabs'), ('1 g x 50 Tabs'), ('200 mg x 20 Caps'), ('10 mg x 30 Tabs'), ('50 mg x 100 Tabs'), ('500 mg x 10 Caps'), ('125 mg/5ml Jarabe'), ('250 mg/5ml Susp'), ('100 mg Inyectable'), ('Gotas 15ml');

INSERT INTO Productos (NombreProd, DescProd, PrecioP, ExistP, EstadoP, R_Receta, FechaElab, FechaVenc, IdDist)
SELECT TOP 10000 
    p.Nombre + ' ' + pr.Pres,
    m.Marca,
    (ABS(CHECKSUM(NEWID())) % 500) + 10,
    (ABS(CHECKSUM(NEWID())) % 500) + 50,
    CASE WHEN (ABS(CHECKSUM(NEWID())) % 100) < 5 THEN 0 ELSE 1 END,
    CASE WHEN (ABS(CHECKSUM(NEWID())) % 100) < 30 THEN 1 ELSE 0 END,
    DATEADD(MONTH, -(ABS(CHECKSUM(NEWID())) % 12), GETDATE()),
    DATEADD(MONTH, (ABS(CHECKSUM(NEWID())) % 36) + 6, GETDATE()),
    CASE WHEN (ABS(CHECKSUM(NEWID())) % 2) = 0 THEN 'D09' ELSE 'ID03' END
FROM #Principios p CROSS JOIN #Marcas m CROSS JOIN #Presentaciones pr;

DROP TABLE #Principios;
DROP TABLE #Marcas;
DROP TABLE #Presentaciones;

CREATE TABLE #ValidProds (Id INT IDENTITY(1,1), CodProd INT);
INSERT INTO #ValidProds (CodProd) SELECT CodProd FROM Productos;
DECLARE @CountProds INT = (SELECT COUNT(*) FROM #ValidProds);

CREATE TABLE #ValidClients (Id INT IDENTITY(1,1), IdCliente INT);
INSERT INTO #ValidClients (IdCliente) SELECT IdCliente FROM Clientes;
DECLARE @CountClients INT = (SELECT COUNT(*) FROM #ValidClients);

CREATE TABLE #ValidVendedores (Id INT IDENTITY(1,1), VendedorId INT);
INSERT INTO #ValidVendedores (VendedorId) SELECT VendedorId FROM Vendedores;
DECLARE @CountVendedores INT = (SELECT COUNT(*) FROM #ValidVendedores);

PRINT 'Generando 10,000 Compras...'
;WITH N1(C) AS (SELECT 1 UNION ALL SELECT 1),
N2(C) AS (SELECT 1 FROM N1 AS T1 CROSS JOIN N1 AS T2),
N3(C) AS (SELECT 1 FROM N2 AS T1 CROSS JOIN N2 AS T2),
N4(C) AS (SELECT 1 FROM N3 AS T1 CROSS JOIN N3 AS T2),
N5(C) AS (SELECT 1 FROM N4 AS T1 CROSS JOIN N4 AS T2),
Nums AS (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS N FROM N5)

INSERT INTO Compras (FechaCompra, IdDist, SubtC, TotalC)
SELECT TOP 10000 
    DATEADD(DAY, -(ABS(CHECKSUM(NEWID())) % 730), GETDATE()), 
    CASE WHEN (ABS(CHECKSUM(NEWID())) % 2) = 0 THEN 'D09' ELSE 'ID03' END,
    0, 0
FROM Nums;

INSERT INTO DetCompras (IdCompra, CodProd, CantC, PrecioC, SubtC)
SELECT 
    c.IdCompra,
    vp.CodProd,
    (ABS(CHECKSUM(NEWID())) % 50) + 1,
    (ABS(CHECKSUM(NEWID())) % 300) + 10,
    0
FROM Compras c
CROSS APPLY (SELECT CodProd FROM #ValidProds WHERE Id = (ABS(CHECKSUM(NEWID())) % @CountProds) + 1) vp;

UPDATE DetCompras SET SubtC = CantC * PrecioC;

;WITH CTE AS (SELECT IdCompra, SUM(SubtC) as TotalS FROM DetCompras GROUP BY IdCompra)
UPDATE c SET c.SubtC = cte.TotalS, c.TotalC = cte.TotalS * 1.15
FROM Compras c INNER JOIN CTE cte ON c.IdCompra = cte.IdCompra;


PRINT 'Generando 10,000 Ventas...'
;WITH N1(C) AS (SELECT 1 UNION ALL SELECT 1),
N2(C) AS (SELECT 1 FROM N1 AS T1 CROSS JOIN N1 AS T2),
N3(C) AS (SELECT 1 FROM N2 AS T1 CROSS JOIN N2 AS T2),
N4(C) AS (SELECT 1 FROM N3 AS T1 CROSS JOIN N3 AS T2),
N5(C) AS (SELECT 1 FROM N4 AS T1 CROSS JOIN N4 AS T2),
Nums AS (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS N FROM N5)

INSERT INTO Ventas (FechaV, IdCliente, TotalV, VendedorId)
SELECT TOP 10000 
    DATEADD(DAY, -(ABS(CHECKSUM(NEWID())) % 730), GETDATE()), 
    vc.IdCliente,
    1,
    vv.VendedorId
FROM Nums
CROSS APPLY (SELECT IdCliente FROM #ValidClients WHERE Id = (ABS(CHECKSUM(NEWID())) % @CountClients) + 1) vc
CROSS APPLY (SELECT VendedorId FROM #ValidVendedores WHERE Id = (ABS(CHECKSUM(NEWID())) % @CountVendedores) + 1) vv;

INSERT INTO DetVentas (IdVenta, CodProd, CantV, SubtP)
SELECT 
    v.IdVenta,
    vp.CodProd,
    (ABS(CHECKSUM(NEWID())) % 5) + 1,
    (ABS(CHECKSUM(NEWID())) % 400) + 20
FROM Ventas v
CROSS APPLY (SELECT CodProd FROM #ValidProds WHERE Id = (ABS(CHECKSUM(NEWID())) % @CountProds) + 1) vp;

;WITH CTE AS (SELECT IdVenta, SUM(SubtP) as TotalS FROM DetVentas GROUP BY IdVenta)
UPDATE v SET v.TotalV = cte.TotalS * 1.15
FROM Ventas v INNER JOIN CTE cte ON v.IdVenta = cte.IdVenta;

DROP TABLE #ValidProds;
DROP TABLE #ValidClients;
DROP TABLE #ValidVendedores;

PRINT 'Limpieza de inconsistencias...'
-- Eliminar ventas con IdCliente o VendedorId inexistentes por el random offset (raro pero posible)
DELETE FROM Ventas WHERE IdCliente NOT IN (SELECT IdCliente FROM Clientes);
DELETE FROM Ventas WHERE VendedorId NOT IN (SELECT VendedorId FROM Vendedores);
DELETE FROM DetVentas WHERE IdVenta NOT IN (SELECT IdVenta FROM Ventas);
DELETE FROM DetVentas WHERE CodProd NOT IN (SELECT CodProd FROM Productos);
DELETE FROM DetCompras WHERE CodProd NOT IN (SELECT CodProd FROM Productos);

PRINT '¡10,000 registros de farmacia reales generados exitosamente!'
GO
