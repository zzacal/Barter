using System;
using System.Collections.Generic;
using System.Text;

namespace Barter.Models
{
    public class Thing
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Hook { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }
        public int BarteredUserId { get; set; }
        public int Satisfaction { get; set; }
        public string Review { get; set; }
    }
}
