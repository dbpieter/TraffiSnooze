using System;

namespace TraffiSnooze.Domain.Models
{
    public class User
    {

        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual WakeUpRoutine WakeUpRoutine { get; set; }
    }
}
