namespace Infrastructure.Configurations.Extensions
{
    public static class AppEnvironment
    {
        public static string Name => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        public static bool IsDevelopment() => Name.Equals("Development", StringComparison.OrdinalIgnoreCase);
        public static bool IsProduction() => Name.Equals("Production", StringComparison.OrdinalIgnoreCase);
    }
}
