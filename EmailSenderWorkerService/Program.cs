using EmailSenderWorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<UserCreatedEventEmailHandlerWorkerService>();

var host = builder.Build();
host.Run();
