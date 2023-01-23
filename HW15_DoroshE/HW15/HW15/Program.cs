using HW15.Data.Entities;

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

CinemaHalls multiplex = new()
{
    Address = "Pid Dybom 73"
};

Hall firstHall = new()
{
    CinemaGuid = multiplex.Id
};

Hall secondHall = new()
{
    CinemaGuid = multiplex.Id
};

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

Showtime bladerunnerShowtime = new()
{
    DateTime = Convert.ToDateTime("2023-02-01 18:00:00"),

}