using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;
using SibGAU.Blogs.Infrastructure.DataAccess;
using SibGAU.Blogs.UseCases;
using SibGAU.Blogs.UseCases.Blogs;
using SibGAU.Blogs.Web.Middlewares;
using SibGAU.Blogs.Web.Startup;

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
builder.Services.AddAsyncInitializer<DatabaseInitializer>();

// Exception middleware.
builder.Services.AddScoped<ExceptionMiddleware>();

builder.Services.AddIdentity<Author, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// Mediatr.
builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Temp).Assembly));

// Automapper.
builder.Services.AddAutoMapper(typeof(BlogsMappingProfile));
var app = builder.Build();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

await app.InitAsync();
await app.RunAsync();