using Microsoft.EntityFrameworkCore;
using AccountingService.Core.Repositories;
using AccountingService.Core.Services;
using AccountingService.Infrastructure.Data;
using AccountingService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AccountingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AccountingDbConnection"),b => b.MigrationsAssembly("AccountingService.Api")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICuentaRepository,CuentaRepository>();
builder.Services.AddScoped<IMovimientoRepository, MovimientoRepository>();
builder.Services.AddScoped<IReporteService, ReporteService>();
builder.Services.AddScoped<ICuentaService, CuentaService>();
builder.Services.AddScoped<IMovimientoService, MovimientoService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
