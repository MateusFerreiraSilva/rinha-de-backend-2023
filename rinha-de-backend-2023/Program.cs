using System.Reflection;
using Medallion.Threading.Postgres;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using rinha_de_backend_2023.Models;
using rinha_de_backend_2023.Data;
using rinha_de_backend_2023.Data.Repositories;
using rinha_de_backend_2023.Data.Repositories.Interfaces;
using rinha_de_backend_2023.Services;
using rinha_de_backend_2023.Services.Interfaces;
using rinha_de_backend_2023.Utils;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });

#region Add Database

var connectionString = builder.Configuration.GetConnectionString(Constants.DATEBASE_DEFAULT_CONNECTION);

builder.Services.AddDbContext<RinhaDbContext>(options =>
    {
        options
            .UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure();
                }
            )
            .UseValidationCheckConstraints();
    }
);

#endregion

#region Adding Repositories

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

#endregion

#region Adding Services

builder.Services.AddSingleton<IContagemPessoasService, ContagemPessoasService>();
builder.Services.AddScoped<IPessoaService, PessoaService>();

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
        Contact = new OpenApiContact
        {
            Name = "Mateus Ferreira Silva",
            Url = new Uri("https://github.com/MateusFerreiraSilva")
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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rinha de backend 2023 API");
    c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
});

#endregion

#region Creating Database

var @lock = new PostgresDistributedLock(new PostgresAdvisoryLockKey("MyLock", allowHashing: true), connectionString);

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

await using (var context = services.GetRequiredService<RinhaDbContext>())
{
    await using (await @lock.AcquireAsync())
    {
        var hasDatabaseBeenCreated = await context.Database.EnsureCreatedAsync();
        
        Console.WriteLine($"Database has been created by this application: {hasDatabaseBeenCreated}");
    }
}

#endregion

app.MapControllers();

app.Run();