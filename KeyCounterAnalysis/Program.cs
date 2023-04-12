namespace KeyCounterAnalysis;

using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Listando os arquivos do diretório...");
        Console.WriteLine("");

        // Get the directory
        DirectoryInfo place = new DirectoryInfo(@"keycounter");

        // Using GetFiles() method to get list of all the files present in the directory
        FileInfo[] files = place.GetFiles();
        Console.WriteLine("Files are:");
        Console.WriteLine();

        // Display the file names
        foreach(FileInfo info in files) {

            if (info.Extension == ".day") {
                try {
                    Console.WriteLine("File name - {0}", info.Name);
                    StreamReader sr = new StreamReader(info.FullName);
                    string? line = sr.ReadLine();
                    while (line != null) {
                        line = sr.ReadLine();
                        string[] text = line.Split(",");
                        // Index 0 - key
                        // Index 1 - mouse
                    }
                    sr.Close();

                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
                
            }

            break;

        }

    }
}
