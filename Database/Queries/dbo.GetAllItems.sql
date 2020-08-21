-- =============================================
-- Author:		Gor Grigoryan
-- Create date: 19.08.2020
-- Description:	Get all items from dbo.Addresses
-- =============================================
CREATE PROCEDURE GetAllItems 
AS
BEGIN
	SELECT Id, FullName, Email, PhoneNumber, PhysicalAddress
	FROM dbo.Addresses
END