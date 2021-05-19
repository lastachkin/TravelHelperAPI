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
    [Route("api/[controller]")]
    public class ManagerController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpGet("{userId}")]
        public string Get(string userId)
        {
            Managers manager = dbContext.Managers.Where(manager => manager.UserId.Equals(userId)).FirstOrDefault();
            return manager.HotelId;
        }

        [HttpPost]
        public string Post([FromBody] Managers value)
        {
            Managers manager = new Managers();
            manager.Id = value.Id;
            manager.UserId = value.UserId;
            manager.HotelId = value.HotelId;

            try
            {
                dbContext.Add(manager);
                dbContext.SaveChanges();
                return JsonConvert.SerializeObject("Manager added");
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(e.InnerException.Message);
            }
        }
    }
}
