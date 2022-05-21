#### [Excellence.Randomizers.Core](Excellence.Randomizers.md 'Excellence.Randomizers')
### [Excellence.Randomizers.Core](Excellence.Randomizers.md#Excellence.Randomizers.Core 'Excellence.Randomizers.Core')

## IConfigurationCore<TItem,TConfiguration> Interface

The core configuration.

```csharp
public interface IConfigurationCore<TItem,out TConfiguration>
    where TConfiguration : Excellence.Randomizers.Core.IConfigurationCore<TItem, TConfiguration>
```
#### Type parameters

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TItem'></a>

`TItem`

The item type.

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TConfiguration'></a>

`TConfiguration`

The configuration type.

Derived  
&#8627; [IConfiguration&lt;TItem&gt;](IConfiguration_TItem_.md 'Excellence.Randomizers.Core.IConfiguration<TItem>')
### Properties

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.Items'></a>

## IConfigurationCore<TItem,TConfiguration>.Items Property

The items.

```csharp
System.Collections.Generic.IEnumerable<TItem> Items { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TItem](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TItem 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.MaxCount'></a>

## IConfigurationCore<TItem,TConfiguration>.MaxCount Property

The maximum number of items (inclusive).

```csharp
int MaxCount { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.MinCount'></a>

## IConfigurationCore<TItem,TConfiguration>.MinCount Property

The minimum number of items (inclusive).

```csharp
int MinCount { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UniqueOnly'></a>

## IConfigurationCore<TItem,TConfiguration>.UniqueOnly Property

Indicates if unique items should be used in the resulting set.

```csharp
bool UniqueOnly { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.Copy()'></a>

## IConfigurationCore<TItem,TConfiguration>.Copy() Method

Copies the configuration.

```csharp
TConfiguration Copy();
```

#### Returns
[TConfiguration](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TConfiguration 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TConfiguration')  
The new instance.

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.Use(System.Collections.Generic.IEnumerable_TItem_,int,int,bool)'></a>

## IConfigurationCore<TItem,TConfiguration>.Use(IEnumerable<TItem>, int, int, bool) Method

Adds the items.

```csharp
TConfiguration Use(System.Collections.Generic.IEnumerable<TItem> items, int minCount, int maxCount, bool uniqueOnly=false);
```
#### Parameters

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.Use(System.Collections.Generic.IEnumerable_TItem_,int,int,bool).items'></a>

`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TItem](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TItem 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The items.

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.Use(System.Collections.Generic.IEnumerable_TItem_,int,int,bool).minCount'></a>

`minCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The minimum number of items (inclusive).

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.Use(System.Collections.Generic.IEnumerable_TItem_,int,int,bool).maxCount'></a>

`maxCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximum number of items (inclusive).

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.Use(System.Collections.Generic.IEnumerable_TItem_,int,int,bool).uniqueOnly'></a>

`uniqueOnly` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when unique (non-repeating) items should be used in the resulting set or [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when repeats are allowed.

#### Returns
[TConfiguration](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TConfiguration 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TConfiguration')  
The current instance.

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UseItems(System.Collections.Generic.IEnumerable_TItem_)'></a>

## IConfigurationCore<TItem,TConfiguration>.UseItems(IEnumerable<TItem>) Method

Adds the items.

```csharp
TConfiguration UseItems(System.Collections.Generic.IEnumerable<TItem> items);
```
#### Parameters

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UseItems(System.Collections.Generic.IEnumerable_TItem_).items'></a>

`items` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TItem](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TItem 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The items.

#### Returns
[TConfiguration](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TConfiguration 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TConfiguration')  
The current instance.

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UseItems(TItem[])'></a>

## IConfigurationCore<TItem,TConfiguration>.UseItems(TItem[]) Method

Adds the items.

```csharp
TConfiguration UseItems(params TItem[] items);
```
#### Parameters

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UseItems(TItem[]).items'></a>

`items` [TItem](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TItem 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TItem')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The items.

#### Returns
[TConfiguration](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TConfiguration 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TConfiguration')  
The current instance.

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UseMaxCount(int)'></a>

## IConfigurationCore<TItem,TConfiguration>.UseMaxCount(int) Method

Sets the maximum number of items (inclusive).

```csharp
TConfiguration UseMaxCount(int maxCount);
```
#### Parameters

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UseMaxCount(int).maxCount'></a>

`maxCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximum number of items (inclusive).

#### Returns
[TConfiguration](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TConfiguration 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TConfiguration')  
The current instance.

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UseMinCount(int)'></a>

## IConfigurationCore<TItem,TConfiguration>.UseMinCount(int) Method

Sets the minimum number of items (inclusive).

```csharp
TConfiguration UseMinCount(int minCount);
```
#### Parameters

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UseMinCount(int).minCount'></a>

`minCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The minimum number of items (inclusive).

#### Returns
[TConfiguration](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TConfiguration 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TConfiguration')  
The current instance.

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UseUnique(bool)'></a>

## IConfigurationCore<TItem,TConfiguration>.UseUnique(bool) Method

Sets if unique items should be used in the resulting set.

```csharp
TConfiguration UseUnique(bool uniqueOnly);
```
#### Parameters

<a name='Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.UseUnique(bool).uniqueOnly'></a>

`uniqueOnly` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when only unique (non-repeating) items should be used in the resulting set or [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when repeats are allowed.

#### Returns
[TConfiguration](IConfigurationCore_TItem,TConfiguration_.md#Excellence.Randomizers.Core.IConfigurationCore_TItem,TConfiguration_.TConfiguration 'Excellence.Randomizers.Core.IConfigurationCore<TItem,TConfiguration>.TConfiguration')  
The current instance.