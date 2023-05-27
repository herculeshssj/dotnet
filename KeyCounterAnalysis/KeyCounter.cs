using Microsoft.Data.Sqlite;

namespace KeyCounterAnalysis;

public class KeyCounter {

/*
    Objetivo: realizar a carga dos dados existentes para a base SQlite. A execução será feita sempre no dia posterior
    à contagem dos passos para evitar problemas com concorrência.

    Passo a passo da execução
    0 - Obtém-se a data atual no formato yyyy-mm-dd
    1 - Abre uma conexão com a base SQlite
    2 - Verifica se a data de hoje existe na base
    2.1 - Caso a data atual exista na base, as informações daquela data serão apagadas
    3. Abre o diretório com os arquivos de rastreio
    4. Para cada arquivo de rastreio, será feito o insert de todos os dados na base
    4.1 - Haverá um contador para controlar hora e minuto, para que os mesmos sejam inseridos corretamente
    4.1.1 - Intervalo de hora: 0 - 23; Intervalo de minuto: 0 - 59
    4.2 - Antes do insert, gera-se um UUID que servirá de PK para o registro inserido
    5. Ao final, encerra a conexão com a base.
    

*/

    private Boolean dayExistsOnDatabase(string currentDate, SqliteConnection connection) {
        var command = connection.CreateCommand();
        command.CommandText = @"
            select count(*) from track where day = $day;
        ";
        command.Parameters.AddWithValue("$day", currentDate);

        var contagem = (long)command.ExecuteScalar();

        return contagem == 0 ? false : true ;
    }

    private void deleteCurrentDay(SqliteConnection connection) {
        var command = connection.CreateCommand();

        DateTime today = DateTime.Now;
        DateTime yesterday = DateTime.Now.AddDays(-1);

        command.CommandText = @"
            delete from track where day = $today or day = $yesterday;
        ";
        command.Parameters.AddWithValue("$today", today.ToString("yyyy-MM-dd"));
        command.Parameters.AddWithValue("$yesterday", yesterday.ToString("yyyy-MM-dd"));

        command.ExecuteNonQuery();
        
    }

    public void processFiles() {
        using (var connection = new SqliteConnection("Data Source=keycounter.db")) {
            
            connection.Open();

            DirectoryInfo keycounterDirectory = new DirectoryInfo(@"keycounter");
            FileInfo[] keycounterFileList = keycounterDirectory.GetFiles();

            // Delete current day and yesterday
            this.deleteCurrentDay(connection);

            foreach(FileInfo keycounterFile in keycounterFileList) {
                if (keycounterFile.Extension == ".day") {
                    try {
                        string[] filename = keycounterFile.Name.Split(".");
                        string currentDate = "20" + filename[0]; // FIXME não está no formato yyyy-mm-dd

                        if (this.dayExistsOnDatabase(currentDate, connection)) {
                            Console.WriteLine("Day already loaded: " + currentDate);
                            continue;
                        }
                
                        int hour = 0;
                        int minute = 0;
                        StreamReader reader = new StreamReader(keycounterFile.FullName);
                        string? line = reader.ReadLine();
                        Console.WriteLine("Loading day " + currentDate + "...");

                        while (line != null) {
                            Guid uuid = Guid.NewGuid();
                            string[] record = line.Split(",");
                            // Index 0 - key
                            // Index 1 - mouse

                            var command = connection.CreateCommand();
                            command.CommandText = @"
                                INSERT INTO track
                                (id, day, hour, minute, keys, mouse)
                                VALUES($id, $day, $hour, $minute, $keys, $mouse);
                            ";

                            command.Parameters.AddWithValue("$id", uuid.ToString());
                            command.Parameters.AddWithValue("$day", currentDate);
                            command.Parameters.AddWithValue("$hour", hour);
                            command.Parameters.AddWithValue("$minute", minute);
                            command.Parameters.AddWithValue("$keys", record[0]);
                            command.Parameters.AddWithValue("$mouse", record[1]);

                            command.ExecuteNonQuery();

                            minute++;
                            if (minute > 59) {
                                hour++;
                                minute = 0;
                            }
                            line = reader.ReadLine();

                        }


                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                    }
                }
            }

            connection.Close();
        }
    }
}