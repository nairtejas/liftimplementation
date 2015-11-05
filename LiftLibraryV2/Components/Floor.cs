using LiftLibraryV2.Buttons;

namespace LiftLibraryV2.Components
{
    public class Floor
    {
        public int Number;
        private Building _building;
        private FloorButton _floorButton;

        public Floor(int floorNumber, Building building)
        {
            Number = floorNumber;
            _building = building;
            _floorButton = new FloorButton() {Number = Number};
        }

        public void RequestLift()
        {
            _floorButton.Execute();
            //_building.MakeRequest(Number);
        }
    }
}
