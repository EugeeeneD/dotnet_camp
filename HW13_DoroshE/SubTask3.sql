SELECT * FROM Seats AS s
WHERE s.SeatGuid NOT IN (SELECT SeatGuid FROM Tickets);