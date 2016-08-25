using BrowserHistoryFetcher.Pathing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite.RecordStructures
{
    public class MozillaHistoryRecord : HistoryRecordBase
    {
        public string rev_host { get; internal set; }
        public long typed { get; internal set; }
        public long frecency { get; internal set; }
        public long last_visit_date { get; internal set; }
        public string guid { get; internal set; }
        public long foreign_count { get; internal set; }
    }
}
