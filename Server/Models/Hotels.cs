using System;
using System.Collections.Generic;

namespace TravelHelperAPI.Models
{
    public partial class Hotels
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; }
    }
}
