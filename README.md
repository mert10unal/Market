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
  
![Bildschirmfoto 2023-02-12 um 23 42 38](https://user-images.githubusercontent.com/120198895/218336002-8319f6c2-9746-4251-9f07-afced9f199f4.png)

  
