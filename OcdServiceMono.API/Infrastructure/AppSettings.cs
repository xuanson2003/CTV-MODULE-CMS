using Serilog.Events;
using System.Collections.Generic;

namespace OcdServiceMono.API.Infrastructure
{
    public class AppSettings
    {
        public string ReadConnectionString { get; set; }
        public string WriteConnectionString { get; set; }
        public IdentityServerAuthentication IdentityServerAuthentication { get; set; }
        public GoogleAuthentication GoogleAuthentication { get; set; }
        public FacebookAuthentication FacebookAuthentication { get; set; }
        public FileServerConfiguration FileServerConfiguration { get; set; }
        public RabbitMQConfig RabbitMQConfig { get; set; }
        public SSOConfig SSOConfig { get; set; }
        public MailConfig MailConfig { get; set; }
        public LoggingOptions Logging { get; set; }
    }
    public class RabbitMQConfig
    {
        public string Host { get; set; }
        public ushort Port { get; set; }
        public string VirtualHost { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
    public class SSOConfig
    {

    }
    public class MailConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class FileServerConfiguration
    {
        public string SavePath { get; set; }
    }
    public class GoogleAuthentication
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
    public class FacebookAuthentication
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
    public class IdentityServerAuthentication
    {
        public string Authority { get; set; }
        public string ApiName { get; set; }
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double AccessTokenExpiration { get; set; }
        public double RefreshTokenExpiration { get; set; }
        public bool RequireHttpsMetadata { get; set; }
    }
    public class LoggingOptions
    {
        public Dictionary<string, string> LogLevel { get; set; }

        public FileOptions File { get; set; }
    }
    public class FileOptions
    {
        public LogEventLevel MinimumLogEventLevel { get; set; }
    }
}
