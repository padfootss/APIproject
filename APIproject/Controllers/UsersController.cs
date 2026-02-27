using Microsoft.AspNetCore.Mvc;
using APIproject.Data;
using APIproject.Models;

namespace APIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost] // veri göndermek için istek
        public IActionResult CreateUser(User user)
        {
            _context.Users.Add(user); //user ekledi        
            _context.SaveChanges(); //dbye kaydetti
            return Ok(user); // 200 OK döndürdü
        }

        [HttpGet] // veri almak için istek
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.ToList()); // userları alıp listeliyor ve 200 döndürüyor
        }
    }
}
