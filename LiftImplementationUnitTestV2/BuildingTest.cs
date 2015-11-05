using System;
using System.Linq;
using LiftLibraryV2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiftLibraryV2.Components;

namespace LiftImplementationUnitTest
{
    [TestClass]
    public class BuildingTest
    {
        [TestMethod]
        public void WhenFloorRequestsLift_AndLiftsAreUnavailable_EnsureRequestIsQueued()
        {
            var building = new Building(4,1);
            building.Floors[0].RequestLift();
            building.Floors[1].RequestLift();
            building.Floors[2].RequestLift();
            building.Floors[3].RequestLift();

            Assert.IsTrue(FloorRequestManager.FloorRequestQueue.Any(), "Test case failed. Requests not queued" );
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFloorException))]
        public void WhenRequestedFloorIsInvalid_ThrowInvalidFloorException()
        {
            var building = new Building(4, 1);
            building.GetAvailableLifts(100);
        }

        [TestMethod]
        public void WhenLiftPlacesMultipleRequests_EnsureRequestIsQueued()
        {
            var building = new Building(4, 1);
            building.Lifts[0].FloorButtonList.First(btn => btn.Number == 1).Execute();
            building.Lifts[0].FloorButtonList.First(btn => btn.Number == 2).Execute();
            building.Lifts[0].FloorButtonList.First(btn => btn.Number == 3).Execute();
            building.Lifts[0].FloorButtonList.First(btn => btn.Number == 4).Execute();

            Assert.IsTrue(building.Lifts[0].Controller.LiftRequestQueue.Any(), "Test case failed. Requests not queued");
        }
    }
}
