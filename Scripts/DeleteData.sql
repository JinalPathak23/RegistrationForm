    CREATE PROCEDURE [dbo].[DeleteData]
        @Id INT
    AS
    BEGIN
        DELETE FROM FormDatas
        WHERE Id = @Id
    END
    GO

