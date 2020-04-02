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

### 

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

