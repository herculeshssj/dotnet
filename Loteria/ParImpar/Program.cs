/*
    Premissa: pegar as dezenas pares e ímpares mais sorteadas, e gerar novos jogos onde estas dezenas apareçam de forma
    alternada:
    - 10 pares, 5 ímpares;
    - 9 pares, 6 ímpares;
    - 8 pares, 7 ímpares;
    - 7 pares, 8 ímpares;
    - 6 pares, 9 ímpares;
    - 5 pares, 10 ímpares.

    As 5 dezenas restantes são escolhidas aleatoriamente.
*/

namespace ParImpar;
class Program
{

    List<int> pares = new List<int>();
    List<int> impares = new List<int>();

    public List<int> gerarJogo(int contadorPar, int contadorImpar, List<int> pares, List<int> impares) {
        // Generate a random number  
        Random random = new Random(); 

        while(impares.Count < contadorImpar) {
            int randomBetween1and25 = random.Next(1,25);
            if (randomBetween1and25 % 2 != 0) {

                Boolean numeroExiste = false;
                foreach(int num in impares) {
                    if (num == randomBetween1and25) {
                        numeroExiste = true;
                        break;
                    }
                }

                if (!numeroExiste)
                    impares.Add(randomBetween1and25);

            }
        }

        while(pares.Count < contadorPar) {
            int randomBetween1and25 = random.Next(1,25);
            if (randomBetween1and25 % 2 == 0) {

                Boolean numeroExiste = false;
                foreach(int num in pares) {
                    if (num == randomBetween1and25) {
                        numeroExiste = true;
                        break;
                    }
                }

                if (!numeroExiste)
                    pares.Add(randomBetween1and25);

            }
        }

        List<int> listaNumeros = new List<int>();

        foreach(int num in impares) {
            listaNumeros.Add(num);
        }
        foreach(int num in pares) {
            listaNumeros.Add(num);
        }

        return listaNumeros;
    }

    static void Main(string[] args)
    {

        int contadorPar = 10;
        int contadorImpar = 5;
        List<int> listaNumeros;

        while (contadorPar >= 5) {
            
            listaNumeros = new List<int>();

            listaNumeros = new Program().gerarJogo(contadorPar, contadorImpar,
                new List<int>{10, 20, 4, 16, 12}, /* Dezenas Pares */
                new List<int>{9, 3, 13, 15, 5} /* Dezenas Ímpares */
            );

            listaNumeros.Sort();
            Console.WriteLine($"{contadorPar} pares {contadorImpar} ímpares");
            foreach(int num in listaNumeros) {
                if (num < 10)
                    Console.Write("0" + num + " ");
                else
                    Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            contadorPar--;
            contadorImpar++;
        }
          
    }
}
