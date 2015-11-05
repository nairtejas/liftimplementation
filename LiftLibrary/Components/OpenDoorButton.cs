using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftLibrary.Components
{
    public enum LiftDoorState
    {
        Closed = 0,
        Open = 1
    }
    public class OpenDoorButton : LiftButton
    {
        public LiftDoorState DoorState;
        public override void Execute()
        {
            base.Execute();
            DoorState = (DoorState == LiftDoorState.Closed) ? LiftDoorState.Open : LiftDoorState.Closed;
        }
    }
}
