using Cinecrate.Server.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Server.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();
builder.Services.AddRazorPages();

// Swagger documentation at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cinecrate", Version = "v1" }); });

// Determine file type to return the correct content media type
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

// Define Database Context
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_SE641");
builder.Services.AddDbContext<MovieInfoContext>(DbContextOptions => DbContextOptions.UseSqlServer(connectionString));

// Add Movie Service
builder.Services.AddScoped<IMovieService, MovieService>();

// Add AutoMapper which is being used to map the database context models to data transfer objects.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#if DEBUG
// Load debug services here
#else
// Load production services here
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SE 694 Advanced Data Base System v1"));
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
