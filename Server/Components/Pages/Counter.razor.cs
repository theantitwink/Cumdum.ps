/*
 * Counter.razor.cs
 *     Created: 2024-06-03T13:36:18-04:00
 *    Modified: 2024-06-03T13:36:18-04:00
 *      Author: David G. Moore, Jr. <david@dgmjr.io>
 *   Copyright: © 2022 - 2024 David G. Moore, Jr., All Rights Reserved
 *     License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Cumdumps.Server.Components.Pages;

public partial class Counter
{
    private int _currentCount = 0;

    private void IncrementCount()
    {
        _currentCount++;
    }
}
