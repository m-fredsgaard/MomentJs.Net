# MomentJs.Net
A .net implementation of momentjs, with seamless collaboration between client and server as main focus.

### Get started
Get the [NuGet Package](https://www.nuget.org/packages/MomentJs.Net)

## Display
### Format
The format method is fully localizable based on the static property `GlobalizationProvider.Instance`.
So for localized formatting, set the properties on that object. See [Globalization (i18n)](#globalization-i18n).

Method signature:
```
public static string Format(this DateTime dateTime, CultureInfo culture = null)

public static string Format(this DateTime dateTime, string format, CultureInfo culture = null)

public static string Format(this DateTime dateTime, DateFormat dateFormat, CultureInfo culture = null)
```
It takes a string of tokens and replaces them with their corresponding values.

| |Token|Default output (en-US)|
|:- |:- |:-- |
|Month|M|1 2 ... 11 12
|||[see other momentjs examples](https://momentjs.com/docs/#/displaying/format/)

## Globalization (i18n)
The `MomentJs.Net.Globalization.GlobalizationProvider` provides localized information used for displaying a given date. 
It uses the .net frameworks data from [`CultureInfo.DateTimeFormat`](https://docs.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo) such as month names and date format patterns etc.

To use another custom data source, just set the properties on the static property `GlobalizationProvider.Instance`.
This could be a ressource file or a custom database in your own solution.

The `GlobalizationProvider` is fully serializable to the json object that momentjs uses in the [javascript implementation](https://momentjs.com/docs/#/i18n/).

Example on how to serialize the `en-US` locale json object:
```
JsonConvert.SerializeObject(GlobalizationProvider.Instance, new JsonSerializerSettings
{
    Culture = new CultureInfo("en-US")
});
```