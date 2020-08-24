-- =============================================
-- Author:		Gor Grigoryan
-- Create date: 19.08.2020
-- Description:	Search item
-- =============================================
CREATE PROCEDURE SearchItem
 @FullName NVARCHAR (500),
 @Email NVARCHAR (MAX),
 @PhoneNumber NVARCHAR (1000),
 @PhysicalAddress NVARCHAR (MAX)
AS
BEGIN
	SELECT Id, FullName, Email, PhoneNumber, PhysicalAddress 
	FROM dbo.Addresses
	WHERE FullName LIKE '%'+ @FullName +'%' AND 
	Email LIKE '%'+ @Email +'%' AND
	PhoneNumber LIKE '%'+ @PhoneNumber +'%' AND
	PhysicalAddress LIKE '%'+ @PhysicalAddress +'%';
END