-- =============================================
-- Author:		Gor Grigoryan
-- Create date: 19.08.2020
-- Description:	Add new item
-- =============================================
CREATE PROCEDURE AddNewItem 
 @FullName NVARCHAR (500),
 @Email NVARCHAR (MAX),
 @PhoneNumber NVARCHAR (1000),
 @PhysicalAddress NVARCHAR (MAX)
AS
BEGIN
	INSERT INTO dbo.Addresses(FullName, Email, PhoneNumber, PhysicalAddress)
	VALUES(@FullName, @Email, @PhoneNumber, @PhysicalAddress)
END