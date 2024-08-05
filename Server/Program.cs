using Microsoft.EntityFrameworkCore;
using OnionServer.Application.Interfaces;
using OnionServer.Application.Services;
using OnionServer.Infrastructure.Data;
using OnionServer.Infrastructure.Interfaces;
using OnionServer.Infrastructure.Repositories;
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

builder.Services.AddScoped<IPlanilhaService, PlanilhaService>();

// repositories
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPedidoProdutoRepository, PedidoProdutoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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

