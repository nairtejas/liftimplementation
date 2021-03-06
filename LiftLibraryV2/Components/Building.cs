﻿
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiftLibraryV2.Components
{
    public class Building : IBuilding
    {
        public List<Floor> Floors;
        public List<Lift> Lifts;

        public Building(int numberOfFloors, int numberOfLifts)
        {
            Floors = CreateFloors(numberOfFloors);
            Lifts = CreateLifts(numberOfLifts, numberOfFloors);
            FloorRequestManager.Lifts.AddRange(Lifts);
        }

        private List<Floor> CreateFloors(int numberOfFloors)
        {
            var floors = new List<Floor>();
            for (int i = 1; i <= numberOfFloors; i++)
            {
                var floor = new Floor(i, this);
                floors.Add(floor);
            }
            return floors;
        }
        private List<Lift> CreateLifts(int numberOfLifts, int numberOfFloors)
        {
            var lifts = new List<Lift>();
            for (int i = 1; i <= numberOfLifts; i++)
            {
                var floor = new Lift(i, numberOfFloors);
                lifts.Add(floor);
            }
            return lifts;
        }

        public Lift GetAvailableLifts(int requestedFloorNumber)
        {
            if (!IsValidFloorNumber(requestedFloorNumber))
            {
                throw new InvalidFloorException();
            }
            var availableLifts = Lifts.Where(lift => !lift.IsMoving).ToList();
            if (availableLifts.Any())
                return GetNearestLift(availableLifts, requestedFloorNumber);

            // if all lifts busy then return any one lift
            var nearestLift = GetNearestLift(Lifts, requestedFloorNumber);
            return nearestLift;
        }

        private Lift GetNearestLift(List<Lift> lifts, int requestedFloorNumber)
        {
            // simulate logic to find nearest lift
            return lifts.FirstOrDefault();
        }

        private bool IsValidFloorNumber(int requestedFloorNumber)
        {
            return Floors.Any(fl => fl.Number == requestedFloorNumber);
        }

        //public void MakeRequest(int requestedFloorNumber)
        //{
        //    var lift = GetAvailableLifts(requestedFloorNumber);
        //    lift.Controller.Request(new CallRequest() {FloorNumber = requestedFloorNumber});
        //}
    }
}
