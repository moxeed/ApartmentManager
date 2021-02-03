create procedure [dbo].[buildings_create]
@name nvarchar(50),
@number_of_units int
as

INSERT INTO [dbo].[Building]
           ([name]
           ,[number_of_units])
     VALUES
           (@name
           ,@number_of_units)
select SCOPE_IDENTITY()


