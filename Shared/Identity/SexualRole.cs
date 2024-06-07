/*
 * SexualRole.cs
 *     Created: 2024-06-07T18:57:01-04:00
 *    Modified: 2024-06-07T18:57:02-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Cumdumps.Identity.Enums;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

[GenerateEnumerationRecordStruct("SexualRole", "Cumdump.Identity")]
public enum SexualRole
{
    [Display(Name = "Top (breeder)", Description = "You breed cumudmps.")]
    [Guid("654f1256-4118-45e6-84f6-db96368a28d0")]
    [Uri("https://cumdum.ps/role/breeder")]
    Top = 1,

    [Display(Name = "Bottom (cumdump)", Description = "You're a cumdump.")]
    [Guid("5baf7958-2e12-4a4b-9a76-6c5fc01c2903")]
    [Uri("https://cumdum.ps/role/bottom")]
    Bottom = 2,

    [Display(Name = "Versatile (goes both ways)", Description = "You do both.")]
    [Guid("f9056e48-193a-4af2-9bc0-59e59bc1f845")]
    [Uri("https://cumdum.ps/role/vers")]
    Versatile = 3
}
