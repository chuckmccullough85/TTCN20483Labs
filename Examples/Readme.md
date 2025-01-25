*Examples* contains source code and notebooks that demonstrates various features.

Most of the example code fragments are used in the slide deck.

## Notebooks
The notebooks are written in C# and are intended to be run in Visual Studio Code.  You will need the *Polyglot Notebooks* extension for Visual Studio Code.

When opening, you will need to first select the kernel.  The kernel for these notebooks is the `.Net Interactive` kernel.  To install this kernel, you will need to install the `dotnet-interactive` global tool.  You can do this by running the following command:

```powershell 
dotnet tool install -g Microsoft.dotnet-interactive
```

You will alson need the `Jupyter` extension for VS Code.  You can install this by running the following command:

```powershell
dotnet interactive jupyter install
```
