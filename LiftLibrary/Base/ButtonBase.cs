using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftLibrary.Base
{
    public enum ButtonState
    {
        Off = 0,
        On = 1
    }


    public abstract class ButtonBase
    {
        public ButtonState State;

        public virtual void Execute()
        {
            
        }
    }
}
