# Useful Unity Functions

## InvokeRepeating 
Useful for things that need to repeat at regular intervals.
```C#
public void InvokeRepeating(string methodName, float time, float repeatRate);
```

## StartCoroutine
Useful for things that need timers, or functions that need to be threaded.
```C#
public Coroutine StartCoroutine(IEnumerator routine);
```

