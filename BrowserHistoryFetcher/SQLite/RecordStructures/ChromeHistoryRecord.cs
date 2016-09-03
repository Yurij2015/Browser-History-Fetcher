using BrowserHistoryFetcher.Pathing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite.RecordStructures
{
    public class ChromeHistoryRecord : HistoryRecordBase
    {
        public long typed_count { get; internal set; }
    }
}
