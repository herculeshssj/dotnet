namespace KeyCounterAnalysis;

using System.IO;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main(string[] args)
    {

        KeyCounter keyCounter = new KeyCounter();
        Console.WriteLine("Loading data to database...");
        keyCounter.processFiles();
        Console.WriteLine("Load completed!...");



        //keyCounter.hello();
        /*


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

        Console.WriteLine("Testando conexão com a base SQLite...");

        using (var connection = new SqliteConnection("Data Source=keycounter.db"))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                select * from track t ;
            ";
            //command.Parameters.AddWithValue("$id", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var name = reader.GetString(0);

                    Console.WriteLine($"Hello, {name}!");
                }
            }

            // UUID
            Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();


            // command WriteLine
            var commandWrite = connection.CreateCommand();
            commandWrite.CommandText = @"
                INSERT INTO track
                (id, day, hour, minute, keys, mouse)
                VALUES($id, $day, $hour, $minute, $keys, $mouse);
            ";
            commandWrite.Parameters.AddWithValue("$id", myuuidAsString);
            commandWrite.Parameters.AddWithValue("$day", "2023-01-15");
            commandWrite.Parameters.AddWithValue("$hour", 10);
            commandWrite.Parameters.AddWithValue("$minute", 15);
            commandWrite.Parameters.AddWithValue("$keys", 384);
            commandWrite.Parameters.AddWithValue("$mouse", 3928);

            commandWrite.ExecuteNonQuery();

            connection.Close();
        }
        */

    }
}

/* Gerar UUID 
using System;
using System.Diagnostics;

namespace SampleApplication {
    class Program {
        static void Main(string[] args) {
            Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();

            Debug.WriteLine("Your UUID is: " + myuuidAsString);
        }
    }
}
*/