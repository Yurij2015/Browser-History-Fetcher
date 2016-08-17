using BrowserHistoryFetcher.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.Pathing
{
    internal interface IBrowserInfo
    {
        string GetHistoryPath();
        BrowserEnum GetBrowserType();
    }
}
