namespace LiftLibraryV2.Components
{
    public interface IBuilding
    {
        Lift GetAvailableLifts(int requestedFloorNumber);
       // void MakeRequest(int requestedFloorNumber);
    }
}