
namespace ExampleUsersDDD.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase(int id)
        {
            Id = id;
        }

        protected EntityBase() { }

        public int Id { get; set; }

    }
}
