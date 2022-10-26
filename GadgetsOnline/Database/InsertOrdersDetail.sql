USE [GadgetsOnlineDB]
GO

/****** Object:  StoredProcedure [dbo].[InsertOrders_Detail]    Script Date: 10/26/2022 11:25:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertOrders_Detail]
	-- Add the parameters for the stored procedure here
	--@OrderDate DateTime,
	@OrderId int ,
	@ProductId int,
    @Quantity int,

    @UnitPrice decimal(18,2)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @OrderDate1 Date
	SET NOCOUNT ON;
	
	
    -- Insert statements for procedure here


INSERT INTO [dbo].[OrderDetails]
           ([OrderId]
           ,[ProductId]
           ,[Quantity]
           ,[UnitPrice])
     VALUES
           (@OrderId
           ,@ProductId
           ,@Quantity
           ,@UnitPrice)




END
GO


