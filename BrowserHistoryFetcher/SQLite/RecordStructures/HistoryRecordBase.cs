using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite.RecordStructures
{
    public class HistoryRecordBase
    {
        public long id { get; internal set; }
        public string url { get; internal set; }
        public string title { get; internal set; }
        public long visit_count { get; internal set; }
        public long favicon_id { get; internal set; }
        public long hidden { get; internal set; }
    }
}
