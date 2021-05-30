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
    public class ManagerExtensionController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpGet("{reservationId}")]
        public ManagerResponse Get(string reservationId)
        {
            ManagerResponse response = new ManagerResponse();
            

            Reservations reservation = dbContext.Reservations.Where(u => u.Id.Equals(reservationId)).FirstOrDefault();

            double diffDays = (reservation.EndDate.Date - reservation.StartDate.Date).TotalDays;

            response.Name = dbContext.Users.Where(u => u.Id.Equals(reservation.UserId)).FirstOrDefault().Firstname + " " + dbContext.Users.Where(u => u.Id.Equals(reservation.UserId)).FirstOrDefault().Lastname;
            response.Type = dbContext.Rooms.Where(u => u.Id.Equals(reservation.RoomId)).FirstOrDefault().Type;
            response.Cost = (dbContext.Rooms.Where(u => u.Id.Equals(reservation.RoomId)).FirstOrDefault().Cost * diffDays).ToString();
            response.Comment = reservation.Comment;

            return response;
        }
    }
}
