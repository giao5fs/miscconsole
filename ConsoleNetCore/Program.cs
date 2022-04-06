using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using DataAccess.Data;
using DataAccess.DbAccess;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateHostBuilder(args).Build().Run();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddCommandLine(args);
                })
                .ConfigureLogging(o => { })
                .ConfigureServices(services =>
                {
                    services.AddHostedService<MyServices>();
                    Console.WriteLine("Enter MyServices");
                })
                .ConfigureContainer<ContainerBuilder>((context, builder) =>
                {
                    builder.RegisterType<EmployeeData>().As<IEmployeeData>().InstancePerLifetimeScope();

                    builder.RegisterType<SqlDataAccess>().As<ISqlDataAccess>().InstancePerLifetimeScope();

                });
    }
}
