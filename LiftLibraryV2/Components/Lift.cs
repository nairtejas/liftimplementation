using System.Collections.Generic;
using LiftLibraryV2.Buttons;

namespace LiftLibraryV2.Components
{
    public enum PowerSource
    {
        Mains = 0,
        GeneratorBackup = 1
    }
    public class Lift
    {
        public LiftController Controller;
        public LiftButton EmergencyCallButton;
        public LiftButton EmergencyExitButton;
        public OpenDoorButton OpenDoorButton;
        public CloseDoorButton CloseDoorButton;
        public ToggleButton FanButton = new ToggleButton();
        public ToggleButton LightsButton = new ToggleButton();
        public List<LiftButton> FloorButtonList;

        public PowerSource PowerSource;
        public int Number;

        public Lift(int liftNumber, int numberOfFloorButtons)
        {
            Number = liftNumber;
            EmergencyCallButton = new LiftButton(this);
            EmergencyExitButton = new LiftButton(this);
            OpenDoorButton = new OpenDoorButton(this);
            CloseDoorButton = new CloseDoorButton(this);
            FloorButtonList = CreateFloorButtons(numberOfFloorButtons);
            Controller = new LiftController(this);
        }

        private List<LiftButton> CreateFloorButtons(int numberOfFloors)
        {
            var liftButtons = new List<LiftButton>();
            for (int i = 1; i <= numberOfFloors; i++)
            {
                var button = new LiftButton(this) { Number = i };
                liftButtons.Add(button);
            }
            return liftButtons;
        }

        public bool IsMoving = false;
        public int CurrentFloor = 0;
    }
}
