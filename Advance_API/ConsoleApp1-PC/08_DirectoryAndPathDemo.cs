using System;
using System.IO;

namespace ConsoleApp1_PC
{
    internal class DirectoryAndPathDemo
    {
        public static void DirectoryAndPathDemoMethod()
        {
            string baseDirectory = @"F:\Rohanshu\DemoBackend - 1\AdvanceAPI";
            string subDirectory = "ConsoleApp1 - PC";
            string filePath = "file3.txt";
            //F:\Rohanshu\DemoBackend - 1\Advance_API\ConsoleApp1 - PC
            // Ensure the base directory exists
            if (!Directory.Exists(baseDirectory))
            {
                //Directory.CreateDirectory(baseDirectory);
                //Console.WriteLine($"Created directory: {baseDirectory}");
                Console.WriteLine("Base directory do not exists.");
            }

            // --- Demonstrating Path Methods ---
            Console.WriteLine("\nDemonstrating Path class methods:");

            // Combine paths
            string combinedPath = Path.Combine(baseDirectory, subDirectory);
            Console.WriteLine($"Combined path: {combinedPath}");

            // Get file name (from a full path)
            string fileName = Path.GetFileName(filePath);
            Console.WriteLine($"File name from '{filePath}': {fileName}");

            // Get file name without extension
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
            Console.WriteLine($"File name without extension from '{filePath}': {fileNameWithoutExt}");

            // Get file extension
            string fileExtension = Path.GetExtension(filePath);
            Console.WriteLine($"File extension from '{filePath}': {fileExtension}");

            // Get directory name from a full path
            string directoryName = Path.GetDirectoryName(filePath);
            Console.WriteLine($"Directory name from '{filePath}': {directoryName}");

            // Get full path (absolute path) from a relative path
            string relativePath = "DemoFile.txt";
            string fullPath = Path.GetFullPath(relativePath);
            Console.WriteLine($"Full path of '{relativePath}': {fullPath}");

            // Get the system's temporary folder path
            string tempPath = Path.GetTempPath();
            Console.WriteLine($"System temporary path: {tempPath}");

            // --- Demonstrating Directory Methods ---
            Console.WriteLine("\nDemonstrating Directory class methods:");

            // Check if the directory exists
            bool directoryExists = Directory.Exists(combinedPath);
            Console.WriteLine($"Does '{combinedPath}' exist? {directoryExists}");

            // Create a subdirectory if it doesn't exist
            if (!directoryExists)
            {
                Directory.CreateDirectory(combinedPath);
                Console.WriteLine($"Created subdirectory: {combinedPath}");
            }

            // Get files in the directory (here, we expect no files initially)
            string[] filesInDirectory = Directory.GetFiles(baseDirectory);
            Console.WriteLine("\nFiles in base directory:");
            foreach (var file in filesInDirectory)
            {
                Console.WriteLine(file);
            }

            // Get subdirectories in the directory (here, we expect the new subdirectory)
            string[] subdirectories = Directory.GetDirectories(baseDirectory);
            Console.WriteLine("\nSubdirectories in base directory:");
            foreach (var subdir in subdirectories)
            {
                Console.WriteLine(subdir);
            }

            // Set the current directory to the new subdirectory
            Directory.SetCurrentDirectory(combinedPath);
            Console.WriteLine($"\nChanged current directory to: {Directory.GetCurrentDirectory()}");

            // --- Clean up: Delete created directories ---
            Console.WriteLine("\nDeleting the created subdirectory...");
            Directory.Delete(combinedPath, true); // True to delete the subdirectory and its contents
            Console.WriteLine($"Deleted directory: {combinedPath}");
        }
    }
}
