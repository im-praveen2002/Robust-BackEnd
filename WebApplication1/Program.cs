using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication1;
using WebApplication1.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

# region Configure DB

var connectionstring = builder.Configuration.GetConnectionString("defaultconnection");

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionstring));


# endregion


# region Configre Automapper

builder.Services.AddAutoMapper(typeof(MappingProfile));

# endregion


var app = builder.Build();


# region Configure CORS

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

# endregion


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
