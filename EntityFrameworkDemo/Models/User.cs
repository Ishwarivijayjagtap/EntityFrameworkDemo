using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.Models
{
    [Table("User")]
    public class User
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "USer Email")]
        public string Email { get; set; }

        [Required]
        
        [Display(Name = "USer Password")]
        public string Password { get; set; }
    }

}
