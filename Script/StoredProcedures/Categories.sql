-- 1. Get All Categories
CREATE PROCEDURE sp_GetAllCategories
AS
BEGIN
    SELECT * FROM Categories;
END
GO

-- 2. Get Category By ID
CREATE PROCEDURE sp_GetCategoryById
    @CategoryID INT
AS
BEGIN
    SELECT * FROM Categories WHERE CategoryID = @CategoryID;
END
GO

-- 3. Insert Category
CREATE PROCEDURE sp_InsertCategory
    @CategoryName NVARCHAR(100)
AS
BEGIN
    INSERT INTO Categories (CategoryName)
    VALUES (@CategoryName);
END
GO

-- 4. Update Category
CREATE PROCEDURE sp_UpdateCategory
    @CategoryID INT,
    @CategoryName NVARCHAR(100)
AS
BEGIN
    UPDATE Categories 
    SET CategoryName = @CategoryName
    WHERE CategoryID = @CategoryID;
END
GO

-- 5. Delete Category
CREATE PROCEDURE sp_DeleteCategory
    @CategoryID INT
AS
BEGIN
    DELETE FROM Categories WHERE CategoryID = @CategoryID;
END
GO