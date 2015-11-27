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
            using(var ctx = new TraffiSnoozeContext())
            {
                var data = ctx.Set<User>();
                var usr = new User
                {
                    Password = "lol",
                    UserName = "lol"
                };

                data.Add(usr);
                ctx.SaveChanges();
            }
        }
    }
}
