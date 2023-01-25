using HW15;
using HW15.Data;
using HW15.Data.Entities;
using HW15.Services;
using Microsoft.EntityFrameworkCore;

//Data initializing
/*User sara = new User
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
CinemaHalls garden = new()
{
    Address = "Naykova 54"
};


CinemaHallsService cinemaHallsService = new();
cinemaHallsService.Add(multiplex);
cinemaHallsService.Add(garden);

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
    MovieGuid = bladerunner.Id,
    HallGuid = firstHall.Id,
    Price = 200
};

Showtime darkShowtime = new()
{
    DateTime = Convert.ToDateTime("2023-01-29 18:00:00"),
    MovieGuid = dark.Id,
    HallGuid = firstHall.Id,
    Price = 200
};

ShowtimeService showtimeService = new();
showtimeService.Add(bladerunnerShowtime);
showtimeService.Add(darkShowtime);

Ticket ticketForTogether = new()
{
    UserGuid = sara.Id,
    ShowtimeGuid = darkShowtime.Id,
    SeatGuid = fHallSeat1.Id,
    TotalSum = darkShowtime.Price * fHallSeat1.SeatPriceCoef
};

Ticket ticketForTogether2 = new()
{
    UserGuid = luka.Id,
    ShowtimeGuid = darkShowtime.Id,
    SeatGuid = fHallSeat2.Id,
    TotalSum = darkShowtime.Price * fHallSeat2.SeatPriceCoef
};

Ticket ticket1 = new()
{
    UserGuid = kyrie.Id,
    ShowtimeGuid = bladerunnerShowtime.Id,
    SeatGuid = fHallSeat3.Id,
    TotalSum = bladerunnerShowtime.Price * fHallSeat3.SeatPriceCoef
};

Ticket ticket2 = new()
{
    UserGuid = kyrie.Id,
    ShowtimeGuid = bladerunnerShowtime.Id,
    SeatGuid = fHallSeat2.Id,
    TotalSum = bladerunnerShowtime.Price * fHallSeat2.SeatPriceCoef
};

Ticket ticket3= new()
{
    UserGuid = john.Id,
    ShowtimeGuid = darkShowtime.Id,
    SeatGuid = fHallSeat3.Id,
    TotalSum = darkShowtime.Price * fHallSeat3.SeatPriceCoef
};

TicketService ticketService = new();
ticketService.Add(ticketForTogether);
ticketService.Add(ticketForTogether2);
ticketService.Add(ticket1);
ticketService.Add(ticket2);
ticketService.Add(ticket3);*/

TaskQueries tasks = new();

//task1
Console.WriteLine("Task 1");
var task1 = tasks.CurrentWeekShowtimes();
await task1.ForEachAsync(x => Console.WriteLine(x.Movie.Name + " - " + x.DateTime));

//task2
Console.WriteLine("\nTask 2");
CinemaDBContext context = new();
var show = context.Showtimes.Include(x => x.Movie).FirstOrDefault();
Console.WriteLine($"{show.Movie.Name} - {show.DateTime} - Hall: {show.HallGuid}");

var task2 = tasks.AvaiblabeSeatsForShow(show);
await task2.ForEachAsync(x => Console.WriteLine(x.SeatNumber));

//task3
Console.WriteLine("\nTask 3");
var task3 = tasks.NeverBooked();
Console.WriteLine("Seat number and hall id:");
await task3.ForEachAsync(x => Console.WriteLine(x.SeatNumber + " - " + x.HallGuid));

//task4
Console.WriteLine("\nTask 4");
var task4 = tasks.EarnedByMovie();
foreach (var item in task4)
{
    Console.WriteLine(item.Key + " - " + item.Value);
}

//task5
Console.WriteLine("\nTask 5");
var task5 = tasks.Top3Users(DateTime.Now, DateTime.Now.AddDays(55));

foreach (var item in task5)
{
    Console.WriteLine(item.Key.FirstName + " - " + item.Value);
}

//task6
Console.WriteLine("\nTask 6");
var task6 = tasks.LessThanTwoWeeksAgo();

foreach (var item in task6)
{
    Console.WriteLine(item.Address);
}

//task7
Console.WriteLine("\nTask 7");
var task7 = tasks.Together();

foreach (var item in task7)
{
    Console.WriteLine(item.Key.FirstName + " - " + item.Value.FirstName);
}