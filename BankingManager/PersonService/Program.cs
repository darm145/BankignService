using Microsoft.EntityFrameworkCore;
using PersonService.Core.Repositories;
using PersonService.Core.Services;
using PersonService.Infrastructure.Data;
using PersonService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PersonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonDbConnection"), b => b.MigrationsAssembly("PersonService.Api")));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddCors(options => { options.AddPolicy(name: "AllowAll", policy => { policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod(); }); });
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}
    
// Configure the HTTP request pipeline.
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
