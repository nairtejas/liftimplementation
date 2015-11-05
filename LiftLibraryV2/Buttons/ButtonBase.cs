using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftLibraryV2.Buttons
{
    public enum ButtonState
    {
        Off = 0,
        On = 1
    }


    public abstract class ButtonBase
    {
        public ButtonState State;
        public int Number;
        public virtual void Execute()
        {
            
        }
    }
}
