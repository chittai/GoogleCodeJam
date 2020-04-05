using System;
using System.Linq;

namespace GCJ2020
{
    class B
    {
        static void Main(string[] args)
        {
            // input
            var n = int.Parse(Console.ReadLine());

            // for 0 - n:
            // input s
            //// for 0 - s.length
            //// 各桁の値をみる。
            //// sum を用意して、かっこを自分の前におく。そして、openだったらsumに足す。
            //// closeだったらsumから引く。最後までいったらsの中の最大値から
            /// sumを引いた値最後にカッコを置く
            var res = new string[n];
            for (int i = 0; i < n; i++)
            {
                var s = Console.ReadLine();
                var stemp = "";
                var sum = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    // 初回だけ別
                    var now = s[j] - '0';
                    if (j == 0) { stemp += new string('(', now); sum += now; }
                    if (j == s.Length - 1) { stemp += s[j]; continue; }
                    var next = s[j + 1] - '0';

                    // 先頭にopneを置く
                    if (now < next)
                    {
                        stemp += s[j];
                        stemp += new string('(', next - now);
                        sum += (next - now);
                    }
                    else if (next < now)
                    {
                        stemp += s[j];
                        stemp += new string(')', now - next);
                        sum -= (now - next);
                    }
                    else { stemp += s[j]; }
                }
                stemp += new string(')', sum);
                res[i] = stemp;
                //Console.WriteLine((s.Max() - '0'));
            }

            for (int i = 0; i < n; i++)
            {
                // 出力
                Console.WriteLine("Case #{0}: {1}", i + 1, res[i]);
            }
        }
    }
}
