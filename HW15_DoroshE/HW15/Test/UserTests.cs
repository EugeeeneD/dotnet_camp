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
using HW15.Controllers;
using HW15.Validator;
using HW15.Validators;

namespace Test
{
    public class UserTests
    {
        Mock<CinemaDBContext> contextMock = new Mock<CinemaDBContext>();
        UserService userService;

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("@")]
        [InlineData("asdasd@")]
        [InlineData("asdad[]@gmail")]
        [InlineData("asdad'@gmail")] // single quote is acceptable?
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

        [Theory]
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
            userService = new(contextMock.Object);

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
        [InlineData("", "", "", "First name is invalid.", false)]
        [InlineData("a", "Lengrie", "asd@gmail.com", "First name is invalid.", false)]
        [InlineData("Arnold", "Lengrie", "@", "Email is invalid.", false)]
        [InlineData("Arnold", "Lengrie", "asdasd@", "Email is invalid.", false)]
        [InlineData("Arnold", "Lengrie", "asdad[]@gmail", "Email is invalid.", false)]
        [InlineData("Arnold", "Lengrie", "asdad\"@gmail", "Email is invalid.", false)]
        [InlineData("Arnold", "Lengrie", "asd@gmail.com", "Alright.", true)]
        public void ValidateUser_IsCorrectValidationWithEmail_Pass(string name, string lastName, string email, string expectedMessage, bool expectedResult)
        {
            //Arrange
            var emailValidatorMock = new Mock<IEmailValidator>();

            switch (expectedMessage)
            {
                case "Email is invalid.":
                    emailValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(false);
                    break;
                default:
                    emailValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
                    break;
            }

            var userContoller = new UserContoller(emailValidatorMock.Object);

            User user = new User()
            {
                FirstName = name,
                LastName = lastName,
                Email = email
            };

            //Act
            var res = userContoller.ValidateUser(user, out string message);

            //Assert
            Assert.Equal(res, expectedResult);
            Assert.Equal(message, expectedMessage);
        }

        [Theory]
        [InlineData("", "", "", "First name is invalid.", false)]
        [InlineData("a", "Lengrie", "asd@gmail.com", "First name is invalid.", false)]
        public void ValidateUser_IsCorrectValidationWithdName_Pass(string name, string lastName, string email, string expectedMessage, bool expectedResult)
        {
            //Arrange
            var emailValidatorMock = new Mock<IEmailValidator>();
            emailValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            var userContoller = new UserContoller(emailValidatorMock.Object);

            User user = new User()
            {
                FirstName = name,
                LastName = lastName,
                Email = email
            };

            //Act
            var res = userContoller.ValidateUser(user, out string message);

            //Assert
            Assert.Equal(res, expectedResult);
            Assert.Equal(message, expectedMessage);
        }
    }
}
