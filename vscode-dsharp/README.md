# D# Language Support for Visual Studio Code

Syntax highlighting extension for D# language files (`.ds`).

## Features

- Syntax highlighting for D# files
- Support for D# keywords: `func`, `async func`
- Full C# syntax support
- String interpolation highlighting
- Comment support (line and block)
- Bracket matching and auto-closing
- Code folding support

## Installation

### Option 1: Install from .vsix file (recommended)

1. Open VS Code
2. Press `Ctrl+Shift+P` (or `Cmd+Shift+P` on macOS)
3. Type "Extensions: Install from VSIX..."
4. Select the `dsharp-language-0.1.0.vsix` file

### Option 2: Install locally for development

1. Copy this `vscode-dsharp` folder to your VS Code extensions directory:
   - **Windows**: `%USERPROFILE%\.vscode\extensions\`
   - **macOS/Linux**: `~/.vscode/extensions/`

2. Restart VS Code

3. Open any `.ds` file to see syntax highlighting

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

## Building the Extension

To build a `.vsix` package:

```bash
npm install -g @vscode/vsce
cd vscode-dsharp
vsce package
```

This will create a `dsharp-language-0.1.0.vsix` file that can be installed in VS Code.

## License

MIT

