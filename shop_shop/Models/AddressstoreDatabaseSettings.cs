namespace shop_shop.Models
{
    public class AddresstoreDatabaseSettings : IAddressstoreDatabaseSettings
    {
        public string AddressCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAddressstoreDatabaseSettings
    {
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}