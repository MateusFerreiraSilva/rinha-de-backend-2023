using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using rinha_de_backend_2023.Models;
using rinha_de_backend_2023.Data;
using rinha_de_backend_2023.Data.Repositories;
using rinha_de_backend_2023.Data.Repositories.Interfaces;
using rinha_de_backend_2023.Services;
using rinha_de_backend_2023.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

#region Add Database

builder.Services.AddDbContext<RinhaDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString(Constants.DATEBASE_DEFAULT_CONNECTION);
        options.UseNpgsql(
            connectionString
            // x => x.MigrationsAssembly(Constants.PROJECT_DATA_NAME)
        );
    }
);

#endregion

#region Adding Services

builder.Services.AddScoped<IPessoaService, PessoaService>();

#endregion

#region Adding Repositories

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

#endregion

#region Configuring The Swagger

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Rinha de Backend 2023",
        Description = "API - Rinha de Backend 2023",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Mateus Ferreira Silva",
            Url = new Uri("https://github.com/MateusFerreiraSilva")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    
    // adding xml comments
    foreach (var filePath in System.IO.Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!), "*.xml"))
    {
        try
        {
            options.IncludeXmlComments(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My service");
    c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
});

#endregion

#region Applying Migrations

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<RinhaDbContext>();

if (context.Database.GetPendingMigrations().Any()) {
    context.Database.Migrate();
}

#endregion

app.MapControllers();

app.Run();