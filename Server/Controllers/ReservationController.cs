using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperAPI.Models;

namespace TravelHelperAPI.Controllers
{
    public class ReservationController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpPost]
        public string Post([FromBody] Reservations value)
        {
            if (!dbContext.Reservations.Any(reservation => reservation.HotelId.Equals(value.HotelId) && reservation.StartDate.Equals(value.StartDate)))
            {
                Reservations reservation = new Reservations();
                reservation.Id = value.Id;
                reservation.UserId = value.UserId;
                reservation.HotelId = value.HotelId;
                reservation.Status = value.Status;
                reservation.StartDate = value.StartDate;
                reservation.EndDate = value.EndDate;

                try
                {
                    dbContext.Add(reservation);
                    dbContext.SaveChanges();
                    return JsonConvert.SerializeObject("Reservation created");
                }
                catch (Exception e)
                {
                    return JsonConvert.SerializeObject(e.InnerException.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("Reservation already exists");
            }
        }
    }
}
