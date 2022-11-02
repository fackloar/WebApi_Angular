SELECT EmployeeName FROM dbo.Employee

SELECT EmployeeName, EmployeeSalary FROM dbo.Employee WHERE EmployeeSalary>10000

DELETE FROM dbo.Employee WHERE DATEDIFF(year, DateOfBirth, GETDATE()) > 70

UPDATE dbo.Employee SET EmployeeSalary = 15000 WHERE EmployeeSalary < 15000