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

        public Guid StartId { get; set; }
        public virtual Location Start { get; set; }

        public Guid EndId { get; set; }
        public virtual Location End { get; set; }

        public Guid? LastRouteStatId { get; set; }
        public RouteStat LastRouteStat { get; set; }

        public virtual ICollection<RouteStat> RouteStats { get; set; }
    }
}
