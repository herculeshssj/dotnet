// See https://aka.ms/new-console-template for more information
/*
Console.WriteLine("Hello, World!");

Console.WriteLine("What is your name?");
var name = Console.ReadLine();
var currentDate = DateTime.Now;
Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
Console.Write($"{Environment.NewLine}Press any key to exit...");
Console.ReadKey(true);
*/

// Exemplo de método
void mensagem() {
    Console.WriteLine("Hello World!");
}

List<int> pares = new List<int>();
List<int> impares = new List<int>();

pares.Add(12);
pares.Add(4);
pares.Add(16);
pares.Add(8);
pares.Add(10);

impares.Add(1);
impares.Add(3);
impares.Add(15);
impares.Add(7);
impares.Add(19);

//Console.WriteLine(pares.ToString());
//Console.WriteLine(impares.ToString());
/*
foreach(int numero in pares) {
    Console.Write(numero + " ");
}
*/
//Console.WriteLine();

// Generate a random number  
Random random = new Random(); 

// A random number within a range  
// int randomBetween100And500 = random.Next(100, 500);  
// Console.WriteLine(randomBetween100And500); 


// Console.WriteLine(impares.Count);

// 5 par 10 ímpares
//int contadorPar = 5;
//int contadorImpar = 10;

// 6 par 9 ímpar
//int contadorPar = 6;
//int contadorImpar = 9;

// 7 par 8 ímpar
//int contadorPar = 7;
//int contadorImpar = 8;

// 8 par 7 ímpar
//int contadorPar = 8;
//int contadorImpar = 7;

// 9 par 6 ímpar
//int contadorPar = 9;
//int contadorImpar = 6;

// 10 par 5 ímpar
int contadorPar = 10;
int contadorImpar = 5;

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


listaNumeros.Sort();
Console.WriteLine("5 pares 10 ímpares");
foreach(int num in listaNumeros) {
    if (num < 10)
        Console.Write("0" + num + " ");
    else
        Console.Write(num + " ");
}
Console.WriteLine();

/*
5 pares 10 ímpares
6 pares 9 ímpares
7 pares 8 ímpares
8 pares 7 ímpares
9 pares 6 ímpares
10 pares 5 ímpares
*/

mensagem();