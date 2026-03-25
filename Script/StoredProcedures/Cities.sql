-- 1. Get All Cities
CREATE PROCEDURE sp_GetAllCities
AS
BEGIN
    SELECT * FROM Cities;
END
GO

-- 2. Get City By ID
CREATE PROCEDURE sp_GetCityById
    @CityID INT
AS
BEGIN
    SELECT * FROM Cities WHERE CityID = @CityID;
END
GO

-- 3. Insert City
CREATE PROCEDURE sp_InsertCity
    @CityName NVARCHAR(100),
    @ProvinceID INT
AS
BEGIN
    INSERT INTO Cities (CityName, ProvinceID)
    VALUES (@CityName, @ProvinceID);
END
GO

-- 4. Update City
CREATE PROCEDURE sp_UpdateCity
    @CityID INT,
    @CityName NVARCHAR(100),
    @ProvinceID INT
AS
BEGIN
    UPDATE Cities 
    SET CityName = @CityName, ProvinceID = @ProvinceID
    WHERE CityID = @CityID;
END
GO

-- 5. Delete City
CREATE PROCEDURE sp_DeleteCity
    @CityID INT
AS
BEGIN
    DELETE FROM Cities WHERE CityID = @CityID;
END
GO