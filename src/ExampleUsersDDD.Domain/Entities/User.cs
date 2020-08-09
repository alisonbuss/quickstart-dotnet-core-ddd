
using System;
using ExampleUsersDDD.Domain.Enums;

namespace ExampleUsersDDD.Domain.Entities
{
    public class User : Account
    {
        public User(
            string email, string password, string group
        ) : base(email, password, group) {}

        public User(
            int id, string email, string password, string group, DateTime registered, AccountStatus status, string roles
        ) : base(id, email, password, group, registered, status, roles) {}

        public User(
            string email, string password, string group, string photo, string nickname,
            string firstName, string lastName, string phone, DateTime? birthDate, char? gender
        ) : this(email, password, group)
        {
            this.setUser(photo, nickname, firstName, lastName, phone, birthDate, gender);
        }

        public User(
            int id, string email, string password, string group, DateTime registered, AccountStatus status, string roles,
            string photo, string nickname, string firstName, string lastName, string phone, DateTime? birthDate, char? gender
        ) : this(id, email, password, group, registered, status, roles)
        {
            this.setUser(photo, nickname, firstName, lastName, phone, birthDate, gender);
        }

        // Empty constructor for EF
        protected User() { }

        private void setUser(string photo, string nickname, string firstName, string lastName, string phone, DateTime? birthDate, char? gender) {
            this.Photo = photo;
            this.Nickname = nickname;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.BirthDate = birthDate;
            this.Gender = gender;
        }

        public string Photo { get; set; }

        public string Nickname { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"${this.FirstName} ${this.LastName}";

        public string Phone { get; set; }

        public DateTime? BirthDate { get; set; }

        public char? Gender { get; set; }

    }
}
