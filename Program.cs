using System;
using System.IO;
using System.Linq;

namespace searchColumnInsideFile
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string searchableFolder = @"C:\Users\suhigor\Downloads\дичь\txt";
                string columnsToBeSearched = @"C:\Users\suhigor\Downloads\дичь\columnsToBeSearched.txt";

                string[] columns = File.ReadAllLines(columnsToBeSearched);
                
                foreach (var f in Directory.EnumerateFiles(searchableFolder, "*.txt", SearchOption.AllDirectories))
                {
                    var filename = Path.GetFileName(f);

                    foreach (var searchedColumn in columns)
                    {
        
                        string textdata = File.ReadAllText(f);

                        if (textdata.Contains(searchedColumn))
                        {
                            Console.WriteLine("В файле "+ filename + " найден столбец: " + searchedColumn);
                           
                        }
                    }
                   Console.WriteLine("---------------------------------------------------------------------");
                }

                Console.ReadKey();

            }
            catch (UnauthorizedAccessException uAEx)
            {
                Console.WriteLine(uAEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                Console.WriteLine(pathEx.Message);
            }
        }
    }
}
