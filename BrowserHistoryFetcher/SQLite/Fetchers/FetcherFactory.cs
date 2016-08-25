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
        public static IFetchable<HistoryRecordBase> Create<H>() where H : HistoryRecordBase
        {
            IFetchable<HistoryRecordBase> fetcher = null;

            if (typeof(H) == typeof(ChromeHistoryRecord))
            {
                fetcher = new ChromeHistoryFetcher().NullFetcherIfFailed;
            }
            else if (typeof(H) == typeof(OperaHistoryRecord))
            {
                return new OperaHistoryFetcher().NullFetcherIfFailed;
            }
            else if (typeof(H) == typeof(MozillaHistoryRecord))
            {
                return new MozillaHistoryFetcher().NullFetcherIfFailed;
            }
            else
            {
                throw new ArgumentException("Template type not recognized");
            }
            return fetcher;
        }
    }
}
