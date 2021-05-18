using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelHelperAPI.Models;

namespace TravelHelperAPI.Controllers
{
    [Route("api/[controller]")]
    public class FavoriteController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpGet("{userId}")]
        public List<Hotels> Get(string userId)
        {
            List<Favorites> favorites = dbContext.Favorites.Where(favorite => favorite.UserId.Equals(userId)).ToList();
            List<Hotels> favoriteHotels = new List<Hotels>();

            foreach(Hotels hotel in dbContext.Hotels.ToList())
            {
                foreach(Favorites favorite in favorites)
                {
                    if (hotel.Id == favorite.HotelId)
                        favoriteHotels.Add(hotel);
                }
            }
            return favoriteHotels;
        }

        [HttpPost]
        public string Post([FromBody] Favorites value)
        {
            if (!dbContext.Favorites.Any(favorite => favorite.HotelId.Equals(value.HotelId) && favorite.UserId.Equals(value.UserId)))
            {
                Favorites favorite = new Favorites();
                favorite.Id = value.Id;
                favorite.HotelId = value.HotelId;
                favorite.UserId = value.UserId;

                try
                {
                    dbContext.Add(favorite);
                    dbContext.SaveChanges();
                    return JsonConvert.SerializeObject("Favorite hotel added");
                }
                catch (Exception e)
                {
                    return JsonConvert.SerializeObject(e.InnerException.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("Favorite hotel for this user already exists");
            }
        }

        [HttpDelete]
        public string Delete(string userId, string hotelId)
        {
            try
            {
                Favorites favorite = dbContext.Favorites.FirstOrDefault(favorite => favorite.UserId.Equals(userId) && favorite.HotelId.Equals(hotelId));
                dbContext.Favorites.Remove(favorite);
                dbContext.SaveChangesAsync();
                return JsonConvert.SerializeObject("Fvorite hotel deleted");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.InnerException.Message);
            }
        }
    }
}
