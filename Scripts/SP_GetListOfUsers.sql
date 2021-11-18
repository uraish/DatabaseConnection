CREATE PROCEDURE GetListOfUsers 
@UserID AS INT
AS 
SELECT * FROM [dbo].[tb_users] WHERE id=@UserID