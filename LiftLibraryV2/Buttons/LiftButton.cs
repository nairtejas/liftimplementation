
using LiftLibraryV2.Components;

namespace LiftLibraryV2.Buttons
{
    public class LiftButton : ButtonBase
    {
        private Lift _lift;
        
        public LiftButton(Lift lift)
        {
            _lift = lift;
        }
        public override void Execute()
        {
            //_lift.Controller.LiftRequestQueue.Enqueue(new LiftCallRequest() {FloorNumber = Number});
            _lift.Controller.Request(new CallRequest() {FloorNumber = Number});
        }
    }
}
