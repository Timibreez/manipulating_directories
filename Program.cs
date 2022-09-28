﻿// See https://aka.ms/new-console-template for more information

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

Console.WriteLine(Directory.GetCurrentDirectory());

string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
Console.WriteLine(docPath);

Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");

Console.WriteLine(Path.Combine("stores", "203"));