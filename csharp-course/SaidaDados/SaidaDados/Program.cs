// See https://aka.ms/new-console-template for more information

using System.Globalization;

// Diferença entre os métodos Console.WriteLine() e Console.Write()
Console.WriteLine("*** Impressão de texto no console ***");
Console.WriteLine("Bom dia!");
Console.Write("Boa tarde!");
Console.WriteLine("Boa noite!");

// Impressão de variáveis no console
Console.WriteLine("*** Impressão de variáveis no console ***");
char genero = 'F';
int idade = 32;
double saldo = 10.35784;
string nome = "Maria";

Console.WriteLine(genero);
Console.WriteLine(nome);
Console.WriteLine(idade);
Console.WriteLine(saldo);

// Imprimindo valores double controlando o número de casas decimais
Console.WriteLine(saldo.ToString("F2")); // F2 limita o número de casas decimais para 2 casas, fazendo o arredondamento
Console.WriteLine(saldo.ToString("F4")); // F4 limita o número de casas decimais para 4 casas

// Imprimindo valores double com formatação
Console.WriteLine(saldo.ToString("F3", CultureInfo.InvariantCulture));

/*** Placeholders, concatenação e interpolação ***/

// Usando placeholders
Console.WriteLine("{0} tem {1} anos, é do gênero {2} e tem {3} reais de saldo no banco.",
    nome, idade, genero, saldo);

// Usando placeholders e arredondando números double
Console.WriteLine("{0} tem {1} anos, é do gênero {2} e tem {3:F2} reais de saldo no banco.",
    nome, idade, genero, saldo);

// Usando interpolação - disponível do C# 6.0 em diante
Console.WriteLine($"{nome} tem {idade} anos, é do gênero {genero} e tem {saldo:F2} reais de saldo no banco.");

// Usando concatenação (igual em qualquer outra linguagem)
Console.WriteLine(nome + " tem " + idade + " anos, é do gênero " + genero + " e tem " + saldo.ToString("F2") + " reais de saldo no banco.");

