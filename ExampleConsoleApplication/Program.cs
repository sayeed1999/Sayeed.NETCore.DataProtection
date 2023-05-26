using Sayeed.NETCore.DataProtection;

// declaring array of keywords that should be hidden from entity.
string[] keywords = new string[] { "phone", "email" };

// initializing an instance of helper class with customly defined keywords.
var helper = new Helper(keywords);

// creating mock entity to hide properties from.
var entity = new MockClass
{
    Name = "mock class",
    Phone = "880000000000",
};

// hiding sensative properties from original object.
helper.HideSensativeProperties(entity);

Console.WriteLine($"Name = {entity.Name}");
Console.WriteLine($"Phone = {entity.Phone}");
Console.WriteLine("Press any key to exit.");
Console.ReadKey();

class MockClass
{
    public string Name { get; set; }
    public string Phone { get; set; }
}