# D# Language Support for JetBrains Rider

Syntax highlighting configuration for D# language files (`.ds`) in JetBrains Rider and other IntelliJ-based IDEs.

## Features

- Syntax highlighting for D# files
- Support for D# keywords: `func`, `async func`
- Full C# syntax support
- Comment highlighting (line and block)
- Keyword and type recognition

## Installation

### Manual Installation

1. Locate your Rider configuration directory:
   - **Windows**: `%APPDATA%\JetBrains\Rider<version>\`
   - **macOS**: `~/Library/Application Support/JetBrains/Rider<version>/`
   - **Linux**: `~/.config/JetBrains/Rider<version>/`

2. Create the `fileTypes` directory if it doesn't exist

3. Copy `DSharp.xml` to the `fileTypes` directory

4. Restart Rider

5. Open any `.ds` file to see syntax highlighting

### Alternative: Import Settings

1. Open Rider
2. Go to `File` → `Manage IDE Settings` → `Import Settings...`
3. Select the `DSharp.xml` file
4. Choose to import File Types
5. Restart Rider

## D# Language Features

D# is a C#-based language with simplified syntax:

- `void` methods → `func` keyword
- `async Task` methods → `async func` keyword
- All other C# syntax remains the same

## Example

```dsharp
namespace MyApp;

public class Calculator
{
    // D# method using 'func' instead of 'void'
    public func Add(int a, int b)
    {
        Console.WriteLine($"Result: {a + b}");
    }

    // D# async method using 'async func' instead of 'async Task'
    public async func AsyncOperation()
    {
        await Task.Delay(1000);
        Console.WriteLine("Done!");
    }
}
```

## Notes

- This is a basic syntax highlighting configuration
- For full IDE support (IntelliSense, refactoring, etc.), a full Rider plugin would be needed
- Current implementation provides basic keyword and type highlighting

## Troubleshooting

If syntax highlighting doesn't work:

1. Make sure the file has `.ds` extension
2. Check that `DSharp.xml` is in the correct directory
3. Try invalidating caches: `File` → `Invalidate Caches / Restart...`
4. Verify that Rider recognizes the file type: `Settings` → `Editor` → `File Types`

## License

MIT

