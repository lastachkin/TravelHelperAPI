using System;
using System.Collections.Generic;

namespace TravelHelperAPI.Models
{
    public partial class Rooms
    {
        public string Id { get; set; }
        public string HotelId { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }
        public string Type { get; set; }
    }
}
