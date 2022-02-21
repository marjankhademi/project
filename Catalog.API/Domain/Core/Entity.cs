namespace Catalog.API.Domain.Data.Core
{
    public abstract class Entity<Key> : IEntity<Key>
    {
        public Key Id { get; set; }
    }
}
