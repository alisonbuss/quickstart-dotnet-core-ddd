
using System;
using System.ComponentModel.DataAnnotations;

namespace ExampleUsersDDD.Application.Dtos
{
    public class DtoUser
    {
        [Key]
        public int Id { get; set; }

        // [Required(ErrorMessage = "The Email is Required")]
        // [MinLength(0)]
        // [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Group is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Group { get; set; }

    }
}
