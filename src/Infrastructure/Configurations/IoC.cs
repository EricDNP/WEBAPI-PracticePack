using Domain.Interfaces;
using Infrastructure.Models;
using Infrastructure.Context;
using Application.Interfaces;
using Infrastructure.Services;
using Infrastructure.Repositories;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Configurations.Extensions;

namespace Infrastructure.Configurations
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var encryptorSettings = new EncryptorSettings()
            {
                Key = configuration["EncryptionSettings:Key"],
                IV = configuration["EncryptionSettings:IV"]
            };

            services.AddSingleton(encryptorSettings);

            services.AddHttpContextAccessor();

            services.AddTransient<IPracticePackDbContext, PracticePackDbContext>();

            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IEncryptorService, EncryptorService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.ConfigureAuthentication(configuration);

            if (AppEnvironment.IsDevelopment())
            {
                var connectionString = configuration["AppSettings:DbConnection"];
                services.AddDbContext<PracticePackDbContext>(op => op.UseSqlServer(connectionString));
            }

            return services;
        }
    }
}
