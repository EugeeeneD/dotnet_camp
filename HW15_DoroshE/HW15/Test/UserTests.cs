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

        // ------------------------------- USERVALIDATION VALIDDATA PART -------------------------------

        [Theory]
        [InlineData("Arnold", "", "", "", "Alright.", true)]
        [InlineData("ValidName", "", "", "", "Alright.", true)]
        public void ValidateUser_ValidationWithValidData_Correct(string name, string lastName, string email, string phoneNumber, string expectedMessage, bool expectedResult)
        {
            //Arrange
            var emailValidatorMock = new Mock<IEmailValidator>();
            var phoneValidatorMock = new Mock<IPhoneNumberValidator>();

            emailValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            phoneValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            var userContoller = new UserContoller(emailValidatorMock.Object, phoneValidatorMock.Object);

            User user = new User()
            {
                FirstName = name,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            //Act
            var res = userContoller.ValidateUser(user, out string message);

            //Assert
            Assert.True(res);
            Assert.Equal(message, expectedMessage);
        }

        // ------------------------------- EMAILS PART -------------------------------

        [Theory]
        [InlineData("Arnold", "Lengrie", "asdad\"@gmail", "", "Email is invalid.")]
        public void ValidateUser_ValidationWithInvalidEmail_ShouldReturnFalse(string name, string lastName, string email, 
            string phoneNumber, string expectedMessage)
        {
            //Arrange
            var emailValidatorMock = new Mock<IEmailValidator>();
            var phoneValidatorMock = new Mock<IPhoneNumberValidator>();

            phoneValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(false);
            phoneValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            var userContoller = new UserContoller(emailValidatorMock.Object, phoneValidatorMock.Object);
            
            User user = new User()
            {
                FirstName = name,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            //Act
            var res = userContoller.ValidateUser(user, out string message);

            //Assert
            Assert.False(res);
            Assert.Equal(message, expectedMessage);
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData("a", "Lengrie", "asd@gmail.com")]
        public void ValidateUser_DoesTheEmailValidateAfterInvalidName_Pass(string name, string lastName, string email)
        {
            //Arrange
            var emailValidatorMock = new Mock<IEmailValidator>();
            var phoneValidatorMock = new Mock<IPhoneNumberValidator>();

            emailValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            phoneValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            var userContoller = new UserContoller(emailValidatorMock.Object, phoneValidatorMock.Object);

            User user = new User()
            {
                FirstName = name,
                LastName = lastName,
                Email = email
            };

            //Act
            var res = userContoller.ValidateUser(user, out string message);

            //Assert
            emailValidatorMock.Verify(x => x.IsValid(email), Times.Never);
        }

            // ------------------------------- NAMES PART -------------------------------

        [Theory]
        [InlineData("", "", "", "", "First name is invalid.")]
        [InlineData("a", "Lengrie", "asd@gmail.com", "", "First name is invalid.")]

        public void ValidateUser_ValidationWithInvalidName_ShouldReturnFalse(string name, string lastName, string email, 
            string phoneNumber, string expectedMessage)
        {
            //Arrange
            var emailValidatorMock = new Mock<IEmailValidator>();
            var phoneValidatorMock = new Mock<IPhoneNumberValidator>();

            emailValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            phoneValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);

            var userContoller = new UserContoller(emailValidatorMock.Object, phoneValidatorMock.Object);

            User user = new User()
            {
                FirstName = name,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            //Act
            var res = userContoller.ValidateUser(user, out string message);

            //Assert
            Assert.False(res);
            Assert.Equal(message, expectedMessage);
        }

        // ------------------------------- PHONES PART -------------------------------

        [Theory]
        [InlineData("Arnold", "Lengrie", "asdad@gmail", "+393923", "Phone number is invalid.")]
        [InlineData("Arnold", "Lengrie", "asdad@gmail", "+23232ew2", "Phone number is invalid.")]
        public void ValidateUser_ValidationWithInvalidPhone_ShouldReturnFalse(string name, string lastName, string email,
            string phoneNumber, string expectedMessage)
        {
            //Arrange
            var emailValidatorMock = new Mock<IEmailValidator>();
            var phoneValidatorMock = new Mock<IPhoneNumberValidator>();

            emailValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(true);
            phoneValidatorMock.Setup(x => x.IsValid(It.IsAny<string>())).Returns(false);

            var userContoller = new UserContoller(emailValidatorMock.Object, phoneValidatorMock.Object);

            User user = new User()
            {
                FirstName = name,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            //Act
            var res = userContoller.ValidateUser(user, out string message);

            //Assert
            Assert.False(res);
            Assert.Equal(message, expectedMessage);
        }
    }
}
