USE Supermarket;
SELECT * FROM Users;
SELECT CommodityName,CommoditySort.SortName,CommodityPrice,IsDiscount,ReducedPrice from Commodity,CommoditySort where 
Commodity.SortID = CommoditySort.SortID and CommodityName like '%ºì%'
SELECT UserName,Password From Users WHERE UserName = 'admin' and Password = 'admin'
INSERT INTO Commodity(CommodityName,SortID,CommodityPrice,IsDiscount,ReducedPrice,CreateUserId) VALUES('¾Æ','1','12.22','false','12.2','1')
SELECT * FROM Commodity;
select SortID from CommoditySort where SortName = '¾ÆÒû';
SELECT Username,Password FROM Users;
SELECT SortName FROM CommoditySort
SELECT SortID,SortName FROM CommoditySort