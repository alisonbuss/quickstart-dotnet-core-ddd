
using ExampleUsersDDD.Domain.Notifications;

namespace ExampleUsersDDD.Domain.Entities
{
    public class EntityBase //: Notifies
    {
        public EntityBase(int id)
        {
            Id = id;
        }

        protected EntityBase() { }

        public int Id { get; set; }

    }
}
