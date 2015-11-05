
using LiftLibraryV2.Components;

namespace LiftLibraryV2.Buttons
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
            DoorState = (DoorState == LiftDoorState.Closed) ? LiftDoorState.Open : LiftDoorState.Closed;
        }

        public OpenDoorButton(Lift lift) : base(lift)
        {
        }
    }
}
