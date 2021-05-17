using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelHelperAPI.Models;

namespace TravelHelperAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpGet("{userId}")]
        public List<Reservations> Get(string userId)
        {
            return dbContext.Reservations.Where(reservation => reservation.UserId.Equals(userId)).ToList();
            /*
            List<ReservationsResponse> response = new List<ReservationsResponse>();
            List<Reservations> reservations =  dbContext.Reservations.Where(reservation => reservation.UserId.Equals(userId)).ToList();
            foreach(Reservations item in reservations)
            {
                ReservationsResponse reservationsResponse = new ReservationsResponse();
                reservationsResponse.Id = item.Id;
                reservationsResponse.RoomId = item.RoomId;
                reservationsResponse.UserId = item.UserId;
                reservationsResponse.Status = item.Status;
                reservationsResponse.StartDate = item.StartDate.Year.ToString() + "-" + item.StartDate.Month.ToString() + "-" + item.StartDate.Day.ToString();
                reservationsResponse.EndDate = item.EndDate.Year.ToString() + "-" + item.EndDate.Month.ToString() + "-" + item.EndDate.Day.ToString();
                response.Add(reservationsResponse);
            }
            return response;*/
        }

        [HttpPost]
        public string Post([FromBody] Reservations value)
        {
            if (!dbContext.Reservations.Any(reservation => reservation.RoomId.Equals(value.RoomId) && reservation.StartDate.Equals(value.StartDate)))
            {
                Reservations reservation = new Reservations();
                reservation.Id = value.Id;
                reservation.UserId = value.UserId;
                reservation.RoomId = value.RoomId;
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

        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            try
            {
                Reservations reservation = dbContext.Reservations.FirstOrDefault(reservation => reservation.Id.Equals(id));
                dbContext.Reservations.Remove(reservation);
                dbContext.SaveChangesAsync();
                return JsonConvert.SerializeObject("Reservation deleted");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.InnerException.Message);
            }
        }
    }
}
