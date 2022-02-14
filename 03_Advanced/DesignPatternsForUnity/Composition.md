# Design Patterns for Unity: Composition

<!-- TOC START min:2 max:4 link:true asterisk:false update:true -->
- [Introduction](#introduction)
- [Goal](#goal)
- [Process](#process)
  - [Create the Interfaces](#create-the-interfaces)
  - [Create a damageable thing](#create-a-damageable-thing)
- [Wrap-Up](#wrap-up)
- [Resources](#resources)
<!-- TOC END -->

## Introduction

With Object-oriented languages, it's easy to create large family hierarchies. Objects can have children, grandchildren, etc etc.

But an object can only have *one* parent. This sometimes makes sharing functionality quite difficult: as to get common functionality, very different objects must share a common ancestor. This can lead to massive hierarchies (see: Java, circa 2000).

The design strategy called **Composition** uses Interfaces to *assemble* common functionality, like spec'ing out a computer in an online store. Want liquid cooling? Add it on. Want an  extra GPU? Add it on.

> This unit requires having read the unit on Interfaces first.

## Goal

In this unit we will use Interfaces and Composition to add a flexible damage system.

## Process

### Create the Interfaces

The first thing to do is create the script that defines our Interface.

1. Create a new script, called `Interfaces.cs`, and remove the bits about MonoBehaviour:

    ```C#
    using UnityEngine;
    using System.Collections;
    ```

2. Next, we define the Interace.

    ```C#
    using UnityEngine;
    using System.Collections;

    public Interface IDamageable
    {

    }
    ```
    > Note how we define it as an `Interface`, not a `Class`. And by starting the name of our Interface with an `I`, we tell anyone using it that it's an Interface.

3. Then we can define the methods needed:

    ```C#
    using UnityEngine;
    using System.Collections;

    public Interface IDamageable
    {
        public void Damage(int amount);
    }
    ```
    > Note how we don't need to actually say what the method does -- we leave that up to the implementing class. We just need to say which methods that class *must* implement.

### Create a damageable thing

Now that we have an Interface, let's create a dummy object that implements that Interface.

> IRL you'd add this to a real class.

1. Create a new script, called `Door.cs`.

    ```C#
    using UnityEngine;
    using System.Collections;

    public class Door : MonoBehaviour
    {

    }
    ```

2. Next, let's indicate that it will implement the `IDamageable` interface.

    ```C#
    using UnityEngine;
    using System.Collections;

    public class Door : MonoBehaviour, IDamageable
    {

    }
    ```
    > Note that if you try to run it now, you'll get an error that you haven't implemented the complete Interface.

3. Let's implement it! First, create a variable for health.

    ```C#
    using UnityEngine;
    using System.Collections;

    public class Door : MonoBehaviour, IDamageable
    {
        public int health;

    }
    ```

4. Then, create the method defined in the Interface.

    ```C#
    using UnityEngine;
    using System.Collections;

    public class Door : MonoBehaviour, IDamageable
    {
        public int health;

        public void Damage(int amount)
        {
            health -= amount;
        }
    }
    ```
    > Make sure your method declaration matches the Interface *exactly*, or you'll get errors.

You can then add this Interface to any object that can be damaged in your game. Every time you do, you can implement it as needed for that particular object.

> For example, the Door object might just keep taking damage until it's broken, whereas a NanoGhost might take 1/10 of the incoming damage until it dies.

Easy as!

## Wrap-Up

Using Interfaces and clever architecture, we can sgnificantly reduce our coding efforts and make our game more readible and effective.

Before delving too deeply on these, think about how you might use **Unity Components** instead -- they are already design by component! And you know how to use them.

For extra credit, consider how you can combine Interfaces with Generics.

## Resources
- [The Decorator Design Pattern](https://refactoring.guru/design-patterns/decorator)
