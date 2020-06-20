CREATE PROCEDURE [dbo].[spOrders_GetByID]
	@Id int
AS
	BEGIN

	SET NOCOUNT ON;

	SELECT [Id], [OrderName], [OrderDate], [FoodID], [Quantity], [Total] 
	FROM dbo.[Order]
	WHERE Id = @Id;

	END