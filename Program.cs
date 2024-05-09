
global using RPG__API.Services.Interface;
global using RPG__API.DTOs.Character;
using RPG__API.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Contections string
builder.Services.AddDbContext<ApplicationDBContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));


builder.Services.AddControllers(); //Services for Controllers
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly); //Services for automaping

builder.Services.AddScoped<ICharacterService, CharacterService>(); //Services for character
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
