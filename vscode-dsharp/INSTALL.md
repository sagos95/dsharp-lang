# Quick Installation Guide for VS Code

## Method 1: Direct Copy (Easiest)

1. Copy the entire `vscode-dsharp` folder to your VS Code extensions directory:

   **Windows**:
   ```
   %USERPROFILE%\.vscode\extensions\dsharp-language-0.1.0\
   ```

   **macOS**:
   ```
   ~/.vscode/extensions/dsharp-language-0.1.0/
   ```

   **Linux**:
   ```
   ~/.vscode/extensions/dsharp-language-0.1.0/
   ```

2. Restart VS Code

3. Open any `.ds` file - syntax highlighting will work automatically!

## Method 2: Symlink (For Development)

If you want to keep the extension in the project folder:

**macOS/Linux**:
```bash
ln -s /Users/alexander/Projs/dsharp/vscode-dsharp ~/.vscode/extensions/dsharp-language-0.1.0
```

**Windows** (run as Administrator):
```cmd
mklink /D "%USERPROFILE%\.vscode\extensions\dsharp-language-0.1.0" "C:\path\to\dsharp\vscode-dsharp"
```

Then restart VS Code.

## Method 3: Package as VSIX (Optional)

If you have Node.js installed:

```bash
# Install packaging tool
npm install -g @vscode/vsce

# Navigate to extension directory
cd vscode-dsharp

# Create package
vsce package

# Install the package
code --install-extension dsharp-language-0.1.0.vsix
```

## Verify Installation

1. Open VS Code
2. Open any `.ds` file from the project (e.g., `DSharp.Sandbox/Example.ds`)
3. Check the language mode in the bottom-right corner - it should show "D#"
4. The `func` and `async func` keywords should be highlighted

## Troubleshooting

If it doesn't work:
1. Make sure the folder name is exactly `dsharp-language-0.1.0`
2. Restart VS Code completely (close all windows)
3. Check Developer Console: `Help` → `Toggle Developer Tools` → Console tab
4. Look for any extension loading errors

