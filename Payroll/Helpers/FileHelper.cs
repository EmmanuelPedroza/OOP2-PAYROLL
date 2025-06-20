using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payroll.Classes;

namespace Payroll.Helpers
{
    public static class FileHelper
    {
        public static string GetFilePath(string fileName)
        {
            // dir for the txt file relative to the exe or dll file
            string currentDirectory = Directory.GetCurrentDirectory();
            // dir for the txt file relative to the c# file
            string resDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\res\"));

            return Path.Combine(resDirectory, fileName);
        }

        /// <summary>
        /// Saves a list of employee to a file.
        /// </summary>
        /// <param name="fileName">The name of the file to save to.</param>
        /// <param name="appliances">The list of appliances to save.</param>
        public static void SaveToFile(string fileName, List<Employee> appliances)
        {
            string filePath = GetFilePath(fileName);
            //string[] lines = appliances.Select(appliance => appliance.FormatForFile()).ToArray();
            //File.WriteAllLines(filePath, lines);
        }

        /// <summary>
        /// Reads all lines from a file.
        /// </summary>
        /// <param name="fileName">The name of the file to read from.</param>
        /// <returns>An array of strings, each representing a line from the file.</returns>
        public static string[] ReadFromFile(string fileName)
        {
            string filePath = GetFilePath(fileName);
            return File.ReadAllLines(filePath);
        }
    }
}
