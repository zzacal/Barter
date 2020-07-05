using System;
using System.Collections.Generic;
using System.Text;

namespace Barter.Models
{
    public class Tag
    {
        public string Title { get; set; }
        public Thing Thing { get; set; }
        public int ThingId { get; set; }
    }
}
