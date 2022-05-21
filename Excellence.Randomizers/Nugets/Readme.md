<!-- omit in toc -->
# Randomizers

<!-- omit in toc -->
## Table of contents

- [Overview](#overview)
- [Configurations](#configurations)
- [Randomizers](#randomizers)
  - [Create a randomizer](#create-a-randomizer)
  - [Add configurations](#add-configurations)
  - [Create resulting sets](#create-resulting-sets)
  - [`Copy`](#copy)

<br/>

## Overview

Randomizers are used to create the set of items randomly selected and then shuffled from a provided collection of items.

Every randomizer use configurations to create the resulting set.

A configuration defines the rules that are used by a randomizer.

<br />

## Configurations

Randomizer should have configurations added to create the resulting sets.

Configurations are created using default constructor. Then configuration methods define the rules.

**Example**:

```csharp
var configuration = new Configuration<int>();
configuration.UseItems(1, 2, 3);
configuration.UseMinCount(2);
configuration.UseMaxCount(10);
configuration.UseUnique(false);

// or

var configuration2 = new Configuration<int>()
    .UseItems(new List<int>() { 3, 4, 5, 6, 7, 8 })
    .UseMinCount(1)
    .UseMaxCount(5)
    .UseUnique(true);

// or

var configuration3 = new Configuration<int>();
configuration3.Use(new List<int>() { 1, 3, 5, 7, 9 }, 2, 4, false);
```

<br/>

## Randomizers

When configurations are ready a randomizer can create shuffled sets of randomly selected items.

<br/>

### Create a randomizer

Randomizers can be created using the `IRandomizerFactory`.

**Example**:

```csharp
var randomGenerator = new DefaultRandomGenerator();
var shuffler = new KnuthShuffler(randomGenerator);

var randomizerFactory = new RandomizerFactory(randomGenerator, shuffler);

var randomizer = randomizerFactory.CreateRandomizer<int>();
```

<br/>

### Add configurations

Configurations are added using `Use` methods.

Every configuration defines its own rules so the randomizer generates the resulting sets that match the rules of every configuration.

**Example**:

```csharp
randomizer.Use(configuration);

// or

randomizer.Use(new List<IConfiguration<int>>() { configuration2, configuration3 });
```

<br/>

### Create resulting sets

`Next` methods create the resulting sets.

**Example**:

```csharp
// one set
var randomSet = randomizer.Next();

// 5 sets
var randomSets = randomizer.Next(5);
```

<br/>

### `Copy`

`Copy` copies the randomizers with all configurations and returns a new randomizer instance. Instances are independent and adding configuration to one randomizer does not affect another one.

**Example**:

```csharp
var randomizerCopy = randomizer.Copy()
                .Use(configuration3.Copy());

var anotherRandomSet = randomizerCopy.Next();
var anotherRandomSets = randomizerCopy.Next(5);
```

<br/>
