using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelHelperAPI.Models;

namespace TravelHelperAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpGet("{id}")]
        public List<Rooms> Get(string id)
        {
            return dbContext.Rooms.Where(room => room.HotelId.Equals(id)).ToList();
        }

        [HttpPost]
        public string Post([FromBody] Rooms value)
        {
            if (!dbContext.Rooms.Any(room => room.HotelId.Equals(value.HotelId) && room.Type.Equals(value.Type)))
            {
                Rooms room = new Rooms();
                room.Id = value.Id;
                room.HotelId = value.HotelId;
                room.Count = value.Count;
                room.Cost = value.Cost;
                room.Type = value.Type;

                try
                {
                    dbContext.Add(room);
                    dbContext.SaveChanges();
                    return JsonConvert.SerializeObject("Room type created");
                }
                catch (Exception e)
                {
                    return JsonConvert.SerializeObject(e.InnerException.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("Room type already exists");
            }
        }

        [HttpPut("{id}")]
        public string Put(string id, [FromBody] Rooms value)
        {
            try
            {
                Rooms room = dbContext.Rooms.Where(room => room.Id.Equals(id)).First();

                room.Id = value.Id;
                room.HotelId = value.HotelId;
                room.Count = value.Count;
                room.Cost = value.Cost;
                room.Type = value.Type;

                dbContext.Update(room);
                dbContext.SaveChanges();

                return JsonConvert.SerializeObject("Room updated");
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
                Rooms room = dbContext.Rooms.FirstOrDefault(room => room.Id.Equals(id));
                dbContext.Rooms.Remove(room);
                dbContext.SaveChangesAsync();
                return JsonConvert.SerializeObject("Room deleted");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.InnerException.Message);
            }
        }
    }
}
