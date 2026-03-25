-- 1. Get All Products
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products;
END
GO

-- 2. Get Product By ID
CREATE PROCEDURE sp_GetProductById
    @ProductID INT
AS
BEGIN
    SELECT * FROM Products WHERE ProductID = @ProductID;
END
GO

-- 3. Insert Product
CREATE PROCEDURE sp_InsertProduct
    @ProductName NVARCHAR(200),
    @CategoryID INT,
    @SupplierID INT,
    @Price DECIMAL(18,2),
    @IsActive BIT
AS
BEGIN
    INSERT INTO Products (ProductName, CategoryID, SupplierID, Price, IsActive)
    VALUES (@ProductName, @CategoryID, @SupplierID, @Price, @IsActive);
END
GO

-- 4. Update Product
CREATE PROCEDURE sp_UpdateProduct
    @ProductID INT,
    @ProductName NVARCHAR(200),
    @CategoryID INT,
    @SupplierID INT,
    @Price DECIMAL(18,2),
    @IsActive BIT
AS
BEGIN
    UPDATE Products 
    SET ProductName = @ProductName,
        CategoryID = @CategoryID,
        SupplierID = @SupplierID,
        Price = @Price,
        IsActive = @IsActive
    WHERE ProductID = @ProductID;
END
GO

-- 5. Delete Product
CREATE PROCEDURE sp_DeleteProduct
    @ProductID INT
AS
BEGIN
    DELETE FROM Products WHERE ProductID = @ProductID;
END
GO