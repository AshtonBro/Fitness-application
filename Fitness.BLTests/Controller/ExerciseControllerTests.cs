using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddExerciseTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var acrivityName = Guid.NewGuid().ToString();
            var rnd = new Random();

            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(acrivityName, rnd.Next(10, 50));

            // Act
            exerciseController.AddExercise(activity, DateTime.Now, DateTime.Now.AddHours(1));

            // Assert
            Assert.AreEqual(acrivityName, exerciseController.Activities.First().Name);
        }
    }
}