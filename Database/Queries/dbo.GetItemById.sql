-- =============================================
-- Author:		Gor Grigoryan
-- Create date: 19.08.2020
-- Description:	Get item by id
-- =============================================
CREATE PROCEDURE GetItemById 
 @id INT
AS
BEGIN
	SELECT Id, FullName, Email, PhoneNumber, PhysicalAddress
	FROM dbo.Addresses
	WHERE Id = @id
END