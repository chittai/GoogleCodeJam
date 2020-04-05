using System;
using System.Linq;

namespace GCJ2020
{
    class A
    {
        static void Main(string[] args)
        {
            var T = int.Parse(Console.ReadLine());
            var res = new Tuple<int, int, int>[T];
            for (int t = 0; t < T; t++)
            {
                var N = int.Parse(Console.ReadLine());
                var nn = Enumerable.Range(0, N).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();

                var rowcount = 0;
                var colcount = 0;
                // 行
                for (int r = 0; r < N; r++)
                {
                    if (nn[r].Distinct().Count() != N) rowcount++;
                }
                // 列
                for (int c = 0; c < N; c++)
                {
                    var col = new int[N];
                    for (int r = 0; r < N; r++)
                    {
                        col[nn[r][c] - 1]++;
                    }
                    if (0 < col.Count(x => 1 < x)) colcount++;
                    //Console.WriteLine(string.Join(",", col));
                }
                // トレース計算
                var trace = 0;
                for (int r = 0; r < N; r++)
                {
                    for (int c = 0; c < N; c++)
                    {
                        if (r == c) trace += nn[r][c];
                    }
                }

                res[t] = Tuple.Create(trace, rowcount, colcount);

            }

            for (int i = 0; i < T; i++)
            {
                // 出力
                Console.WriteLine("Case #{0}: {1} {2} {3}", i + 1, res[i].Item1, res[i].Item2, res[i].Item3);

            }
        }
    }
}
