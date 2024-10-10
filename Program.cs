using DotNetEnv;
using GestionDeProductosYServicios.Data;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;


//cargar las variables de entorno

Env.Load();

var DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
var DB_PORT = Environment.GetEnvironmentVariable("DB_PORT");
var DB_DATABASE = Environment.GetEnvironmentVariable("DB_DATABASE");
var DB_UID = Environment.GetEnvironmentVariable("DB_UID");
var DB_PASSWORD = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString =  $"server={DB_HOST};port={DB_PORT};database={DB_DATABASE};uid={DB_UID};password={DB_PASSWORD}";

//Crear builder de la aplicacion web
var builder = WebApplication.CreateBuilder(args);

//configurar acceso a la base de datos
builder.Services.AddDbContext<ApplicationDbcontext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("8.0.20-mysql")));


//configurando el entorno de la pagina
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>{
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseWelcomePage(new WelcomePageOptions{
    Path = "/"
});


//desarrollar el entorno de la pagina
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

