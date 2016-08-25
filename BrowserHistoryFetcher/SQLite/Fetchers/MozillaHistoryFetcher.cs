using BrowserHistoryFetcher.SQLite;
using BrowserHistoryFetcher.SQLite.RecordStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserHistoryFetcher.Pathing;

namespace BrowserHistoryFetcher.SQLite.Fetchers
{
    public class MozillaHistoryFetcher : AbstractHistoryFetcher<MozillaHistoryRecord>
    {
        public MozillaHistoryFetcher() : base(new MozillaPathManager())
        {
        }

        protected override dynamic GetHistoryTable(dynamic db)
        {
            return db.moz_places;
        }

        public AbstractHistoryFetcher<MozillaHistoryRecord> NullFetcherIfFailed
        {
            get
            {
                if (this.TriggeredException != null)
                    return new NullMozillaHistoryFetcher();
                else return this;
            }
        }
    }

    public class NullMozillaHistoryFetcher : AbstractHistoryFetcher<MozillaHistoryRecord>
    {
        public NullMozillaHistoryFetcher() : base()
        {
        }

        protected override dynamic GetHistoryTable(dynamic db) { return null; }

        public override IEnumerable<MozillaHistoryRecord> FetchAll()
        {
            return new List<MozillaHistoryRecord>();
        }

        public override IEnumerable<MozillaHistoryRecord> FetchByUrlLike(string pattern)
        {
            return new List<MozillaHistoryRecord>();
        }
    }
}
