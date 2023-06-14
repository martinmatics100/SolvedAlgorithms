using BANK_CONSOLE_APP.Implementations;
using BANK_CONSOLE_APP.Interface;
using BANK_CONSOLE_APP.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Principal;

namespace BANK_CONSOLE_APP
{
    public class Program
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
            services.AddScoped<IRegistration, Registration>(/*provider =>
            {
                var filePath = "accounts.csv";
                var printer = provider.GetRequiredService<IPrinter>();
                //var registration = provider.GetRequiredService<IRegistration>();
                var validation = provider.GetRequiredService<IValidation>();
                //var account = provider.GetRequiredService<IAccount>();
                return new Registration(filePath, printer, validation);
            }*/
            
            );
        }
    }
}