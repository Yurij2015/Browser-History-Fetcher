using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrowserHistoryFetcher.Pathing;
using BrowserHistoryFetcher.FileSystem;
using BrowserHistoryFetcher.SQLite.RecordStructures;
using BrowserHistoryFetcher.SQLite.Fetchers;
using System.Linq;

namespace BrowserHistoryFetcherTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFetchAll()
        {
            var fetcher = FetcherFactory.Create<OperaHistoryRecord>();
            var records = fetcher.FetchAll().ToList();
        }

        [TestMethod]
        public void TestFetchByUrlLike()
        {
            var fetcher = new MozillaHistoryFetcher();
            var records = fetcher.FetchByUrlLike("youtube");

            foreach (var record in records)
            {
                Console.WriteLine(record.url);
            }
        }

        [TestMethod]
        public void TestFileCopy()
        {
            string filePath = new OperaPathManager().HistoryPath;
            string copyPath = FileManager.CopyFileToTempFolder(filePath);
            Console.WriteLine(copyPath);
        }
    }
}
