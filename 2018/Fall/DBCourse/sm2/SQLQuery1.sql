SELECT FirstName
FROM DimCustomer
WHERE TotalChildren > 1 AND (BirthDate <= '1970' OR BirthDate >= '1990')