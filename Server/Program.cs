using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using OnionServer.Application.Interfaces;
using OnionServer.Application.Mapping;
using OnionServer.Application.Services;
using OnionServer.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddDbContext<OnionDbContext>(opt =>
    opt.UseSqlite(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(OnionProfile));

builder.Services.AddScoped<IPlanilhaService, PlanilhaService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IPedidoProdutoService, PedidoProdutoService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IPedidoVendasService, PedidoVendasService>();

// Adicione o HttpClientFactory
builder.Services.AddHttpClient<IEnderecoService, EnderecoService>(client =>
{
    client.BaseAddress = new Uri("https://viacep.com.br/ws/");
});

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

