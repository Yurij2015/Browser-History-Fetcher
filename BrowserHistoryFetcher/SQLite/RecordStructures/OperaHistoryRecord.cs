using BrowserHistoryFetcher.Pathing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite.RecordStructures
{
    public class OperaHistoryRecord : HistoryRecordBase
    {
        public long typed_count { get; internal set; }
        public long last_visit_time { get; internal set; }
    }
}
