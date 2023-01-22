using HW15.Data;
using HW15.Data.Entities;
using HW15.Services;
using Microsoft.EntityFrameworkCore;

CinemaDBContext context = new();

UserService users = new UserService();

/*users.Add(
    new User()
    { 
        FirstName = "Jenny",
        LastName = "Genny"
    });
*/

foreach (var x in users.FindAll())
{
    Console.WriteLine(x.FirstName + " - " + x.LastName);
}