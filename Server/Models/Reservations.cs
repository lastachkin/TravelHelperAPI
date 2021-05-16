using System;
using System.Collections.Generic;

namespace TravelHelperAPI.Models
{
    public partial class Reservations
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoomId { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
