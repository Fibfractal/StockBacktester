USE [GraphProject]

GO
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON

GO

Alter PROCEDURE [dbo].[Insert_OMX_Data]
	@Open float,
	@High float,
	@Low float,
	@Close float,
	@MilliSeconds float


AS
BEGIN
	SET NOCOUNT ON;
	select *
	from [dbo].[OMX Data]
	
END
