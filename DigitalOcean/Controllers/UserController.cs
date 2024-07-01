using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DigitalOcean.Infrastructure;
using DigitalOcean.Models;

namespace DigitalOcean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DigitalOceanContext _digitalOceanContext;

        public UserController(DigitalOceanContext digitalOceanContext)
        {
            _digitalOceanContext = digitalOceanContext;
        }

        [HttpGet]
        public List<User> GetAsync()
        {
            var users = _digitalOceanContext.Users.ToList();
            return users;
        }

        [HttpPost]
        public IActionResult PostAsync(User userModel)
        {
            _digitalOceanContext.Users.Add(userModel);
            _digitalOceanContext.SaveChanges();

            return Ok();
        }
    }
}