// Referência: https://pt.stackoverflow.com/questions/10776/algoritmo-para-cria%c3%a7%c3%a3o-de-aposta-na-lotof%c3%a1cil

var comb = new Combinador<int>(15, Enumerable.Range(1, 25).ToArray());
var rnd = new Random();

// Criando os jogos de 1 a 1 e colocando num HashSet até ter N elementos
// esse método é rápido para poucas combinações, e vai ficando mais lento
// tendendo a infinito quando o número se aproxima da quantidade máxima.
// Mesmo assim, essa técnica é a recomendável para até 3 milhões de jogos.
// Use para 0% até 95% de todas as alternativas.
var numeros = new HashSet<int>();
int tentativas = 0;
while (numeros.Count < 200000)
{
    numeros.Add(rnd.Next(3268760));
    tentativas++;
}
var jogosAleatorios2 = numeros
    .Select(comb.PegarCombinacao)
    .ToArray();

// Criando todos os jogos e pegando N aleatórios
// esse método é lento, e não recomendo se não for
// gerar todos os jogos ou algo muito próximo de todos.
// Use somente para 95% até 100% de todas as alternativas.
var jogosAleatorios1 = Enumerable.Range(0, 3268760)
    .OrderBy(a => rnd.Next())
    .Select(comb.PegarCombinacao)
    .Take(100000)
    .ToArray();