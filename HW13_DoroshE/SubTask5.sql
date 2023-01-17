SELECT TOP 3 SUM(sh.Price * s.SeatPriceCoef) spend, c.UserGuid FROM Customers c
INNER JOIN Tickets t ON c.UserGuid = t.UserGuid
INNER JOIN Seats s ON s.SeatGuid = t.SeatGuid
INNER JOIN 
(
	SELECT * FROM Showtimes sh
	WHERE sh.DataTime BETWEEN '2022-01-01' AND '2023-02-01'
) AS sh 
ON sh.ShowtimeGuid = t.ShowtimeGuid
GROUP BY c.UserGuid
ORDER BY spend DESC;