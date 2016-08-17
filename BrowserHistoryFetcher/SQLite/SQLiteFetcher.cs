using BrowserHistoryFetcher.Enums;
using BrowserHistoryFetcher.FileSystem;
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

        public SQLiteFetcher(string historyFilePath = null)
        {
            if (typeof(T) == typeof(MozillaHistoryRecord))
                _browserInfo = new MozillaPathManager();
            else if (typeof(T) == typeof(OperaHistoryRecord))
                _browserInfo = new OperaPathManager();
            else if (typeof(T) == typeof(ChromeHistoryRecord))
                _browserInfo = new ChromePathManager();

            string historyCopypath = FileManager.CopyFileToTempFolder(historyFilePath ?? _browserInfo.GetHistoryPath());
            db = Database.OpenFile(historyCopypath);

            // Mozilla has diferent table name (moz_places)
            _dbTable = _browserInfo.GetBrowserType() == BrowserEnum.Mozilla ? db.moz_places : db.urls;
        }

        public IList<T> FetchByUrlLike(string urlPattern)
        {
            IList<T> resultList = new List<T>();

            dynamic result = _dbTable.All()
                        .Where(db.moz_places.url.Like(string.Concat("%", urlPattern, "%")))
                        .OrderByDescending(db.moz_places.visit_count);

            foreach (dynamic record in result)
            {
                T historyRecord = Slapper.AutoMapper.MapDynamic<T>(record) as T;
                resultList.Add(historyRecord);
            }

            return resultList;
        }

        public IList<T> FetchAll()
        {
            IList<T> resultList = new List<T>();

            SimpleQuery query = _dbTable.All();

            foreach (dynamic record in query)
            {
                T historyRecord = Slapper.AutoMapper.MapDynamic<T>(record) as T;
                resultList.Add(historyRecord);
            }

            return resultList;
        }
    }
}
