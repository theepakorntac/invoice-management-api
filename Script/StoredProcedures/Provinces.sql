CREATE PROCEDURE sp_GetAllProvinces
AS
BEGIN
    SELECT * FROM Provinces;
END
GO

CREATE PROCEDURE sp_GetProvinceById
    @ProvinceID INT
AS
BEGIN
    SELECT * FROM Provinces WHERE ProvinceID = @ProvinceID;
END
GO

CREATE PROCEDURE sp_InsertProvince
    @ProvinceName NVARCHAR(100),
    @RegionID INT
AS
BEGIN
    INSERT INTO Provinces (ProvinceName, RegionID)
    VALUES (@ProvinceName, @RegionID);
    
    SELECT SCOPE_IDENTITY() AS ProvinceID;
END
GO