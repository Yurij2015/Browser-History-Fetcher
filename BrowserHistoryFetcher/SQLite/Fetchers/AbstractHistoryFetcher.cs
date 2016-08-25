using BrowserHistoryFetcher.FileSystem;
using BrowserHistoryFetcher.Pathing;
using BrowserHistoryFetcher.SQLite.Fetchers;
using BrowserHistoryFetcher.SQLite.RecordStructures;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserHistoryFetcher.SQLite.Fetchers
{
    public abstract class AbstractHistoryFetcher<T> : IFetchable<T> where T : HistoryRecordBase
    {
        private Exception _initException = null;
        protected dynamic db;
        protected dynamic _dbTable;

        internal AbstractHistoryFetcher(IHistoryPath historyManager)
        {
            if (historyManager == null)
                throw new ArgumentNullException("historyManager");

            try
            {
                string historyCopypath = FileManager.CopyFileToTempFolder(historyManager.HistoryPath);
                db = Database.OpenFile(historyCopypath);
                _dbTable = GetHistoryTable(db);
            }
            catch (Exception ex)
            {
                _initException = ex;
            }
        }

        /// <summary>
        /// Used only by NUll fetchers.
        /// </summary>
        internal AbstractHistoryFetcher() { }

        public Exception TriggeredException
        {
            get { return _initException; }
        }

        protected abstract dynamic GetHistoryTable(dynamic db);

        public virtual IEnumerable<T> FetchByUrlLike(string urlPattern)
        {
            IList<T> resultList = new List<T>();

            dynamic result = _dbTable.All()
                        .Where(_dbTable.url.Like(string.Concat("%", urlPattern, "%")))
                        .OrderByDescending(_dbTable.visit_count);

            foreach (dynamic record in result)
            {
                T historyRecord = Slapper.AutoMapper.MapDynamic<T>(record) as T;
                resultList.Add(historyRecord);
            }

            return resultList.ToArray();
        }

        public virtual IEnumerable<T> FetchAll()
        {
            IList<T> resultList = new List<T>();

            SimpleQuery query = _dbTable.All();

            foreach (dynamic record in query)
            {
                T historyRecord = Slapper.AutoMapper.MapDynamic<T>(record) as T;
                resultList.Add(historyRecord);
            }

            return resultList.ToArray();
        }
    }
}
