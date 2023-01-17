# Project Title
Database for Ukrainian cinema network.
## Description
This database was built with use of MS SQL SERVER.
Main purpouse of this database is to structure and store importante information for cinema network.

## Database structure
### Entities
* Movies - this table store all information about movie. 
* CinemaHalls - this table store information about cinema in general.
* Hall - this table store information about hall itself and to which cinema it belongs.
* Seats - this table store information about seat number, price coefficient for exact seat and hall to which this
seat belongs.
* Customers - this table store information about customers.

### Connection tables
* Showtime - this table store information about which movie will be shown, date, time, 
in which hall everything will be and base price for this session.
* Tickets - this table store information about tickets, total price, showtime, seats and customer, which booked it.

## Decisions
* Added price coefficient to seat, because not all seat cost the same. But maybe it should be calculated somewhere 
out of the database.
* Added total price in tickets to apply some sort of discounts for users if its in need.

## Authors
EugeneDorosh
