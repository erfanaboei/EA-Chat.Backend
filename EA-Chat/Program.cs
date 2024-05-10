using EA_Chat.Data.Context;
using EA_Chat.IOC.Dependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AddServices

builder.Services.RegisterServices();

#endregion

#region AddDbContext

builder.Services.AddDbContext<EAChatContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EA-Chat-ConnectionString"));
});

#endregion

#region Add Cors

builder.Services.AddCors();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

#region Use Cors

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

#endregion

app.MapControllers();

app.Run();