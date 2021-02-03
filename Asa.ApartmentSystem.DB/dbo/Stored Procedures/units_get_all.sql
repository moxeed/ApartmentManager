create procedure [dbo].[units_get_all]
@building_id int
as
SELECT [Id],[building_id],[number] ,[area],[description]
  FROM [dbo].[Units]
  where [building_id]=@building_id
GO


