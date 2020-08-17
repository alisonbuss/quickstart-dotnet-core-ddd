
using System.ComponentModel.DataAnnotations;

namespace ExampleUsersDDD.Application.Dtos
{
    public class DtoUser
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

        // [Required(ErrorMessage = "The name is required")]
        // [MinLength(2)]
        // [MaxLength(100)]
        // [RegularExpression(
        //     @"^[a-zA-Z''-'\s]{1,40}$", 
        //     ErrorMessage = "Numbers and special characters are not allowed in the name.")
        // ]
        // public string Name { get; set; }

        // [Required(ErrorMessage = "The firstName is required")]
        // [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 2)]
        // [RegularExpression(
        //     @"^[a-zA-Z''-'\s]{1,40}$", 
        //     ErrorMessage = "Numbers and special characters are not allowed in the name.")
        // ]
        // public string FirstName { get; set; }

        // [Required(ErrorMessage = "The lastName is required")]
        // [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 2)]
        // [RegularExpression(
        //     @"^[a-zA-Z''-'\s]{1,40}$", 
        //     ErrorMessage = "Numbers and special characters are not allowed in the name.")
        // ]
        // public string LastName { get; set; }

    }
}
