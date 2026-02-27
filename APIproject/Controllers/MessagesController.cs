using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIproject.Data;
using APIproject.Models;

namespace APIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MessagesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost] // istek geliyor veri göndermek için
        public IActionResult SendMessage(Message message)
        {
            _context.Messages.Add(message);  //mesaj gönderiyor
            _context.SaveChanges(); // database kaydediyor
            return Ok(message); // http response 200 döndürür 
        }

        [HttpGet("{userId}")] // istek veri alma
        public IActionResult GetMessages(int userId)
        {    
        //database sorguuyor
            var messages = _context.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .OrderByDescending(m => m.SentAt)
                .ToList();

            return Ok(messages);
        }
    }
}
