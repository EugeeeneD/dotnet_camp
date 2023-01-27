using HW15.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using HW15.Data;
using HW15.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Test
{
    public class UserTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("@")]
        [InlineData("asdasd@")]
        [InlineData("asdad[]@gmail")]
        [InlineData("asdad'@gmail")]
        [InlineData("asdad\"@gmail")]
        [InlineData("asdad\\'@gmail")]
        public void Add_InvalidEmails_ShouldThrowException(string email)
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CinemaDBContext>()
                .UseInMemoryDatabase(databaseName: "CinemaNetwork")
                .Options;

            using (var context = new CinemaDBContext(options))
            {
                UserService userService = new UserService(context);

                User user = new()
                {
                    Email = email,
                    FirstName = "Test",
                    LastName = "Test",
                    Id = Guid.NewGuid()
                };

                //Assert AND Act
                Assert.Throws<ArgumentException>(() => userService.Add(user));
            }
        }

        [Theory]
        [InlineData("asdad@gmail.com")]
        [InlineData("asdad@ymail.com")]
        public void Add_ValidEmails_ShouldAddUser(string email)
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CinemaDBContext>()
                .UseInMemoryDatabase(databaseName: "CinemaNetwork")
                .Options;

            using (var context = new CinemaDBContext(options))
            {
                UserService userService = new UserService(context);
                var users = userService.FindAll().ToList();

                int usersCountBefore = users.Count;

                User user = new()
                {
                    Email = email,
                    FirstName = "Test",
                    LastName = "Test",
                    Id = Guid.NewGuid()
                };

                //Act
                userService.Add(user);

                //Assert
                users = userService.FindAll().ToList();
                Assert.Equal(usersCountBefore + 1, users.Count);
            }
        }
    }
}
