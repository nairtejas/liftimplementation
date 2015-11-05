namespace LiftLibrary.Components
{
    public class Floor
    {
        public int Number;
        private Building _building;

        public Floor(int floorNumber, Building building)
        {
            Number = floorNumber;
            _building = building;
        }

        public void RequestLift()
        {
            _building.MakeRequest(Number);
        }
    }
}
