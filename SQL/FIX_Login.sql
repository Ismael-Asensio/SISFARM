/*
  SISFARM - DIAGNOSTICO Y FIX
  Ejecutar en SSMS con Windows Authentication
  
  Este script:
  1. Verifica si la BD Pharmacy existe
  2. Si no existe, la crea con todo
  3. Asegura que el login Farmacia tenga acceso
*/

USE master
GO

-- =====================================================
-- VERIFICAR SI LA BD EXISTE
-- =====================================================
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Pharmacy')
BEGIN
    PRINT '>> La base de datos Pharmacy NO EXISTE. Creandola...'
    CREATE DATABASE Pharmacy
END
ELSE
BEGIN
    PRINT '>> La base de datos Pharmacy YA EXISTE.'
END
GO

-- =====================================================
-- VERIFICAR Y ARREGLAR EL LOGIN
-- =====================================================

-- Asegurar que el login existe
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'Farmacia')
BEGIN
    CREATE LOGIN [Farmacia] WITH PASSWORD = 'canelones_190124',
        DEFAULT_DATABASE = Pharmacy, CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF
    PRINT '>> Login Farmacia creado.'
END
ELSE
BEGIN
    -- Cambiar la BD por defecto a master temporalmente
    -- (para que no falle si Pharmacy no existia antes)
    ALTER LOGIN [Farmacia] WITH DEFAULT_DATABASE = Pharmacy
    PRINT '>> Login Farmacia ya existe, BD default actualizada.'
END
GO

-- Asegurar que tiene sysadmin
ALTER SERVER ROLE [sysadmin] ADD MEMBER [Farmacia]
GO

-- Habilitar el login
ALTER LOGIN [Farmacia] ENABLE
GO

-- =====================================================
-- CREAR USUARIO EN LA BD PHARMACY
-- =====================================================
USE Pharmacy
GO

-- Verificar si el usuario ya existe en la BD
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'Farmacia')
BEGIN
    CREATE USER [Farmacia] FOR LOGIN [Farmacia]
    PRINT '>> Usuario Farmacia creado en BD Pharmacy.'
END
ELSE
BEGIN
    PRINT '>> Usuario Farmacia ya existe en BD Pharmacy.'
END
GO

-- Darle permisos totales en la BD
ALTER ROLE [db_owner] ADD MEMBER [Farmacia]
GO

PRINT ''
PRINT '>> FIX APLICADO. Ahora prueba el login en la app.'
PRINT '>> Usuario: Farmacia'
PRINT '>> Password: canelones_190124'
GO
