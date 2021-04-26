using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelHelperAPI.Models;
using System;
using System.Linq;

namespace TravelHelperAPI.Controllers
{
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpPost]
        public string Post([FromBody] Hotels value)
        {
            if (!dbContext.Hotels.Any(hotel => hotel.Title.Equals(value.Title) && hotel.Address.Equals(value.Address)))
            {
                Hotels hotel = new Hotels();
                hotel.Id = Guid.NewGuid().ToString();
                hotel.Title = value.Title;
                hotel.Address = value.Address;

                try
                {
                    dbContext.Add(hotel);
                    dbContext.SaveChanges();
                    return JsonConvert.SerializeObject("Hotel created");
                }
                catch (Exception e)
                {
                    return JsonConvert.SerializeObject(e.InnerException.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("Hotel already exists");
            }
        }
    }
}
