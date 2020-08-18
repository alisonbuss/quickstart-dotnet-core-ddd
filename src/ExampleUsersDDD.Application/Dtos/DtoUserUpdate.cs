
using System;
using System.ComponentModel.DataAnnotations;

using ExampleUsersDDD.Domain.Enums;

namespace ExampleUsersDDD.Application.Dtos
{
    public class DtoUserUpdate
    {
        [Key]
        public int Id { get; set; }

        [MinLength(0)]
        [MaxLength(77)]
        [RegularExpression(
            @"^[a-z0-9-]*\.(jpg|jpeg|png|gif)$", 
            ErrorMessage = "The name of the photo must contain only lowercase letters, numbers and hyphens, from type: (jpg, jpeg, png or gif).")
        ]
        public string Photo { get; set; }

        [Required(ErrorMessage = "The nickname is required")]
        [MinLength(3)]
        [MaxLength(66)]
        [RegularExpression(
            @"^[a-zA-Z''-'\s]{1,40}$", 
            ErrorMessage = "Numbers and special characters are not allowed in the nickname.")
        ]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "The firstName is required")]
        [MinLength(3)]
        [MaxLength(66)]
        [RegularExpression(
            @"^[a-zA-Z''-'\s]{1,40}$", 
            ErrorMessage = "Numbers and special characters are not allowed in the name.")
        ]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The lastName is required")]
        [MinLength(3)]
        [MaxLength(66)]
        [RegularExpression(
            @"^[a-zA-Z''-'\s]{1,40}$", 
            ErrorMessage = "Numbers and special characters are not allowed in the name.")
        ]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [MaxLength(99)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        // [RegularExpression(
        //     @"^[0-9]{8,18}", 
        //     ErrorMessage = "The phone number should only contain numbers between 8 to 18 digits.")
        // ]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The birth date is required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(1)]
        public char Gender { get; set; }

        [Required(ErrorMessage = "The status is required")]
        public AccountStatusEnum Status { get; set; }

        [Required(ErrorMessage = "The group is required")]
        [MinLength(3)]
        [MaxLength(66)]
        public string Group { get; set; }
     
        [Required(ErrorMessage = "The roles is required")]
        [MinLength(3)]
        [MaxLength(99)]
        public string Roles { get; set; }
        
    }
}
