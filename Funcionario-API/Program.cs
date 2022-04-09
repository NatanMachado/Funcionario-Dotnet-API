
using FluentValidation.AspNetCore;
using Funcionario_API.Middlewares.Exceptions;
using FuncionarioApi.Context;
using FuncionarioApi.Middlewares.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConnections();
builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidadorFuncionario>());

var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DBFuncionarioContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("Default")));

var app = builder.Build();
app.UseMiddleware(typeof(ErrorHandlingMiddleware));
app.MapControllers();
app.Run();