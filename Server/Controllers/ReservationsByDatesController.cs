using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelHelperAPI.Models;

namespace TravelHelperAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsByDatesController : Controller
    {

        [HttpPost]
        public string Post([FromBody] Reservations value)
        {
            using (TravelHelperContext dbContext = new TravelHelperContext())
            {
                Microsoft.Data.SqlClient.SqlParameter roomIdParam = new Microsoft.Data.SqlClient.SqlParameter("@roomId", value.RoomId);
                Microsoft.Data.SqlClient.SqlParameter startDateParam = new Microsoft.Data.SqlClient.SqlParameter("@startDate", value.StartDate);
                Microsoft.Data.SqlClient.SqlParameter endDateParam = new Microsoft.Data.SqlClient.SqlParameter("@endDate", value.EndDate);

                int activeReservationsCount = dbContext.Reservations.FromSqlRaw("GetActiveReservationsByDates {0}, {1}, {2}", roomIdParam, startDateParam, endDateParam).ToList().Count();

                int count = dbContext.Rooms.Where(room => room.Id.Equals(value.RoomId)).FirstOrDefault().Count;

                if (activeReservationsCount >= count)
                    return "Too much reservations";
                else
                    return "Ok";
            }
        }
    }
}
