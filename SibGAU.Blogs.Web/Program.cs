using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;
using SibGAU.Blogs.Infrastructure.DataAccess;
using SibGAU.Blogs.UseCases;
using SibGAU.Blogs.UseCases.Blogs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("AppDbContext");

if (connectionString is null)
{
    throw new ArgumentException("Connection string not provided", nameof(connectionString));
}

builder.Services.AddDbContext<IReadOnlyAppDbContext, AppDbContext>(options 
        => options.UseNpgsql(connectionString)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options => options.UseNpgsql(connectionString));

// Mediatr.
builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Temp).Assembly));

// Automapper.
builder.Services.AddAutoMapper(typeof(BlogsMappingProfile));
var app = builder.Build();

app.MapControllers();

app.Run();