CREATE PROCEDURE [dbo].[spOrders_UpdateName]
	@OrderName nvarchar(50),
	@Id int
AS
	BEGIN

	SET NOCOUNT ON;

	UPDATE dbo.[Order]
	SET OrderName = @OrderName
	WHERE Id = @Id;

	END