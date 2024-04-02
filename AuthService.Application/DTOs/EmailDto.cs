using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs
{
    public class EmailDto
    {
        [Required,EmailAddress] 
        public string To { get; set; }=string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; }=string.Empty;
    }
}
