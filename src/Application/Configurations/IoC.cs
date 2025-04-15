using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Addresses.ManageAddress;
using Application.UseCases.Addresses.RemoveAddress;
using Application.UseCases.Addresses.SearchAddress;
using Application.UseCases.Categories.ManageCategory;
using Application.UseCases.Categories.RemoveCategory;
using Application.UseCases.Categories.SearchCategory;
using Application.UseCases.Orders.ManageOrder;
using Application.UseCases.Orders.RemoveOrder;
using Application.UseCases.Orders.SearchOrder;
using Application.UseCases.Payments.ManagePayment;
using Application.UseCases.Payments.SearchPayment;
using Application.UseCases.Payments.RemovePayment;
using Application.UseCases.OrderItems.ManageOrderItem;
using Application.UseCases.OrderItems.SearchOrderItem;
using Application.UseCases.OrderItems.RemoveOrderItem;
using Application.UseCases.Products.ManageProduct;
using Application.UseCases.Products.SearchProduct;
using Application.UseCases.Products.RemoveProduct;
using Application.UseCases.Users.LoginUser;
using Application.UseCases.Users.ManageUser;
using Application.UseCases.Users.SearchUser;
using Application.UseCases.Users.RemoveUser;
using Application.UseCases.Users.RegisterUser;

namespace Application.Configurations
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IManageAddressUseCase, ManageAddressUseCase>();
            services.AddTransient<ISearchAddressUseCase, SearchAddressUseCase>();
            services.AddTransient<IRemoveAddressUseCase, RemoveAddressUseCase>();

            services.AddTransient<IManageCategoryUseCase, ManageCategoryUseCase>();
            services.AddTransient<ISearchCategoryUseCase, SearchCategoryUseCase>();
            services.AddTransient<IRemoveCategoryUseCase, RemoveCategoryUseCase>();
            
            services.AddTransient<IManageOrderUseCase, ManageOrderUseCase>();
            services.AddTransient<ISearchOrderUseCase, SearchOrderUseCase>();
            services.AddTransient<IRemoveOrderUseCase, RemoveOrderUseCase>();
            
            services.AddTransient<IManageOrderItemUseCase, ManageOrderItemUseCase>();
            services.AddTransient<ISearchOrderItemUseCase, SearchOrderItemUseCase>();
            services.AddTransient<IRemoveOrderItemUseCase, RemoveOrderItemUseCase>();
            
            services.AddTransient<IManagePaymentUseCase, ManagePaymentUseCase>();
            services.AddTransient<ISearchPaymentUseCase, SearchPaymentUseCase>();
            services.AddTransient<IRemovePaymentUseCase, RemovePaymentUseCase>();

            services.AddTransient<IManageProductUseCase, ManageProductUseCase>();
            services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
            services.AddTransient<IRemoveProductUseCase, RemoveProductUseCase>();
            
            services.AddTransient<ILoginUserUseCase, LoginUserUseCase>();
            services.AddTransient<IManageUserUseCase, ManageUserUseCase>();
            services.AddTransient<ISearchUserUseCase, SearchUserUseCase>();
            services.AddTransient<IRemoveUserUseCase, RemoveUserUseCase>();
            services.AddTransient<IRegisterUserUseCase, RegisterUserUseCase>();

            return services;
        }
    }
}
