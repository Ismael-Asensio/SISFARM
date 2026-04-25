/*
  SISFARM - Script 05: Datos Iniciales (Seed Data)
  Departamentos de Nicaragua.
*/
USE Pharmacy
GO

-- Departamentos de Nicaragua
INSERT INTO Departamento VALUES
('001','Managua',1),
('002','Masaya',1),
('003','Madriz',1),
('004','Matagalpa',1),
('005','Nueva Segovia',1),
('006','Río San Juan',1),
('007','Rivas',1),
('008','León',1),
('009','Jinotega',1),
('010','Granada',1),
('011','Estelí',1),
('012','Chontales',1),
('013','Chinandega',1),
('014','Carazo',1),
('015','Boaco',1),
('016','RACCN',1),
('017','RACCS',1)
GO

PRINT '>> Datos iniciales insertados exitosamente.'
GO
