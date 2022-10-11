// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var requiredFiles = FindFiles(storesDirectory);
var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory("salesTotalDir");

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

foreach(var file in requiredFiles){
    Console.WriteLine(file);
}

Console.WriteLine("Hello, World!");

IEnumerable<string> FindFiles(string folderName){
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    // foreach(var file in foundFiles){
    //     var extension = Path.GetExtension(file);

    //     if (extension == ".json"){
    //         salesFiles.Add(file);
    //     }
    // }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles){
    double SalesTotal = 0;

    foreach(var file in  salesFiles){
        string salesJson = File.ReadAllText(file);

        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        SalesTotal += data?.Total ?? 0;
    }

    return SalesTotal;
}

// Get current working directory
Console.WriteLine(Directory.GetCurrentDirectory());

// Find path of specific direcotry
string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
Console.WriteLine(docPath);

// Get corresponding path to file, directory irrespective of operating system convention
Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");

// Find paths using conventional joining 
Console.WriteLine(Path.Combine("stores", "203"));

// Determine file extension
Console.WriteLine(Path.GetExtension("sales.json"));

// Getting detailed information about a file or directory
string filename = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";
FileInfo info = new FileInfo(filename);
Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}");

// Creating a new Directory
string checkVariable(){
    string pat = Path.Combine("stores", "201", "timsNewDir");

    string message;

    if (Directory.Exists(pat) == true){
        message = "path already exist";

    }
    else {
        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "timsNewDir"));
        message = "Successfully created directory";
    }
    return message;
}

var checker = checkVariable();
Console.WriteLine(checker);

// File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "timsNewDir", "greetings.txt"), "Hello, World!");
// Console.WriteLine(File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}timsNewDir{Path.DirectorySeparatorChar}greetings.txt"));
var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data.Total}{Environment.NewLine}");

Console.WriteLine(salesData.Total);

class SalesTotal {
    public double Total { get; set; }
}

record SalesData (double Total);
