CREATE PROCEDURE [dbo].[GetDataById]
    @Id INT
AS
BEGIN
    SELECT * FROM FormDatas WHERE Id = @Id
END
GO


