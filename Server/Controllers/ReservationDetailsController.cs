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
    public class ReservationDetailsController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpGet]
        public ReservationsResponse Get(string roomId)
        {
            Rooms room = dbContext.Rooms.Where(room => room.Id.Equals(roomId)).FirstOrDefault();
            Hotels hotel = dbContext.Hotels.Where(hotel => hotel.Id.Equals(room.HotelId)).FirstOrDefault();

            ReservationsResponse response = new ReservationsResponse();
            response.Title = hotel.Title;
            response.Type = room.Type;
            response.City = hotel.City;
            response.Address = hotel.Address;
            response.Cost = room.Cost;

            return response;
        }
    }
}
