-- 1. Get All OrderItems
CREATE PROCEDURE sp_GetAllOrderItems
AS
BEGIN
    SELECT * FROM OrderItems;
END
GO


-- 2. Get OrderItem By ID
CREATE PROCEDURE sp_GetOrderItemById
    @ItemID INT
AS
BEGIN
    SELECT * FROM OrderItems WHERE ItemID = @ItemID;
END
GO

-- 3. Insert OrderItem
CREATE PROCEDURE sp_InsertOrderItem
    @OrderID INT,
    @ProductID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(18,2)
AS
BEGIN
    INSERT INTO OrderItems (OrderID, ProductID, Quantity, UnitPrice)
    VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);
END
GO

-- 4. Update OrderItem
CREATE PROCEDURE sp_UpdateOrderItem
    @ItemID INT,
    @OrderID INT,
    @ProductID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(18,2)
AS
BEGIN
    UPDATE OrderItems 
    SET OrderID = @OrderID,
        ProductID = @ProductID,
        Quantity = @Quantity,
        UnitPrice = @UnitPrice
    WHERE ItemID = @ItemID;
END
GO

-- 5. Delete OrderItem
CREATE PROCEDURE sp_DeleteOrderItem
    @ItemID INT
AS
BEGIN
    DELETE FROM OrderItems WHERE ItemID = @ItemID;
END
GO