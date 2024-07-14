using DistributedCache.Data;
using DistributedCache.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddServices(configuration);

var app = builder.Build();

// Seed Database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    dbContext.Database.Migrate();
}


app.AddApplication();

app.MapControllers();
app.Run();
