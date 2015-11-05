using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftLibraryV2.Components;


namespace LiftLibraryV2
{
    public class LiftController
    {
        private Lift _lift;
        public Queue<CallRequest> LiftRequestQueue = new Queue<CallRequest>();

        public LiftController(Lift lift)
        {
            _lift = lift;
        }

        public void Request(CallRequest request)
        {
            if (!_lift.IsMoving)
            {
                if (_lift.CurrentFloor == request.FloorNumber)
                {
                    OpenDoors();
                    return;
                }
                request.RequestServedEvent += RequestServed;
                request.Execute(_lift);
            }
            else
            {
                request.RequestServedEvent += RequestServed;
                LiftRequestQueue.Enqueue(request);
            }
        }

        private void RequestServed()
        {
            _lift.IsMoving = false;
            OpenDoors();
            if (LiftRequestQueue.Any())
            {
                var nextRequest = LiftRequestQueue.Dequeue();
                nextRequest.Execute(_lift);
            }
        }

        public void OpenDoors()
        {
            _lift.OpenDoorButton.Execute();
        }
        public void CloseDoors()
        {
            _lift.CloseDoorButton.Execute();
        }

        public void Move(int requestedFloor)
        {
            CloseDoors();
            _lift.IsMoving = true;
            if (_lift.CurrentFloor > requestedFloor) MoveDown();
            else MoveUp();
        }

        private void MoveUp()
        {
            //simulate actual moving of lift


        }
        private void MoveDown()
        {

        }
    }
}
