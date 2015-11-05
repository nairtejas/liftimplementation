using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftLibrary.Components
{
   
    public class CloseDoorButton : LiftButton
    {
        public LiftDoorState DoorState;
        public override void Execute()
        {
            base.Execute();
            DoorState = (DoorState == LiftDoorState.Closed) ? LiftDoorState.Closed : LiftDoorState.Open;
        }
    }
}
