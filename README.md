# Sayeed.NETCore.DataProtection

Sayeed.NETCore.DataProtection is a library that provides a helper class for hiding sensitive properties within C# objects. It allows you to iterate over an object and identify any property names that contain sensitive keywords, and then hide their values. This library can be used to protect sensitive information within your application, such as passwords, tokens, or any other sensitive data.

## Features

- Iterate over any C# object and hide sensitive properties
- Customizable set of sensitive keywords to match against property names
- Customizable maximum depth of recursion loop
- Supports classes, records, and pre-defined types (anonymous objects are not supported)

## Installation

You can install the Sayeed.NETCore.DataProtection library via NuGet. Run the following command in the NuGet Package Manager Console:

```csharp
Install-Package Sayeed.NETCore.DataProtection
```

## Usage

1. Create an instance of the `Helper` class, which provides various constructors to customize the behavior:
```csharp
Helper helper = new Helper();
```
2. Call the HideSensativeProperties method and pass the object you want to process:
```csharp
MyClass myObject = new MyClass();
helper.HideSensativeProperties(myObject);
```
The HideSensativeProperties method will recursively iterate over the object and its properties, searching for property names that contain sensitive keywords. If a match is found, the property value will be set to null. The method modifies the existing object, don't return anything.

## Customization

#### Custom Set of Sensitive Keywords
You can provide your own set of sensitive keywords to match against property names by using the constructor that accepts an array of strings:

```csharp
string[] customKeywords = new string[] { "custom", "keywords" };
Helper helper = new Helper(customKeywords);
```

#### Maximum Depth of Recursion Loop
By default, the maximum depth of the recursion loop is set to 10. You can customize this value using the constructor that accepts an integer:

```csharp
int maxDepth = 5;
Helper helper = new Helper(maxDepth);
```

####Custom Set of Keywords and Maximum Depth
If you want to customize both the sensitive keywords and the maximum depth of the recursion loop, use the constructor that accepts both parameters:

```csharp
string[] customKeywords = new string[] { "custom", "keywords" };
int maxDepth = 5;
Helper helper = new Helper(customKeywords, maxDepth);
```

## Examples

Here's an example of using Sayeed.NETCore.DataProtection to hide sensitive properties within an object:

```csharp
Helper helper = new Helper();

// Create an object with sensitive properties
MyClass myObject = new MyClass
{
    Password = "secretpassword",
    Token = "sometoken",
    Name = "John Doe"
};

// Hide sensitive properties
helper.HideSensativeProperties(myObject);

// Sensitive properties are now null
Console.WriteLine(myObject.Password); // null
Console.WriteLine(myObject.Token); // null
Console.WriteLine(myObject.Name); // "John Doe" (not sensitive)
```

## Contributing
Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue on the [GitHub repository](https://github.com/sayeed1999/Sayeed.NETCore.DataProtection).

## License
This library is licensed under the MIT License. See the LICENSE file for more details.

## Acknowledgements
This library was developed by [Md. Sayeed Rahman](https://www.linkedin.com/in/mdsayeedrahman1999/).
