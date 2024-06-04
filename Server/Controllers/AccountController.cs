/*
 * AccountController.cs
 *     Created: 2024-06-03T16:27:44-04:00
 *    Modified: 2024-06-03T16:27:45-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Short.IO.Web.Server.Controllers;

[ApiController]
public class AccountController : ApiControllerBase
{
    private const string MicrosoftIdentity = nameof(MicrosoftIdentity);
    private const string Account = nameof(Account);
    private new const string SignIn = nameof(SignIn);
    private new const string SignOut = nameof(SignOut);

    [HttpGet(nameof(Login))]
    public IActionResult Login() =>
        base.RedirectToAction(SignIn, Account, new { Area = MicrosoftIdentity });

    [HttpGet(nameof(Logout))]
    public IActionResult Logout() =>
        base.RedirectToAction(SignOut, Account, new { Area = MicrosoftIdentity });
}
