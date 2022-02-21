namespace Catalog.API.Domain.Data.Core
{
    public interface IEntity<Key>
    {
        Key Id { get; set; }//int, string, guid
    }
}
