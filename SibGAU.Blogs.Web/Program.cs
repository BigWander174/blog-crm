using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SibGAU.Blogs.Domain;
using SibGAU.Blogs.Infrastructure.Abstractions.DbContexts;
using SibGAU.Blogs.Infrastructure.DataAccess;
using SibGAU.Blogs.UseCases;
using SibGAU.Blogs.UseCases.Auth;
using SibGAU.Blogs.UseCases.Blogs;
using SibGAU.Blogs.UseCases.Common;
using SibGAU.Blogs.UseCases.Rubrics;
using SibGAU.Blogs.Web.Controllers;
using SibGAU.Blogs.Web.Middlewares;
using SibGAU.Blogs.Web.Startup.Initializers;
using SibGAU.Blogs.Web.Startup.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add admin credentials.
builder.Services.Configure<List<AdminCredentials>>(builder.Configuration.GetSection("Admins"));

// Database.
var connectionString = builder.Configuration.GetConnectionString("AppDbContext");
if (connectionString is null)
{
    throw new ArgumentException("Connection string not provided", nameof(connectionString));
}

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddAsyncInitializer<DatabaseInitializer>();

// Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Include XML comments in Swagger documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Add initializer for admin credentials to database.
builder.Services.AddAsyncInitializer<AdminsInitializer>();

// Exception middleware.
builder.Services.AddScoped<ExceptionMiddleware>();

// Cors policy.
builder.Services.AddCors(options =>
{
    options.AddPolicy("myClient", policyBuilder =>
    {
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyOrigin();
    } );
});

// Jwt settings.
const string jwtSettingsSection = "JwtSettings";
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(jwtSettingsSection));

var jwtSettings = builder.Configuration.GetSection(jwtSettingsSection).Get<JwtSettings>();
if (jwtSettings is null)
{
    throw new ArgumentException("Something went wrong by binding jwtSettings section to DI");
}

// Jwt token generator.
builder.Services.AddScoped<JwtTokenGenerator>();

// Authentication, Authorization
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
            };
        });
builder.Services.AddAuthorization();

// Configure identity.
builder.Services.AddIdentity<Author, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Mediatr.
builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Temp).Assembly));

// Automapper.
builder.Services.AddAutoMapper(typeof(BlogsMappingProfile), 
    typeof(ControllersMappingProfile),
    typeof(AuthorMappingProfile),
    typeof(RubricsMappingProfile));

var app = builder.Build();

app.UseCors("myClient");

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

await app.InitAsync();
await app.RunAsync();