-- =============================================
-- Author:		Gor Grigoryan
-- Create date: 19.08.2020
-- Description:	Edit item
-- =============================================
CREATE PROCEDURE EditItem
 @Id INT,
 @FullName NVARCHAR (500),
 @Email NVARCHAR (MAX),
 @PhoneNumber NVARCHAR (1000),
 @PhysicalAddress NVARCHAR (MAX)
AS
BEGIN
	UPDATE dbo.Addresses
	SET FullName = @FullName, 
	Email = @Email, 
	PhoneNumber = @PhoneNumber, 
	PhysicalAddress = @PhysicalAddress
	WHERE Id = @Id
END