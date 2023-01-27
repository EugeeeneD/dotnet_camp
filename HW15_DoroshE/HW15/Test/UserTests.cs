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
using System.Reflection.Metadata;

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
        public void Add_InvalidEmails_ShouldThrowException_InMemoryVersion(string email)
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
        public void Add_ValidEmails_ShouldAddUser_InMemoryVersion(string email)
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CinemaDBContext>()
                .UseInMemoryDatabase(databaseName: "CinemaNetwork")
                .Options;

            using (var context = new CinemaDBContext(options))
            {
                UserService userService = new UserService(context);

                int usersCountBefore = context.Users.Count();

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
                Assert.Equal(usersCountBefore + 1, context.Users.Count());
            }
        }

/*        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("@")]
        [InlineData("asdasd@")]
        [InlineData("asdad[]@gmail")]
        [InlineData("asdad'@gmail")]
        [InlineData("asdad\"@gmail")]
        [InlineData("asdad\\'@gmail")]
        public void Add_InvalidEmails_ShouldThrowException_MockVersion(string email)
        {
            //Arrange 
            var contextMock = new Mock<CinemaDBContext>();
            UserService userService = new(contextMock.Object);

            User user = new()
            {
                Email = email,
                FirstName = "Test",
                LastName = "Test",
                Id = Guid.NewGuid()
            };

            //Assert And Act
            Assert.Throws<ArgumentException>(() => userService.Add(user));
        }

        [Theory]
        [InlineData("asdad@gmail.com")]
        [InlineData("asdad@ymail.com")]
        public void Add_ValidEmails_ShouldAddUser_MockVersion(string email)
        {
            //Arrange
            var contextMock = new Mock<CinemaDBContext>();

            var users = new List<User>().AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            contextMock.Setup(x => x.Users)

            UserService userService = new(contextMock.Object);

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
            Assert.Equal(usersCountBefore + 1, contextMock.Object.Users.Count());
        }*/
    }
}
