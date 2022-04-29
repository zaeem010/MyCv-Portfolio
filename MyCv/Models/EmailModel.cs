using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MyCv.Models
{
    public class EmailModel
    {
        [Required]
        [EmailAddress]
        public string To { get; set; }
        [Required]
        public string Name { get; set; }
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public IFormFile Attachment { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
