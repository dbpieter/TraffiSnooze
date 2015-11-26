using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepTitle.Domain.Models
{
    public class RouteStat
    {

        public Guid Id { get; set; }

        public Guid RouteId { get; set; }
        public Route Route { get; set; }

        public DateTime CaptureTime { get; set; }

        public uint Duration { get; set; }
    }
}
