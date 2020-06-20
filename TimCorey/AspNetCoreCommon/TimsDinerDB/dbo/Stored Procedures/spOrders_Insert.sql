﻿CREATE PROCEDURE [dbo].[spOrders_Insert]
	@OrderName nvarchar(50),
	@OrderDate datetime2(7),
	@FoodId int,
	@Quantity int,
	@Total int,
	@Id int output
AS
	BEGIN

	SET NOCOUNT ON;

	INSERT INTO dbo.[Order](OrderName, OrderDate, FoodID, Quantity, Total)
	VALUES (@OrderName, @OrderDate, @FoodId, @Quantity, @Total);

	SET @Id = SCOPE_IDENTITY();

	END