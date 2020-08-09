
using System;

using ExampleUsersDDD.Domain.Enums;

namespace ExampleUsersDDD.Domain.Entities
{
    public class Account : EntityBase
    {
        private readonly string[] DEFAULT_RULES = new string[] {
            "public", "visitant", "pre-registered"
        };
        
        public Account(
            string email, string password, string group
        )
        {
            this.Email = email;
            this.Password = password;
            this.Group = group;
            this.Registered = DateTime.Today;
            this.Status = AccountStatus.Created;
            this.Roles = string.Join(",", this.DEFAULT_RULES);
        }
        
        public Account(
            int id, string email, string password, string group, DateTime registered, AccountStatus status, string roles
        ) : this(email, password, group)
        {
            this.Id = id;
            this.Registered = registered;
            this.Status = status;
            this.Roles = roles;
        }

        // Empty constructor for EF
        protected Account() { }

        public string Email { get; private set; }

        public string Password { get; set; }

        public DateTime Registered { get; private set; }

        public AccountStatus Status { get; set; }

        public string Group { get; private set; }
     
        public string Roles { get; private set; }

    }
}
