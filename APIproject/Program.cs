using APIproject.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://0.0.0.0:7126"); //API ın ağdaki diğer cihazlarda da erişmesine izin veriyor

builder.Services.AddControllers(); // Controllerı ekliyor

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))); // Database e bağlanıyor DefaultConnection appsettingsten alıyor

//Swagger için
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run(); ;
