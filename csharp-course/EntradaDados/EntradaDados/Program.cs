using System.Globalization;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Entrada de dados");
Console.WriteLine();

string frase  = Console.ReadLine();

Console.WriteLine("Você digitou '{0}'", frase);

string x = Console.ReadLine();
string y = Console.ReadLine();  
string z = Console.ReadLine();

Console.WriteLine("Você digitou '{0}', '{1}', '{2}'", x, y, z);

Console.Write("Digite 3 palavras: ");
string s = Console.ReadLine();
string[] vet = s.Split(" ");
Console.WriteLine(vet[0]);
Console.WriteLine(vet[1]);
Console.WriteLine(vet[2]);

Console.WriteLine();

// nome, idade, gênero, altura
Console.Write("Informe um nome: "); string nome = Console.ReadLine();
Console.Write("Informe a idade: "); int idade = int.Parse(Console.ReadLine());
Console.Write("Informe o gênero (M ou F): "); char genero = char.Parse(Console.ReadLine());
Console.Write("Informe a altura: "); double altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
Console.WriteLine();
Console.WriteLine("{0} tem {1}, é do gênero {2} e tem {3}m de altura.", nome, idade, genero, altura);




