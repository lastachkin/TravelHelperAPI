using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        TravelHelperContext dbContext = new TravelHelperContext();

        [HttpGet]
        public string Get(string login, string password)
        {
            if (dbContext.Users.Any(user => user.Login.Equals(login)))
            {
                Users user = dbContext.Users.Where(u => u.Login.Equals(login)).First();
                if (user.Password.Equals(password))
                    return JsonConvert.SerializeObject(user);
                else
                    return JsonConvert.SerializeObject("Incorrect password");
            }
            else
            {
                return JsonConvert.SerializeObject("Not found");
            }
        }


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
                    return JsonConvert.SerializeObject("Create User OK - Remote DB");
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
