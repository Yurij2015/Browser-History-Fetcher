# Browser-History-Fetcher

## Overview
Browser History Fetcher is tiny .NET library, written in C# which is capable of retrieving history records for these browsers:
- Opera
- Mozilla
- Chrome

## Example for Chrome browser

```c#
// path to history file is determined automatically, but constuctor accepts also path to history sqlite file.
var fetcher = new ChromeHistoryFetcher();
var records = fetcher.FetchAll();

foreach (ChromeHistoryRecord record in records)
{
    Console.WriteLine(record.url);
    Console.WriteLine(record.visit_count);
    ...
}
```

In case browser is not installed or path to history file is not found, fetcher will throw exception when calling methods of fetchable interface. If u want to return empty collections in that case u can use NullFetchers.
```c#
var fetcher = new ChromeHistoryFetcher().NullFetcherIfFailed;
// or
var fetcher = FetcherFactory.Create(BrowserEnum.CHROME);
...
```
## Licensing
This project is licensed under MIT license.
