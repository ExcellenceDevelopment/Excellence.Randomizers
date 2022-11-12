#### [Excellence.Randomizers.Core](Excellence.Randomizers.md 'Excellence.Randomizers')
### [Excellence.Randomizers.Core.Shufflers](Excellence.Randomizers.md#Excellence.Randomizers.Core.Shufflers 'Excellence.Randomizers.Core.Shufflers')

## IShuffler Interface

The shuffler

```csharp
public interface IShuffler
```
### Methods

<a name='Excellence.Randomizers.Core.Shufflers.IShuffler.Shuffle_TItem_(System.Collections.Generic.IEnumerable_TItem_)'></a>

## IShuffler.Shuffle<TItem>(IEnumerable<TItem>) Method

Shuffles the collection.

```csharp
System.Collections.Generic.IEnumerable<TItem> Shuffle<TItem>(System.Collections.Generic.IEnumerable<TItem> source);
```
#### Type parameters

<a name='Excellence.Randomizers.Core.Shufflers.IShuffler.Shuffle_TItem_(System.Collections.Generic.IEnumerable_TItem_).TItem'></a>

`TItem`

The item type.
#### Parameters

<a name='Excellence.Randomizers.Core.Shufflers.IShuffler.Shuffle_TItem_(System.Collections.Generic.IEnumerable_TItem_).source'></a>

`source` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TItem](IShuffler.md#Excellence.Randomizers.Core.Shufflers.IShuffler.Shuffle_TItem_(System.Collections.Generic.IEnumerable_TItem_).TItem 'Excellence.Randomizers.Core.Shufflers.IShuffler.Shuffle<TItem>(System.Collections.Generic.IEnumerable<TItem>).TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The source collection.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TItem](IShuffler.md#Excellence.Randomizers.Core.Shufflers.IShuffler.Shuffle_TItem_(System.Collections.Generic.IEnumerable_TItem_).TItem 'Excellence.Randomizers.Core.Shufflers.IShuffler.Shuffle<TItem>(System.Collections.Generic.IEnumerable<TItem>).TItem')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The shuffled collection.