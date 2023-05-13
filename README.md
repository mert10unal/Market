# Market Automation Database

 The problems about the market automation database : 
 
 - Products are purchased from suppliers (vendors) in bulk from time to time at wholesale prices against invoice.
 - Products are purchased and sold to customers piece by piece at retail prices.
 - Products are identified by barcode, name, brand, price and how much is left in stock by quantity and unit of measure (150 kg, 350
  quantity, 25 meters, etc.).
 - Suppliers have a name, tax number and telephone number.
 
    In a procurement, one or several different products are supplied from one supplier against one invoice.
  For example: On 22.12.2020, with invoice number 43222 from the supplier "Biz Toptan", the following
  products were purchased and a total of 6000 TL was paid. All information in the invoice in the database
  keep it. Stocks increase as purchases are made.
  
  - In sales, customers buy one or more different products in exchange for a receipt. For example 22.12.2020 a customer purchased 
  the following products with receipt number 53222 and paid a total of 10 TL has been made. Payment can be in cash or by credit card. 
  But credit card information is not kept in the system. The receipt store all information (except the name of the market) in the database. 
  Stocks decrease as sales are made.

  The database scheme of market automation is shown below : 
  
![Bildschirmfoto 2023-03-18 um 16 04 00](https://user-images.githubusercontent.com/120198895/226108036-4c0cc56d-3ab9-462a-8601-a5a1cfaefb4a.png)


create table Supplier(
Id int primary key GENERATED ALWAYS AS IDENTITY,
SupplierName character varying (100),
TaxNumber int,
PhoneNumber character varying (10)
);

create table Product(
Id int primary key GENERATED ALWAYS AS IDENTITY,
ProductName character varying(100),
Barcode character varying(50),
Brand character varying(100),
Price float,
Quantity int,
MeasurePrice float
);

create table Receipt(
Id int primary key GENERATED ALWAYS AS IDENTITY,
ReceiptNumber character varying(13),
TaxNumber character varying(10),
Unit int,
UnitPrice float
);

create table ProductReceipt(
Id int primary key GENERATED ALWAYS AS IDENTITY,
ReceiptId int,
ProductId int,
FOREIGN KEY (ReceiptId) REFERENCES Receipt(Id),
FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

create table Bill(
Id int primary key GENERATED ALWAYS AS IDENTITY,
BillNumber character varying(16),
SupplierId int,
FOREIGN KEY (SupplierId) REFERENCES Supplier(Id)
);

create table SupplierProduct(
Id int primary key GENERATED ALWAYS AS IDENTITY,
ProductId int,
SupplierId int,
FOREIGN KEY (SupplierId) REFERENCES Supplier(Id),
FOREIGN KEY (ProductId) REFERENCES Product(Id)
);
insert into Supplier(SupplierName,TaxNumber,PhoneNumber) values ('Mert',32647,'5335246062')
insert into Supplier(SupplierName,TaxNumber,PhoneNumber) values ('Efe', 71628,'535074476')
insert into Supplier(SupplierName,TaxNumber,PhoneNumber) values ('Ege',32254,'5334211648')
insert into Supplier(SupplierName,TaxNumber,PhoneNumber) values ('Burak',46312,'5364512009')
insert into Supplier(SupplierName,TaxNumber,PhoneNumber) values ('Demir',46176,'5376054489')

select * from Receipt

insert into Product(ProductName,Barcode,Brand,Price,Quantity,MeasurePrice) values ('Shampoo','4533819020921','Head&Shoulders',3.30,3,1.10)
insert into Product(ProductName,Barcode,Brand,Price,Quantity,MeasurePrice) values ('Toothpaste','1548796650392','Colgate',7.5,3,2.5)
insert into Product(ProductName,Barcode,Brand,Price,Quantity,MeasurePrice) values ('Football','4837119452065','Adidas',21,2,10.5)
insert into Product(ProductName,Barcode,Brand,Price,Quantity,MeasurePrice) values ('Shoe','5649102364951','Puma',150,2,75)
insert into Product(ProductName,Barcode,Brand,Price,Quantity,MeasurePrice) values ('Pencil','5489192650437','Faber Castel',24,5,4.8)

insert into Receipt(ReceiptNumber,TaxNumber,Unit,UnitPrice) values ('4519840321452','1234567893',5,2)
insert into Receipt(ReceiptNumber,TaxNumber,Unit,UnitPrice) values ('3748192034185','9876543214',6,3)
insert into Receipt(ReceiptNumber,TaxNumber,Unit,UnitPrice) values ('3618229035491','9182736455',15,3)
insert into Receipt(ReceiptNumber,TaxNumber,Unit,UnitPrice) values ('4019283193014','7918217302',8,4)
insert into Receipt(ReceiptNumber,TaxNumber,Unit,UnitPrice) values ('4815291482014','1192438254',27,7)

insert into ProductReceipt(ReceiptId,ProductId) values (1,1)
insert into ProductReceipt(ReceiptId,ProductId) values (2,3)
insert into ProductReceipt(ReceiptId,ProductId) values (3,2)
insert into ProductReceipt(ReceiptId,ProductId) values (4,5)
insert into ProductReceipt(ReceiptId,ProductId) values (5,4)

select * from bill

insert into Bill(BillNumber,SupplierId) values ('1234567887654321',1)
insert into Bill(BillNumber,SupplierId) values ('1284739102530165',3)
insert into Bill(BillNumber,SupplierId) values ('4952134948102632',2)
insert into Bill(BillNumber,SupplierId) values ('3819263108974391',5)
insert into Bill(BillNumber,SupplierId) values ('4829152836143976',4)

select * from SupplierProduct

insert into SupplierProduct (ProductId ,SupplierId) values (1,2)
insert into SupplierProduct (ProductId ,SupplierId) values (2,1)
insert into SupplierProduct (ProductId ,SupplierId) values (3,4)
insert into SupplierProduct (ProductId ,SupplierId) values (4,3)
insert into SupplierProduct (ProductId ,SupplierId) values (5,5)


In line with my design, sql codes of some questions asked by end users:

--The products of the bill with billnumber '3'

select *  from Bill,Supplier,SupplierProduct,Product
where Bill.SupplierId=Supplier.Id
and Supplier.Id=SupplierProduct.SupplierId
and SupplierProduct.ProductId = Product.Id
and BillNumber = '1234567887654321'

--Product names of reciept whose RecieptNumber is equal to '3'

select ProductName from Receipt,ProductReceipt,Product
where Receipt.Id=ProductReceipt.ReceiptId
and ProductReceipt.ProductId = Product.Id
and ReceiptNumber = '4519840321452'


--The name and tax number of supliers of reciept with RecieptNumber equal to '3'

select SupplierName,PhoneNumber from Receipt,ProductReceipt,Product,SupplierProduct,Supplier
where Receipt.Id=ProductReceipt.ReceiptId
and ProductReceipt.ProductId = Product.Id
and Product.Id=SupplierProduct.ProductId
and SupplierProduct.SupplierId = SupplierId
and ReceiptNumber = '3748192034185'

--Product price totals of suppliers with supplier tax number '123' 

select SUM(Price) from Supplier,SupplierProduct,Product
where Supplier.Id=SupplierProduct.SupplierId
and SupplierProduct.ProductId = Product.Id
and Supplier.TaxNumber = '32647'

--Reciept unit price totals of suppliers with supplier tax number '123'

select SUM(UnitPrice) from Receipt,ProductReceipt,Product,SupplierProduct
where Receipt.Id=ProductReceipt.ReceiptId
and Product.Id=ProductReceipt.ProductId
and SupplierProduct.SupplierId = Supplier.Id
and Product.Id=SupplierProduct.ProductId
and Supplier.TaxNumber = '71628'

--All columns of the highest of the product prices of suppliers with supplier tax number '123'

select Product.Id,Product.ProductName,Product.Barcode,Product.Brand,Product.Price,Product.Quantity,
Product.MeasurePrice 
from Supplier,SupplierProduct,Product
where Supplier.Id=SupplierProduct.SupplierId
and SupplierProduct.ProductId=Product.Id
and Price = (select MAX(Price) from Product)

select Receipt.Id,Receipt.ReceiptNumber,Receipt.TaxNumber,Receipt.Unit,Receipt.UnitPrice 
from Receipt,ProductReceipt,Product
where Receipt.Id=ProductReceipt.ReceiptId
and ProductReceipt.ProductId = Product.Id
and UnitPrice = (select MAX(UnitPrice) from Receipt)

  
