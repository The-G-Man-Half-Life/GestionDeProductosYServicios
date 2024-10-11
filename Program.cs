using DotNetEnv;
using GestionDeProductosYServicios.Data;
using GestionDeProductosYServicios.Repositories.Interfaces;
using GestionDeProductosYServicios.Services;
using GestionDeShipment_ProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


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

//espacio para las encriptaciones jwt

//registrar repositorios y servicios
builder.Services.AddScoped<ICarrierRepository, CarrierServices>();
builder.Services.AddScoped<CarrierServices>();
builder.Services.AddScoped<ICategoryRepository, CategoryServices>();
builder.Services.AddScoped<CategoryServices>();
builder.Services.AddScoped<IClientRepository, ClientServices>();
builder.Services.AddScoped<ClientServices>();
builder.Services.AddScoped<IShipmentRepository, ShipmentServices>();
builder.Services.AddScoped<ShipmentServices>();
builder.Services.AddScoped<IProductRepository, ProductServices>();
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<IShipment_ProductRepository, Shipment_ProductServices>();
builder.Services.AddScoped<Shipment_ProductServices>();

//configurando el entorno de la pagina
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestion De Productos y servicios", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Gestion De Productos y servicios", Version = "v2" });
    c.EnableAnnotations();

    // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    // {
    //     Description = "JWT Authorization header usando el esquema Bearer. Ejemplo: \"Bearer {token}\"",
    //     Name = "Authorization",
    //     In = ParameterLocation.Header,
    //     Type = SecuritySchemeType.Http,
    //     Scheme = "Bearer"
    // });

    // c.AddSecurityRequirement(new OpenApiSecurityRequirement
    // {
    //     {
    //         new OpenApiSecurityScheme
    //         {
    //             Reference = new OpenApiReference
    //             {
    //                 Type = ReferenceType.SecurityScheme,
    //                 Id = "Bearer"
    //             }
    //         },
    //         new string[] {}
    //     }
    // });
});

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

