using System;
using System.Collections.Generic;
using System.Text;

namespace Barter.Models
{
    public class Friendship
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime FriendDate { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
