using System;
using System.Collections.Generic;

namespace TravelHelperAPI.Models
{
    public partial class Hotels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int? Rating { get; set; }
    }
}
