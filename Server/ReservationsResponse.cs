using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelHelperAPI
{
    public class ReservationsResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoomId { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
