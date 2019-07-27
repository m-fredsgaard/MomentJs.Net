# MomentJs.Net
A .net implementation of momentjs, with seamless collaboration between client and server as main focus.

### Get started
Get the [NuGet Package](https://www.nuget.org/packages/MomentJs.Net)

## Display
### Format
The format method is fully localizable based on `LocaleDefinition` witch is based on a `CultureInfo`.

Method signature:
```
public static string Format<T>(this DateTime dateTime, string format, T locale = null)
    where T : LocaleDefinition<T>

public static string Format<T>(this DateTime dateTime, DateFormat dateformat, T locale = null)
    where T : LocaleDefinition<T>
```
This is the most robust display option. It takes a string of tokens and replaces them with their corresponding values.

| |Token|Default output (en-US)|
|:- |:- |:-- |
|Month|M|1 2 ... 11 12
|||[see other momentjs examples](https://momentjs.com/docs/#/displaying/format/)

## Localize (i18n)
The `MomentJs.Net.Definitions.LocaleDefinition` is a object that contains localized information used for displaying a given date. 
It uses the .net frameworks data from [`CultureInfo.DateTimeFormat`](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo) such as month names and date format patterns etc.

The abstract `MomentJs.Net.Definitions.LocaleDefinition<>` generic type can be used when you want to implement your own custom LocaleDefinition,
that gets the information the a custom data source. This could be a ressource file or a custom database in your own solution.

It's fully serializable to the json object that momentjs uses in the [javascript implementation](https://momentjs.com/docs/#/i18n/)