using System;
using System.Linq;
using LiftLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiftLibrary.Components;

namespace LiftImplementationUnitTest
{
    [TestClass]
    public class BuildingTest
    {
        [TestMethod]
        public void WhenRequestedLiftUnavailable_EnsureRequestIsQueued()
        {
            var building = new Building(4,1);
            building.Floors[0].RequestLift();
            building.Floors[1].RequestLift();
            building.Floors[2].RequestLift();
            building.Floors[3].RequestLift();

            Assert.IsTrue(building.Lifts.First().RequestQueue.Any(), "Test case failed. Requests not queued" );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFloorException))]
        public void WhenRequestedFloorIsInvalid_ThrowInvalidFloorException()
        {
            var building = new Building(4, 1);
            building.GetAvailableLifts(100);
        }
    }
}
