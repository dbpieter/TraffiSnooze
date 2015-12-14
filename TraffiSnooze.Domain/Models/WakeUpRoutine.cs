using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraffiSnooze.Domain.Models
{
    public class WakeUpRoutine
    {

        public Guid Id { get; set; }

        public Guid RouteId { get; set; }
        public virtual Route Route { get; set; }

        public string Name { get; set;}
        
        public DateTime ShouldArriveAt { get; set; }

        public TimeSpan TimeNeededAfterWakeUp { get; set; }
    }
}
