CREATE PROCEDURE [dbo].[InsertData]
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Address NVARCHAR(200) = NULL,
    @State NVARCHAR(50),
    @City NVARCHAR(50)
AS
BEGIN
    INSERT INTO FormDatas (Name, Email, Phone, Address, State, City)
    VALUES (@Name, @Email, @Phone, @Address, @State, @City)
END
GO


