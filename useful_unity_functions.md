# Useful Unity Comment Formatting

Check out https://docs.microsoft.com/en-us/dotnet/csharp/codedoc

# Useful Unity Keywords

### Private
```Private``` is used when declaring variables to hide that variable from other objects and functions. By default, the variable does not show up in the editor.

```C#
private GameObject player;
```
### Protected
```Protected``` is used when declaring variables to hide that variable from other objects and functions, except objects that inherit from the class it is declared in. By default, the variable does not show up in the editor.

```C#
protected GameObject player;
```
### Static

### Readonly

### Override

### Virtual

### Abstract

### Sealed

# Useful Unity Components

## Transform
Clearly, `Transform` is an essential component. But here are some useful features:

### localRotation
You'll need to use `localRotation` to explicitly assign rotation values to **child** objects.
> https://docs.unity3d.com/ScriptReference/Transform-localRotation.html
```C#
transform.localRotation = Quaternion.Euler(Vector3.up * scale);
```
## Time
Likewise, `Time` is also super important.
> https://docs.unity3d.com/ScriptReference/Time.html

# Useful Unity Functions

### InvokeRepeating 
Useful for things that need to repeat at regular intervals.
```C#
public void InvokeRepeating(string methodName, float time, float repeatRate);
```

### StartCoroutine
Useful for things that need timers, or functions that need to be threaded.
```C#
public Coroutine StartCoroutine(IEnumerator routine);
```
# Useful Unity Helpers

### Assertions
> https://docs.unity3d.com/ScriptReference/Assertions.Assert.html
