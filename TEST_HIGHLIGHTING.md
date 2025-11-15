# Test Syntax Highlighting

This document helps verify that D# syntax highlighting is working correctly in your editor.

## How to Test

1. **Restart your editor** (VS Code or Rider)
2. Open any `.ds` file from the project
3. Check that the syntax is highlighted according to the examples below

## Expected Highlighting

### Test File 1: Example.ds

Open `DSharp.Sandbox/Example.ds` and verify:

✅ `func` keyword should be highlighted like `void` (as a keyword, usually blue/purple)
✅ `public static` should be highlighted as modifiers (usually blue)
✅ `Console.WriteLine` should show `Console` as a type
✅ String literals should be highlighted (usually orange/red)
✅ Comments should be highlighted (usually green/gray)

### Test File 2: Calculator.ds

Open `DSharp.Sandbox/Calculator.ds` and verify:

✅ `func` in multiple methods
✅ `private int _result;` - `private` and `int` highlighted
✅ String interpolation `$"..."` should work
✅ Numbers should be highlighted
✅ Block structure visible

### Test File 3: Comprehensive.ds

Open `DSharp.Sandbox/Comprehensive.ds` and verify:

✅ `async func` highlighted correctly (both words as keywords)
✅ `await Task.Delay` - `await` as keyword, `Task` as type
✅ Comments starting with `//`
✅ Control flow keywords: `if`, `for`, etc.

## Create a New Test File

Create a new file `Test.ds` with this content:

```dsharp
namespace DSharp.Test;

// This is a line comment
/* This is a 
   block comment */

public class TestHighlighting
{
    private readonly string _name;
    private int _counter = 0;

    public TestHighlighting(string name)
    {
        _name = name;
    }

    // Test D# func keyword
    public func SimpleMethod()
    {
        Console.WriteLine("Testing func keyword");
    }

    // Test D# async func keyword
    public async func AsyncMethod()
    {
        await Task.Delay(100);
        Console.WriteLine("Testing async func keyword");
    }

    // Test with parameters
    public func MethodWithParams(int value, string text, bool flag)
    {
        if (flag)
        {
            Console.WriteLine($"Value: {value}, Text: {text}");
        }
        else
        {
            Console.WriteLine("Flag is false");
        }
    }

    // Test loops
    public func LoopTest()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        while (_counter < 5)
        {
            _counter++;
        }

        foreach (var item in new[] { 1, 2, 3 })
        {
            Console.WriteLine(item);
        }
    }

    // Test strings
    public func StringTest()
    {
        var simple = "Simple string";
        var interpolated = $"Counter: {_counter}";
        var verbatim = @"C:\Path\To\File";
        var verbatimInterpolated = $@"Name: {_name}";
        var character = 'A';
    }

    // Test numbers
    public func NumberTest()
    {
        var decimal = 123;
        var hex = 0x7F;
        var binary = 0b1010;
        var floating = 3.14f;
        var doubleNum = 3.14159;
        var decimalNum = 123.45m;
        var scientific = 1.23e-4;
    }

    // Test return type (should use regular void, not func)
    public int GetValue()
    {
        return _counter;
    }

    // Test static method
    public static func StaticMethod()
    {
        Console.WriteLine("Static method");
    }

    // Test attributes
    [Obsolete("Use NewMethod instead")]
    public func OldMethod()
    {
        Console.WriteLine("Old method");
    }

    // Test preprocessor
    #region Test Region
    public func RegionMethod()
    {
        #if DEBUG
        Console.WriteLine("Debug mode");
        #else
        Console.WriteLine("Release mode");
        #endif
    }
    #endregion
}
```

## Checklist

After opening the test file, verify:

- [ ] `func` and `async func` are highlighted as keywords (not as identifiers)
- [ ] All C# keywords remain highlighted: `public`, `private`, `class`, `namespace`, `if`, `for`, `while`, `foreach`, `static`, `readonly`, `await`, `return`
- [ ] Type names are highlighted: `string`, `int`, `bool`, `Console`, `Task`
- [ ] String literals are highlighted (all types: simple, interpolated, verbatim)
- [ ] Numbers are highlighted (all types: decimal, hex, binary, float, double)
- [ ] Comments are highlighted (line and block)
- [ ] String interpolation expressions `{...}` show nested syntax highlighting
- [ ] Attributes `[...]` are highlighted
- [ ] Preprocessor directives `#region`, `#if`, etc. are highlighted
- [ ] Regular method with return type (using `void`, not `func`) works normally
- [ ] Brackets, parentheses, and braces are matched correctly

## Color Expectations

The exact colors depend on your theme, but typical expectations:

| Element | Typical Color |
|---------|--------------|
| Keywords (`func`, `if`, `public`, etc.) | Blue or Purple |
| Types (`int`, `string`, `Console`, etc.) | Teal or Cyan |
| Strings | Orange or Red |
| Numbers | Light Green or Light Blue |
| Comments | Green or Gray |
| Variables/Identifiers | White or Light Gray |
| Method names | Yellow or White |

## VS Code Specific Tests

### Language Mode
- Click the language indicator in the bottom-right corner
- It should show "D#" (not "Plain Text" or "C#")

### IntelliSense (Limited)
- Type `Console.` - you might not get IntelliSense (that requires full language server)
- Syntax highlighting should still work

### Folding
- Click the fold indicators next to methods, regions, etc.
- Code should fold/unfold correctly

## Rider Specific Tests

### File Type Recognition
1. Go to Settings → Editor → File Types
2. Find "D#" in the list
3. Verify `.ds` is associated with it

### Syntax Check
- Rider will show C# errors (since it's treating it as text, not compiling)
- This is expected - syntax highlighting works, but full IDE features require a plugin

## Troubleshooting

### VS Code: No Highlighting

**Check extension is loaded:**
```bash
code --list-extensions | grep dsharp
```

Should output: `dsharp.dsharp-language` or similar.

**Check language mode:**
- Open a `.ds` file
- Check bottom-right corner shows "D#"
- If not, click it and select "D#" manually
- If "D#" doesn't appear in the list, the extension isn't loaded

### Rider: No Highlighting

**Check file type:**
- Right-click a `.ds` file
- Look at "Associate with File Type..."
- It should show "D#"

**Manual association:**
1. Settings → Editor → File Types
2. Find "D#"
3. Add `*.ds` pattern if missing

## Success Criteria

✅ `func` keyword highlighted same as other keywords  
✅ `async func` both words highlighted as keywords  
✅ All C# syntax works  
✅ Files with `.ds` extension automatically use D# highlighting  
✅ No errors in editor console/logs  

If all above are true, syntax highlighting is working correctly! 🎉

