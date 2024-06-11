/*
 * Role.cs
 *     Created: 2024-06-06T21:44:14-04:00
 *    Modified: 2024-06-06T21:44:15-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Cumdumps.Identity
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    namespace Enums
    {
        public enum Role
        {
            [Display(Name = "None", Description = "The role of a user who has no role.")]
            None,

            [Display(
                Name = "Administrator",
                Description = "The role of a user who is an administrator."
            )]
            Administrator = 1,

            [Display(Name = "Cumdump", Description = "The cumdump role.")]
            Guest = 2,

            [Display(Name = "User", Description = "The user role.")]
            User = 3,

            [Display(Name = "Breeder", Description = "The breeder (top) role.")]
            Breeder = 4
        }
    }

    public record struct Role(Enums.Role role)
    {
        public string Name =>
            role switch
            {
                Enums.Role.Administrator => "Administrator",
                Enums.Role.Guest => "Cumdump",
                Enums.Role.User => "User",
                Enums.Role.Breeder => "Breeder",
                _ => "Unknown"
            };

        public string Description =>
            role switch
            {
                Enums.Role.Administrator => "The role of a user who is an administrator.",
                Enums.Role.Guest => "The cumdump role.",
                Enums.Role.User => "The user role.",
                Enums.Role.Breeder => "The breeder (top) role.",
                _ => "Unknown"
            };

        public guid Guid =>
            role switch
            {
                Enums.Role.Administrator => new("2d392118-b159-078a-f211-e90f73c55890"),
                Enums.Role.Guest => new("2ebd6ec1-5f9c-9fa3-7ffb-32959e86a57a"),
                Enums.Role.User => new("d5508971-87da-f609-d425-fdc6a7506931"),
                Enums.Role.Breeder => new("72242f90-a03c-ca18-bbe9-66855ea3b343"),
                _ => Guid.Empty
            };

        public Uri Uri =>
            role switch
            {
                Enums.Role.Administrator => new("https://cumdum.ps/roles/administrator"),
                Enums.Role.Guest => new("https://cumdum.ps/roles/cumdump"),
                Enums.Role.User => new("https://cumdum.ps/roles/user"),
                Enums.Role.Breeder => new("https://cumdum.ps/roles/breeder"),
                _ => new("https://cumdum.ps/roles/unknown")
            };
    }
}
