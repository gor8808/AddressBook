namespace AddressBook.DataAccessLayer
{
    public class DataStorageConfiguration
    {
        public string ConnectionString { get; set; }

        public DataStorageConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
