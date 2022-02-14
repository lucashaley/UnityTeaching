# More C Sharp: Generics

<!-- TOC START min:2 max:4 link:true asterisk:false update:true -->
- [Introduction](#introduction)
- [Goal](#goal)
- [Process](#process)
  - [Create the Attribute class](#create-the-attribute-class)
  - [Create the implementation code](#create-the-implementation-code)
- [Wrap-Up](#wrap-up)
- [Resources](#resources)
<!-- TOC END -->

## Introduction

In your prior C# coding efforts, you've used **types**. And noted that C# is a *strongly typed* language: that if you've defined a variable as a `float`,  you can't use it as a `string` without changing its type (*typecasting* or *unboxing*).

On the whole, this is a good thing: it means you have to be strict about what your data are, and how you use them. Discipline is good.

But as we delve into some deeper parts of C#, we'll need to start using a new type: the **Generic**. The Generic type is a non-typed placeholder for future assignment, and it allows you to create methods, classes, and data structures without a specific type, so you can define it later during assignment.

In code, the Generic class is simply `T`.

## Goal

To create a class that uses Generics, and create example code of how we would use that class with specific types.

## Process

Let's say you have an RPG with attributes that define each character. Those attributes miight be numeric, but sometimes they might be `int`s and sometimes they might be `float`s.

> Let's not get too picky about why you might do this IRL. Just go with it. Relax. Flow.

Using Generics, we can create one Attribute class, and choose what particular type to use it with later.

### Create the Attribute class

1. Create a new Attribute class.

    ```C#
    using UnityEngine;
    using System.Collections;

    public class Attribute
    {

    }
    ```

2. Next, let's define it as being a Generic, by adding `<T>` at the end of its class definition:

    ```C#
    using UnityEngine;
    using System.Collections;

    public class Attribute <T>
    {

    }
    ```

    > Note how we just say "this class will be generic later on!"

3. Then we add a variable to store the data. This will also be a generic:

    ```C#
    using UnityEngine;
    using System.Collections;

    public class Attribute <T>
    {
        T value;
    }
    ```

    > We don't know what type it is, so the variable is again simply `T`.

4. Lastly, we can make an accessor methods to get the value:

    ```C#
    using UnityEngine;
    using System.Collections;

    public class Attribute <T>
    {
        T value;

        public T SetValue<T>(T input)
        {
            value = input;
        }

        public T GetValue<T>
        {
            return value;
        }
    }
    ```

    > `T`s are everywhere!

### Create the implementation code

Now we can create some code that will instantiate some Attribute objects, each with their own type.

1. Create the script

    ```C#
    using UnityEngine;
    using System.Collections;

    public class GenerateAttributes : MonoBehaviour
    {
        void Start ()
        {   

        }
    }
    ```

2. Create an `int` attribute for how many arms the character has.

    ```C#
    using UnityEngine;
    using System.Collections;

    public class GenerateAttributes : MonoBehaviour
    {
        void Start ()
        {   
            Attribute<int> armsAttribute = new Attribute<int>;

            armsAttribute.SetValue(5);
            armsAttribute.GetValue();
        }
    }
    ```

    > So here we are actually defining what type it is, using the `<int>`. This replaces the `T` in the class definition.

3. Create a `float` attribute for the character's strength.

    ```C#
    using UnityEngine;
    using System.Collections;

    public class GenerateAttributes : MonoBehaviour
    {
        void Start ()
        {   
            Attribute<int> armsAttribute = new  Attribute<int>;

            armsAttribute.SetValue(5);
            armsAttribute.GetValue();

            Attribute<float> strengthAttribute = new Attribute<float>;

            strengthAttribute.SetValue(0.8);
            strengthAttribute.GetValue();
        }
    }
    ```

## Wrap-Up

Generics are quite tricky, and take some time to get used to them. They are often used in creating classes that iterate through things, like `List`s, where you have common functionality (loop through a bunch of similar things), but don't care what kind of things they are yet.

## Resources

- [C# Reference on Generics](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics)
- [Unity Learn on Generics](https://learn.unity.com/tutorial/generics)
