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

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok(message);
        }

        [HttpGet("{userId}")]
        public IActionResult GetMessages(int userId)
        {
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