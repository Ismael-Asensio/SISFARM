USE Pharmacy

CREATE PROCEDURE ListClientJ
AS
BEGIN
		SELECT * FROM ClienteJuridico 
END

CREATE PROC ListClientN
AS
BEGIN
		SELECT * FROM ClienteNatural
END


ListClient

alter PROC ListCompra
AS
BEGIN

SELECT 
    C.IdCompra,
    C.FechaCompra,
    C.IdDist,
	DC.CodProd,
	DC.CantC,
    DC.PrecioC,
    C.SubtC AS SubCompra,
    C.TotalC AS TotalCompra
FROM Compras C
INNER JOIN DetCompras DC ON C.IdCompra = DC.IdCompra;

END

ListCompra

/*
	LISTAR ACTIVOS
*/
CREATE PROC ListProd
AS
BEGIN
		SELECT* FROM Productos WHERE EstadoP = 1
END


/*
	LISTAR INACTIVOS
*/
CREATE PROC ListProdIn
AS
BEGIN
		SELECT* FROM Productos WHERE EstadoP = 0
END


alter PROC ListVent
AS
BEGIN
	SELECT 
    V.FechaV AS Feha,
    V.IdCliente,
    V.VendedorId,
    DV.CodProd,
    DV.CantV,
    DV.SubtP AS Subtotal,
	V.TotalV AS Total
FROM Ventas V
INNER JOIN DetVentas DV ON V.IdVenta = DV.IdVenta;
END

CREATE PROC ListEmp
AS
BEGIN

		SELECT * FROM Empleados

END

CREATE PROC ListSupp
AS
BEGIN

		SELECT * FROM Proveedores

END


CREATE PROC ListCA
AS
BEGIN

		SELECT * FROM Cont_Asesor

END


/*
	LISTAR ACTIVOS
*/
CREATE PROC ListEnv
AS
BEGIN

		SELECT * FROM Envios WHERE EstadoEnv = 1

END

/*
	LISTAR INACTIVOS
*/
CREATE PROC ListEnvIn
AS
BEGIN

		SELECT * FROM Envios WHERE EstadoEnv = 0

END

/*
	LISTAR ACTIVOS
*/
CREATE PROC ListSuc
AS
BEGIN

		SELECT * FROM Sucursales WHERE EstadoSuc = 1

END

/*
	LISTAR INACTIVOS
*/
CREATE PROC ListSucIn
AS
BEGIN

		SELECT * FROM Sucursales WHERE EstadoSuc = 0

END

CREATE PROC ListDep
AS
BEGIN
		SELECT * FROM Departamento WHERE EstadoDep = 1
END