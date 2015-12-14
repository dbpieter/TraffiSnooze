using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraffiSnooze.Domain.Models
{
    public class RouteSegmentStat
    {

        public Guid Id { get; set; }

        public Guid RouteId { get; set; }
        public virtual Route Route { get; set; }

        public DateTime CaptureTime { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
