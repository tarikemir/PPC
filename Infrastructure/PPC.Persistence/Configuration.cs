using Microsoft.Extensions.Configuration;

namespace PPC.Persistence
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();

                string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Infrastructure\\PPC.Persistence";

                configurationManager.SetBasePath(path);

                configurationManager.AddJsonFile("PrivateInformations.json");

                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }

    }
}