
using System;

namespace ExampleUsersDDD.Domain.Entities
{
    public class User : Account
    {
        public User() { }

        public User(
            string email, string password, DateTime registered, bool isConfirmed, bool isActive, string group
        ) : base(email, password, registered, isConfirmed, isActive, group)
        {
            
        }

        public User(
            int id, string email, string password, DateTime registered, bool isConfirmed, bool isActive, string group
        ) : base(id, email, password, registered, isConfirmed, isActive, group)
        {
            
        }

        public User(
            int id, string email, string password, DateTime registered, bool isConfirmed, bool isActive, string group,
            byte[] photo, string nickname, string firstName, string fullName, string phone, DateTime? birthDate, char? gender
        ) : base(id, email, password, registered, isConfirmed, isActive, group)
        {
            this.Photo = photo;
            this.Nickname = nickname;
            this.FirstName = firstName;
            this.FullName = fullName;
            this.Phone = phone;
            this.BirthDate = birthDate;
            this.Gender = gender;
        }

        public byte[] Photo { get; set; }

        public string Nickname { get; set; }

        public string FirstName { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public DateTime? BirthDate { get; set; }

        public char? Gender { get; set; }

    }
}
