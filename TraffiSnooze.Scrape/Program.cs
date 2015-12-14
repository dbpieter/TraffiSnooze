using SleepTitle.Data.ExternalServices;
using SleepTitle.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraffiSnooze.Data.EF;
using TraffiSnooze.Domain.Models;

namespace TraffiSnooze.Scrape
{
    class Program
    {
        static void Main(string[] args)
        {
            WazeRoutingService wazeSrvc = new WazeRoutingService();
            var task = wazeSrvc.GetRoutingInfo(4.262249f, 50.752061f, 3.954767f, 50.969350f);
            Task.WaitAll(task);
            var result = task.Result;
        }
    }
}
