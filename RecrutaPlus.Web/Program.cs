using RecrutaPlus.Web;
using RecrutaPlus.Web.Extensions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using RecrutaPlus.Infra.Data.Context;
using RecrutaPlus.Infra.Data.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

//Default
var dbProviderFactoryType = configuration.GetSection(AppSettingsWebConst.APPSETTINGS)
    .GetValue<string>(AppSettingsWebConst.DBPROVIDERFACTORY_TYPE);

var dbProviderFactoryName = configuration.GetSection(AppSettingsWebConst.APPSETTINGS)
    .GetValue<string>(AppSettingsWebConst.DBPROVIDERFACTORY_NAME);

var connectionStringDefault = configuration.GetConnectionString(
 configuration.GetSection(AppSettingsWebConst.APPSETTINGS)
 .GetValue<string>(AppSettingsWebConst.CONNECTIONSTRING_DEFAULT));

//DbContext
if (dbProviderFactoryType == AppSettingsWebConst.CONNECTIONSTRINGTYPE_MSSQL)
{
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStringDefault).UseLoggerFactory(AppDbContext.loggerFactoryDatabase));
}

if (dbProviderFactoryType == AppSettingsWebConst.CONNECTIONSTRINGTYPE_MYSQL)
{
    builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionStringDefault, ServerVersion.AutoDetect(connectionStringDefault)).UseLoggerFactory(AppDbContext.loggerFactoryDatabase));
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//DI
NativeInjectorConfig.RegisterServices(builder.Services);

//AutoMapper
builder.Services.AddAutoMapperSetup();

builder.Services.AddResponseCaching();
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.AddMemoryCache();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();



//app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching();
app.UseResponseCompression();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();