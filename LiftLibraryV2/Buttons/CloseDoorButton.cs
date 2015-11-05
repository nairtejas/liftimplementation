

using LiftLibraryV2.Components;

namespace LiftLibraryV2.Buttons
{
   
    public class CloseDoorButton : LiftButton
    {
        public LiftDoorState DoorState;
        public override void Execute()
        {
            DoorState = (DoorState == LiftDoorState.Closed) ? LiftDoorState.Closed : LiftDoorState.Open;
        }

        public CloseDoorButton(Lift lift) : base(lift)
        {
        }
    }
}
