-- 1. Get All Suppliers
CREATE PROCEDURE sp_GetAllSuppliers
AS
BEGIN
    SELECT * FROM Suppliers;
END
GO

-- 2. Get Supplier By ID
CREATE PROCEDURE sp_GetSupplierById
    @SupplierID INT
AS
BEGIN
    SELECT * FROM Suppliers WHERE SupplierID = @SupplierID;
END
GO

-- 3. Insert Supplier
CREATE PROCEDURE sp_InsertSupplier
    @SupplierName NVARCHAR(200),
    @ContactEmail NVARCHAR(255),
    @CompanyID INT
AS
BEGIN
    INSERT INTO Suppliers (SupplierName, ContactEmail, CompanyID)
    VALUES (@SupplierName, @ContactEmail, @CompanyID);
END
GO

-- 4. Update Supplier
CREATE PROCEDURE sp_UpdateSupplier
    @SupplierID INT,
    @SupplierName NVARCHAR(200),
    @ContactEmail NVARCHAR(255),
    @CompanyID INT
AS
BEGIN
    UPDATE Suppliers 
    SET SupplierName = @SupplierName, 
        ContactEmail = @ContactEmail, 
        CompanyID = @CompanyID
    WHERE SupplierID = @SupplierID;
END
GO

-- 5. Delete Supplier
CREATE PROCEDURE sp_DeleteSupplier
    @SupplierID INT
AS
BEGIN
    DELETE FROM Suppliers WHERE SupplierID = @SupplierID;
END
GO