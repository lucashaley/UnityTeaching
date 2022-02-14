# More C Sharp: Interfaces

<!-- TOC START min:2 max:4 link:true asterisk:false update:true -->
- [Introduction](#introduction)
- [Goal](#goal)
- [Process](#process)
- [Wrap-Up](#wrap-up)
- [Resources](#resources)
<!-- TOC END -->

## Introduction

Interfaces are ways of adding functionality to a class, outside of the inheritance hierarchies. This means that you can add things to a Class that do not exist in the parent class, but are *consistent* across different classes.

One way of thinking about an Interface is that it is a *contract* that the class adheres to. By adding an Interface to a class, you're guaranteeing that class will implement all the methods defined in the Interface.

> A cafe and a car rental both take reservations, but how they actually implement how that reservation works is very different; yet the *interface* of getting a reservation is exactly the same: you call up, tell them what you want, and they hold it for you.

> Why would you do this? In our example above, if we wanted to create consistent behavior across a cafe *and* car rental, we would need to have them both inherit from one parent: `Store`, for example. But there are some stores that don't use a reservation system! So we've created functionality that we then need to ignore. Ugh.

> Instead we can create an `IReserveable` interface, and add it to both the `Cafe` class and the `CarRental` class. Heck, we could also add it to the `PublicLibrary` class too!

>  In addition, we can now treat that object as the Interface type. So intead of referring to that object as a `gameObject`, you can refer to it as `IReserveable`. Just like you do when you refer to a GameObject as a `Transform` instead.

The contents of an Interface are pretty simple. It looks a lot like a class. Any methods you define are not defined -- you just make the declaration. You can include variables, but have a good think about how this would work.

On their own, Interfaces don't do anything. You have to *add* them to a class for the contract to come into effect.

Once you add it to a class, that class *must* implement everything defined in that Interface, or else you'll get errors.

> Much like a cafe takes your reservation for 4, but only gives you two chairs -- you'll complain too.

To implement, you create new versions of each method, and define how it works.

## Goal

The goal of Interfaces is to allow consistent functionality across hierarchies.

## Process

> Creating an Interface on its own doesn't make a lot of sense, so make sure you check out the [Composition](../DesignPatternsForUnity/Composition.md) unit to see how to implement one in a game setting.

This is what a basic Interface looks like:

```C#
using UnityEngine;
using System.Collections;

public Interface IContainer
{
    // variables to implement
    public int maxItems;

    // methods to implement
    public int ItemCount();
    public void Add(T item);
}
```

> Things to note:
    - we call it an `Interface` in the declaration
    - we *do not* implement the methods, we just declare them.

And to use the Interface, we might add it to a class like this:

```C#
using UnityEngine;
using System.Collections;

public Class Sack : MonoBehaviour, IContainer
{
    // implement the interface variable
    public int maxItems;

    // implement the interface methods
    public int ItemCount()
    {
        // do some stuff
    }
    public void Add(T item)
    {
        // do some stuff
    }
}
```

> Things to note:
    - we put the interface name after the class inheritance
    - we have to implement *all* of the methods


## Wrap-Up

## Resources
- [C# References on Interfaces](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces)
