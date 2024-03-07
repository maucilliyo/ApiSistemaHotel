using Datos;
using Datos.Interfaces;
using Datos.Repositorios;
using Negocio;
using Negocio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configuración global para que Dapper pueda pasar de snake_case a PascalCase para mapear automaticamente
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
//regritro de pruebas de conexion 
builder.Services.AddTransient<TestConexion>(); // Registra TestConexion de la capa de dato
builder.Services.AddTransient<N_TestConexion>(); // Registra N_TestConexion
builder.Services.AddSingleton<ConexionMogo>();
builder.Services.AddSingleton<ConexionSql>();
builder.Services.AddTransient<BitacoraAccionesRepository>();
//registrando 
builder.Services.AddTransient<INegocioUsuario, NegocioUsuario>();
builder.Services.AddTransient<IUsuariosRepository, UsuariosRepository>();

builder.Services.AddTransient<INegocioReserva, NegocioReserva>();
builder.Services.AddTransient<IReservaRepository, ReservaRepository>();

builder.Services.AddTransient<INegocioHabitacion, NegocioHabitacion>();
builder.Services.AddTransient<IHabitacionRepository, HabitacionRepository>();

builder.Services.AddTransient<INegocioFactura, NegocioFactura>();
builder.Services.AddTransient<IFacturaRepository, FacturaRepository>();

builder.Services.AddTransient<INegocioRole, NegocioRole>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();

builder.Services.AddCors(opciones => {
    opciones.AddPolicy("nuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("nuevaPolitica");
app.MapControllers();

app.Run();
