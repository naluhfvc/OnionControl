using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddDbContext<OnionDbContext>(opt =>
    opt.UseSqlite(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin() 
              .WithMethods("GET", "POST")
              .AllowAnyHeader();
    });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OnionDbContext>();
    dbContext.Database.OpenConnection();
    dbContext.Database.EnsureCreated();
    OnionDbInitializer.Seed(dbContext); // Inicializa com dados
}


app.Run();

