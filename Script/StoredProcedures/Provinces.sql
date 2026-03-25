-- 1. Get All
CREATE PROCEDURE sp_GetAllProvinces
AS
BEGIN
    SELECT * FROM Provinces;
END
GO

-- 2. Get By ID
CREATE PROCEDURE sp_GetProvinceById
    @ProvinceID INT
AS
BEGIN
    SELECT * FROM Provinces WHERE ProvinceID = @ProvinceID;
END
GO

-- 3. Insert
CREATE PROCEDURE sp_InsertProvince
    @ProvinceName NVARCHAR(100),
    @RegionID INT
AS
BEGIN
    INSERT INTO Provinces (ProvinceName, RegionID)
    VALUES (@ProvinceName, @RegionID);
END
GO

-- 4. Update
CREATE PROCEDURE sp_UpdateProvince
    @ProvinceID INT,
    @ProvinceName NVARCHAR(100),
    @RegionID INT
AS
BEGIN
    UPDATE Provinces 
    SET ProvinceName = @ProvinceName, RegionID = @RegionID
    WHERE ProvinceID = @ProvinceID;
END
GO

-- 5. Delete (ตัวที่ Error ฟ้องว่าขาด)
CREATE PROCEDURE sp_DeleteProvince
    @ProvinceID INT
AS
BEGIN
    DELETE FROM Provinces WHERE ProvinceID = @ProvinceID;
END
GO