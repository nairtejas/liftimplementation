using System.Threading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftLibrary.Components;

namespace LiftLibrary
{
    public class CallRequest
    {
        public delegate void RequestServed();

        public event RequestServed RequestServedEvent;

        public Floor Floor;
        public void Execute(Lift lift)
        {
            lift.Move(Floor);
            // simulate lift moving by adding delay
            Thread.Sleep(5000);
            if (RequestServedEvent != null)
                RequestServedEvent();

        }
    }
}
