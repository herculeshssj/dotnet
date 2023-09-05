public class Combinador<T>
{

    // Referência: https://pt.stackoverflow.com/questions/10776/algoritmo-para-cria%c3%a7%c3%a3o-de-aposta-na-lotof%c3%a1cil
    
    private readonly int _cnt;
    private readonly T[] _items;
    private readonly List<int[]> _somatorios;

    public Combinador(int cnt, T[] items)
    {
        _cnt = cnt;
        _items = items;
        var line0 = new[] { 1 }.Concat(Enumerable.Repeat(0, cnt)).ToArray();
        var lines = new List<int[]>(cnt) { line0 };
        for (int itLine = 1; itLine <= cnt; itLine++)
        {
            var prevLine = lines[itLine - 1];
            var newLine = new int[line0.Length];
            for (int itCol = 0; itCol < newLine.Length; itCol++)
                newLine[itCol] = (itCol > 0 ? newLine[itCol - 1] : 0) + prevLine[itCol];
            lines.Add(newLine);
        }
        _somatorios = lines;
    }

    public T[] PegarCombinacao(int seed)
    {
        return GerarIndices(_somatorios, _items.Length - _cnt, _cnt, seed)
            .Select(i => _items[i])
            .ToArray();
    }

    private static IEnumerable<int> GerarIndices(List<int[]> lines, int fs, int ts, int num)
    {
        if (ts <= 0) yield break;
        var line = lines[ts];
        var min = 0;
        for (int itFs = 0; itFs <= fs; itFs++)
        {
            var max = min + line[itFs];
            if (num < max)
            {
                var num2 = num - min;
                yield return fs - itFs;
                foreach (var idx in GerarIndices(lines, itFs, ts - 1, num2))
                    yield return fs - itFs + idx + 1;
                yield break;
            }
            min = max;
        }

        throw new Exception("O parâmetro deve ser menor que " + min);
    }
}