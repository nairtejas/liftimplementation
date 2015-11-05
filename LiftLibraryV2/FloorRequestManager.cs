using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftLibraryV2.Components;

namespace LiftLibraryV2
{
    public static class FloorRequestManager
    {
        public static readonly Queue<FloorCallRequest> FloorRequestQueue = new Queue<FloorCallRequest>();
        public static List<Lift> Lifts = new List<Lift>(); 
        public static void PlaceRequest(FloorCallRequest request)
        {
            FloorRequestQueue.Enqueue(request);
        }

        public static void ProcessRequests()
        {
            // implement scheduling algo
        }

    }
}
