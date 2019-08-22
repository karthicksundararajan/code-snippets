public class SampleDbContext : DbContext
{
    public SampleDbContext()
        : base(EFConnectionString)
    {
        Configuration.ProxyCreationEnabled = false;
        Configuration.LazyLoadingEnabled = false;
    }

    public static string ConnectionString
    {
        get
        {
            string connectionString = string.Empty;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
            }
            catch
            {
            }
            return connectionString;
        }
    }

    public static string EFConnectionString
    {
        get
        {
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = ConnectionString,
                Metadata = "res://*/Entities.Model.csdl|res://*/Entities.Model.ssdl|res://*/Entities.Model.msl"
            };
            return builder.ConnectionString;
        }
    }
}
