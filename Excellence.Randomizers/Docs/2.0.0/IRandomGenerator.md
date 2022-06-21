#### [Excellence.Randomizers.Core](Excellence.Randomizers.md 'Excellence.Randomizers')
### [Excellence.Randomizers.Core.RandomGenerators](Excellence.Randomizers.md#Excellence.Randomizers.Core.RandomGenerators 'Excellence.Randomizers.Core.RandomGenerators')

## IRandomGenerator Interface

The random generator.

```csharp
public interface IRandomGenerator
```
### Methods

<a name='Excellence.Randomizers.Core.RandomGenerators.IRandomGenerator.GetInt32(int,int)'></a>

## IRandomGenerator.GetInt32(int, int) Method

Generates random Int32 number.

```csharp
int GetInt32(int min, int max);
```
#### Parameters

<a name='Excellence.Randomizers.Core.RandomGenerators.IRandomGenerator.GetInt32(int,int).min'></a>

`min` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The min value (inclusive).

<a name='Excellence.Randomizers.Core.RandomGenerators.IRandomGenerator.GetInt32(int,int).max'></a>

`max` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The max value (inclusive).

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The random Int32 value.