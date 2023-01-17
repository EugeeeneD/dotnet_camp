SELECT * FROM Seats AS s
JOIN Hall AS h ON s.HallGuid = h.HallGuid
JOIN Showtimes AS sh ON h.HallGuid = sh.HallGuid
WHERE NOT EXISTS
(
	SELECT t.SeatGuid, t.ShowtimeGuid FROM Tickets AS t
	JOIN Showtimes ON Showtimes.ShowtimeGuid = t.ShowtimeGuid
	JOIN Movies AS m ON m.MovieGuid = Showtimes.MovieGuid
	WHERE m.Name = 'Berserk' AND Showtimes.ShowtimeGuid = sh.ShowtimeGuid AND s.SeatGuid = t.SeatGuid
)
ORDER BY seatNumber;