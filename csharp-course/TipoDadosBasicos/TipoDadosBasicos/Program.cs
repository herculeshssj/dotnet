// See https://aka.ms/new-console-template for more information
Console.WriteLine("Tipos de dados básicos");

// Tipo sbyte
sbyte x = 100;
Console.WriteLine(x);

byte n1 = 126;
Console.WriteLine(n1);

int n2 = 1000;
Console.WriteLine(n2);
int n3 = 2 * 1024 * 1024 * 1023; // limite do tipo int
Console.WriteLine(n3);

long n4 = 2 * 1024L * 1024L * 1024L; // os valores são do tipo int, e o resultado também será do tipo int
// Preciso converter o resultado para long antes de armazenar na variável
Console.WriteLine(n4);

bool completo = false;
Console.WriteLine(completo);

char genero = 'F';
Console.WriteLine(genero);

char letra = '\u0041';
Console.WriteLine(letra);


float n5 = 4.5f;
double n6 = 4.5;
Console.WriteLine(n5);
Console.WriteLine(n6);

string nome = "Maria Green"; // String é imutável, igual Java
Console.WriteLine(nome);

// object em C# é igual Object em Java: todos os objetos herdam de object em C#
object obj1 = "Alex Brown";
object obj2 = 4.5;
Console.WriteLine(obj1);
Console.WriteLine(obj2);

// Os tipos tem métodos para informar o valor mínimo e máximo
int n10 = int.MinValue;
int n20 = int.MaxValue;
Console.WriteLine("Mínimo: " + n10);
Console.WriteLine("Máximo: " + n20);
