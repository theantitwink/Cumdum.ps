/*
 * LoggingExtensions.cs
 *     Created: 2024-06-07T16:56:36-04:00
 *    Modified: 2024-06-07T16:56:37-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Cumdumps.Server;

public static partial class LoggingExtensions
{
    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Information,
        Message = "Checking if the user is over 18..."
    )]
    public static partial void CheckingIfUserIsOver18(this ILogger<EnsureUserIs18OrOlder> logger);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "User is not over 18.")]
    public static partial void UserIsNotOver18(this ILogger<EnsureUserIs18OrOlder> logger);

    [LoggerMessage(EventId = 3, Level = LogLevel.Information, Message = "User is over 18.")]
    public static partial void UserIsOver18(this ILogger<EnsureUserIs18OrOlder> logger);
}
