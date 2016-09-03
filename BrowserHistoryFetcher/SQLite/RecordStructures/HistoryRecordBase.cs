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

        private long _last_visit_time;

        public long last_visit_time
        {
            get
            {
                return _last_visit_time > 0 ? _last_visit_time : _last_visit_date;
            }
            internal set { _last_visit_time = value; }
        }

        private long _last_visit_date;

        public long last_visit_date
        {
            get
            {
                return _last_visit_date > 0 ? _last_visit_date : _last_visit_time;
            }
            internal set { _last_visit_date = value; }
        }
    }
}
