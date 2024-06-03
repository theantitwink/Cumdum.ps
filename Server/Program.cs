using Microsoft.Extensions.DependencyInjection;

using Serilog;

using Short.IO.Web.Server.Components;

using MsidConstants = Microsoft.Identity.Web.Constants;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>();

builder.Host.UseSerilog(
    (hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom
            .Configuration(hostingContext.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console();
    }
);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind(MsidConstants.AzureAdB2C, options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/User.Read");
    options.ProviderOptions.DefaultAccessTokenScopes.Add(
        "https://graph.microsoft.com/User.ReadBasic.All"
    );
    options.ProviderOptions.DefaultAccessTokenScopes.Add(
        "https://graph.microsoft.com/User.ReadWrite"
    );
    options.ProviderOptions.DefaultAccessTokenScopes.Add(
        "https://graph.microsoft.com/User.ReadWrite.All"
    );
    options.ProviderOptions.DefaultAccessTokenScopes.Add(
        "https://graph.microsoft.com/User.Read.All"
    );
    options.ProviderOptions.DefaultAccessTokenScopes.Add(
        "https://graph.microsoft.com/User.ReadWrite.All"
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
