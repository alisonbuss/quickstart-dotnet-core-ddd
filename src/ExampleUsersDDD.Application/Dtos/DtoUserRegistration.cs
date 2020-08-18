
using System.ComponentModel.DataAnnotations;

namespace ExampleUsersDDD.Application.Dtos
{
    public class DtoUserRegistration
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(66)]
        [RegularExpression(
            "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$",
            ErrorMessage = "Passwords must be at least 8 characters long, with upper and lower case letters, numbers and special characters.")
        ]
        public string Password { get; set; }

        [Required(ErrorMessage = "The group is required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Group { get; set; }

    }
}
