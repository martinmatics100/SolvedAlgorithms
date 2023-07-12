using MyBankApp.Implementations;
using MyBankApp.Interface;
using MyBankApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MyBankApp
{
    internal class Program
    {
        //private static Registration registered;

        public static void Main(string[] args)
        {
            //var registration = new Registration();
            //registration.RegisterFunction();

            var services = new ServiceCollection();
            ConfigureServices(services);

            services
                .BuildServiceProvider()
                .GetService<IRegistration>()
                .Instruction();
        }

        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IPrinter, Printer>();
            services.AddScoped<IValidation, Validation>();
            //services.AddScoped<IDisplayUI, DisplayUI>();
            //services.AddTransient<IBank, Banks>(); // Register the Banks class itself as the implementation for IBank
            //services.AddScoped<IAccount, Account>();
            services.AddSingleton<IRegistration, Registration>();
        }
    }
}