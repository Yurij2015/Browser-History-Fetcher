using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite
{
    public class OperaHistoryRecord : HistoryRecordBase
    {
        public long typed_count { get; internal set; }
        public string last_visit_time { get; internal set; }
    }
}
