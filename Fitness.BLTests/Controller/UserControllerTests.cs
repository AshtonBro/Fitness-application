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
            Assert.Fail();
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