using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepTitle.Domain.Models
{
    public class Route
    {

        public Guid id { get; set; }

        public Guid StartId { get; set; }
        public virtual Location Start { get; set; }

        public Guid EndId { get; set; }
        public virtual Location End { get; set; }
    }
}
