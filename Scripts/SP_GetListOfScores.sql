CREATE PROCEDURE GetListOfScores 
@UserID AS INT
AS 
SELECT * FROM [dbo].[tb_scores] WHERE id=@UserID