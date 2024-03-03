namespace EstruturaCondicional;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Estrutura condicional (if-else)");
        Console.WriteLine("-------------------------------");
    
        int a = 10;

        Console.WriteLine("Bom dia");

        if (a > 5) {
            Console.WriteLine("Boa tarde");
        }
        
        Console.WriteLine("Boa noite");

        Console.WriteLine("-------------------------------");
        Console.Write("Entre com um número inteiro: ");
        int x = int.Parse(Console.ReadLine());

        if (x % 2 == 0) {
            Console.WriteLine("Par");
        } else {
            Console.WriteLine("Ímpar");
        }

        Console.WriteLine("-------------------------------");
        Console.Write("Qual a hora atual? ");
        int hora = int.Parse(Console.ReadLine());

        if (hora < 12) {
            Console.WriteLine("Bom dia!");
        } else if (hora > 12 && hora < 18) {
            Console.WriteLine("Boa tarde!");
        } else if (hora >= 18) {
            Console.WriteLine("Boa noite!");
        } else {
            Console.WriteLine("Hora inválida!");
        }

    }
}
