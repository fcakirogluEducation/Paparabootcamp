using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TokenAuth.Repository.Models;

namespace TokenAuth.Service.BackgroundServices
{
    public class UserEmailSenderBackgroundService(IServiceProvider serviceProvider) : BackgroundService
    {
        // private readonly IServiceProvider _serviceProvider = serviceProvider;

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }


        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var day = DateTime.Now.Day;
                if (DateTime.Now.Day == 7)
                {
                    //hangi hangi gününde çalışacak
                }


                // Do something here

                using (var scope = serviceProvider.CreateScope())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                    var users = userManager.Users.ToList();

                    // user foreach
                    foreach (var user in users)
                    {
                        if (user.EmailConfirmed == false)
                        {
                            //Her 12 saate kullanıcılara kampanya email gönderir.
                            // await EmailSender.SendEmailAsync(user.Email);
                        }
                    }
                }

                //12 saat arayla çalışacak
                await Task.Delay(1000 * 60 * 60 * 12, stoppingToken);
            }
        }
    }
}