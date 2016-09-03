using BrowserHistoryFetcher.Enums;
using BrowserHistoryFetcher.SQLite;
using BrowserHistoryFetcher.SQLite.Fetchers;
using BrowserHistoryFetcher.SQLite.RecordStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite.Fetchers
{
    public static class FetcherFactory
    {
        public static IFetchable<HistoryRecordBase> Create(string browserName)
        {
            switch (browserName)
            {
                case BrowserEnum.CHROME:
                    return new ChromeHistoryFetcher().NullFetcherIfFailed;
                case BrowserEnum.OPERA:
                    return new OperaHistoryFetcher().NullFetcherIfFailed;
                case BrowserEnum.MOZILLA:
                    return new MozillaHistoryFetcher().NullFetcherIfFailed;
                default:
                    throw new ArgumentException("Unknown broswer name");
            }
        }
    }
}
