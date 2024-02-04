using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace TokenAuth.Service.BackgroundServices
{
    public class ProductCountEmailSenderBackgroundService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //Console.WriteLine("ProductCountEmailSender çalıştı");
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}