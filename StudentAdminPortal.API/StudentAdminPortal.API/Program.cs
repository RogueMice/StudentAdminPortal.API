using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using StudentAdminPortal.API.Data.Context;
using StudentAdminPortal.API.Service.Implement;
using StudentAdminPortal.API.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("angularApplication", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .WithMethods("GET", "POST", "PUT", "DELETE","PATCH")
               .WithExposedHeaders("*");
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//add validation
builder.Services.AddFluentValidationAutoValidation(); 
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

//add db context
builder.Services.AddDbContext<StudentAdminContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminPortalDb"));
});

//inject
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IImageService, ImageService>();


//add automapper
builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(Program).Assembly));

var app = builder.Build();

//enable CORS
app.UseCors("angularApplication");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//add static image
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
    RequestPath = "/Resources"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
