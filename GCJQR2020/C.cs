using System;
using System.Linq;

namespace GCJ2020
{
    class C
    {
        static void Main(string[] args)
        {
            // input
            var T = int.Parse(Console.ReadLine());
            var res = new string[T];

            for (int i = 0; i < T; i++)
            {
                var n = int.Parse(Console.ReadLine());
                //var task = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
                var task = new Tuple<int, int, int>[n];
                for (int j = 0; j < n; j++)
                {
                    var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    var s = input[0]; var e = input[1];
                    // taskのインデクスは0index
                    task[j] = Tuple.Create(j, s, e);
                }
                task = task.OrderBy(x => x.Item3).ToArray();

                /*
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("case " + task[j].Item3);
                }
                */

                // まず、片方チェック。該当しなかったら次へ。
                // 両方とも該当しなかったらIMPOを出す。
                // ソートすると、インデックスがわからなくなり、文字列の生成に問題が生じる。
                // タスクのインデックスをタプルにして情報として保持しておく。
                // char[]でi番目のタスクをインデクスiの要素として格納する

                int endC = int.MinValue;
                int endJ = int.MinValue;
                var anstemp = new char[n];
                var isImpossible = true;
                for (int j = 0; j < n; j++)
                {
                    // 終了時間が遅い方を選択する。
                    if (endJ <= endC)
                    {
                        // Cのほうが遅い。もしくは同じ場合。
                        if (endC <= task[j].Item2)
                        {
                            endC = task[j].Item3;
                            anstemp[task[j].Item1] = 'C';
                        }
                        else if (endJ <= task[j].Item2)
                        {
                            endJ = task[j].Item3;
                            anstemp[task[j].Item1] = 'J';
                        }
                        else { isImpossible = false; }
                    }
                    else
                    {
                        // Jの終了時間のほうが遅い場合。
                        if (endJ <= task[j].Item2)
                        {
                            endJ = task[j].Item3;
                            anstemp[task[j].Item1] = 'J';
                        }
                        else if (endC <= task[j].Item2)
                        {
                            endC = task[j].Item3;
                            anstemp[task[j].Item1] = 'C';
                        }
                        else { isImpossible = false; }
                    }
                }
                if (!isImpossible) res[i] = "IMPOSSIBLE";
                else res[i] = string.Join("", anstemp);
            }

            for (int i = 0; i < T; i++)
            {
                // 出力
                Console.WriteLine("Case #{0}: {1}", i + 1, res[i]);
            }
        }
    }
}
