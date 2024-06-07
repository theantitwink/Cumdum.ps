using Azure.Identity;
using Cumdumps.Server.Components;
using Microsoft.ApplicationInsights.WindowsServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole;
using Serilog.Sinks.SystemConsole.Themes;
using MsidConstants = Microsoft.Identity.Web.Constants;
using TokenValidatedContext = Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Cumdumps.Server.Controllers.AccountController>();

builder.Host.UseSerilog(
    (hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration
            .ReadFrom.Configuration(hostingContext.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console();
    }
);

#if AZURE
builder
    .Services.AddDataProtection()
    .SetApplicationName(nameof(Cumdumps))
    .SetDefaultKeyLifetime(TimeSpan.FromDays(30))
    .PersistKeysToAzureBlobStorage(
        new Uri("https://cumdumps.blob.core.windows.net/keyrings/master.xml"),
        new DefaultAzureCredential()
    )
/*.ProtectKeysWithAzureKeyVault(
    new Uri("https://myvault.vault.azure.net/keys/MasterEncryptionKey"),
    new DefaultAzureCredential()
)*/;
#endif

builder.Services.AddBlazorBootstrap();

builder.Services.ConfigureAll<MicrosoftIdentityOptions>(options =>
    options.Events.OnTokenValidated += GetTwitterUsername
);

// Add services to the container.

builder
    .Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddProgressiveWebApp();
builder.Services.AddMicrosoftIdentityConsentHandler();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();

app.Run();

async Task GetTwitterUsername(TokenValidatedContext context)
{
    using var scope = context.HttpContext.RequestServices.CreateScope();

    var logger = scope.ServiceProvider.GetRequiredService<
        ILogger<MicrosoftGraphAutoConfigurator>
    >();

    var userGuid = context.Principal.GetObjectId();

    var services = scope.ServiceProvider;
    var graphClientOptions = services.GetRequiredService<IOptions<AzureAdB2CGraphOptions>>().Value;
    var graphClient = services.GetRequiredService<GraphServiceClient>();

    var graphUser = await graphClient.Users[userGuid].Request().GetAsync();
}
