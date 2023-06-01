WITH MainQuery AS
(
SELECT Id, Name, Price, IzdelUp, 
CASE  
  WHEN IzdelUp IS NULL THEN 1 
  ELSE kol 
END AS kol, ROW_NUMBER() OVER(PARTITION BY IzdelUp ORDER BY Id) AS n,
Sum(Price) OVER(PARTITION BY IzdelUp ORDER BY Id) AS t
FROM Izdel 
LEFT JOIN Links ON Links.Izdel = Izdel.Id
),
RecursiveQuery AS
(
 SELECT Id, Name, Price, kol, 1 AS lvl,
 CAST(0x AS VARBINARY(MAX)) + CAST(n AS BINARY(2)) AS sortpath
 FROM MainQuery
 WHERE IzdelUp IS NULL

 UNION ALL

 SELECT m.Id, m.Name, m.Price, m.kol, r.lvl + 1, r.sortpath + CAST(m.n AS BINARY(2))
 FROM RecursiveQuery r
 JOIN MainQuery m ON m.IzdelUp = r.Id
),
ChildrenSum AS (
SELECT r.IzdelUp, sum( i.Price * i.kol) AS ChildrenTotal
FROM MainQuery r
JOIN MainQuery i ON r.Id = i.Id
WHERE r.IzdelUp IS NOT NULL
GROUP BY r.IzdelUp
)

SELECT r.Id, r.Name, r.kol, 
r.kol * r.Price + CASE 
  WHEN c.ChildrenTotal IS NULL THEN 0
  ELSE c.ChildrenTotal
END AS value, r.Price, r.lvl
FROM RecursiveQuery r 
LEFT JOIN ChildrenSum c ON c.IzdelUp = r.Id 
ORDER BY sortpath
