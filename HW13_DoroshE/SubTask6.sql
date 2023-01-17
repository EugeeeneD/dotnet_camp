SELECT * FROM CinemaHalls c
WHERE
(
	SELECT  COUNT(t.TicketGuid) AS visA FROM Hall h
	INNER JOIN Showtimes sh ON sh.HallGuid = h.HallGuid
	INNER JOIN Tickets t ON t.ShowtimeGuid = sh.ShowtimeGuid
	WHERE c.CinemaHallGuid = h.FK_CinemaHallId AND sh.DataTime BETWEEN DATEADD(day, -7, GETDATE()) AND DATEADD(day, 0, GETDATE())
	GROUP BY h.FK_CinemaHallId
)
<
(
	SELECT COUNT(t.TicketGuid) AS visA FROM Hall h
	INNER JOIN Showtimes sh ON sh.HallGuid = h.HallGuid
	INNER JOIN Tickets t ON t.ShowtimeGuid = sh.ShowtimeGuid
	WHERE c.CinemaHallGuid = h.FK_CinemaHallId AND sh.DataTime BETWEEN DATEADD(day, -14, GETDATE()) AND DATEADD(day, -7, GETDATE())
	GROUP BY h.FK_CinemaHallId
);