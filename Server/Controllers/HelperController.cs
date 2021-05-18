using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperAPI.Models;

namespace TravelHelperAPI.Controllers
{
    [Route("api/[controller]")]
    public class HelperController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpGet("{hotelId}")]
        public List<Reservations> Get(string hotelId)
        {
            List<Reservations> reservations = new List<Reservations>();
            List<Rooms> rooms = dbContext.Rooms.Where(room => room.HotelId.Equals(hotelId)).ToList();

            foreach(Reservations item in dbContext.Reservations)
            {
                foreach(Rooms roomItem in rooms)
                {
                    if (item.RoomId == roomItem.Id)
                        reservations.Add(item);
                }
            }

            return reservations;
        }
    }
}
