using DataAccess.Data;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleNetCore
{
    class MyServices : BackgroundService
    {
        private readonly IEmployeeData data;

        public MyServices(IEmployeeData data)
        {
            this.data = data;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("ExecuteAsync");
            var result = await data.GetEmployeeById(22);
            Console.WriteLine(result.Name);
            var emps = await data.GetEmployees();
            foreach (var item in emps)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
