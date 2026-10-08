-- Module 7 Lab by Dr. Mary Lebens
-- Step 4 - SELECT Query that gets data from the shipppers table
SELECT * FROM Shippers;

-- Step 5: ADD more queries
-- 1. Sort rows 
SELECT ContactName, Country, Phone FROM Customers
ORDER BY Country, ContactName LIMIT 5;

-- 2. Filter rows using the WHERE clause
SELECT CustomerID, OrderDate, ShipCity FROM Orders
WHERE CustomerID = 'ALFKI';

-- 3. Retrieve rows from two tables using JOIN
SELECT c.CompanyName, o.OrderDate FROM Customers AS c
JOIN Orders AS o ON c.CustomerID = o.CustomerID 
WHERE c.CompanyName = 'QUICK-Stop' LIMIT 5;

-- Step 6: Modify Data
-- 1. Add a row using INSERT
INSERT INTO Customers (CustomerID, ContactName, CompanyName, Country)
VALUES ('ALICE', 'Alice Johnson', 'Wonderful Widgets', 'USA');

-- SELECT statement to show the new record we just added
SELECT * FROM Customers WHERE CustomerID = 'ALICE';

-- 2. Changing a row using an UPDATE statement
UPDATE Customers SET ContactName = 'Maria Anders'
WHERE CustomerID = 'ALFKI';

-- SELECT statement to check that the update worked OK
SELECT CustomerID, ContactName FROM Customers WHERE CustomerID = 'ALFKI';

-- 3. Use DELETE to remove a record from a table in the database
INSERT INTO Customers (CustomerID, ContactName, CompanyName, Country)
VALUES ('TEMP1', 'Tom Temp', 'Temporary Traders', 'USA');

SELECT * FROM Customers WHERE CustomerID = 'TEMP1';

DELETE FROM Customers WHERE CustomerID = 'TEMP1';
-- THe where clause is important because otherwise you will delete 
-- all the records in the table 
SELECT * FROM Customers WHERE CustomerID = 'TEMP1';