using BrowserHistoryFetcher.Pathing;
using BrowserHistoryFetcher.SQLite.RecordStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite.Fetchers
{
    public class ChromeHistoryFetcher : AbstractHistoryFetcher<ChromeHistoryRecord>, IFetchable<ChromeHistoryRecord>
    {
        public ChromeHistoryFetcher() : base(new ChromePathManager())
        {
        }

        protected override dynamic GetHistoryTable(dynamic db)
        {
            return db.urls;
        }

        public AbstractHistoryFetcher<ChromeHistoryRecord> NullFetcherIfFailed
        {
            get
            {
                if (this.TriggeredException != null)
                    return new NullChromeHistoryFetcher();
                else return this;
            }
        }
    }

    public class NullChromeHistoryFetcher : AbstractHistoryFetcher<ChromeHistoryRecord>, IFetchable<ChromeHistoryRecord>
    {
        public NullChromeHistoryFetcher() : base()
        {
        }

        protected override dynamic GetHistoryTable(dynamic db) { return null; }

        public override IEnumerable<ChromeHistoryRecord> FetchAll()
        {
            return new List<ChromeHistoryRecord>();
        }

        public override IEnumerable<ChromeHistoryRecord> FetchByUrlLike(string pattern)
        {
            return new List<ChromeHistoryRecord>();
        }
    }
}
