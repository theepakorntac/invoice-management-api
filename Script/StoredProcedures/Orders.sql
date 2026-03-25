-- 1. Get All Orders
CREATE PROCEDURE sp_GetAllOrders
AS
BEGIN
    SELECT * FROM Orders;
END
GO

-- 2. Get Order By ID
CREATE PROCEDURE sp_GetOrderById
    @OrderID INT
AS
BEGIN
    SELECT * FROM Orders WHERE OrderID = @OrderID;
END
GO

-- 3. Insert Order
CREATE PROCEDURE sp_InsertOrder
    @CustomerID INT,
    @OrderDate DATETIME,
    @StatusID INT,
    @TotalAmount DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Orders (CustomerID, OrderDate, StatusID, TotalAmount)
    VALUES (@CustomerID, @OrderDate, @StatusID, @TotalAmount);
END
GO

-- 4. Update Order
CREATE PROCEDURE sp_UpdateOrder
    @OrderID INT,
    @CustomerID INT,
    @OrderDate DATETIME,
    @StatusID INT,
    @TotalAmount DECIMAL(18,2)
AS
BEGIN
    UPDATE Orders 
    SET CustomerID = @CustomerID,
        OrderDate = @OrderDate,
        StatusID = @StatusID,
        TotalAmount = @TotalAmount
    WHERE OrderID = @OrderID;
END
GO

-- 5. Delete Order
CREATE PROCEDURE sp_DeleteOrder
    @OrderID INT
AS
BEGIN
    DELETE FROM Orders WHERE OrderID = @OrderID;
END
GO