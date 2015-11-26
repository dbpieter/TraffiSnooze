using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepTitle.Domain.Models
{
    public class Location
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public float X { get; set; }

        public float Y { get; set; }
    }
}
