/*
 * Role.cs
 *     Created: 2024-06-06T21:44:14-04:00
 *    Modified: 2024-06-06T21:44:15-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Cumdumps.Identity.Enums;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

[GenerateEnumerationRecordStruct("Role", "Cumdumps.Identity")]
public enum Role
{
    [Display(Name = "Administrator", Description = "The role of a user who is an administrator.")]
    [Guid("2d392118-b159-078a-f211-e90f73c55890")]
    [Uri("https://cumdum.ps/roles/administrator")]
    Administrator = 1,

    [Display(Name = "Cumdump", Description = "The cumdump role.")]
    [Guid("2ebd6ec1-5f9c-9fa3-7ffb-32959e86a57a")]
    [Uri("https://cumdum.ps/roles/cumdump")]
    Guest = 2,

    [Display(Name = "User", Description = "The user role.")]
    [Guid("d5508971-87da-f609-d425-fdc6a7506931")]
    [Uri("https://cumdum.ps/roles/user")]
    User = 3,

    [Display(Name = "Breeder", Description = "The breeder (top) role.")]
    [Guid("72242f90-a03c-ca18-bbe9-66855ea3b343")]
    [Uri("https://cumdum.ps/roles/breeder")]
    Breeder = 3
}
