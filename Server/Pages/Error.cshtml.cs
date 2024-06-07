using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cumdumps.Server.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel(ILogger<ErrorModel> logger)
    : Dgmjr.AspNetCore.Razor.PageModel(logger: logger)
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => RequestId.IsPresent();

    public void OnGet()
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}
