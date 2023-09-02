using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;
using SibGAU.Blogs.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDbContext");

if (connectionString is null)
{
    throw new ArgumentException("Connection string not provided", nameof(connectionString));
}

builder.Services.AddDbContext<IReadOnlyAppDbContext, AppDbContext>(options 
        => options.UseNpgsql(connectionString)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options => options.UseNpgsql(connectionString));
var app = builder.Build();

app.Run();