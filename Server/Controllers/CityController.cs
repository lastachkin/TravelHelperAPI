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
    public class CityController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpGet]
        public List<string> Get()
        {
            List<string> cities = new List<string>();
            foreach(Hotels item in dbContext.Hotels)
            {
                cities.Add(item.City);
            }

            return cities.Distinct().ToList();
        }
    }
}
