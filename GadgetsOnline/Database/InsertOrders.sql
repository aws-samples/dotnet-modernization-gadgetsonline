USE [GadgetsOnlineDB]
GO

/****** Object:  StoredProcedure [dbo].[InsertOrders]    Script Date: 10/26/2022 11:24:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertOrders]
	-- Add the parameters for the stored procedure here
	--@OrderDate DateTime,
	@OrderId int  OUTPUT ,
	@Username nvarchar,
    @FirstName nvarchar,
    @LastName nvarchar,
    @Address nvarchar,
    @City nvarchar,
    @State nvarchar(40),
    @PostalCode nvarchar(10),
    @Country nvarchar(40),
    @Phone nvarchar(24),
    @Email nvarchar(max),
    @Total decimal(18,2)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @OrderDate1 Date
	SET NOCOUNT ON;
	SET @OrderDate1 = GETDATE()
	--SET @OrderId = 0
	
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Orders]
           (
		     [OrderDate]
           ,[Username]
           ,[FirstName]
           ,[LastName]
           ,[Address]
           ,[City]
           ,[State]
           ,[PostalCode]
           ,[Country]
           ,[Phone]
           ,[Email]
           ,[Total])
     VALUES
           (@OrderDate1
           ,@Username
           ,@FirstName
           ,@LastName
           ,@Address
           ,@City
           ,@State
           ,@PostalCode
           ,@Country
           ,@Phone
           ,@Email
           ,@Total)

SELECT @OrderId  = SCOPE_IDENTITY();

END
GO


