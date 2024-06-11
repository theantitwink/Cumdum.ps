/*
 * SocialIdentityConfigurator.cs
 *     Created: 2024-06-10T20:41:22-04:00
 *    Modified: 2024-06-10T20:41:22-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Cumdumps.Identity;

using Microsoft.AspNetCore.Authentication.OpenIdConnect;

public class SocialIdentityConfigurator
    : ConfiguratorBase<SocialIdentityConfigurator>,
        IConfigureOptions<MicrosoftIdentityOptions>
{
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        services.ConfigureAll<MicrosoftIdentityOptions>(Configure);
    }

    public void Configure(MicrosoftIdentityOptions options)
    {
        options.Events.OnTokenValidated += OnTokenValidated;
    }

    private async Task OnTokenValidated(TokenValidatedContext context)
    {
        using var scope = context.HttpContext.RequestServices.CreateScope();

        var userGuid = context.Principal.GetObjectId();

        var services = scope.ServiceProvider;
        var graphClient = services.GetRequiredService<GraphServiceClient>();

        var graphUser = await graphClient.Users[userGuid].Request().GetAsync();

        var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
        if (claimsIdentity != null)
        {
            // Get the identity provider
            var identityProvider = claimsIdentity.FindFirst("idp")?.Value;
            if (identityProvider == "twitter.com")
            {
                // the user's Twitter username will be in the "name" claim
                var twitterUsername = claimsIdentity.FindFirst(Ct.Name)?.Value;
                if (!IsNullOrEmpty(twitterUsername))
                {
                    // Add the Twitter username as a claim
                    claimsIdentity.AddClaim(new("extension_twitter_username", twitterUsername));
                }
            }
        }
    }
}
