namespace AspNetCoreAppEFCore.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            // Here some lookup data may be provided...
        }
    }
}
