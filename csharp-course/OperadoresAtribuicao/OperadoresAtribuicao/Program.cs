// See https://aka.ms/new-console-template for more information
Console.WriteLine("Operadores de atribuição");

int a = 10;
Console.WriteLine("a recebe 10: {0}", a);

a += 2;
Console.WriteLine("a recebe a + 2: {0}", a);

a -= 2;
Console.WriteLine("a recebe a - 2: {0}", a);

a *= 2;
Console.WriteLine("a recebe a * 2: {0}", a);

a /= 2;
Console.WriteLine("a recebe a / 2: {0}", a);

a %= 3;
Console.WriteLine("a recebe a % 3: {0}", a);

string s = "ABC";
s += "DEF";
Console.WriteLine("Concatenação de string: {0}", s);

// Operadores de incremento/decremento

// ++ - a++ ou ++a -> a = a + 1;
// -- - a-- ou --a -> a = a - 1;
a++;
Console.WriteLine("a++: {0}", a);

a--;
Console.WriteLine("a--: {0}", a);

// Atribui e incrementa
int b = a++;
Console.WriteLine("Valor de a: {0}", a);
Console.WriteLine("Valor de b: {0}", b);

// Incrementa e atribui;
b = ++a;
Console.WriteLine("Valor de a: {0}", a);
Console.WriteLine("Valor de b: {0}", b);