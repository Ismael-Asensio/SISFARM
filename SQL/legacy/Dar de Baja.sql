/*
	DAR DE BAJA PRODUCTO
*/


USE Pharmacy

CREATE procedure DarBProducto
@CodP INT
as
declare @idprod as INT
set @idprod=(select CodProd from Productos
where CodProd= @CodP)
if(@CodP= @idprod)
begin
	update Productos set EstadoP=0 where CodProd = @CodP
end
else
begin
	print 'Producto no encontrado'
end

SELECT * FROM Productos

DarBProducto 4

/*
	DAR DE BAJA SUCURSAL
*/

CREATE procedure DarBSuc
@IDS CHAR(5)
as
declare @idprov as char(5)
set @idprov=(select IdSuc from Sucursales
where IdSuc = @IDS)
if(@IDS= @idprov)
begin
	update Sucursales set EstadoSuc =0 where IdSuc = @IDS
end
else
begin
	print 'Sucursal no encontrada'
end

SELECT * FROM Sucursales


/*
	DAR DE BAJA ENVIO
*/

CREATE procedure DarBEnv
@IDS INT
as
declare @idprov as INT
set @idprov=(select IdEnvio from Envios
where IdEnvio = @IDS)
if(@IDS= @idprov)
begin
	update Envios set EstadoEnv =0 where IdEnvio = @IDS
end
else
begin
	print 'Envio no Encontrado'
end

SELECT * FROM Envios


/*
	CAMBIAR RECETA PRODUCTO
*/

CREATE procedure CamRec
@CodP INT
as
declare @idprod as INT
set @idprod=(select CodProd from Productos
where CodProd= @CodP)
if(@CodP= @idprod)
begin
	update Productos set R_Receta = 1 where CodProd=@CodP AND R_Receta = 0
end
else
begin
	print 'Producto no encontrado'
end