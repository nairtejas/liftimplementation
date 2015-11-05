using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftLibrary.Components
{
    public enum PowerSource
    {
        Mains = 0,
        GeneratorBackup = 1
    }
    public class Lift 
    {
        public LiftButton EmergencyCallButton = new LiftButton();
        public LiftButton EmergencyExitButton = new LiftButton();
        public OpenDoorButton OpenDoorButton = new OpenDoorButton();
        public CloseDoorButton CloseDoorButton = new CloseDoorButton();
        public ToggleButton FanButton = new ToggleButton();
        public ToggleButton LightsButton = new ToggleButton();

        public PowerSource PowerSource;
        public int Number;

        public Queue<CallRequest> RequestQueue = new Queue<CallRequest>();

        public Lift(int liftNumber)
        {
            Number = liftNumber;
        }

        public bool IsMoving = false;
        public int CurrentFloor = 0;

        public void Request(CallRequest request)
        {
            if (!IsMoving)
            {
                if (CurrentFloor == request.Floor.Number)
                {
                    OpenDoors();
                    return;
                }
                request.RequestServedEvent += RequestServed;
                request.Execute(this);
            }
            else
            {
                request.RequestServedEvent += RequestServed;
                RequestQueue.Enqueue(request);
            }
        }

        private void RequestServed()
        {
            IsMoving = false;
            OpenDoors();
            if (RequestQueue.Any())
            {
                var nextRequest = RequestQueue.Dequeue();
                nextRequest.Execute(this);
            }
        }

        public void OpenDoors()
        {
            OpenDoorButton.Execute();
        }
        public void CloseDoors()
        {
            CloseDoorButton.Execute();
        }

        public void Move(Floor requestedFloor)
        {
            CloseDoors();
            IsMoving = true;
            if (CurrentFloor > requestedFloor.Number) MoveUp();
            else MoveDown();
        }

        public void MoveUp()
        {
            //simulate actual moving of lift
            

        }

        public void MoveDown()
        {
           
        }

        public void EmergencyExit()
        {
        }

        public void EmergencyCall()
        {
        }
    }
}
