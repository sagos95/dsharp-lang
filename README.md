# D# Language

D# (D-Sharp, or "Domain Sharp") is an experimental language extension for C# that provides alternative syntax while compiling to standard C#. D# is domain driven design oriented and aims to provide an environment where it is impossible to write bad or incorrect architectures.

## Features

- **Automatic asynchronous code generation**: No more async-await bullshit! You don't have to write `async` and `await` 100500 times. D# automatically detects `Task` methods and always awaits them. If you really want to run some method asynchronously – just use `Run.Async(() => Method());` construction. Because you don't need asynchronous calls that often, huh? And yes, `async` and `Task<>` types will automatically propagate to all the necessary methods. Seriously, guys, stop worrying about async-await.
- **`func` keyword**: Use `func` instead of `void` for methods that don't return a value. No more avoiding in your favorite code language.
- **`.ds` file extension**: Write D# code in `.ds` files
- **Automatic compilation**: D# code is automatically translated to C# during build time using Source Generators

## Project Structure

- **DSharp.Generator**: Source generator that translates `.ds` files to C# code
- **DSharp.Sandbox**: Playground project to experiment with D# language features

## Getting Started

### Prerequisites

- .NET 9 SDK

### Building the Project

```bash
dotnet build
```

### Running the Sandbox

```bash
dotnet run --project DSharp.Sandbox
```

### Writing D# Code

Create a `.ds` file in the `DSharp.Sandbox` project:

```csharp
namespace DSharp.Sandbox.Generated;

public static class MyClass
{
    public static func MyMethod()
    {
        Console.WriteLine("Using func instead of void!");
    }
}
```

The source generator will automatically convert this to:

```csharp
namespace DSharp.Sandbox.Generated;

public static class MyClass
{
    public static void MyMethod()
    {
        Console.WriteLine("Using func instead of void!");
    }
}
```

## How It Works

1. Write code in `.ds` files using D# syntax
2. The `DSharpSourceGenerator` reads all `.ds` files during compilation
3. D# keywords (like `func`) are translated to C# equivalents (like `void`)
4. Generated C# code is added to the compilation automatically
5. Use the generated classes in your regular C# code

## Supported Features

Currently implemented D# language features:

| D# Syntax | C# Translation | Description |
|-----------|---------------|-------------|
| `func MethodName()` | `void MethodName()` | Non-returning methods |
| `func MethodName()` | `async Task MethodName()` | Async methods without return value, if there are any awaitable Tasks in the method body |

## Examples

### Example 1: Basic Methods

**D# Code (Example.ds):**
```csharp
public static func HelloWorld()
{
    Console.WriteLine("Hello from D#!");
}
```

**Generated C# Code:**
```csharp
public static void HelloWorld()
{
    Console.WriteLine("Hello from D#!");
}
```

### Example 2: Async Methods

**D# Code (AsyncExample.ds):**
```csharp
public static func DelayedPrint(string message, int delayMs)
{
    Console.WriteLine($"Starting: {message}");
    Task.Delay(delayMs);
    Console.WriteLine($"Completed: {message}");
}
```

**Generated C# Code:**
```csharp
public static async Task DelayedPrint(string message, int delayMs)
{
    Console.WriteLine($"Starting: {message}");
    await Task.Delay(delayMs);
    Console.WriteLine($"Completed: {message}");
}
```

## Syntax Highlighting

D# now has syntax highlighting support for popular code editors!

### Visual Studio Code

Install the D# extension for VS Code:

```bash
# Create symlink to the extension
ln -s /Users/alexander/Projs/dsharp/vscode-dsharp ~/.vscode/extensions/dsharp-language-0.1.0

# Or copy the extension directory
cp -r vscode-dsharp ~/.vscode/extensions/dsharp-language-0.1.0
```

Then restart VS Code. See [SYNTAX_HIGHLIGHTING.md](SYNTAX_HIGHLIGHTING.md) for detailed instructions.

### JetBrains Rider

Copy the configuration file:

```bash
# macOS
cp rider-dsharp/fileTypes/DSharp.xml ~/Library/Application\ Support/JetBrains/Rider*/fileTypes/

# Linux
cp rider-dsharp/fileTypes/DSharp.xml ~/.config/JetBrains/Rider*/fileTypes/

# Windows
copy rider-dsharp\fileTypes\DSharp.xml %APPDATA%\JetBrains\Rider*\fileTypes\
```

Then restart Rider. See [SYNTAX_HIGHLIGHTING.md](SYNTAX_HIGHLIGHTING.md) for detailed instructions.

## Project Statistics

- **.NET Version**: .NET 9.0
- **Generator Target**: .NET Standard 2.0 (for Roslyn compatibility)
- **Source Generator**: Incremental Source Generator (IIncrementalGenerator)
- **File Extension**: `.ds` (D# files)
- **Supported Editors**: VS Code, Rider (with syntax highlighting)

## Future Extensions

Later there will be constructs like
`slice` for declaring subdomains:

```
slice EShop.AddOrderItem;
slice EShop.RemoveOrderItem;
```

DI shortcuts (lifetime types instead of the word “class”):

```
singleton AddOrderItemHandler { ... }
transient OrderItemsMySqlRepository { ... }
```

Automatic storage of domain models together with their domain events:

```
entity OrderItem { ... }
```

And other constructs that explicitly enforce a hexagonal-architecture style, making it impossible to violate boundaries and dependencies.

```
infrastructure EShop.MySql;
application EShop.Order;
domain EShop.Order;
Error ds5012: Unable to use MySql package in domain layer. Domain layers must not depend on infrastructure layers.
```

Other potential features to add:
- Simplified syntax for common patterns
- Custom operators
- Macro system
- Advanced type inference
- Full IDE plugin with IntelliSense (beyond syntax highlighting)

