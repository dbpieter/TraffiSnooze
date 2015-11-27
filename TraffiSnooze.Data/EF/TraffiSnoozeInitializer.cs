using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraffiSnooze.Data.EF;

namespace SleepTitle.Data.EF
{
    public class TraffiSnoozeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TraffiSnoozeContext>
    {

    }
}
