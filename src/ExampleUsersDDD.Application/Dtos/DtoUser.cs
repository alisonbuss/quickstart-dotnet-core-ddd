
using System;
using System.ComponentModel.DataAnnotations;

using ExampleUsersDDD.Domain.Enums;

namespace ExampleUsersDDD.Application.Dtos
{
    public class DtoUser
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Photo { get; set; }

        public string Nickname { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"${this.FirstName} ${this.LastName}";

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public char Gender { get; set; }

        public AccountStatusEnum Status { get; set; }

        public DateTime Registered { get; set; }

        public string Group { get; set; }
     
        public string Roles { get; set; }

    }
}
