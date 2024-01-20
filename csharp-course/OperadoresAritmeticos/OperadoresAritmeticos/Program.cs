// See https://aka.ms/new-console-template for more information
Console.WriteLine("Operadores aritméticos");
Console.WriteLine();
Console.WriteLine("Testando os operadores e sua precedência usando a Fórmula de Bhaskara");
Console.WriteLine();

double a = 1.0, b = -3.0, c = -4.0;

//double delta = b * b - 4.0 * a * c;
double delta = Math.Pow(b, 2) - 4.0 * a * c;

double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
double x2 = (-b + Math.Sqrt(delta)) / (2 * a);

Console.WriteLine("a: {0}", a);
Console.WriteLine("b: {0}", b);
Console.WriteLine("c: {0}", c);
Console.WriteLine("Delta: {0}", delta);
Console.WriteLine("x1: {0}", x1);
Console.WriteLine("x2: {0}", x2);