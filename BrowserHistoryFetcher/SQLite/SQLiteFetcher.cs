using BrowserHistoryFetcher.Enums;
using BrowserHistoryFetcher.Pathing;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite
{
    public class SQLiteFetcher<T> where T : HistoryRecordBase
    {
        private dynamic db;
        private dynamic _dbTable;
        private IBrowserInfo _browserInfo;

        public SQLiteFetcher()
        {
            if (typeof(T) == typeof(MozillaHistoryRecord))
                _browserInfo = new MozillaPathManager();
            else if (typeof(T) == typeof(OperaHistoryRecord))
                _browserInfo = new OperaPathManager();
            else if (typeof(T) == typeof(ChromeHistoryRecord))
                _browserInfo = new ChromePathManager();

            db = Database.OpenFile(_browserInfo.GetHistoryPath());

            _dbTable = _browserInfo.GetBrowserType() == BrowserEnum.Mozilla ? db.moz_places : db.urls;
        }

        /*public IList<T> FetchAll(BrowserEnum browser)
        {
            IList<T> resultList = new List<T>();

            dynamic records;

            if (browser == BrowserEnum.Mozilla) // Mozilla has diferent table name (moz_places)
            {
                records = db.moz_places.All()
                        .Select(db.moz_places.url, db.moz_places.visit_count)
                        .Where(db.moz_places.url.Like(string.Concat("%", "youtube", "%")))
                        .OrderByDescending(db.moz_places.visit_count);
            }
            else
            {
                records = db.urls.All()
                        .Select(db.urls.url, db.urls.visit_count)
                        .Where(db.urls.url.Like(string.Concat("%", "youtube", "%")))
                        .OrderByDescending(db.urls.visit_count);
            }

            foreach (dynamic record in records)
            {
                T historyRecord = Slapper.AutoMapper.MapDynamic<T>(record) as T;
                resultList.Add(historyRecord);
            }

            return resultList;
        }*/

        public IList<T> FetchAll()
        {
            IList<T> resultList = new List<T>();

            dynamic records;

            records = _dbTable.All();

            foreach (dynamic record in records)
            {
                T historyRecord = Slapper.AutoMapper.MapDynamic<T>(record) as T;
                resultList.Add(historyRecord);
            }

            return resultList;
        }
    }
}
