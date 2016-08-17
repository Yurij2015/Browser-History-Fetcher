using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrowserHistoryFetcher.SQLite;
using BrowserHistoryFetcher.Enums;
using BrowserHistoryFetcher.Pathing;
using BrowserHistoryFetcher.FileSystem;

namespace BrowserHistoryFetcherTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFetchAll()
        {
            var fetcher = new SQLiteFetcher<OperaHistoryRecord>();
            var records = fetcher.FetchAll();

            Assert.IsTrue(records.Count > 0);
        }

        [TestMethod]
        public void TestFetchByUrlLike()
        {
            var fetcher = new SQLiteFetcher<MozillaHistoryRecord>();
            var records = fetcher.FetchByUrlLike("youtube");

            foreach (var record in records)
            {
                Console.WriteLine(record.url);
            }
        }

        [TestMethod]
        public void TestFileCopy()
        {
            string filePath = new OperaPathManager().GetHistoryPath();
            string copyPath = FileManager.CopyFileToTempFolder(filePath);
            Console.WriteLine(copyPath);
        }
    }
}
