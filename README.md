# Browser-History-Fetcher

## Overview
Browser History Fetcher is tiny .NET library, written in C# which is capable of retrieving history records for these browsers:
- Opera
- Mozilla
- Chrome

## Example for Chrome browser

```c#
// path to history file is determined automatically, but constuctor accepts also path to history sqlite file.
var fetcher = new SQLiteFetcher<ChromeHistoryRecord>();
var records = fetcher.FetchAll();

foreach (ChromeHistoryRecord record in records)
{
    Console.WriteLine(record.url);
    Console.WriteLine(record.visit_count);
    ...
}
```

As I mentioned only 3 browsers are supported for fetcher:
```c#
new SQLiteFetcher<ChromeHistoryRecord>();
new SQLiteFetcher<MozillaHistoryRecord>();
new SQLiteFetcher<OperaHistoryRecord>();
```
## Licensing
This project is licensed under MIT license.
