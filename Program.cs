using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SvSupportSales.Commons;
using SvSupportSales.Entities;
using SvSupportSales.Repositories;
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
builder.Services.AddSwaggerGen();

//localization
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

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


/*
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
app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
