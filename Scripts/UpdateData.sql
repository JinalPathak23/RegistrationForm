-- Stored procedure for updating an existing contact
CREATE PROCEDURE [dbo].[UpdateData]
    @Id INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Address NVARCHAR(200)= NULL,
    @State NVARCHAR(50),
    @City NVARCHAR(50)
AS
BEGIN
    UPDATE FormDatas
    SET Name = @Name,
        Email = @Email,
        Phone = @Phone,
        Address = @Address,
        State = @State,
        City = @City
    WHERE Id = @Id
END
GO


