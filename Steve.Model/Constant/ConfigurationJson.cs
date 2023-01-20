using Newtonsoft.Json;

namespace Steve.Model
{
    public class ConfigurationJson
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public OpenAIConfiguration OpenAIConfiguration { get; set; }
    }

    public class ConnectionStrings
    {
        public static string DefaultConnection { get; set; }
    }

    public class Logging
    {
        public static LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public static string Default { get; set; }

        [JsonProperty("Microsoft.AspNetCore")]
        public static string MicrosoftAspNetCore { get; set; }
    }

    public class OpenAIConfiguration
    {
        public static string APIKey { get; set; }
        public static string PromptMessage { get; set; }
        public static string EndPoint { get; set; }
        public static string Model { get; set; }
    }
}
