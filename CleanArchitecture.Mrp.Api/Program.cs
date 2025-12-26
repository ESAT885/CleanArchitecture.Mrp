using CleanArchitecture.Mrp.Api.Extensions;
using CleanArchitecture.Mrp.Api.Middlewares;
using CleanArchitecture.Mrp.Application;
using CleanArchitecture.Mrp.Application.Abstractions.Repositories;
using CleanArchitecture.Mrp.Application.Abstractions.Security;
using CleanArchitecture.Mrp.Application.Features.Auth.Commands.Login;
using CleanArchitecture.Mrp.Infrastructure;
using CleanArchitecture.Mrp.Infrastructure.Data;
using CleanArchitecture.Mrp.Infrastructure.Repository;
using CleanArchitecture.Mrp.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddApplication();
//builder.Services.AddCustomApiBehavior();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDatabase")));

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddInfrastructure(builder.Configuration);



var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
