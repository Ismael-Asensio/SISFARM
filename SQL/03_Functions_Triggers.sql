/*
  SISFARM - Script 03: Functions & Triggers
  Gestión de compras y ventas con triggers de inventario.
*/
USE Pharmacy
GO

-- Función subtotal detalle compra
CREATE OR ALTER FUNCTION CSubtDC (@PC MONEY, @CDC INT) RETURNS MONEY
AS BEGIN RETURN @PC * @CDC END
GO

-- Función subtotal producto venta
CREATE OR ALTER FUNCTION SubtotalProd (@CP INT, @cv INT) RETURNS MONEY
AS BEGIN
    DECLARE @stp MONEY
    SELECT @stp = PrecioP * @cv FROM Productos WHERE CodProd = @CP
    RETURN @stp
END
GO

-- Gestión de Compras (SP transaccional)
CREATE OR ALTER PROCEDURE GestionDeCompras
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
        PRINT 'Error en gestión de compras: ' + ERROR_MESSAGE()
    END CATCH
END
GO

-- Gestión de Ventas (SP transaccional)
CREATE OR ALTER PROCEDURE GestionarVentas @IDC INT, @VID INT, @CP INT, @cv INT
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
        END ELSE BEGIN ROLLBACK PRINT 'No se pudo obtener ID de venta válido' END
    END TRY
    BEGIN CATCH
        ROLLBACK
        PRINT 'Error al gestionar venta: ' + ERROR_MESSAGE()
    END CATCH
END
GO

-- Detalle de Venta
CREATE OR ALTER PROCEDURE NuevoDetVenta @IDV INT, @CP INT, @cv INT
AS BEGIN
    SET NOCOUNT ON
    DECLARE @Existencia INT
    SELECT @Existencia = ExistP FROM Productos WHERE CodProd = @CP
    IF @Existencia IS NULL BEGIN PRINT 'Producto no registrado' RETURN END
    IF @cv <= 0 OR @cv > @Existencia BEGIN PRINT 'Cantidad inválida o excede existencia' RETURN END
    INSERT INTO DetVentas(IdVenta, CodProd, CantV, SubtP) VALUES(@IDV, @CP, @cv, dbo.SubtotalProd(@CP, @cv))
END
GO

-- Trigger: Actualizar inventario post-compra
CREATE OR ALTER TRIGGER ActualizarInv ON DetCompras AFTER INSERT
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

-- Trigger: Reducir inventario post-venta
CREATE OR ALTER TRIGGER ActualizarInvPostV ON DetVentas AFTER INSERT
AS BEGIN
    SET NOCOUNT ON
    UPDATE P SET ExistP = ExistP - I.CantV
    FROM Productos P JOIN inserted I ON P.CodProd = I.CodProd
END
GO

-- Trigger: Actualizar total venta
CREATE OR ALTER TRIGGER ActualizarV ON DetVentas AFTER INSERT
AS BEGIN
    SET NOCOUNT ON
    UPDATE V SET TotalV = (SELECT SUM(SubtP) FROM DetVentas WHERE IdVenta = V.IdVenta) * 1.15
    FROM Ventas V JOIN inserted I ON V.IdVenta = I.IdVenta
END
GO
