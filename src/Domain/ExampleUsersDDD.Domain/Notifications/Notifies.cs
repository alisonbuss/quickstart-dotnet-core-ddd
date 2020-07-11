using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExampleUsersDDD.Domain.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notifies> Notitycoes;

        public bool ValidatePropertyString(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notitycoes.Add(new Notifies
                {
                    Message = "Required field",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }

        public bool ValidatePropertyInt(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notitycoes.Add(new Notifies
                {
                    Message = "The value must be greater than 0",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }

        public bool ValidatePropertyDecimal(decimal value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notitycoes.Add(new Notifies
                {
                    Message = "The value must be greater than 0",
                    PropertyName = propertyName
                });

                return false;
            }
            return true;
        }

    }
}
