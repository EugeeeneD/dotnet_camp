using HW15.Data.Entities;
using HW15.Services;

User sara = new User
{
    FirstName = "Sara",
    LastName = "Konor"
};

User john = new User
{
    FirstName = "John",
    LastName = "Wick"
};

User kyrie = new User
{
    FirstName = "Kyrie",
    LastName = "Irwing"
};

User luka = new User
{
    FirstName = "Luka",
    LastName = "Doncic"
};

UserService userService = new();
userService.Add(sara);
userService.Add(john);
userService.Add(kyrie);
userService.Add(luka);

Movie bladerunner = new Movie()
{
    Name = "Bladerunner 2049",
    Description = "Rayan Gosling"
};

Movie dark = new Movie()
{
    Name = "Dark",
    Description = "Germany thriller"
};

MovieService movieService = new();
movieService.Add(bladerunner);
movieService.Add(dark);

CinemaHalls multiplex = new()
{
    Address = "Pid Dybom 73"
};

CinemaHallsService cinemaHallsService = new();
cinemaHallsService.Add(multiplex);

Hall firstHall = new()
{
    CinemaGuid = multiplex.Id
};

Hall secondHall = new()
{
    CinemaGuid = multiplex.Id
};

HallService hallService = new();
hallService.Add(firstHall);
hallService.Add(secondHall);

Seat fHallSeat1 = new()
{
    HallGuid = firstHall.Id,
    SeatPriceCoef = 1,
    SeatNumber = 1
};
Seat fHallSeat2 = new()
{
    HallGuid = firstHall.Id,
    SeatPriceCoef = 1,
    SeatNumber = 2
};
Seat fHallSeat3 = new()
{
    HallGuid = firstHall.Id,
    SeatPriceCoef = 0.75M,
    SeatNumber = 3
};
Seat fHallSeat4 = new()
{
    HallGuid = firstHall.Id,
    SeatPriceCoef = 0.75M,
    SeatNumber = 4
};

SeatService seatService = new();
seatService.Add(fHallSeat1);
seatService.Add(fHallSeat2);
seatService.Add(fHallSeat3);
seatService.Add(fHallSeat4);

Showtime bladerunnerShowtime = new()
{
    DateTime = Convert.ToDateTime("2023-02-01 18:00:00"),
    Movie = bladerunner,
    Hall = firstHall,
    Price = 200
};

Showtime darkShowtime = new()
{
    DateTime = Convert.ToDateTime("2023-01-29 18:00:00"),
    Movie = dark,
    Hall = firstHall,
    Price = 200
};

ShowtimeService showtimeService = new();
showtimeService.Add(bladerunnerShowtime);
showtimeService.Add(darkShowtime);

Ticket ticketForTogether = new()
{
    User = sara,
    Showtime = darkShowtime,
    Seat = fHallSeat1,
    TotalSum = darkShowtime.Price * fHallSeat1.SeatPriceCoef
};

Ticket ticketForTogether2 = new()
{
    User = luka,
    Showtime = darkShowtime,
    Seat = fHallSeat2,
    TotalSum = darkShowtime.Price * fHallSeat2.SeatPriceCoef
};

Ticket ticket1 = new()
{
    User = kyrie,
    Showtime = bladerunnerShowtime,
    Seat = fHallSeat3,
    TotalSum = bladerunnerShowtime.Price * fHallSeat3.SeatPriceCoef
};

Ticket ticket2 = new()
{
    User = kyrie,
    Showtime = bladerunnerShowtime,
    Seat = fHallSeat2,
    TotalSum = bladerunnerShowtime.Price * fHallSeat2.SeatPriceCoef
};

Ticket ticket3= new()
{
    User = john,
    Showtime = darkShowtime,
    Seat = fHallSeat3,
    TotalSum = darkShowtime.Price * fHallSeat3.SeatPriceCoef
};

TicketService ticketService = new();
ticketService.Add(ticketForTogether);
ticketService.Add(ticketForTogether2);
ticketService.Add(ticket1);
ticketService.Add(ticket2);
ticketService.Add(ticket3);