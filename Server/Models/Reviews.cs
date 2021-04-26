using System;
using System.Collections.Generic;

namespace TravelHelperAPI.Models
{
    public partial class Reviews
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string HotelId { get; set; }
        public int Rate { get; set; }
        public string Text { get; set; }
    }
}
