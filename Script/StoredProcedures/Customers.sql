-- 1. Get All Customers
CREATE PROCEDURE sp_GetAllCustomers
AS
BEGIN
    SELECT * FROM Customers;
END
GO

-- 2. Get Customer By ID
CREATE PROCEDURE sp_GetCustomerById
    @CustomerID INT
AS
BEGIN
    SELECT * FROM Customers WHERE CustomerID = @CustomerID;
END
GO

-- 3. Insert Customer
CREATE PROCEDURE sp_InsertCustomer
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Phone NVARCHAR(20),
    @CityID INT
AS
BEGIN
    INSERT INTO Customers (FirstName, LastName, Email, Phone, CityID)
    VALUES (@FirstName, @LastName, @Email, @Phone, @CityID);
END
GO

-- 4. Update Customer
CREATE PROCEDURE sp_UpdateCustomer
    @CustomerID INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Phone NVARCHAR(20),
    @CityID INT
AS
BEGIN
    UPDATE Customers 
    SET FirstName = @FirstName, 
        LastName = @LastName, 
        Email = @Email, 
        Phone = @Phone, 
        CityID = @CityID
    WHERE CustomerID = @CustomerID;
END
GO

-- 5. Delete Customer
CREATE PROCEDURE sp_DeleteCustomer
    @CustomerID INT
AS
BEGIN
    DELETE FROM Customers WHERE CustomerID = @CustomerID;
END
GO