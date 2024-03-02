using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductManagementService.Data;
using ProductManagementService.Repositories.General;
using ProductManagementService.Repositories.Implementations;
using ProductManagementService.Repositories.Interfaces;
using ProductManagementService.Services.Implementations;
using ProductManagementService.Services.Interfaces;
using ProductManagementService.UnitOfWork.Implementations;
using ProductManagementService.UnitOfWork.Interfaces;
using ProductManagementService.Validators;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Product Management API",
        Description = "An ASP.NET Core Web API for managing Stock Market Actions"
    });
});

builder.Services.AddControllers()
.AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Registring Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

// Registring Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<ICountryService, CountryService>();

// Registring Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registring Helper library services (AutoMapper and FluentValidation)
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<GroupRequestDTOValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
