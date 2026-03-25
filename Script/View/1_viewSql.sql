-- View 1: รายงานลูกค้าและที่อยู่แบบละเอียด
CREATE VIEW v_CustomerDetails AS
SELECT c.CustomerID, c.FirstName, c.LastName, c.Email, c.Phone,
       ci.CityName, p.ProvinceName, r.RegionName
FROM Customers c
JOIN Cities ci ON c.CityID = ci.CityID
JOIN Provinces p ON ci.ProvinceID = p.ProvinceID
JOIN Regions r ON p.RegionID = r.RegionID;
GO

-- View 2: รายงานสินค้า หมวดหมู่ และผู้ผลิต
CREATE VIEW v_ProductDetails AS
SELECT p.ProductID, p.ProductName, p.Price, p.IsActive,
       cat.CategoryName, s.SupplierName, comp.CompanyName AS Manufacturer
FROM Products p
JOIN Categories cat ON p.CategoryID = cat.CategoryID
JOIN Suppliers s ON p.SupplierID = s.SupplierID
JOIN Companies comp ON s.CompanyID = comp.CompanyID;
GO

-- View 3: รายงานสรุปการสั่งซื้อ (Order)
CREATE VIEW v_OrderSummary AS
SELECT o.OrderID, o.OrderDate, o.TotalAmount,
       os.StatusName AS OrderStatus,
       c.FirstName + ' ' + c.LastName AS CustomerName
FROM Orders o
JOIN OrderStatuses os ON o.StatusID = os.StatusID
JOIN Customers c ON o.CustomerID = c.CustomerID;
GO

-- View 4: รายงานใบแจ้งหนี้ฉบับเต็ม (Invoice Full Report)
CREATE VIEW v_InvoiceFullReport AS
SELECT i.InvoiceID, i.InvoiceDate, i.DueDate, i.PaidDate, i.TotalAmount AS InvoiceTotal,
       ist.StatusName AS InvoiceStatus,
       c.FirstName + ' ' + c.LastName AS CustomerName,
       o.OrderID
FROM Invoices i
JOIN InvoiceStatuses ist ON i.InvoiceStatusID = ist.InvoiceStatusID
JOIN Orders o ON i.OrderID = o.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID;
GO