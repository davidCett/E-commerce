USE master
GO
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Test')
BEGIN
  CREATE DATABASE Test;
END;
GO