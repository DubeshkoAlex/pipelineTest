namespace Configuration
{
    using Microsoft.Extensions.Configuration;
    using System;

    public static class ConfigurationManager
    {
        public static T GetConfiguration<T>() where T : class
        {        
            var modelObject = Activator.CreateInstance<T>();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"settings.{Environment.GetEnvironmentVariable("stage",EnvironmentVariableTarget.Machine)}.json")
                .Build();
            configuration.GetSection(typeof(T).Name).Bind(modelObject);
            return modelObject;           
        }
    }
}
