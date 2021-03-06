# MyCashFlowSharp: A .NET library for MyCashFlow.

MyCashFlowSharp is a .NET library that enables you to authenticate and make API calls to MyCashFlow. It's great for 
building custom MyCashFlow Apps using C# and .NET. You can quickly and easily get up and running with MyCashFlow
using this library.

# Installation

MyCashFlowSharp is [available on NuGet](https://www.nuget.org/packages/MyCashFlowSharp/). Use the package manager
console in Visual Studio to install it:

```
Install-Package PrimePenguin.MyCashFlowSharp
```

If you're using .NET Core, you can use the `dotnet` command from your favorite shell:

```
dotnet add package MyCashFlowSharp
```

# Using MyCashFlowSharp

**Note**: All instances of `user_name` and `password` in the examples below **do not refer to your MyCashFlow credentials**.

```cs
var service = new ProductService(storName, userName, apiKey);
```

# APIS Implemented
- Order
- Product
