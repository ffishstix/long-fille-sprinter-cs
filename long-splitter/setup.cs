using System;
using System.Runtime.CompilerServices;
using System.IO;
namespace long_Splitter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("Current Directory: " + currentDirectory);
            
            // Step 2: Get the parent directory
            DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory);
            DirectoryInfo temp = Directory.GetParent(parentDirectory);
            Console.WriteLine("Parent Directory: " + parentDirectory.FullName);
            
            // Step 3: Construct the path to the data file
            // Assuming the data folder is named "data" and the file is named "myfile.txt"
            string dataFolderPath = Path.Combine(temp.FullName, "data");
            string filePath = Path.Combine(dataFolderPath, "fileExtensions.txt");
            int x = Program.getInputInt("give me ya best input ladey>", 1, 2, 1);
            bool t = stringInFile(".txt");
            Console.WriteLine(t);
            {
                
            }
        }
        static public int getInputInt(string prompt, int min = 1, int max = 2, int defaultNum = 1) {
            while (true) {
                Console.WriteLine(prompt);
                string userinput = Console.ReadLine();

                if (int.TryParse(userinput, out int number)){
                    if (number >= min && number <= max){
                        return number;
                    }
                    else {
                        Console.WriteLine("number is not within range: " + min + " to " + max);
                        Console.WriteLine("please try again ");
                    
                    }
                }
                else {
                    
                    if (string.IsNullOrWhiteSpace(userinput)) {
                        Console.WriteLine("default selected: " + defaultNum + " ");
                        return defaultNum;

                    }
                    else {
                        Console.WriteLine("input was not num");
                    }

                }
            }

        }

        static public bool stringInFile (string strSearch, string filePath="fileExtensions.txt") {
           try
        {
            // Read the file line by line and check if the string exists
            Console.WriteLine(filePath);
            foreach (string line in File.ReadLines(filePath))
            {
                if (line == strSearch)  // You can use line.Contains(strSearch) for partial matches
                {
                    return true;
                    
                }
                
            }return false;

            
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: The file was not found.");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
           
        } 
    }

}
