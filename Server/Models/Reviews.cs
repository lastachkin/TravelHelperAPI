using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Reviews
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public int Rate { get; set; }
        public string Text { get; set; }
    }
}
