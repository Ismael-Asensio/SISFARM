USE Pharmacy
GO

SET NOCOUNT ON;

DECLARE @i INT = 1;

PRINT 'Insertando 300 Productos...'
WHILE @i <= 300
BEGIN
    DECLARE @IdDist CHAR(5) = CASE WHEN @i % 2 = 0 THEN 'D09' ELSE 'ID03' END;
    DECLARE @EstadoP BIT = CASE WHEN @i % 5 = 0 THEN 0 ELSE 1 END; -- 20% inactivos
    
    INSERT INTO Productos (NombreProd, DescProd, PrecioP, ExistP, EstadoP, R_Receta, FechaElab, FechaVenc, IdDist)
    VALUES (
        'Producto_Mock_' + CAST(@i AS NVARCHAR),
        'Desc_Mock_' + CAST(@i AS NVARCHAR),
        (RAND() * 500) + 10, -- Precio entre 10 y 510
        (RAND() * 200) + 1,  -- Existencia entre 1 y 201
        @EstadoP,
        CASE WHEN @i % 3 = 0 THEN 1 ELSE 0 END,
        DATEADD(MONTH, -CAST((RAND()*12) AS INT), GETDATE()),
        DATEADD(MONTH, CAST((RAND()*24) AS INT)+1, GETDATE()),
        @IdDist
    );
    
    SET @i = @i + 1;
END
PRINT '300 Productos insertados.'

SET @i = 1;
PRINT 'Insertando 300 Compras y sus Detalles...'
WHILE @i <= 300
BEGIN
    DECLARE @IdDistC CHAR(5) = CASE WHEN @i % 2 = 0 THEN 'D09' ELSE 'ID03' END;
    DECLARE @FechaCompra DATE = DATEADD(DAY, -CAST((RAND()*365) AS INT), GETDATE());
    
    INSERT INTO Compras (FechaCompra, IdDist, SubtC, TotalC)
    VALUES (@FechaCompra, @IdDistC, 0, 0);
    
    DECLARE @CurrentIdCompra INT = SCOPE_IDENTITY();
    
    -- Elegir un producto al azar
    DECLARE @CodProdC INT = (SELECT TOP 1 CodProd FROM Productos ORDER BY NEWID());
    DECLARE @CantC INT = CAST((RAND() * 50) + 1 AS INT);
    DECLARE @PrecioC FLOAT = (SELECT PrecioP * 0.7 FROM Productos WHERE CodProd = @CodProdC);
    DECLARE @SubtC MONEY = @CantC * @PrecioC;
    
    INSERT INTO DetCompras (IdCompra, CodProd, CantC, PrecioC, SubtC)
    VALUES (@CurrentIdCompra, @CodProdC, @CantC, @PrecioC, @SubtC);
    
    UPDATE Compras
    SET SubtC = @SubtC, TotalC = @SubtC * 1.15
    WHERE IdCompra = @CurrentIdCompra;
    
    SET @i = @i + 1;
END
PRINT '300 Compras insertadas.'

SET @i = 1;
PRINT 'Insertando 300 Ventas y sus Detalles...'
DECLARE @IdCliente INT = (SELECT TOP 1 IdCliente FROM Clientes);
DECLARE @VendedorId INT = (SELECT TOP 1 VendedorId FROM Vendedores);

WHILE @i <= 300
BEGIN
    DECLARE @FechaVenta DATETIME = DATEADD(DAY, -CAST((RAND()*365) AS INT), GETDATE());
    
    INSERT INTO Ventas (FechaV, IdCliente, TotalV, VendedorId)
    VALUES (@FechaVenta, @IdCliente, 1, @VendedorId);
    
    DECLARE @CurrentIdVenta INT = SCOPE_IDENTITY();
    
    DECLARE @CodProdV INT = (SELECT TOP 1 CodProd FROM Productos ORDER BY NEWID());
    DECLARE @CantV INT = CAST((RAND() * 10) + 1 AS INT);
    DECLARE @PrecioV FLOAT = (SELECT TOP 1 PrecioP FROM Productos WHERE CodProd = @CodProdV);
    DECLARE @SubtV FLOAT = @CantV * @PrecioV;
    
    INSERT INTO DetVentas (IdVenta, CodProd, CantV, SubtP)
    VALUES (@CurrentIdVenta, @CodProdV, @CantV, @SubtV);
    
    UPDATE Ventas
    SET TotalV = @SubtV * 1.15
    WHERE IdVenta = @CurrentIdVenta;
    
    SET @i = @i + 1;
END
PRINT '300 Ventas insertadas.'
PRINT 'Proceso completado.'
GO
