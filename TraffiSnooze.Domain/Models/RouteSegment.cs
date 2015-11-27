using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraffiSnooze.Domain.Models
{
    public class RouteSegment
    {
        public Guid Id { get; set; }

        public Guid StartId { get; set; }
        public Location Start { get; set; }

        public Guid EndId { get; set; }
        public Location End { get; set; }
    }
}
