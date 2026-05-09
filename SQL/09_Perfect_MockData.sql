USE Pharmacy
GO

SET NOCOUNT ON;

PRINT '1. Limpiando datos de prueba anteriores...'
DELETE FROM DetVentas;
DELETE FROM Ventas;
DBCC CHECKIDENT ('Ventas', RESEED, 0);

DELETE FROM DetCompras;
DELETE FROM Compras;
DBCC CHECKIDENT ('Compras', RESEED, 0);

DELETE FROM Productos WHERE CodProd NOT IN (1, 2, 3); -- Conservamos la data seed original
DBCC CHECKIDENT ('Productos', RESEED, 3);

PRINT '2. Generando 10,000 Productos...'
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

PRINT '3. Preparando IDs seguros...'
CREATE TABLE #ValidProds (Id INT IDENTITY(1,1) PRIMARY KEY, CodProd INT);
INSERT INTO #ValidProds (CodProd) SELECT CodProd FROM Productos;
DECLARE @CountProds INT = (SELECT COUNT(*) FROM #ValidProds);

CREATE TABLE #ValidClients (Id INT IDENTITY(1,1) PRIMARY KEY, IdCliente INT);
INSERT INTO #ValidClients (IdCliente) SELECT IdCliente FROM Clientes;
DECLARE @CountClients INT = (SELECT COUNT(*) FROM #ValidClients);

CREATE TABLE #ValidVendedores (Id INT IDENTITY(1,1) PRIMARY KEY, VendedorId INT);
INSERT INTO #ValidVendedores (VendedorId) SELECT VendedorId FROM Vendedores;
DECLARE @CountVendedores INT = (SELECT COUNT(*) FROM #ValidVendedores);


PRINT '4. Generando 10,000 Compras y sus Detalles...'
;WITH N1(C) AS (SELECT 1 UNION ALL SELECT 1),
N2(C) AS (SELECT 1 FROM N1 AS T1 CROSS JOIN N1 AS T2),
N3(C) AS (SELECT 1 FROM N2 AS T1 CROSS JOIN N2 AS T2),
N4(C) AS (SELECT 1 FROM N3 AS T1 CROSS JOIN N3 AS T2),
N5(C) AS (SELECT 1 FROM N4 AS T1 CROSS JOIN N4 AS T2),
Nums AS (SELECT TOP 10000 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS N FROM N5)

INSERT INTO Compras (FechaCompra, IdDist, SubtC, TotalC)
SELECT 
    DATEADD(DAY, -(ABS(CHECKSUM(NEWID())) % 730), GETDATE()), 
    CASE WHEN (ABS(CHECKSUM(NEWID())) % 2) = 0 THEN 'D09' ELSE 'ID03' END,
    0, 0
FROM Nums;

INSERT INTO DetCompras (IdCompra, CodProd, CantC, PrecioC, SubtC)
SELECT 
    c.IdCompra,
    (SELECT CodProd FROM #ValidProds WHERE Id = (ABS(CHECKSUM(NEWID())) % @CountProds) + 1),
    (ABS(CHECKSUM(NEWID())) % 50) + 1,
    (ABS(CHECKSUM(NEWID())) % 300) + 10,
    0
FROM Compras c;

UPDATE DetCompras SET SubtC = CantC * PrecioC;

;WITH CTE AS (SELECT IdCompra, SUM(SubtC) as TotalS FROM DetCompras GROUP BY IdCompra)
UPDATE c SET c.SubtC = cte.TotalS, c.TotalC = cte.TotalS * 1.15
FROM Compras c INNER JOIN CTE cte ON c.IdCompra = cte.IdCompra;


PRINT '5. Generando 10,000 Ventas y sus Detalles...'
;WITH N1(C) AS (SELECT 1 UNION ALL SELECT 1),
N2(C) AS (SELECT 1 FROM N1 AS T1 CROSS JOIN N1 AS T2),
N3(C) AS (SELECT 1 FROM N2 AS T1 CROSS JOIN N2 AS T2),
N4(C) AS (SELECT 1 FROM N3 AS T1 CROSS JOIN N3 AS T2),
N5(C) AS (SELECT 1 FROM N4 AS T1 CROSS JOIN N4 AS T2),
Nums AS (SELECT TOP 10000 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS N FROM N5)

INSERT INTO Ventas (FechaV, IdCliente, TotalV, VendedorId)
SELECT 
    DATEADD(DAY, -(ABS(CHECKSUM(NEWID())) % 730), GETDATE()), 
    (SELECT IdCliente FROM #ValidClients WHERE Id = (ABS(CHECKSUM(NEWID())) % @CountClients) + 1),
    1,
    (SELECT VendedorId FROM #ValidVendedores WHERE Id = (ABS(CHECKSUM(NEWID())) % @CountVendedores) + 1)
FROM Nums;

INSERT INTO DetVentas (IdVenta, CodProd, CantV, SubtP)
SELECT 
    v.IdVenta,
    (SELECT CodProd FROM #ValidProds WHERE Id = (ABS(CHECKSUM(NEWID())) % @CountProds) + 1),
    (ABS(CHECKSUM(NEWID())) % 5) + 1,
    (ABS(CHECKSUM(NEWID())) % 400) + 20
FROM Ventas v;

;WITH CTE AS (SELECT IdVenta, SUM(SubtP) as TotalS FROM DetVentas GROUP BY IdVenta)
UPDATE v SET v.TotalV = cte.TotalS * 1.15
FROM Ventas v INNER JOIN CTE cte ON v.IdVenta = cte.IdVenta;

DROP TABLE #ValidProds;
DROP TABLE #ValidClients;
DROP TABLE #ValidVendedores;

PRINT 'Proceso Completado Exitosamente!'
GO
