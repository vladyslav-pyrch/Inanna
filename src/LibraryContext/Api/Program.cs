using Inanna.LibraryContext.Api.Services;
using Inanna.LibraryContext.Application;
using Inanna.LibraryContext.Infrastructure;
using Inanna.LibraryContext.Infrastructure.DataAccess.Mangas.Projections;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });
    
    string file = Path.Combine(AppContext.BaseDirectory, "Inanna.LibraryContext.Api.xml");
    c.IncludeXmlComments(file);
    c.IncludeGrpcXmlComments(file);
});
builder.Services.AddInfrastructureModule();
builder.Services.AddApplicationModule();

WebApplication app = builder.Build();

using (IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<MangasProjectionsDbContext>();
    context.Database.EnsureCreated();
}

app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

// Configure the HTTP request pipeline.
app.MapGrpcService<MangaService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
