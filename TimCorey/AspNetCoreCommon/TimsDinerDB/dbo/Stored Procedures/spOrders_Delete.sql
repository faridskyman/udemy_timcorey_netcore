﻿CREATE PROCEDURE [dbo].[spOrders_Delete]
	@Id int
AS
	BEGIN

	SET NOCOUNT ON;

	DELETE from dbo.[Order]
	WHERE Id = @Id;

	END