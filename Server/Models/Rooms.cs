using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Rooms
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }
        public string Type { get; set; }
    }
}
