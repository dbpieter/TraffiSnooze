using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraffiSnooze.Domain.Models
{
    public class Route
    {

        public Guid Id { get; set; }

        public virtual ICollection<RouteSegment> RouteSegments { get; set; }

    }
}
