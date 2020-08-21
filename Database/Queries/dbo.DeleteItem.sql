-- =============================================
-- Author:		Gor Grigoryan
-- Create date: 19.08.2020
-- Description:	Delete item
-- =============================================
CREATE PROCEDURE DeleteItem
 @id INT
AS
BEGIN
	DELETE
	FROM dbo.Addresses
	WHERE Id = @id
END