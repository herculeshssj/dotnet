namespace OperadoresLogicos;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Operadores Lógicos");

        // Precedência: ! > && > ||

        bool c1 = 2 > 3 || 4 != 5; // retorna true

        bool c2 = !(2 > 3) && 4 != 5; // retorna true

        Console.WriteLine(c1);
        Console.WriteLine(c2);

        Console.WriteLine("--------------------------");

        bool c3 = 10 < 5; // retorna false
        bool c4 = c1 || c2 && c3; // retorna true

        Console.WriteLine(c3);
        Console.WriteLine(c4);
    }
}
