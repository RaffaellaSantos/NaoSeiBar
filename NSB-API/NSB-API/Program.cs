

using Microsoft.EntityFrameworkCore;
using Nao_Sei_Bar_Backend.src.data;
using Nao_Sei_Bar_Backend.src.data.repository;
using Nao_Sei_Bar_Backend.src.services;
using Nao_Sei_Bar_Backend.src.services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Registre o AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<ILogin, LoginService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
