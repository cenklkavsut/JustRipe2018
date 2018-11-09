CREATE TABLE [dbo].[Customer]
(
[CustomerID] int NOT NULL PRIMARY KEY IDENTITY,
[First Name] varchar(50) NOT NULL,
[Surname] varchar(50) NOT NULL,
[Contact Number] varchar(50) NOT NULL,
[Email] varchar(50) NOT NULL,
[OrderID] int NOT NULL,
CONSTRAINT [FK_Customer_Orders] FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
)

