/*
  SISFARM - Script 04: Seguridad y Roles
  Usa CREATE LOGIN moderno (reemplaza sp_addlogin obsoleto).
  Roles de BD personalizados con permisos granulares.
*/
USE master
GO

-- ===================== LOGINS DE SERVIDOR =====================
-- Administrador del sistema
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'ads')
    CREATE LOGIN [ads] WITH PASSWORD = '1234', DEFAULT_DATABASE = Pharmacy
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [ads]
GO

-- Gerente
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'Nestor')
    CREATE LOGIN [Nestor] WITH PASSWORD = 'DaraLove*', DEFAULT_DATABASE = Pharmacy
GO
ALTER SERVER ROLE [processadmin] ADD MEMBER [Nestor]
GO

-- Vendedor
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'Ramon')
    CREATE LOGIN [Ramon] WITH PASSWORD = 'PaolaLove*', DEFAULT_DATABASE = Pharmacy
GO

-- ===================== USUARIOS DE BD =====================
USE Pharmacy
GO

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'Nestor')
    CREATE USER [Nestor] FOR LOGIN [Nestor]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Nestor]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Nestor]
GO

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'Ramon')
    CREATE USER [Ramon] FOR LOGIN [Ramon]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Ramon]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Ramon]
GO

-- ===================== PERMISOS GRANULARES =====================
-- Gerente: ejecutar todos los SPs
GRANT EXECUTE TO [Nestor]
GO

-- Vendedor: solo SPs de venta y consulta
GRANT EXECUTE ON ListVent TO [Ramon]
GO
GRANT EXECUTE ON ListProd TO [Ramon]
GO
GRANT EXECUTE ON ListClientN TO [Ramon]
GO
GRANT EXECUTE ON ListClientJ TO [Ramon]
GO
GRANT EXECUTE ON GestionarVentas TO [Ramon]
GO
GRANT EXECUTE ON ListEnv TO [Ramon]
GO
