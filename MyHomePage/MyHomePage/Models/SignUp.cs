using System.ComponentModel.DataAnnotations;

namespace MyHomePage.Models
{
    public class SignUp
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        public string? Email { get; }

        [Required]
        public string? PassWord { get; }

        [Required]
        public DateTime RegDate { get; set; }
    }
}
