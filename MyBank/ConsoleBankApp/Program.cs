using ConsoleBankApp.Core.Implementation;
using ConsoleBankApp.Data;
using ConsoleBankApp.Core.Interface;
using ConsoleBankApp;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICreateAccount, CreateAccount>();
        services.AddScoped<IValidateService, ValidateServices>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IBankMenu, BankMenu>();
        services.AddSingleton<UserService>();

        var serviceProvider = services.BuildServiceProvider();
        var userInterface = serviceProvider.GetRequiredService<UserService>();
        userInterface.Run();
    }
}