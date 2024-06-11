/*
 * SexualRole.cs
 *     Created: 2024-06-07T18:57:01-04:00
 *    Modified: 2024-06-07T18:57:02-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Cumdumps.Identity
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    namespace Enums
    {
        // [GenerateEnumerationRecordStruct("SexualRole", "Cumdump.Identity")]
        public enum SexualRole
        {
            [Display(
                Name = "Unknown",
                Description = "You haven't made a selection.",
                ShortName = "?"
            )]
            Unknown = 0,

            [Display(Name = "Top", Description = "You breed cumudmps.", ShortName = "top")]
            Top = 1,

            [Display(Name = "Bottom", Description = "You're a cumdump.", ShortName = "btm")]
            Bottom = 2,

            [Display(Name = "Versatile", Description = "You do both.", ShortName = "vers")]
            Versatile = 3
        }
    }

    public static class SexualRoleExtensions
    {
        public static string ToFriendlyString(this Enums.SexualRole role)
        {
            return role switch
            {
                Enums.SexualRole.Top => "Top",
                Enums.SexualRole.Bottom => "Bottom",
                Enums.SexualRole.Versatile => "Versatile",
                _ => "Unknown"
            };
        }
    }

    public record struct SexualRole(Enums.SexualRole role)
    {
        public string Name =>
            role switch
            {
                Enums.SexualRole.Unknown => "Unknown",
                Enums.SexualRole.Top => "Top",
                Enums.SexualRole.Bottom => "Bottom",
                Enums.SexualRole.Versatile => "Versatile",
                _ => "Unknown"
            };

        public string Description =>
            role switch
            {
                Enums.SexualRole.Unknown => "You haven't made a selection.",
                Enums.SexualRole.Top => "You breed cumudmps.",
                Enums.SexualRole.Bottom => "You're a cumdump.",
                Enums.SexualRole.Versatile => "You do both.",
                _ => "Unknown"
            };

        public Guid Guid =>
            role switch
            {
                Enums.SexualRole.Unknown => Guid.Empty,
                Enums.SexualRole.Top => new Guid("654f1256-4118-45e6-84f6-db96368a28d0"),
                Enums.SexualRole.Bottom => new Guid("5baf7958-2e12-4a4b-9a76-6c5fc01c2903"),
                Enums.SexualRole.Versatile => new Guid("f9056e48-193a-4af2-9bc0-59e59bc1f845"),
                _ => Guid.Empty
            };

        public Uri Uri =>
            role switch
            {
                Enums.SexualRole.Unknown => new Uri("https://cumdum.ps/role/unknown"),
                Enums.SexualRole.Top => new Uri("https://cumdum.ps/role/breeder"),
                Enums.SexualRole.Bottom => new Uri("https://cumdum.ps/role/bottom"),
                Enums.SexualRole.Versatile => new Uri("https://cumdum.ps/role/vers"),
                _ => new Uri("https://cumdum.ps/role/unknown")
            };
    }
}
