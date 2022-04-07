
using FluentValidation.AspNetCore;
using FuncionarioApi.Context;
using FuncionarioApi.Middlewares.Exceptions;
using FuncionarioApi.Middlewares.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConnections();
builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
}).ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
            new BadRequestObjectResult(context.ModelState)
            {
                ContentTypes =
                {
                    Application.Json
                }
            };
    });


builder.Services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidadorFuncionario>());


var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DBFuncionarioContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("Default")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapControllers();
app.MapRazorPages();

app.Run();