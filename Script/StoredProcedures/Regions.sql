CREATE PROCEDURE sp_GetAllRegions
AS
BEGIN
    SELECT * FROM Regions;
END
GO

CREATE PROCEDURE sp_GetRegionById
    @RegionID INT
AS
BEGIN
    SELECT * FROM Regions WHERE RegionID = @RegionID;
END
GO

CREATE PROCEDURE sp_InsertRegion
    @RegionName NVARCHAR(100)
AS
BEGIN
    INSERT INTO Regions (RegionName) VALUES (@RegionName);
END
GO

CREATE PROCEDURE sp_UpdateRegion
    @RegionID INT,
    @RegionName NVARCHAR(100)
AS
BEGIN
    UPDATE Regions 
    SET RegionName = @RegionName
    WHERE RegionID = @RegionID;
END
GO

CREATE PROCEDURE sp_DeleteRegion
    @RegionID INT
AS
BEGIN
    DELETE FROM Regions WHERE RegionID = @RegionID;
END
GO