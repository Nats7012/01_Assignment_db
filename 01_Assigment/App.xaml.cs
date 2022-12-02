using _01_Assigment.Data;
using _01_Assigment.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _01_Assigment
{
    public partial class App : Application
    {
        public static IHost? app { get; private set; }
        public App()
        {
            app = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddScoped<MainWindow>();
                services.AddDbContext<SqlContext>(x => x.UseSqlServer(@"C:\USERS\VERDE\ONEDRIVE\SKRIVBORD\CMS22\DATABASTEKNIK\WPFAPP\01_ASSIGMENT\CONTEXT\LOCAL_WPF_SQL_DB.MDF"));
                services.AddScoped<ProductService>();
                services.AddScoped<CustomerService>();
                services.AddScoped<OrderService>();

            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await app!.StartAsync();
            var MainWindow = app.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
