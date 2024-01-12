// See https://aka.ms/new-console-template for more information

using System.Globalization;

// Diferença entre os métodos Console.WriteLine() e Console.Write()
Console.WriteLine("*** Impressão de texto no console ***");
Console.WriteLine("Bom dia!");
Console.Write("Boa tarde!");
Console.WriteLine("Boa noite!");

// Impressão de variáveis no console
Console.WriteLine("*** Impressão de variáveis no console ***");
char genero1 = 'F';
int idade1 = 32;
double saldo = 10.35784;
string nome = "Maria";

Console.WriteLine(genero1);
Console.WriteLine(nome);
Console.WriteLine(idade1);
Console.WriteLine(saldo);

// Imprimindo valores double controlando o número de casas decimais
Console.WriteLine(saldo.ToString("F2")); // F2 limita o número de casas decimais para 2 casas, fazendo o arredondamento
Console.WriteLine(saldo.ToString("F4")); // F4 limita o número de casas decimais para 4 casas

// Imprimindo valores double com formatação
Console.WriteLine(saldo.ToString("F3", CultureInfo.InvariantCulture));

/*** Placeholders, concatenação e interpolação ***/

// Usando placeholders
Console.WriteLine("{0} tem {1} anos, é do gênero {2} e tem {3} reais de saldo no banco.",
    nome, idade1, genero1, saldo);

// Usando placeholders e arredondando números double
Console.WriteLine("{0} tem {1} anos, é do gênero {2} e tem {3:F2} reais de saldo no banco.",
    nome, idade1, genero1, saldo);

// Usando interpolação - disponível do C# 6.0 em diante
Console.WriteLine($"{nome} tem {idade1} anos, é do gênero {genero1} e tem {saldo:F2} reais de saldo no banco.");

// Usando concatenação (igual em qualquer outra linguagem)
Console.WriteLine(nome + " tem " + idade1 + " anos, é do gênero " + genero1 + " e tem " + saldo.ToString("F2") + " reais de saldo no banco.");

Console.WriteLine();
Console.WriteLine("**********************");
Console.WriteLine("***** EXERCÍCIOS *****");
Console.WriteLine("**********************");
Console.WriteLine();

string produto1 = "Computador";
string produto2 = "Mesa de escritório";

byte idade = 30;
int codigo = 5290;
char genero = 'M';

double preco1 = 2100;
double preco2 = 650.50;
double medida = 53.234567;

Console.WriteLine("Produtos:");
Console.WriteLine($"{produto1}, cujo preço é $ {preco1}");
Console.WriteLine($"{produto2}, cujo preço é $ {preco2}");
Console.WriteLine();
Console.WriteLine($"Registro: {idade} anos de idade, código {codigo} e gênero: {genero}");
Console.WriteLine();
Console.WriteLine($"Medida com oito casas decimais: {medida:F8}");
Console.WriteLine($"Arredondado (três casas decimais): {medida:F3}");
Console.WriteLine($"Separador decimal invariant culture: {medida.ToString("F3", CultureInfo.InvariantCulture)}");

Console.WriteLine();
Console.WriteLine("***** FIM DOS EXERCÍCIOS *****");
