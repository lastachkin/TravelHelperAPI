using System;
using System.Collections.Generic;

namespace TravelHelperAPI.Models
{
    public partial class Favorites
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string HotelId { get; set; }
    }
}
