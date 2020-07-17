using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExampleUsersDDD.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product(
            int id, string name, decimal price, bool isActive, string description
        ) : base(id)
        {
            Name = name;
            Price = price;
            IsActive = isActive;
            Description = description;
        }

        // Empty constructor for EF
        protected Product() { }

        public string Name { get; set; }
        //public string Name { get; private set; }

        public decimal Price { get; set; }
        //public decimal Price { get; private set; }

        public bool? IsActive { get; set; }
        //public bool IsActive { get; private set; }

        public string Description { get; set; }
        //public string Description { get; private set; }

    }
}
