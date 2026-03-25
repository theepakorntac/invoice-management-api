-- 1. Get All Statuses
CREATE PROCEDURE sp_GetAllOrderStatuses
AS
BEGIN
    SELECT * FROM OrderStatuses;
END
GO

-- 2. Get Status By ID
CREATE PROCEDURE sp_GetOrderStatusById
    @StatusID INT
AS
BEGIN
    SELECT * FROM OrderStatuses WHERE StatusID = @StatusID;
END
GO

-- 3. Insert Status
CREATE PROCEDURE sp_InsertOrderStatus
    @StatusName NVARCHAR(50)
AS
BEGIN
    INSERT INTO OrderStatuses (StatusName)
    VALUES (@StatusName);
END
GO

-- 4. Update Status
CREATE PROCEDURE sp_UpdateOrderStatus
    @StatusID INT,
    @StatusName NVARCHAR(50)
AS
BEGIN
    UPDATE OrderStatuses 
    SET StatusName = @StatusName
    WHERE StatusID = @StatusID;
END
GO

-- 5. Delete Status
CREATE PROCEDURE sp_DeleteOrderStatus
    @StatusID INT
AS
BEGIN
    DELETE FROM OrderStatuses WHERE StatusID = @StatusID;
END
GO