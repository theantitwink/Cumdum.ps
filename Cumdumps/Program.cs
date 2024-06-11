using Cumdumps.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Serilog;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    (hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration
            .ReadFrom.Configuration(hostingContext.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console();
    }
);

// Add services to the container.
// builder
//     .Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//     .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));
// builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

builder.Services.AddScoped<Dgmjr.Blazor.Components.CookiesJS>();
builder.Services.AddProgressiveWebApp();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
