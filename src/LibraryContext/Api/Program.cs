using Inanna.LibraryContext.Api.Services;
using Inanna.LibraryContext.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<LibraryDbContext>((provider, optionsBuilder) =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    string connectionString = configuration.GetConnectionString("Database") ?? throw new NullReferenceException();
    optionsBuilder.UseSqlServer(connectionString);
});

var app = builder.Build();


using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
