SELECT SUM(sh.Price * s.SeatPriceCoef) AS earned, m.Name FROM Movies AS m
JOIN Showtimes AS sh ON m.MovieGuid = sh.MovieGuid
JOIN Tickets AS t ON t.ShowtimeGuid = sh.ShowtimeGuid
JOIN Seats AS s ON s.SeatGuid = t.SeatGuid
GROUP BY m.Name
ORDER BY earned DESC;