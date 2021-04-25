using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpPost]
        public string Post([FromBody] Users value)
        {
            if (!dbContext.Users.Any(user => user.Login.Equals(value.Login)))
            {
                Users user = new Users();
                user.Id = Guid.NewGuid().ToString();
                user.Firstname = value.Firstname;
                user.Lastname = value.Lastname;
                user.Role = value.Role;
                user.Phone = value.Phone;
                user.Email = value.Email;
                user.Login = value.Login;
                user.Password = value.Password;

                try
                {
                    dbContext.Add(user);
                    dbContext.SaveChanges();
                    return JsonConvert.SerializeObject("Register OK - Remote DB");
                }
                catch (Exception e)
                {
                    return JsonConvert.SerializeObject(e.InnerException.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("User already exists - Remote DB");
            }
        }

    }
}
