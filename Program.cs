
using InstantAPIs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppEncuestasAPI.Data;
using AppEncuestasAPI.Configurations;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppEncuestasDbContext>(options => {
    options.UseSqlServer("Server=192.168.30.10;Database=OPDMSitioWeb;TrustServerCertificate=True; user=OPDMSitioWeb;password=Aaaa1234");
});

builder.Services.AddIdentityCore<ApiUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppEncuestasDbContext>();

builder.Services.AddAutoMapper(typeof(MapperConfig));
// builder.Services.AddInstantAPIs();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors( options => {
    options.AddPolicy("AllowAll",
    b => b.AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapInstantAPIs<TramitesDbContext>();
app.UseHttpsRedirection();

app.UseCors("AllowAll");
// app.UseAuthorization();

app.MapControllers();

app.Run();

