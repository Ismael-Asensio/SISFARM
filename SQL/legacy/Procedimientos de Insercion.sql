USE Pharmacy
/* 
	PROCEDIMIENTOS DE INSERSION
*/



alter PROCEDURE NuevoProducto
  @NP nvarchar(45),
  @Desc nvarchar(50),
  @PP float,
  @Exist int,
  @FE date,
  @RUC char(5)
AS
BEGIN
  DECLARE @IdProv as char(5)
  SET @IdProv = (SELECT RUC FROM Proveedores WHERE RUC = @RUC)

  IF (@NP = '' OR @Desc = '' OR @PP IS NULL OR @Exist IS NULL OR @FE IS NULL OR @RUC = '')
  BEGIN
    PRINT 'No podemos tener registros en blanco'
  END
  ELSE
  BEGIN
    IF (@RUC = @IdProv)
    BEGIN
      INSERT INTO Productos (NombreProd, DescProd, PrecioP, ExistP, EstadoP, R_Receta, FechaElab, FechaVenc, IdDist)
      VALUES (@NP, @Desc, @PP, @Exist, 1, 0, @FE, DATEADD(YEAR, 2, @FE), @RUC)
    END
    ELSE
    BEGIN
      PRINT 'El proveedor no existe'
    END
  END
END

SELECT * FROM Proveedores
SELECT * FROM Productos

NuevoProducto 'Paracetamol','Anti-inflamatorio',3,100,'2023-11-22','J012'
select * from clientes

/*
	GESTION DE CLIENTES CON TIPO
*/
use Pharmacy

alter PROCEDURE NClientNat
@Dir NVARCHAR(70),
@Tel CHAR(8),
@Cd CHAR(5),
@PN NVARCHAR(25),
@SN NVARCHAR(25),
@PA NVARCHAR(25),
@SA NVARCHAR(25),
@TPC CHAR(1)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @IdCliente INT

    BEGIN TRY
        -- Iniciar la transacción
        BEGIN TRANSACTION

        -- Insertar datos en la tabla Clientes y obtener el ID resultante
        DECLARE @IdClienteTable TABLE (IdCliente INT)
        INSERT INTO Clientes (DirC, TelC, CodDep) 
        OUTPUT INSERTED.IdCliente INTO @IdClienteTable
        VALUES (@Dir, @Tel, @Cd)

        -- Obtener el ID del cliente recién insertado
        SET @IdCliente = (SELECT TOP 1 IdCliente FROM @IdClienteTable)

        -- Commit de la transacción si todo es exitoso
        COMMIT;
    END TRY
    BEGIN CATCH
        -- En caso de error, hacer rollback de la transacción
        IF @@TRANCOUNT > 0
            ROLLBACK;
        -- Imprimir información sobre el error
        PRINT 'Error: ' + ERROR_MESSAGE()
        RETURN -- O realizar alguna acción adicional si es necesario
    END CATCH

    -- Después de haber insertado el cliente, ahora puedes insertar en ClienteNatural o ClienteJuridico según el tipo
    BEGIN TRY
        -- Iniciar otra transacción
        BEGIN TRANSACTION

            EXEC NuevoClienteNat @PN, @SN, @PA, @SA, @TPC, @IdCliente

        -- Commit de la segunda transacción si todo es exitoso
        COMMIT
    END TRY
    BEGIN CATCH
        -- En caso de error en la segunda transacción, hacer rollback
        IF @@TRANCOUNT > 0
            ROLLBACK
        -- Imprimir información sobre el error
        PRINT 'Error: ' + ERROR_MESSAGE()
        RETURN -- O realizar alguna acción adicional si es necesario
    END CATCH
END

SELECT * FROM Clientes
SELECT * FROM ClienteNatural

NClientNat 'San Sebastian','85843319','001','Ismael','','Asensio','','R'

alter PROCEDURE NClientJur
@Dir NVARCHAR(70),
@Tel CHAR(8),
@Cd CHAR(5),
@PN NVARCHAR(25),
@SN NVARCHAR(25),
@PA NVARCHAR(25),
@SA NVARCHAR(25),
@Cargo NVARCHAR(25)

AS
BEGIN
    SET NOCOUNT ON
    DECLARE @IdCliente INT

    BEGIN TRY
        -- Iniciar la transacción
        BEGIN TRANSACTION

        -- Insertar datos en la tabla Clientes y obtener el ID resultante
        DECLARE @IdClienteTable TABLE (IdCliente INT)
        INSERT INTO Clientes (DirC, TelC, CodDep) 
        OUTPUT INSERTED.IdCliente INTO @IdClienteTable
        VALUES (@Dir, @Tel, @Cd)

        -- Obtener el ID del cliente recién insertado
        SET @IdCliente = (SELECT TOP 1 IdCliente FROM @IdClienteTable)

        -- Commit de la transacción si todo es exitoso
        COMMIT
    END TRY
    BEGIN CATCH
        -- En caso de error, hacer rollback de la transacción
        IF @@TRANCOUNT > 0
            ROLLBACK;
        -- Imprimir información sobre el error
        PRINT 'Error: ' + ERROR_MESSAGE();
        RETURN -- O realizar alguna acción adicional si es necesario
    END CATCH

    -- Después de haber insertado el cliente, ahora puedes insertar en ClienteNatural o ClienteJuridico según el tipo
    BEGIN TRY
        -- Iniciar otra transacción
        BEGIN TRANSACTION;

            EXEC NuevoClienteJur @PN, @SN, @PA, @SA, @Cargo, @IdCliente

        -- Commit de la segunda transacción si todo es exitoso
        COMMIT
    END TRY
    BEGIN CATCH
        -- En caso de error en la segunda transacción, hacer rollback
        IF @@TRANCOUNT > 0
            ROLLBACK;
        -- Imprimir información sobre el error
        PRINT 'Error: ' + ERROR_MESSAGE();
        RETURN -- O realizar alguna acción adicional si es necesario
    END CATCH
END



SELECT * FROM Clientes
SELECT * FROM ClienteJuridico

NClientJur 'San Sebastian','85843319','001','Ismael','','Asensio','','Gerente'


create  procedure NuevoClienteJur
@PN nvarchar(25),
@SN nvarchar(25),
@PA nvarchar(25),
@SA nvarchar(25),
@Cargo char(25),
@IdCl int
as
declare @codC as int
set @codC=(select IdCliente from Clientes where IdCliente=@IdCl)
declare @nomC as nvarchar(50)
set @nomC=(select PNCJur from ClienteJuridico where PNCJur=@PN)
if(  @PN='' or @PA='' or @Cargo='' or @IdCl='')
begin
  print 'No podemos tener registros en blanco'
end
else
begin
if(@IdCl=@codC)
  begin
  insert into ClienteJuridico values(@PN,@SN,@PA,@SA,@Cargo,@IdCl)

  end
  else
  begin
   print 'Este cliente no ha sido registrado'

    end

end


create  procedure NuevoClienteNat
@PN nvarchar(25),
@SN nvarchar(25),
@PA nvarchar(25),
@SA nvarchar(25),
@TipoC char(1),
@IdCl int
as
declare @codC as int
set @codC=(select IdCliente from Clientes where IdCliente=@IdCl)
declare @nomC as nvarchar(25)
set @nomC=(select PNCN from ClienteNatural where PNCN=@PN)
if(  @PN='' or @PA='' or @TipoC='' or @IdCl='')
begin
  print 'No podemos tener registros en blanco'
end
else
begin
if(@IdCl=@codC)
  begin
   insert into ClienteNatural values(@PN,@SN,@PA,@SA,@TipoC,@IdCl)

  end
  else
  begin

   print 'No se ha registrado ese cliente'

  end
end

/*
	NUEVO EMPLEADO Y USO DE TRIGGER PARA VENDEDOR
*/

create  procedure NuevoEmpleado
@DNI char(15),
@PN nvarchar(25),
@SN nvarchar(25),
@PA nvarchar(25),
@SA nvarchar(25),
@Tel char(8),
@idDep char(5),
@idSuc char(5),
@Cargo nvarchar(25)
as
declare @Idd as char(5)
set @Idd=(select IdDep from Departamento where IdDep=@idDep)
declare @Ids as char(5)
set @Ids=(select IdSuc from Sucursales where IdSuc=@idSuc)
if( @PN='' or @PA='' or @DNI='' or @Tel='' or @idDep='' or  @idSuc='' or @Cargo='')
begin
  print 'No podemos tener registros en blanco'
end
else
begin
if(@idDep=@Idd)
  begin
    if(@idSuc=@Ids)
    begin
        insert into Empleados values(@DNI,@PN,@SN,@PA,@SA,@Tel,@idDep,@idSuc,@Cargo)
    end 
        else
        begin
            print 'La sucursal no existe'
        end
  end
  else
  begin
    print ' El departamento no existe'
  end
end

use Pharmacy

NuevoEmpleado '001-050006-1002L','Nestor','Ariel','Soto','Palma','82391344','001','001','Vendedor'


select * from Empleados

CREATE PROCEDURE NuevoVendedor
@DNI CHAR(15)
AS
BEGIN
    DECLARE @Cedula AS CHAR(15);
    SET @Cedula = (SELECT DNI FROM Empleados WHERE DNI = @DNI);

    IF (@DNI = '')
    BEGIN
        PRINT 'No podemos tener registros en blanco';
    END
    ELSE
    BEGIN
        IF (@DNI = @Cedula)
        BEGIN
            INSERT INTO Vendedores (DNI) VALUES (@DNI);
        END
        ELSE
        BEGIN
            PRINT 'No existe el vendedor con ese id';
        END
    END
END;

SELECT * FROM Empleados

SELECT * FROM Vendedores

CREATE TRIGGER TR_InsertarVendedor
ON Empleados
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar un nuevo vendedor para cada empleado nuevo con el cargo "Vendedor"
    INSERT INTO Vendedores (DNI)
    SELECT i.DNI
    FROM INSERTED i
    WHERE i.CargoEmp = 'Vendedor';
END




ALTER TABLE Empleados ENABLE TRIGGER TR_InsertarVendedor


/*
	GESTION DE COMPRAS
*/

create PROCEDURE GestionDeCompras
  @NR CHAR(5),
  @cc INT,
  @CP INT,
  @pc MONEY
AS 
BEGIN
  SET NOCOUNT ON;

  DECLARE @IdCompra INT;

  -- Declarar la tabla de tabla para almacenar el ID de la compra recién insertada
  DECLARE @IdCompraTable TABLE (IdCompra INT);

  BEGIN TRANSACTION;

  BEGIN TRY
    -- Obtener el ID de la compra recién insertada
    INSERT INTO Compras (FechaCompra, IdDist, SubtC, TotalC)
    OUTPUT INSERTED.IdCompra INTO @IdCompraTable
    VALUES (GETDATE(), @NR, dbo.CSubtDC(@pc,@cc), 1);

    -- Obtener el ID de la compra desde la tabla de tabla
    SET @IdCompra = (SELECT TOP 1 IdCompra FROM @IdCompraTable);

    -- Verificar si se obtuvo un ID de compra válido
    IF @IdCompra IS NOT NULL
    BEGIN
      -- Llamar a los otros procedimientos con el ID de la compra
      EXEC NuevoDetCompra @IdCompra, @CP, @cc, @pc;

      -- Commit de la transacción si todo es exitoso
      COMMIT;
    END
    ELSE
    BEGIN
      -- Rollback si no se obtuvo un ID de compra válido
      ROLLBACK;
      PRINT 'No se pudo obtener un ID de compra válido';
    END
  END TRY
  BEGIN CATCH
    -- Rollback en caso de error y manejo de excepciones
    ROLLBACK;
    PRINT 'Ha ocurrido un error al gestionar la compra';
  END CATCH;
END;

GestionDeCompras 'J012',1,1,4000

select* from Proveedores
select * from Productos
select * from Compras
select * from DetCompras


create procedure NuevoDetCompra
@IDC int,
@CP int,
@cc int,
@pc money
as
declare @idCompra as int
set @idCompra=(select IdCompra from Compras where
IdCompra=@IDC)
declare @codp as int
set @codp=(select CodProd from Productos where
CodProd=@CP)
if(@IDC=@idCompra)
begin
  if(@CP=@codp)
  begin
	  insert into DetCompras values(@IDC,@CP,@cc,@pc,dbo.CSubtDC(@pc,@cc))
  end
  else
  begin
    print 'El Producto no esta registrado'
  end
end
else
begin
  print 'La Compra no esta  registrada'
end

ALTER TABLE DetCompras ENABLE TRIGGER ActualizarInv

CREATE FUNCTION CSubtDC (@PC MONEY, @CDC INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @subtdc AS MONEY
	SELECT @subtdc = @PC * @CDC
	RETURN @subtdc
END


create TRIGGER ActualizarInv
ON DetCompras
AFTER INSERT
AS
BEGIN
  SET NOCOUNT ON;

  UPDATE P
  SET ExistP = ExistP + I.CantC,
      Preciop = CASE
                  WHEN I.PrecioC > P.Preciop THEN I.PrecioC * 1.08
                  ELSE P.Preciop
                END
  FROM Productos P
  JOIN inserted I ON P.CodProd = I.CodProd;

  UPDATE DC
  SET SubtC = DC.CantC * DC.PrecioC
  FROM DetCompras DC
  JOIN inserted I ON DC.IdCompra = I.IdCompra;

  UPDATE C
  SET TotalC = (SELECT SUM(SubtC) FROM DetCompras WHERE IdCompra = I.IdCompra) * 1.15
  FROM Compras C
  JOIN inserted I ON C.IdCompra = I.IdCompra;
END;


/*
	GESTION DE VENTAS
*/

create PROCEDURE GestionarVentas
  @IDC INT,
  @VID INT,
  @CP INT,
  @cv INT
AS 
BEGIN
  SET NOCOUNT ON;

  DECLARE @IdVenta INT;

  -- Declarar la tabla de tabla para almacenar el ID de la venta recién insertada
  DECLARE @IdVentaTable TABLE (IdVenta INT);

  BEGIN TRANSACTION; -- Iniciar la transacción

  BEGIN TRY
    -- Obtener el ID de la venta recién insertada
    INSERT INTO Ventas (FechaV, IdCliente, TotalV, VendedorId)
    OUTPUT INSERTED.IdVenta INTO @IdVentaTable
    VALUES (GETDATE(), @IDC, 1, @VID);

    -- Obtener el ID de la venta desde la tabla de tabla
    SET @IdVenta = (SELECT TOP 1 IdVenta FROM @IdVentaTable);

    -- Verificar si se obtuvo un ID de venta válido
    IF @IdVenta IS NOT NULL
    BEGIN
      -- Llamar a los otros procedimientos con el ID de la venta
      EXEC NuevoDetVenta @IdVenta, @CP, @cv;

      -- Commit de la transacción si todo es exitoso
      COMMIT;
    END
    ELSE
    BEGIN
      -- Rollback si no se obtuvo un ID de venta válido
      ROLLBACK;
      PRINT 'No se pudo obtener un ID de venta válido';
    END
  END TRY
  BEGIN CATCH
    -- Rollback en caso de error y manejo de excepciones
    ROLLBACK;
    PRINT 'Ha ocurrido un error al gestionar la venta';
  END CATCH;
END;

ALTER TABLE DetVentas ENABLE TRIGGER ActualizarInvPostV
ALTER TABLE DetVentas ENABLE TRIGGER ActualizarV

use Pharmacy
select*from Ventas
select*from DetVentas
select* from Clientes
select*from Productos

GestionarVentas 37,1,1,1
select * from VentasHistory

-- Corregir la función SubtotalProd
CREATE FUNCTION SubtotalProd
(@CP INT, @cv INT)
RETURNS MONEY
AS
BEGIN
  DECLARE @stp MONEY;
  SELECT @stp = PrecioP * @cv FROM Productos WHERE CodProd = @CP;
  RETURN @stp;
END;

-- Trigger para actualizar existencia después de una venta
create TRIGGER ActualizarInvPostV
ON DetVentas
AFTER INSERT
AS
BEGIN
  UPDATE P
  SET ExistP = ExistP - (SELECT cantv FROM inserted)
  FROM Productos P
  JOIN DetVentas DV ON P.CodProd = DV.CodProd;
END

-- Procedimiento para insertar un nuevo detalle de venta
create PROCEDURE NuevoDetVenta
@IDV INT,
@CP INT,
@cv INT
AS
BEGIN
  DECLARE @IdVenta INT, @CodProd INT, @Existencia INT;

  SELECT @IdVenta = IdVenta
  FROM Ventas
  WHERE IdVenta = @IDV;

  SELECT @CodProd = CodProd, @Existencia = ExistP
  FROM Productos
  WHERE CodProd = @CP;

  IF @IdVenta IS NOT NULL
  BEGIN
    IF @CodProd IS NOT NULL
    BEGIN
      IF @cv > 0 AND @cv <= @Existencia
      BEGIN
        INSERT INTO DetVentas (IdVenta, CodProd, CantV, SubtP)
        VALUES (@IDV, @CP, @cv, dbo.SubtotalProd(@CP, @cv));
      END
      ELSE
      BEGIN
        PRINT 'La cantidad debe ser mayor que cero y no puede exceder la existencia del producto';
      END
    END
    ELSE
    BEGIN
      PRINT 'El producto no se encuentra registrado';
    END
  END
  ELSE
  BEGIN
    PRINT 'La venta no está registrada';
  END
END;

-- Trigger para actualizar el total de la venta después de insertar un detalle
create TRIGGER ActualizarV
ON DetVentas
AFTER INSERT
AS
BEGIN
  UPDATE V
  SET TotalV = (SELECT SUM(SubtP) FROM DetVentas WHERE IdVenta = V.IdVenta)
  FROM Ventas V
  JOIN inserted I ON V.IdVenta = I.IdVenta
END

/*
	INSERCION GENERAL DE CONTACTOS, PROVEEDORES, DEPARTAMENTOS, SUCURSALES...
*/
create  procedure NuevosProveedores
@RUC char(15),
@NP nvarchar(25),
@Dir nvarchar(25),
@Tel char(8)
as
if( @RUC='' or @NP='' or @Dir='' or @Tel='')
begin
  print 'No podemos tener registros en blanco'
end
else
begin
    insert into Proveedores values(@RUC,@NP,@Dir,@Tel)
end

NuevosProveedores 'J012','DISEGSA','Carretera Norte','22886799'

--nuevo contacto

use Pharmacy
create  procedure NuevosContactos
@PN nvarchar(25),
@SN nvarchar(25),
@PA nvarchar(25),
@SA nvarchar(25),
@Dir nvarchar(25),
@Tel char(8),
@Mail nvarchar(45),
@RUC char(5)
as
declare @Dist as char(5)
set @Dist=(select RUC from Proveedores where RUC=@RUC)
if( @RUC='' or @PN='' or @SN ='' or @PA=''or  @SA='' or @Dir='' or @Tel='' or @Mail='' or @RUC='')
begin
  print 'No podemos tener registros en blanco'
end
else
begin
if(@RUC=@Dist)
  begin
  insert into Cont_Asesor values( @RUC,@PN,@SN,@PA,@SA,@Dir,@Tel,@Mail,@RUC)
     
  end
  else
  begin
    print ' Este proveedor no existe'
  end
end

SELECT * FROM Cont_Asesor

NuevosContactos 'Nestor','Ariel','Soto','Plama','Racachaca','82391344','nesoto06@gmail.com','D09'


USE Pharmacy
NuevasSucursales '001','racachaca','racaca','001'
create  procedure NuevasSucursales
@IdSuc char(5),
@NS nvarchar(15),
@Dir nvarchar(20),
@IdDept char(5)
as
declare @Dept as int
set @Dept=(select IdDep from Departamento where IdDep=@Dept)
if( @IdSuc='' or @NS='' or @Dir='' or @IdDept='')
begin
  print 'No podemos tener registros en blanco'
end
else
begin
if(@IdSuc=@Dept)
  begin
     print ' ya ha sido registrada este proveedor'
  end
  else
  begin
    insert into Sucursales values(@IdSuc, @NS,@Dir, 1, @IdDept)
  end
end

CREATE  procedure NuevosDepartamentos
@IdD char(5),
@ND nvarchar(15)
as
declare @Dept as CHAR(5)
set @Dept=(select IdDep from Departamento where IdDep=@IdD)
if( @IdD='' or @ND='')
begin
  print 'No podemos tener registros en blanco'
end
else
begin
if(@IdD=@Dept)
  begin
     print ' ya ha sido registrado este departamento'
  end
  else
  begin
    insert into Departamento values(@IdD,@ND,1)
  end
end

NuevosDepartamentos '001','Managua'

-- alerta de producto 


create table Productos 
add FechaElab Date ,
FechaVenc Date
select * from Productos 

insert into Productos values('Xiaomi poco f12','fon tuani',2200,8,1,1,'08-12-2023','11-28-2023','J012')

create procedure AlertP as
declare @Codp char(5);
declare @nombreprod nvarchar(25);
declare @preciop money;
declare @existp int;
declare @estadop bit;
declare @r_receta bit
declare @ruc char(11);
declare @fechaelab date;
declare @fechavenc date;

declare ProductC cursor for
select CodProd, NombreProd, Preciop, ExistP,EstadoP, R_Receta, IdDist, FechaElab, FechaVenc
from Productos

open ProductC

fetch next from ProductC into @Codp, @nombreprod, @preciop, @existp,@estadop,@r_receta, @ruc, @fechaelab, @fechavenc

while @@fetch_status = 0
begin


	if(@estadop<>0)
	begin
		if datediff(year, getdate(), @fechavenc) <= 1
		begin
			print 'El producto: ' + @nombreprod + ' Esta cerncano a vencerse.'
		end
	end
	else 
	begin 
	print 'El producto '+@nombreprod+'esta inactivo'
	end
    

    fetch next from ProductC into @Codp, @nombreprod, @preciop, @existp, @ruc, @fechaelab, @fechavenc
end

close ProductC
deallocate ProductC

--Nuevos Clientes

CREATE PROC NuevosEnvios
@OR NVARCHAR(70),
@IDC INT,
@DNI CHAR(15)

AS
IF( @OR='' or @IDC='' or @DNI='')
BEGIN
  PRINT 'No podemos tener registros en blanco'
END
ELSE
BEGIN
    INSERT INTO Envios VALUES(@OR,@IDC,@DNI,0)
END