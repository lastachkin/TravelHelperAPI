using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelHelperAPI.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TravelHelperAPI.Controllers
{
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpGet]
        public List<Hotels> Get()
        {
            return dbContext.Hotels.ToList();
        }

        [HttpPost]
        public string Post([FromBody] Hotels value)
        {
            if (!dbContext.Hotels.Any(hotel => hotel.Title.Equals(value.Title) && hotel.Address.Equals(value.Address)))
            {
                Hotels hotel = new Hotels();
                hotel.Id = value.Id;
                hotel.Title = value.Title;
                hotel.City = value.City;        
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

        [HttpPut("{id}")]
        public string Put(string id, [FromBody] Hotels value)
        {
            try
            {
                Hotels hotel = dbContext.Hotels.Where(hotel => hotel.Id.Equals(id)).First();

                hotel.Id = value.Id;
                hotel.Title = value.Title;
                hotel.City = value.City;
                hotel.Address = value.Address;

                dbContext.Update(hotel);
                dbContext.SaveChanges();

                return JsonConvert.SerializeObject("Hotel updated");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.InnerException.Message);
            }
        }

        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            try
            {
                Hotels hotel = dbContext.Hotels.FirstOrDefault(hotel => hotel.Id.Equals(id));
                dbContext.Hotels.Remove(hotel);
                dbContext.SaveChangesAsync();
                return JsonConvert.SerializeObject("Hotel deleted");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.InnerException.Message);
            }
        }
    }
}
