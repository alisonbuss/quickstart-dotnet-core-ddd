
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExampleUsersDDD.Application.Dtos
{
    public class DtoProduct
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Active is Required")]
        public bool? IsActive { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(10)]
        [MaxLength(666)]
        public string Description { get; set; }

    }
}
