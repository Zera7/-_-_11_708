SELECT count(*) AS salesCount, BirthDate
FROM DimCustomer
JOIN FactInternetSales ON DimCustomer.CustomerKey = FactInternetSales.CustomerKey
JOIN DimProduct ON FactInternetSales.ProductKey = DimProduct.ProductKey
JOIN DimProductSubcategory ON DimProductSubcategory.ProductSubcategoryKey = DimProduct.ProductSubcategoryKey
JOIN DimProductCategory ON DimProductSubcategory.ProductCategoryKey = DimProductCategory.ProductCategoryKey
JOIN DimGeography ON DimCustomer.GeographyKey = DimGeography.GeographyKey
JOIN DimSalesTerritory ON DimGeography.SalesTerritoryKey = DimSalesTerritory.SalesTerritoryKey
WHERE DimProductCategory.EnglishProductCategoryName = 'Clothing' 
	AND DimSalesTerritory.SalesTerritoryRegion = 'Germany'
GROUP BY DimCustomer.CustomerKey, DimCustomer.BirthDate
ORDER BY salesCount DESC, DimCustomer.BirthDate