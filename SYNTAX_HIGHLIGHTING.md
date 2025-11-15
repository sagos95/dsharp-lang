# D# Syntax Highlighting Setup

This guide explains how to enable syntax highlighting for D# (`.ds`) files in popular code editors.

## Visual Studio Code

### Quick Installation (Recommended)

1. Open VS Code
2. Copy the `vscode-dsharp` folder to your extensions directory:
   - **Windows**: `%USERPROFILE%\.vscode\extensions\dsharp-language-0.1.0\`
   - **macOS/Linux**: `~/.vscode/extensions/dsharp-language-0.1.0\`

3. Restart VS Code

4. Open any `.ds` file - syntax highlighting should work automatically!

### Package Installation (Alternative)

If you want to package the extension as `.vsix`:

```bash
# Install vsce (VS Code Extension Manager)
npm install -g @vscode/vsce

# Navigate to the extension directory
cd vscode-dsharp

# Package the extension
vsce package

# Install the generated .vsix file
code --install-extension dsharp-language-0.1.0.vsix
```

### Features in VS Code
- ✅ Syntax highlighting for D# keywords (`func`, `async func`)
- ✅ Full C# syntax support
- ✅ String interpolation highlighting
- ✅ Comment support
- ✅ Bracket matching and auto-closing
- ✅ Code folding

## JetBrains Rider

### Installation

1. Locate your Rider configuration directory:
   - **Windows**: `%APPDATA%\JetBrains\Rider<version>\fileTypes\`
   - **macOS**: `~/Library/Application Support/JetBrains/Rider<version>/fileTypes/`
   - **Linux**: `~/.config/JetBrains/Rider<version>/fileTypes/`

2. Copy the file `rider-dsharp/fileTypes/DSharp.xml` to the `fileTypes` directory

3. Restart Rider

4. Open any `.ds` file - syntax highlighting should work!

### Verify Installation in Rider

1. Go to `Settings` → `Editor` → `File Types`
2. You should see "D#" in the list of recognized file types
3. The `.ds` extension should be associated with D#

### Features in Rider
- ✅ Syntax highlighting for D# keywords (`func`, `async func`)
- ✅ Keyword and type recognition
- ✅ Comment highlighting
- ⚠️ Note: Full IntelliSense/refactoring requires a full Rider plugin (future enhancement)

## Testing the Installation

Try opening any of these example files to verify syntax highlighting:

- `DSharp.Sandbox/Example.ds`
- `DSharp.Sandbox/Calculator.ds`
- `DSharp.Sandbox/Comprehensive.ds`

You should see:
- `func` keyword highlighted in blue/purple (like other keywords)
- `async func` highlighted properly
- All C# syntax (strings, numbers, comments) highlighted correctly
- Proper color distinction between keywords, types, and identifiers

## Troubleshooting

### VS Code Issues

**Problem**: Extension not working after installation

**Solutions**:
1. Make sure the folder is named exactly `dsharp-language-0.1.0` in extensions directory
2. Restart VS Code completely (close all windows)
3. Check the extension is enabled: `Ctrl+Shift+X` → search for "D#"
4. Try opening a `.ds` file and check the language mode (bottom right corner)

**Problem**: Syntax highlighting looks wrong

**Solutions**:
1. Check your VS Code theme - some themes may color keywords differently
2. Force the language mode: Click language selector (bottom right) → Select "D#"

### Rider Issues

**Problem**: File type not recognized

**Solutions**:
1. Verify `DSharp.xml` is in the correct directory
2. Check file permissions (must be readable)
3. Try `File` → `Invalidate Caches / Restart...`
4. Manually add file type: `Settings` → `Editor` → `File Types` → `+` → Import from XML

**Problem**: Syntax highlighting not working

**Solutions**:
1. Make sure the file has `.ds` extension
2. Close and reopen the file
3. Check that D# file type is properly configured in settings

## Advanced: Customizing Colors

### VS Code

To customize D# syntax colors, add to your `settings.json`:

```json
{
  "editor.tokenColorCustomizations": {
    "textMateRules": [
      {
        "scope": "keyword.control.dsharp",
        "settings": {
          "foreground": "#569CD6",
          "fontStyle": "bold"
        }
      }
    ]
  }
}
```

### Rider

1. Go to `Settings` → `Editor` → `Color Scheme` → `D#`
2. Customize colors for different syntax elements

## What's Highlighted

### D# Specific Keywords
- `func` - void method declaration
- `async func` - async Task method declaration

### C# Keywords (all supported)
- Control flow: `if`, `else`, `while`, `for`, `foreach`, `switch`, `case`, etc.
- Types: `class`, `struct`, `interface`, `enum`, `void`, `int`, `string`, etc.
- Modifiers: `public`, `private`, `static`, `async`, `await`, etc.
- Constants: `true`, `false`, `null`, `this`, `base`

### Other Elements
- Strings (with interpolation support)
- Numbers (decimal, hex, binary)
- Comments (line and block)
- Attributes
- Preprocessor directives

## Future Enhancements

Potential improvements for the future:

- [ ] Full Rider plugin with IntelliSense support
- [ ] Code snippets for common D# patterns
- [ ] Semantic highlighting
- [ ] Error detection
- [ ] Auto-completion
- [ ] Refactoring support

## Contributing

If you improve the syntax highlighting, please share your changes!

1. Edit the grammar files:
   - VS Code: `vscode-dsharp/syntaxes/dsharp.tmLanguage.json`
   - Rider: `rider-dsharp/fileTypes/DSharp.xml`

2. Test your changes

3. Submit a pull request

## License

MIT - Free to use and modify

