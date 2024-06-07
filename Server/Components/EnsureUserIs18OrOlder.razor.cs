/*
 * EnsureUserIs18OrOlder.razor.cs
 *     Created: 2024-06-07T09:44:51-04:00
 *    Modified: 2024-06-07T09:44:51-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */
namespace Cumdumps.Server.Components;

using Dgmjr.Blazor.Components;
using Microsoft.AspNetCore.Components;

public partial class EnsureUserIs18OrOlder : ComponentBase
{
    public const string Over18CookieName = "CumDumpsOver18";

    [Inject]
    public ILogger<EnsureUserIs18OrOlder> Logger { get; set; } = default!;

    [Inject]
    public NavigationManager Navigation { get; set; } = default!;

    [Inject]
    public CookiesJS CookiesJs { get; set; } = default!;

    private Modal _18OrOlderModal = default!;

    protected override void OnInitialized()
    {
        Logger?.ErrorLoagingJsonConfigFile("fuck", new Exception());
        base.OnInitialized();
    }

    private async Task GetMeOutOfHere()
    {
        Logger?.UserIsNotOver18();
        await CookiesJs.SetCookie(Over18CookieName, false.ToString(), int.MaxValue);
        Navigation.NavigateTo(CumdumpsServerConstants.ExitRoute, true, true);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (await CookiesJs.GetCookie(Over18CookieName) == true.ToString())
        {
            Logger?.UserIsOver18();
            return;
        }
        else
        {
            Logger?.CheckingIfUserIsOver18();
            await ShowAreYouAtLeast18Modal();
        }
    }

    private async Task ShowAreYouAtLeast18Modal()
    {
        await _18OrOlderModal.ShowAsync();
    }
}
