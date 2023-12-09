#### [Excellence.Randomizers.Core](Excellence.Randomizers.md 'Excellence.Randomizers')
### [Excellence.Randomizers.Core.Configurations.Core](Excellence.Randomizers.md#Excellence.Randomizers.Core.Configurations.Core 'Excellence.Randomizers.Core.Configurations.Core')

## IConfigurationCoreJsonUtils<TItem,TConfiguration> Interface

The core configuration JSON utils.

```csharp
public interface IConfigurationCoreJsonUtils<TItem,out TConfiguration> :
Excellence.Randomizers.Core.Configurations.Core.IConfigurationCore<TItem, TConfiguration>
    where TConfiguration : Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils<TItem, TConfiguration>
```
#### Type parameters

<a name='Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils_TItem,TConfiguration_.TItem'></a>

`TItem`

The item type.

<a name='Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils_TItem,TConfiguration_.TConfiguration'></a>

`TConfiguration`

The configuration type.

Derived  
&#8627; [IConfiguration&lt;TItem&gt;](IConfiguration_TItem_.md 'Excellence.Randomizers.Core.Configurations.IConfiguration<TItem>')

Implements [Excellence.Randomizers.Core.Configurations.Core.IConfigurationCore&lt;](IConfigurationCore_TItem,TConfiguration_.md 'Excellence.Randomizers.Core.Configurations.Core.IConfigurationCore<TItem,TConfiguration>')[TItem](IConfigurationCoreJsonUtils_TItem,TConfiguration_.md#Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils_TItem,TConfiguration_.TItem 'Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils<TItem,TConfiguration>.TItem')[,](IConfigurationCore_TItem,TConfiguration_.md 'Excellence.Randomizers.Core.Configurations.Core.IConfigurationCore<TItem,TConfiguration>')[TConfiguration](IConfigurationCoreJsonUtils_TItem,TConfiguration_.md#Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils_TItem,TConfiguration_.TConfiguration 'Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils<TItem,TConfiguration>.TConfiguration')[&gt;](IConfigurationCore_TItem,TConfiguration_.md 'Excellence.Randomizers.Core.Configurations.Core.IConfigurationCore<TItem,TConfiguration>')
### Methods

<a name='Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils_TItem,TConfiguration_.UseFromJson(string,Newtonsoft.Json.JsonSerializerSettings)'></a>

## IConfigurationCoreJsonUtils<TItem,TConfiguration>.UseFromJson(string, JsonSerializerSettings) Method

Sets configuration properties from JSON.

```csharp
TConfiguration UseFromJson(string json, Newtonsoft.Json.JsonSerializerSettings? jsonSerializerSettings=null);
```
#### Parameters

<a name='Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils_TItem,TConfiguration_.UseFromJson(string,Newtonsoft.Json.JsonSerializerSettings).json'></a>

`json` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The JSON.

<a name='Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils_TItem,TConfiguration_.UseFromJson(string,Newtonsoft.Json.JsonSerializerSettings).jsonSerializerSettings'></a>

`jsonSerializerSettings` [Newtonsoft.Json.JsonSerializerSettings](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.JsonSerializerSettings 'Newtonsoft.Json.JsonSerializerSettings')

The serializer settings.

#### Returns
[TConfiguration](IConfigurationCoreJsonUtils_TItem,TConfiguration_.md#Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils_TItem,TConfiguration_.TConfiguration 'Excellence.Randomizers.Core.Configurations.Core.IConfigurationCoreJsonUtils<TItem,TConfiguration>.TConfiguration')