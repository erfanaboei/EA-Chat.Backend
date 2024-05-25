using System.Text;
using EA_Chat.Application.Extensions;
using EA_Chat.Data.Context;
using EA_Chat.IOC.Dependencies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AddServices

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.RegisterServices();

#endregion

#region Add Cors

builder.Services.AddCors();

#endregion

#region Add Authentication

builder.Services.AddIdentityService(builder.Configuration);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Use Cors

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

#endregion

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();