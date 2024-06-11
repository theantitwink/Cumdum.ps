/*
 * AutoConfigure.cs
 *     Created: 2024-06-02T21:38:25-04:00
 *    Modified: 2024-06-02T21:38:26-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

[assembly: HostingStartup(typeof(JsonFileAutoConfigurator))]
[assembly: HostingStartup(typeof(AutomaticAzureAdConfigurator))]
[assembly: HostingStartup(typeof(MvcAutoConfigurator))]
[assembly: HostingStartup(typeof(HttpServicesOptionsAutoConfigurator))]
[assembly: HostingStartup(typeof(MicrosoftGraphAutoConfigurator))]
