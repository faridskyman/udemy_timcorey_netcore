CREATE PROCEDURE [dbo].[spFoodAll]
AS

BEGIN
	SET NOCOUNT ON;
	
	SELECT [Id], [Title], [Description], [Price]
	FROM dbo.Food;

END