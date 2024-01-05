using Microsoft.EntityFrameworkCore;
using Pedido.Infra.Contexts;
using Pedido.Infra.Implementations;
using Pedido.Infra.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PedidoContext>(options => 
{
  var mysqlConnection = builder.Configuration.GetConnectionString("MysqlConnection");
  options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection));
});
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(option => 
{
  option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.MapControllers();

app.Run();
