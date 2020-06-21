CREATE PROCEDURE [dbo].[spOrdersAll]

AS
	BEGIN

	SET NOCOUNT ON;

	SELECT [Id], [OrderName], [OrderDate], [FoodID], [Quantity], [Total] 
	FROM dbo.[Order]

	END