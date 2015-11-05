

namespace LiftLibraryV2.Buttons
{
    public class FloorButton : ButtonBase
    {
        public override void Execute()
        {
            FloorRequestManager.PlaceRequest(new FloorCallRequest() {FloorNumber = Number });
        }
    }
}
