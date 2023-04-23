using Go2Climb.API.Activities.Domain.Repositories;
using Go2Climb.API.Activities.Domain.Services;
using Go2Climb.API.Activities.Persistence.Repositories;
using Go2Climb.API.Activities.Services;
using Go2Climb.API.Agencies.Domain.Repositories;
using Go2Climb.API.Agencies.Domain.Services;
using Go2Climb.API.Agencies.Persistence.Repositories;
using Go2Climb.API.Agencies.Services;
using Go2Climb.API.Customers.Domain.Repositories;
using Go2Climb.API.Customers.Domain.Services;
using Go2Climb.API.Customers.Persistence.Repositories;
using Go2Climb.API.Customers.Services;
using Go2Climb.API.HiredServices.Domain.Repositories;
using Go2Climb.API.HiredServices.Domain.Services;
using Go2Climb.API.HiredServices.Persistence.Repositories;
using Go2Climb.API.HiredServices.Services;
using Go2Climb.API.Mapping;
using Go2Climb.API.Persistence.Contexts;
using Go2Climb.API.Reviews.Domain.Repositories;
using Go2Climb.API.Reviews.Domain.Services;
using Go2Climb.API.Reviews.Persistence.Repositories;
using Go2Climb.API.Reviews.Services;
using Go2Climb.API.Security.Authorization.Handlers.Implementations;
using Go2Climb.API.Security.Authorization.Handlers.Interfaces;
using Go2Climb.API.Security.Authorization.Middleware;
using Go2Climb.API.Security.Authorization.Settings;
using Go2Climb.API.Services.Domain.Repositories;
using Go2Climb.API.Services.Domain.Services;
using Go2Climb.API.Services.Persistence.Repositories;
using Go2Climb.API.Services.Services;
using Go2Climb.API.Shared.Domain.Repositories;
using Go2Climb.API.Shared.Domain.Services;
using Go2Climb.API.Shared.Persistence.Repositories;
using Go2Climb.API.Subscriptions.Domain.Repositories;
using Go2Climb.API.Subscriptions.Domain.Services;
using Go2Climb.API.Subscriptions.Persistence.Repositories;
using Go2Climb.API.Subscriptions.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Add CORS service
builder.Services.AddCors();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information
        
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Mecanillama API",
        Description = "Mecanillama RESTful API",
        TermsOfService = new Uri("https://mecanillama.github.io/Landing-Page/"),
        Contact = new OpenApiContact
        {
            Name = "Mecanillama.studio",
            Url = new Uri("https://mecanillama.github.io/Landing-Page/")
        },
        License = new OpenApiLicense
        {
            Name = "Mecanillama Resources License",
            Url = new Uri("https://mecanillama.github.io/Landing-Page/")
        }
    });
    options.EnableAnnotations();
});


// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//var connectionString = builder.Configuration.GetConnectionString("AzureDbConnection");

// Database Connection with Standard Level for Information and Errors

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

// Add lowercase routes

builder.Services.AddRouting(options => 
options.LowercaseUrls = true);

//Dependency Injection Rules
builder.Services.AddScoped<IJwtHandler, JwtHandler>();


builder.Services.AddScoped<IAgencyReviewService, AgencyReviewService>();
builder.Services.AddScoped<IAgencyReviewRepository, AgencyReviewsRepository>();

builder.Services.AddScoped<IServiceReviewRepository, ServiceReviewsRepository>();
builder.Services.AddScoped<IServiceReviewService, ServiceReviewService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IHiredServiceRepository, HiredServiceRepository>();
builder.Services.AddScoped<IHiredServiceService, HiredServiceService>();

builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IAgencyService, AgencyService>();

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityService, ActivityService>();

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();

builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

// Configure CORS

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure Error Handler Middleware

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure JWT Handling Middleware

app.UseMiddleware<JwtMiddleware>();


// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();