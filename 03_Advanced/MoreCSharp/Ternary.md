# More C Sharp: Ternary Operator

<!-- TOC START min:2 max:4 link:true asterisk:false update:true -->
- [Introduction](#introduction)
- [Goal](#goal)
- [Process](#process)
- [Wrap-Up](#wrap-up)
- [Resources](#resources)
<!-- TOC END -->

## Introduction

The **Ternary** conditional operator is a shorthand way of writing a true-false condition. It's often used when checking boolean/flag values, and acting on their state.

The basic format of a ternary operation is:

`is this condition true ? yes : no`

And it can replace clunky code such as:

```C#
if (isReloading)
{
  timer = Time.deltaTime;
} else {
  timer = 0f;
}
```

with:

```C#
timer = isReloading ? Time.deltaTime : 0f;
```

## Goal

The purpose of this technique is to simplify code and increase readibility.

## Process

There really isn't any particular process here -- just keep an eye out for those `if-else` statements, and see if you can rewrite as a ternary operation.

## Wrap-Up

The ternary is a cool shorthand, and demonstrates an increasing facility with C#.

## Resources
- [C# Reference on Ternary](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator)
