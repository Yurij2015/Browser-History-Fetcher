using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrowserHistoryFetcher.SQLite;
using BrowserHistoryFetcher.Enums;
using BrowserHistoryFetcher.Pathing;

namespace BrowserHistoryFetcherTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var fetcher = new SQLiteFetcher<MozillaHistoryRecord>();
            var records = fetcher.FetchAll();

            foreach (var record in records)
            {
                Console.WriteLine(record.url);
            }
        }
    }
}
