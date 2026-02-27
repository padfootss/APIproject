using System.ComponentModel.DataAnnotations;

namespace APIproject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        public List<Message>? SentMessages { get; set; }
        public List<Message>? ReceivedMessages { get; set; }
    }
}