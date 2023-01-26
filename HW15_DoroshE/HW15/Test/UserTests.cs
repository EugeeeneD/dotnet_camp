using HW15.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using HW15.Interface;

namespace Test
{
    public class UserTests
    {
        public Mock<IUserService> userService = new();

        [Fact]
        public void AddUser(User user)
        {
            //Arrange
            //Act
            //Assert
        }
    }
}
