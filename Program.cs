using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SvSupportSales.Commons;
using SvSupportSales.Entities;
using SvSupportSales.Repositories;
using SvSupportSales.Resources;
using SvSupportSales.Services;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
builder.Services.AddDbContext<DataContext>(options => options
.UseNpgsql(connectionString)
.UseCamelCaseNamingConvention()
.UseLoggerFactory(LoggerFactory.Create(bd => bd.AddConsole()))
.EnableSensitiveDataLogging());

builder.Services.AddScoped<IUmService, UmService>();
builder.Services.AddScoped<ISalesProfileService, SalesProfileService>();
builder.Services.AddScoped<IMasterService, MasterService>();

builder.Services.AddTransient<IUmRepository, UmRepository>();
builder.Services.AddTransient<ISalesProfileRepository, SalesProfileRepository>();
builder.Services.AddTransient<IMasterRepository, MasterRepository>();

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "SvSupportSales V1",
            Version = "v1"
        }
     );
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(System.AppContext.BaseDirectory, xmlFilename);
    c.IncludeXmlComments(filePath);
});

// Data Annotation Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName!);
            return factory.Create("SharedResource", assemblyName.Name!);
        };
    });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("th")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

/* ของพี่เก๋
var supportedCultures = new[] { "en", "th" };
var localizationOptions = new RequestLocalizationOptions() { ApplyCurrentCultureToResponseHeaders = true }.SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var requestLocalizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(requestLocalizationOptions!.Value);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
