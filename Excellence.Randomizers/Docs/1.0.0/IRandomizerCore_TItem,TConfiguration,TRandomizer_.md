#### [Excellence.Randomizers.Core](Excellence.Randomizers.md 'Excellence.Randomizers')
### [Excellence.Randomizers.Core](Excellence.Randomizers.md#Excellence.Randomizers.Core 'Excellence.Randomizers.Core')

## IRandomizerCore<TItem,TConfiguration,TRandomizer> Interface

The core randomizer.

```csharp
public interface IRandomizerCore<out TItem,in TConfiguration,out TRandomizer>
    where TConfiguration : Excellence.Randomizers.Core.IConfigurationCore<TItem, TConfiguration>
    where TRandomizer : Excellence.Randomizers.Core.IRandomizerCore<TItem, TConfiguration, TRandomizer>
```
#### Type parameters

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.TItem'></a>

`TItem`

The item type.

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.TConfiguration'></a>

`TConfiguration`

The configuration type.

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.TRandomizer'></a>

`TRandomizer`

The randomizer type.

Derived  
&#8627; [IRandomizer&lt;TItem&gt;](IRandomizer_TItem_.md 'Excellence.Randomizers.Core.IRandomizer<TItem>')
### Properties

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.MaxCount'></a>

## IRandomizerCore<TItem,TConfiguration,TRandomizer>.MaxCount Property

The total maximum number of items (inclusive).

```csharp
int MaxCount { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.MinCount'></a>

## IRandomizerCore<TItem,TConfiguration,TRandomizer>.MinCount Property

The total minimum number of items (inclusive).

```csharp
int MinCount { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Methods

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.Copy()'></a>

## IRandomizerCore<TItem,TConfiguration,TRandomizer>.Copy() Method

Copies the current instance.

```csharp
TRandomizer Copy();
```

#### Returns
[TRandomizer](IRandomizerCore_TItem,TConfiguration,TRandomizer_.md#Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.TRandomizer 'Excellence.Randomizers.Core.IRandomizerCore<TItem,TConfiguration,TRandomizer>.TRandomizer')  
The new instance that has the same configuration as the current one.

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.Next()'></a>

## IRandomizerCore<TItem,TConfiguration,TRandomizer>.Next() Method

Generates the random set of items.

```csharp
System.Collections.Generic.IEnumerable<TItem> Next();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TItem](IRandomizerCore_TItem,TConfiguration,TRandomizer_.md#Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.TItem 'Excellence.Randomizers.Core.IRandomizerCore<TItem,TConfiguration,TRandomizer>.TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The generated set of items.

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.Next(int)'></a>

## IRandomizerCore<TItem,TConfiguration,TRandomizer>.Next(int) Method

Generates multiple random sets of items.

```csharp
System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable<TItem>> Next(int count);
```
#### Parameters

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.Next(int).count'></a>

`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The count of sets to generate.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TItem](IRandomizerCore_TItem,TConfiguration,TRandomizer_.md#Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.TItem 'Excellence.Randomizers.Core.IRandomizerCore<TItem,TConfiguration,TRandomizer>.TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The generated sets of items.

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.Use(System.Collections.Generic.IEnumerable_TConfiguration_)'></a>

## IRandomizerCore<TItem,TConfiguration,TRandomizer>.Use(IEnumerable<TConfiguration>) Method

Add the configurations.

```csharp
TRandomizer Use(System.Collections.Generic.IEnumerable<TConfiguration> configurations);
```
#### Parameters

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.Use(System.Collections.Generic.IEnumerable_TConfiguration_).configurations'></a>

`configurations` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TConfiguration](IRandomizerCore_TItem,TConfiguration,TRandomizer_.md#Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.TConfiguration 'Excellence.Randomizers.Core.IRandomizerCore<TItem,TConfiguration,TRandomizer>.TConfiguration')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The configurations.

#### Returns
[TRandomizer](IRandomizerCore_TItem,TConfiguration,TRandomizer_.md#Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.TRandomizer 'Excellence.Randomizers.Core.IRandomizerCore<TItem,TConfiguration,TRandomizer>.TRandomizer')  
The current instance.

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.Use(TConfiguration[])'></a>

## IRandomizerCore<TItem,TConfiguration,TRandomizer>.Use(TConfiguration[]) Method

Add the configurations.

```csharp
TRandomizer Use(params TConfiguration[] configurations);
```
#### Parameters

<a name='Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.Use(TConfiguration[]).configurations'></a>

`configurations` [TConfiguration](IRandomizerCore_TItem,TConfiguration,TRandomizer_.md#Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.TConfiguration 'Excellence.Randomizers.Core.IRandomizerCore<TItem,TConfiguration,TRandomizer>.TConfiguration')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The configurations.

#### Returns
[TRandomizer](IRandomizerCore_TItem,TConfiguration,TRandomizer_.md#Excellence.Randomizers.Core.IRandomizerCore_TItem,TConfiguration,TRandomizer_.TRandomizer 'Excellence.Randomizers.Core.IRandomizerCore<TItem,TConfiguration,TRandomizer>.TRandomizer')  
The current instance.