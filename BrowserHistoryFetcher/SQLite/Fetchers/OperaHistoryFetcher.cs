using BrowserHistoryFetcher.Pathing;
using BrowserHistoryFetcher.SQLite.RecordStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite.Fetchers
{
    public class OperaHistoryFetcher : AbstractHistoryFetcher<OperaHistoryRecord>
    {
        public OperaHistoryFetcher() : base(new OperaPathManager())
        {
        }

        protected override dynamic GetHistoryTable(dynamic db)
        {
            return db.urls;
        }

        public AbstractHistoryFetcher<OperaHistoryRecord> NullFetcherIfFailed
        {
            get
            {
                if (this.TriggeredException != null)
                    return new NullOperaHistoryFetcher();
                else return this;
            }
        }
    }

    public class NullOperaHistoryFetcher : AbstractHistoryFetcher<OperaHistoryRecord>
    {
        public NullOperaHistoryFetcher() : base()
        {
        }

        protected override dynamic GetHistoryTable(dynamic db) { return null; }

        public override IEnumerable<OperaHistoryRecord> FetchAll()
        {
            return new List<OperaHistoryRecord>();
        }

        public override IEnumerable<OperaHistoryRecord> FetchByUrlLike(string pattern)
        {
            return new List<OperaHistoryRecord>();
        }
    }
}
