# D# Editor Support

This document provides a quick reference for D# syntax highlighting in different editors.

## 📁 Extension Files Location

### VS Code Extension
```
vscode-dsharp/
├── package.json              # Extension manifest
├── language-configuration.json  # Brackets, comments config
├── syntaxes/
│   └── dsharp.tmLanguage.json  # TextMate grammar
├── README.md                 # Extension documentation
├── CHANGELOG.md              # Version history
├── INSTALL.md                # Installation guide
└── .vscodeignore             # Package exclusions
```

### Rider Configuration
```
rider-dsharp/
├── fileTypes/
│   └── DSharp.xml            # Language definition
└── README.md                 # Installation guide
```

## 🚀 Quick Installation

### VS Code (macOS)
```bash
ln -s "$(pwd)/vscode-dsharp" ~/.vscode/extensions/dsharp-language-0.1.0
# Then restart VS Code
```

### VS Code (Windows)
```cmd
mklink /D "%USERPROFILE%\.vscode\extensions\dsharp-language-0.1.0" "%CD%\vscode-dsharp"
# Then restart VS Code
```

### Rider (macOS)
```bash
cp rider-dsharp/fileTypes/DSharp.xml ~/Library/Application\ Support/JetBrains/Rider*/fileTypes/
# Then restart Rider
```

### Rider (Windows)
```cmd
copy rider-dsharp\fileTypes\DSharp.xml %APPDATA%\JetBrains\Rider*\fileTypes\
# Then restart Rider
```

## ✅ Verify Installation

### VS Code
1. Open any `.ds` file
2. Check language mode (bottom-right): should show "D#"
3. Keywords `func` and `async func` should be highlighted

### Rider
1. Go to Settings → Editor → File Types
2. "D#" should appear in the list
3. `.ds` extension should be associated with D#

## 🎨 What Gets Highlighted

### D# Keywords
- `func` - void method declaration
- `async func` - async Task method declaration

### C# Elements (all supported)
- Keywords: `if`, `else`, `for`, `while`, `class`, `public`, etc.
- Types: `int`, `string`, `bool`, `void`, etc.
- Strings: regular, verbatim (`@""`), interpolated (`$""`)
- Numbers: decimal, hex (`0x`), binary (`0b`)
- Comments: `//` and `/* */`
- Attributes: `[AttributeName]`
- Preprocessor: `#region`, `#if`, etc.

## 🔧 Customization

### VS Code Color Customization

Add to your `settings.json`:

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

### Available Scopes
- `keyword.control.dsharp` - D# keywords (func, async func)
- `comment.line.double-slash.dsharp` - Line comments
- `comment.block.dsharp` - Block comments
- `string.quoted.double.dsharp` - Strings
- `constant.numeric.dsharp` - Numbers
- `storage.modifier.dsharp` - Modifiers (public, static, etc.)
- `entity.name.type.dsharp` - Type names

## 🐛 Troubleshooting

### VS Code: Extension Not Loading

**Check extension is installed:**
```bash
ls ~/.vscode/extensions/ | grep dsharp
```

**Should output:**
```
dsharp-language-0.1.0
```

**Force reload:**
1. Cmd+Shift+P (Ctrl+Shift+P on Windows)
2. Type "Developer: Reload Window"
3. Press Enter

**Check for errors:**
1. Help → Toggle Developer Tools
2. Go to Console tab
3. Look for extension loading errors

### Rider: File Type Not Recognized

**Check file was copied:**
```bash
# macOS
ls ~/Library/Application\ Support/JetBrains/Rider*/fileTypes/ | grep DSharp

# Linux  
ls ~/.config/JetBrains/Rider*/fileTypes/ | grep DSharp
```

**Manually add file type:**
1. Settings → Editor → File Types
2. Click "+" to add new file type
3. Import from XML
4. Select `DSharp.xml`

**Clear caches:**
1. File → Invalidate Caches / Restart...
2. Select "Invalidate and Restart"

## 📦 Package Extension (Optional)

### Create VSIX Package

```bash
# Install packaging tool
npm install -g @vscode/vsce

# Navigate to extension
cd vscode-dsharp

# Create package
vsce package

# Install
code --install-extension dsharp-language-0.1.0.vsix
```

## 📚 Documentation

For detailed documentation, see:
- [SYNTAX_HIGHLIGHTING.md](SYNTAX_HIGHLIGHTING.md) - Complete guide
- [vscode-dsharp/README.md](vscode-dsharp/README.md) - VS Code extension docs
- [rider-dsharp/README.md](rider-dsharp/README.md) - Rider configuration docs

## 🤝 Contributing

To improve syntax highlighting:

1. **VS Code**: Edit `vscode-dsharp/syntaxes/dsharp.tmLanguage.json`
2. **Rider**: Edit `rider-dsharp/fileTypes/DSharp.xml`
3. Test your changes
4. Update version numbers
5. Update CHANGELOG

## 📝 License

MIT

