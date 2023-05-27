# Sayeed.NETCore.DataProtection

Sayeed.NETCore.DataProtection is a library that provides a helpful class for hiding sensitive properties within a C# object, even if they are nested within other objects or arrays. This library allows you to go through an object and its nested structures, like sub-objects and lists, to find any properties with sensitive keywords in their names. The class uses a default array of sensative keywords i.e ```"pass", "secret", "key", "pwd", "token"```. Once identified, the values of these properties are replaced with ```null```, ensuring that the sensitive information is hidden. It's a convenient tool to protect important data, such as passwords or tokens, in your application.

## Features

- Iterate over any C# object and its nested structures like sub-objects and lists and hide sensitive properties regardless of depth 
- Has versatile set of keywords to match almost every sensative properties that an entity may contain. ```Example, "pass" matches with Password, password, UserPass. "token" matches with JwtToken, AuthToken. "key" matches with ApiKey.```
- Supports custom set of sensitive keywords to match against property names to match your application needs
- Supports customization of maximum depth of the recursion loop (default value is 10)
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
The HideSensativeProperties method will recursively iterate over the object and its nested structures, like sub-objects and lists, searching for property names that contain sensitive keywords regardless of depth. If a match is found, the property value will be set to null. The method modifies the existing object, don't return anything.

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

#### Custom Set of Keywords and Maximum Depth
If you want to customize both the sensitive keywords and the maximum depth of the recursion loop, use the constructor that accepts both parameters:

```csharp
string[] customKeywords = new string[] { "custom", "keywords" };
int maxDepth = 5;
Helper helper = new Helper(customKeywords, maxDepth);
```

# Example

Here's a complete example of using Sayeed.NETCore.DataProtection to hide sensitive properties within nested objects and arrays across multiple levels of depth:

```csharp
using System;
using System.Collections.Generic;
using Sayeed.NETCore.DataProtection;

public class Website
{
    public string ApiKey { get; set; }
    public int Port { get; set; }
    public string Host { get; set; }
}

public class Student
{
    public string Roll { get; set; }
    public string StudentSecret { get; set; }
}

// Initializing the helper class
Helper helper = new Helper();

// Use your own set of custom keywords to match your business needs.
// Helper helper = new Helper(new string[] { "deletedBy", "counter", "count", "deletedAt" });

// Create an object with sensitive properties
Teacher teacher = new Teacher
{
    Name = "John Doe",
    Password = "secretpassword",
    Token = "sometoken",
    Website = new Website
    {
        ApiKey = "zxcvbnmlkjhgfdsa",
        Port = 5000,
        Host = "localhost"
    },
    Students = new List<Student>
    {
        new Student { Roll = "002", StudentSecret = "abababababbabb" },
        new Student { Roll = "003", StudentSecret = "zzxzxzxzxzxzx" },
    }
};

// Hide sensitive properties
helper.HideSensitiveProperties(teacher);

// Sensitive properties are now null
Console.WriteLine(teacher.Name); // "John Doe" (not sensitive)
Console.WriteLine(teacher.Password); // null
Console.WriteLine(teacher.Token); // null
Console.WriteLine(teacher.Website.ApiKey); // null
Console.WriteLine(teacher.Website.Port); // 5000 (not sensitive)
Console.WriteLine(teacher.Website.Host); // "localhost" (not sensitive)
Console.WriteLine(teacher.Students[0].Roll); // "002" (not sensitive)
Console.WriteLine(teacher.Students[0].StudentSecret); // null (sensitive)
Console.WriteLine(teacher.Students[1].Roll); // "003" (not sensitive)
Console.WriteLine(teacher.Students[1].StudentSecret); // null (sensitive)
```

## Contributing
Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue on the [GitHub repository](https://github.com/sayeed1999/Sayeed.NETCore.DataProtection).

## License
This library is licensed under the MIT License. See the LICENSE file for more details.

## Acknowledgements
This library was developed by [Md. Sayeed Rahman](https://www.linkedin.com/in/mdsayeedrahman1999/).
