using BrowserHistoryFetcher.FileSystem;
using BrowserHistoryFetcher.Pathing;
using BrowserHistoryFetcher.SQLite.RecordStructures;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.IO;
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
                string errorPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "errors.txt");
                File.WriteAllText(errorPath, ex.Message);
            }
        }

        /// <summary>
        /// Used only by Null fetchers.
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

            SimpleQuery result = _dbTable.All()
                        .Where(_dbTable.url.Like(string.Concat("%", urlPattern, "%")))
                        .OrderByDescending(_dbTable.visit_count);

            return result.Cast<T>();
        }

        public virtual IEnumerable<T> FetchAll()
        {
            return ((SimpleQuery)_dbTable.All()).Cast<T>();
        }
    }
}
