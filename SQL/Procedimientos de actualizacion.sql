use Pharmacy

--Actualizacion de los productos 
--------------------------
----------------------------
ALTER PROCEDURE ActualizarProducto
  @NP nvarchar(45),
  @Desc nvarchar(50),
  @PP float,
  @Exist int,
  @FE date,
  @IDP INT
AS
BEGIN
  DECLARE @IdProd as INT
  SET @IdProd = (SELECT CodProd FROM Productos WHERE CodProd = @IDP)

  IF (@IDP = '')
  BEGIN
    PRINT 'No podemos tener registros en blanco'
  END
  ELSE
  BEGIN
    IF (@IDP = @IdProd)
    BEGIN
	  	  update Productos set NombreProd=@NP, DescProd=@Desc,PrecioP=@PP,ExistP=@Exist,FechaElab=@FE
	  where CodProd=@IDP and EstadoP=1
    END
    ELSE
    BEGIN
      PRINT 'El proveedor no existe'
    END
  END
END


SELECT * FROM Productos
ActualizarProducto 'Xiaomi poco f12','fon',48,72,'2023-08-12',1

create  procedure ActualizarEmpleado

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
declare @DNI as char(5)
set @DNI=(select DNI from Empleados where DNI=@DNI)
if( @PN='' or @PA='' or @Tel='' or @idDep='' or  @idSuc='' or @Cargo='')
begin
  print 'No podemos tener registros en blanco'
end
else
begin
if(@idDep=@Idd)
  begin
    if(@idSuc=@Ids)
    begin
			
       update Empleados set PNEmp=@PN,SNEmp=@SN,PAEmp=@PA,SAEmp=@SA,TelEmp=@Tel,IdDep=@idDep,IdSuc=@idSuc,CargoEmp=@Cargo
	  where DNI=@DNI
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


-- actualizar proveedor y contactos 
create  procedure ActualizarProveedores
@RUC char(5),
@NP nvarchar(25),
@Dir nvarchar(25),
@Tel char(8)
as
declare @NRUC as char(5) 
set @NRUC = (Select RUC from Proveedores where RUC=@RUC)
if( @NP='' or @Dir='' or @Tel='')
begin
  print 'No podemos tener registros en blanco'
end
else
begin
	if(@NRUC=@RUC) 

	begin 
	  update Proveedores set Nombreprov=@NP,DirProv=@Dir,TelP=@Tel
	  
	end 
	else 
	begin
	print 'El proveedor no existe'
	end
   
end

NuevosProveedores 'J012','DISEGSA','Carretera Norte','22886799'

--nuevo contacto

use Pharmacy
create  procedure ActializarContactos
@IdC char(5),
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
    update Cont_Asesor set PNC=@PN,SNC=@SN,PAC=@PA,SAC=@SA,DirCont=@Dir,TelCont=@Tel,MailCont=@Mail, IdDist=@RUC
	where IdCont=@IdC
	   
     
  end
  else
  begin
    print ' Este proveedor no existe'
  end
end

CREATE PROC CambiarEstadoEnvio
@IdEnvio int

AS
IF( @IdEnvio='')
BEGIN
  PRINT 'No podemos tener registros en blanco'
END
ELSE
BEGIN
      update Envios set EstadoEnv=1
	  where  IdEnvio=@idEnvio
END

GRANT EXECUTE TO Gerente;