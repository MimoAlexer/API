using System.Reflection;
using APIGame.APIGame.API;

string solutionDirectory = Directory.GetCurrentDirectory();
string pluginsFolderPath = Path.Combine(solutionDirectory, "Plugins");

// Check if the plugins folder exists
if (!Directory.Exists(pluginsFolderPath))
{
    Directory.CreateDirectory(pluginsFolderPath);
    Console.WriteLine("Plugins folder created successfully.");
    return;
}
else
{
    Console.WriteLine("Plugins folder found!");
}

// Check if there are any plugins in the plugins folder
if (Directory.GetFiles(pluginsFolderPath).Length == 0)
{
    Console.WriteLine("No plugins found in the plugins folder.");
    return;
}
else
{
    Console.WriteLine("Plugins found in the plugins folder.");
}

// Ask the user if they want to run the plugins
Console.WriteLine("Are you sure you want to run the plugins? (Y/N)");
string? response = Console.ReadLine();
if (response == null)
{
    Console.WriteLine("Invalid response.");
    return;
}
else if (response.ToLower() == "n")
{
    Console.WriteLine("Exiting program.");
    return;
}
else if (response.ToLower() == "y")
{
    Console.WriteLine("Running plugins...");
}
else
{
    Console.WriteLine("Invalid response.");
    return;
}

// Load and run the plugins
List<Task> pluginTasks = new List<Task>();

foreach (string file in Directory.GetFiles(pluginsFolderPath))
{
    try
    {
        Assembly pluginAssembly = Assembly.LoadFile(file);
        foreach (Type type in pluginAssembly.GetTypes())
        {
            if (typeof(INitialize).IsAssignableFrom(type))
            {
                INitialize pluginInstance = (INitialize)Activator.CreateInstance(type);
                Task pluginTask = Task.Run(() => pluginInstance.Initialize());
                pluginTasks.Add(pluginTask);
                Console.WriteLine("Plugin initialized successfully: " + file);
            }
        }
        Console.WriteLine("----------------------------------------");
    }
    catch (Exception e)
    {
        Console.WriteLine("Error loading plugin: " + e.Message);
        throw;
    }
}

// Wait for all plugins to complete
Task.WaitAll(pluginTasks.ToArray());
Console.WriteLine("----------------------------------------");
Console.WriteLine("All plugins have been run.");