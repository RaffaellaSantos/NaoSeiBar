using Microsoft.EntityFrameworkCore;
using Nao_Sei_Bar_Backend.src.data;
using Nao_Sei_Bar_Backend.src.services;
using NSB_API.data.enums;
using NSB_API.services;

var builder = WebApplication.CreateBuilder(args);

// Configurando o DbContext para MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 39))));


// Add services to the container.
builder.Services.AddScoped<GestorService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<RhService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.UseAllOfForInheritance();
    c.UseOneOfForPolymorphism();
    c.SchemaFilter<EnumSchemaFilter>();
});


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
