using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace split

{
    internal class Program
    {

        public class Settings
        {
            public string Prefix { get; set; }
            public string ToLocation { get; set; }
            public string Suffix { get; set; }
            public string FromFile { get; set; }
            public int FromFileSize { get; set; }
            public int ChunkSize { get; set; }
            public bool Delete { get; set; }
            public int RandomAmount { get; set; }
            public int RunNum { get; set; }
        }
        
        private static bool stringInFile(string strSearch, string filePath="fileExtensions.txt") {
            return Program.stringInFile(strSearch, filePath);
        }


        private static int getInputInt(string prompt= "> ", int min = 1, int max = 2, int def = 1) {
            return Setup.Program.getInputInt(prompt, min, max, def);
        }

        private static string loadSettings(string file) {
            return JsonSerializer.Deserialize<Settings>(File.ReadAllText(file)).ToString();
        }

        private static void saveSettings (string file, string data) {
            File.WriteAllText(file, data);
        }

        private static string randomVar (int num=8){
            string Char = "abcdefghijklmnopqrstuvwxyz";
            char[] result = new char[num];
            for (int i = 0;i <num; i++) {
                result[i] = Char[new Random().Next(Char.Length)];
            } 
            return new string(result);
        }


        private static void place(string source, string destination, int chunckSize) {
        using (FileStream sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
        using (FileStream destinationStream = new FileStream(destination, FileMode.Create, FileAccess.Write)) {
                copyInChunks(sourceStream, destinationStream, chunckSize);
            }
        }
        private static void copyInChunks(FileStream source, FileStream destination, int chunkSize){
            byte[] buffer = new byte[chunkSize];
            int bytesRead;

            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0){
                destination.Write(buffer,0, bytesRead);
            }
        }

        private static void deleteOldFile(string file) {
            if  (File.Exists(file)){
                File.Delete(file);
            }
                
            else {
                Console.WriteLine($"yeah couldnt find {file} matey, \ndouble check it is there if you really want to delete it");
            }
                    
        }
    
        private static void finish(DateTime start) {
            DateTime end = DateTime.Now;
            Console.Write($"operation finished:\n total time taken = {end-start} seconds");
            Console.ReadLine();
        }
        private static void mainloop(string file) {
            JsonDocument jsonDoc = JsonDocument.Parse(File.ReadAllText(file));
            string prefix = jsonDoc.RootElement.GetProperty("prefix").GetString();
            string toLocation = jsonDoc.RootElement.GetProperty("toLocation").GetString();
            string suffix = jsonDoc.RootElement.GetProperty("suffix").GetString();
            string fromFile = jsonDoc.RootElement.GetProperty("fromFile").GetString();
            int fromFileSize = jsonDoc.RootElement.GetProperty("fromFileSize").GetInt32();
            int rands = jsonDoc.RootElement.GetProperty("randomAmount").GetInt32();
            int chunkSize = jsonDoc.RootElement.GetProperty("chunkSize").GetInt32();
            bool delete = jsonDoc.RootElement.GetProperty("delete").GetBoolean();
            int runNum = jsonDoc.RootElement.GetProperty("runNum").GetInt32();
        
            Console.Clear();
            Console.WriteLine("Process started (ctrl + c to cancel), bar below: ");
            string rand = randomVar(rands);
            place(fromFile, toLocation, chunkSize);

        }

        public static void Main (string[] args) {
            string file = @"C:\Users\finla\Documents\ffishstix\settings.fish";
            if (!File.Exists(file)) {
                Setup.Program.memp();
            } else{
                mainloop(file);
                
            }
        }

    }
}
