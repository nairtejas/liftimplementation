using LiftLibraryV2;

namespace LiftLibraryV2
{
    public interface IController
    {
        void Request(CallRequest request);
        void OpenDoors();
        void CloseDoors();
        void MoveUp();
        void MoveDown();

        void EmergencyExit();

       void EmergencyCall();
    }
}