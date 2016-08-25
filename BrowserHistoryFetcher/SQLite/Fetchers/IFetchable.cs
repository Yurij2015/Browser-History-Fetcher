using BrowserHistoryFetcher.SQLite.RecordStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite.Fetchers
{
    public interface IFetchable<out T>
    {
        IEnumerable<T> FetchByUrlLike(string urlPattern);
        IEnumerable<T> FetchAll();
    }
}
