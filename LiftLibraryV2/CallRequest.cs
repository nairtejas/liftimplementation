using System.Threading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftLibraryV2.Components;

namespace LiftLibraryV2
{
    public class CallRequest
    {
        public delegate void RequestServed();

        public event RequestServed RequestServedEvent;

        //public Floor Floor;
        public int FloorNumber;
        public void Execute(Lift lift)
        {

            lift.Controller.Move(FloorNumber);
            ThreadPool.QueueUserWorkItem(target =>
            {
                // simulate lift moving by adding delay
                Thread.Sleep(5000);
                if (RequestServedEvent != null)
                    RequestServedEvent();
            });
        }
    }
}
