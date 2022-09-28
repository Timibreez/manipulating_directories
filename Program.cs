// See https://aka.ms/new-console-template for more information

var requiredFiles = FindFiles("stores");

foreach(var file in requiredFiles){
    Console.WriteLine(file);
}

Console.WriteLine("Hello, World!");

IEnumerable<string> FindFiles(string folderName){
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach(var file in foundFiles){
        if (file.EndsWith("sales.json")){
            salesFiles.Add(file);
        }
    }

    return salesFiles;
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
