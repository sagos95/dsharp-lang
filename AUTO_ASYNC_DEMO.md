# Автоматическая асинхронность в D#

## Концепция

В D# не нужно писать `async` и `await` вручную! Компилятор **автоматически определяет**, когда метод должен быть асинхронным, и сам добавляет все необходимые ключевые слова.

## Как это работает?

### 1. Автоматическое определение async/await

Если внутри D# метода есть вызовы Task-based операций, метод автоматически становится асинхронным:

**D# код:**
```csharp
public func DelayedPrint(string message)
{
    Console.WriteLine($"Before: {message}");
    Task.Delay(1000);  // Обратите внимание: НЕТ await!
    Console.WriteLine($"After: {message}");
}
```

**Сгенерированный C# код:**
```csharp
public async Task DelayedPrint(string message)
{
    Console.WriteLine($"Before: {message}");
    await Task.Delay(1000);  // await добавлен автоматически!
    Console.WriteLine($"After: {message}");
}
```

### 2. Автоматическая трансформация возвращаемых типов

| D# тип | C# тип (синхронный) | C# тип (асинхронный) |
|--------|---------------------|----------------------|
| `func` | `void` | `Task` |
| `int` | `int` | `Task<int>` |
| `string` | `string` | `Task<string>` |
| `MyClass` | `MyClass` | `Task<MyClass>` |

**Пример 1: func → Task**

D# код:
```csharp
public func ProcessData()
{
    Task.Delay(500);
    Console.WriteLine("Done");
}
```

C# код:
```csharp
public async Task ProcessData()
{
    await Task.Delay(500);
    Console.WriteLine("Done");
}
```

**Пример 2: int → Task<int>**

D# код:
```csharp
public int Calculate()
{
    Task.Delay(100);
    return 42;
}
```

C# код:
```csharp
public async Task<int> Calculate()
{
    await Task.Delay(100);
    return 42;
}
```

### 3. Автоматическое распространение (propagation)

Если метод A вызывает асинхронный метод B, то метод A **тоже автоматически становится асинхронным**:

**D# код:**
```csharp
public func MethodA()
{
    Console.WriteLine("Starting...");
    DelayedPrint("Hello");  // DelayedPrint - async метод
    Console.WriteLine("Done");
}
```

**Сгенерированный C# код:**
```csharp
public async Task MethodA()
{
    Console.WriteLine("Starting...");
    await DelayedPrint("Hello");  // await добавлен автоматически!
    Console.WriteLine("Done");
}
```

### 4. Fire-and-Forget с Run.Async

Иногда нужно запустить асинхронную операцию **без ожидания** её завершения. Для этого используйте `Run.Async()`:

**D# код:**
```csharp
public func StartBackgroundTask()
{
    Console.WriteLine("Starting background...");
    Run.Async(() => DelayedPrint("Background"));
    Console.WriteLine("Continued immediately");
}
```

**Сгенерированный C# код:**
```csharp
public void StartBackgroundTask()  // НЕ async - это синхронный метод!
{
    Console.WriteLine("Starting background...");
    Run.Async(() => DelayedPrint("Background"));  // БЕЗ await!
    Console.WriteLine("Continued immediately");
}
```

## Примеры

### Пример 1: Простой async метод

**D# (AutoAsync.ds):**
```csharp
public class DataService
{
    public string FetchData()
    {
        Task.Delay(1000);
        return "Data loaded";
    }
}
```

**C# (сгенерированный):**
```csharp
public class DataService
{
    public async Task<string> FetchData()
    {
        await Task.Delay(1000);
        return "Data loaded";
    }
}
```

### Пример 2: Цепочка вызовов

**D# код:**
```csharp
public class UserService
{
    public string LoadUser(int id)
    {
        Task.Delay(100);
        return $"User {id}";
    }
    
    public func ProcessUser(int id)
    {
        var user = LoadUser(id);  // LoadUser - async
        Console.WriteLine($"Processing: {user}");
    }
}
```

**C# код:**
```csharp
public class UserService
{
    public async Task<string> LoadUser(int id)
    {
        await Task.Delay(100);
        return $"User {id}";
    }
    
    public async Task ProcessUser(int id)
    {
        var user = await LoadUser(id);  // await добавлен автоматически!
        Console.WriteLine($"Processing: {user}");
    }
}
```

### Пример 3: Task.Run

**D# код:**
```csharp
public int CalculateInBackground()
{
    var result = Task.Run(() => HeavyCalculation());
    return result;
}
```

**C# код:**
```csharp
public async Task<int> CalculateInBackground()
{
    var result = await Task.Run(() => HeavyCalculation());
    return result;
}
```

## Правила определения асинхронности

Метод становится асинхронным, если внутри него есть:

1. ✅ `Task.Delay()`, `Task.Run()`, `Task.WhenAll()` и другие статические методы Task
2. ✅ Вызовы методов, содержащих "Async" в названии (например, `FetchDataAsync()`)
3. ✅ Вызовы методов, начинающихся с определённых префиксов:
   - `Get...` (GetUser, GetData)
   - `Fetch...` (FetchData)
   - `Load...` (LoadUser)
   - `Save...` (SaveData)
   - `Send...` (SendMessage)
   - `Process...` (ProcessData)
   - `Delayed...` (DelayedPrint)
4. ✅ Присваивания Task: `var task = Task.Run(...)`
5. ✅ Вызовы других D# методов, которые сами являются асинхронными

## Преимущества

### 🎯 Меньше boilerplate кода
Не нужно помнить про `async`/`await` - компилятор делает всё сам.

**Было (C#):**
```csharp
public async Task<string> GetUserAsync(int id)
{
    await Task.Delay(100);
    return await FetchFromDatabaseAsync(id);
}
```

**Стало (D#):**
```csharp
public string GetUser(int id)
{
    Task.Delay(100);
    return FetchFromDatabase(id);
}
```

### 🚀 Автоматическое распространение
Не нужно вручную добавлять `async`/`await` во всей цепочке вызовов.

### 🎨 Чистый синтаксис
Код выглядит как синхронный, но работает асинхронно.

## Заключение

D# делает асинхронное программирование **проще и естественнее**. Вы пишете код как обычно, а компилятор сам добавляет `async`/`await` где нужно.

Это особенно полезно для:
- Веб-приложений (API calls)
- Работы с базами данных
- Файловых операций
- Network операций
- Любых IO-bound операций

