
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleUsersDDD.Domain.Entities
{
    public class Account : EntityBase
    {
        public Account(
            string email, string password, DateTime registered, bool isConfirmed, bool isActive, string group
        ) : base()
        {
            this.Email = email;
            this.Password = password;
            this.Registered = registered;
            this.IsConfirmed = isConfirmed;
            this.IsActive = isActive;
            this.Group = group;

            this.Roles = new string[] {"Admin", "Manager"};
        }

        public Account(
            int id, string email, string password, DateTime registered, bool isConfirmed, bool isActive, string group
        ) : this(email, password, registered, isConfirmed, isActive, group)
        {
            this.Id = id;
        }

        // Empty constructor for EF
        protected Account() { }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public DateTime Registered { get; private set; }

        public bool IsConfirmed { get; set; }

        public bool IsActive { get; set; }

        public string Group { get; set; }
        
        [NotMapped]
        public string[] Roles { get; private set; }

    }
}
