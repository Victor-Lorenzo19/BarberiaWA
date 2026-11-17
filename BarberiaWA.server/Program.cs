using BarberiaWA.BD.Datos;
using BarberiaWA.Repositorio.Repositorios;
using Microsoft.EntityFrameworkCore;
using ClienteEntidad = BarberiaWA.BD.Datos.Entity.Cliente;

var builder = WebApplication.CreateBuilder(args);

#region Servicios

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "La conexión a la base de datos no funciona.");

builder.Services.AddDbContext<AppDbcontext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IServicioRepositorio, ServicioRepositorio>();
builder.Services.AddScoped<ITurnoRepositorio, TurnoRepositorio>();

#endregion

var app = builder.Build();

#region Middleware

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

#endregion

app.Run();