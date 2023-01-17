SELECT m.Name, sh.DataTime FROM Showtimes AS sh
JOIN Movies AS m ON sh.MovieGuid = m.MovieGuid
WHERE sh.DataTime BETWEEN '2023-01-16' AND '2023-01-23';