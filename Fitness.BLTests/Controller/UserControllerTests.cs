using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange (Данные на вход)
            var userName = Guid.NewGuid().ToString();
            var dateOfBirth = DateTime.Now.AddYears(- 18);
            var gender = "man";
            var weight = 90;
            var height = 180;
            var controller = new UserController(userName);
            // Act (Действие)
            controller.SetNewUserData(gender, dateOfBirth, weight, height);
            var controller2 = new UserController(userName);

            // Assert (Выход, результат)
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(dateOfBirth, controller2.CurrentUser.DateOfBirth);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange (Данные на вход)
            var userName = Guid.NewGuid().ToString();

            // Act (Действие)
            var controller = new UserController(userName);

            // Assert (Выход, результат)
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}