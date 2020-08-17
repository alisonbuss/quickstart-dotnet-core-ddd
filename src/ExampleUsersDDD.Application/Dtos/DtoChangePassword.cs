
using System.ComponentModel.DataAnnotations;

namespace ExampleUsersDDD.Application.Dtos
{
    // The pattern:
    //
    // 1, At least one digit [0-9]
    // 2, At least one lowercase character [a-z]
    // 3, At least one uppercase character [A-Z]
    // 4, At least one special character [*.!@#$%^&(){}[]:;<>,.?/~_+-=|\]
    // 5, At least 8 characters in length, but no more than 32.
    //
    // Regular Expression: ^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$
    // Regular Expression: ^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\]).{8,32}$
    // Regular Expression: ^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$
    //
    // Dissecting the pattern:
    //
    // ^                                      Match the beginning of the string.
    // (?=.*[0-9])                            Require that at least one digit appear anywhere in the string.
    // (?=.*[a-z])                            Require that at least one lowercase letter appear anywhere in the string.
    // (?=.*[A-Z])                            Require that at least one uppercase letter appear anywhere in the string.
    // (?=.*[*.!@$%^&(){}[]:;<>,.?/~_+-=|\])  Require that at least one special character appear anywhere in the string.
    // .{8,32}                                The password must be at least 8 characters long, but no more than 32.
    // $                                      Match the end of the string.
    //
    // Acceptable example: Testing666!
    //
    public class DtoChangePassword
    {
        [Required(ErrorMessage = "The password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(66)]
        [RegularExpression(
            "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$",
            ErrorMessage = "Passwords must be at least 8 characters long, with upper and lower case letters, numbers and special characters.")
        ]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The new password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [MaxLength(66)]
        [RegularExpression(
            "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$",
            ErrorMessage = "Passwords must be at least 8 characters long, with upper and lower case letters, numbers and special characters.")
        ]
        public string NewPassword { get; set; }
    }
}
