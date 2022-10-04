using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment4.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4.Manager;
using MandatoryAssignment;

namespace Assignment4.Controllers.Tests
{
    [TestClass()]
    public class FootballPlayersControlerTests
    {
        FootballPlayersManager manager = new FootballPlayersManager();
        [TestMethod()]
        public void GetByIdTest()
        {
            FootbalPlayer result = manager.GetById(3);

            Assert.AreEqual(result.Name, "Tea");
            Assert.AreEqual(result.ShirtNumber, 50);
        }

        [TestMethod()]
        public void GetByInvalidIdTest()
        {
            FootbalPlayer result = manager.GetById(5);

            Assert.AreEqual(result, null);
        }

        [TestMethod()]
        public void GetByNegativeIdTest()
        {
            FootbalPlayer result = manager.GetById(-1);

            Assert.AreEqual(result, null);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            FootbalPlayer player = manager.GetById(4);

            manager.Delete(player.Id);
            FootbalPlayer result = manager.GetById(player.Id);

            Assert.AreEqual(result, null);
        }

        public void DeleteNotValidIdTest()
        {
            FootbalPlayer player = manager.GetById(5);

            manager.Delete(player.Id);
            FootbalPlayer result = manager.GetById(player.Id);

            Assert.AreEqual(result, null);
            Assert.AreEqual(player, null);
        }
    }
}