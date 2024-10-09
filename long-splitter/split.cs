using System.ComponentModel.DataAnnotations;

namespace split

{
    internal class Program
    {
        private static void Main(string[] args){
            Console.WriteLine("");
        }

        private static int getInputInt(string prompt= "> ", int min = 1, int max = 2, int def = 1) {
            return Setup.Program.getInputInt(prompt, min, max, def);
        }







    }
}