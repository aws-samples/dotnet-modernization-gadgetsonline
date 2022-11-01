USE [GadgetsOnlineDB]
GO
 
/****** Object:  StoredProcedure [dbo].[ViewProducts]    Script Date: 11/1/2022 6:34:19 PM ******/
SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[ViewProducts] AS
BEGIN
   SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
   BEGIN TRAN
       SELECT * FROM dbo.Products
   COMMIT TRAN 
END