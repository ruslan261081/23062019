using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW23062019_Async
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double> funcPie = new Func<double>(ReturnPie);
            IAsyncResult asyncResult = funcPie.BeginInvoke((IAsyncResult ar) =>
            {
                Console.WriteLine("after..........");

                Console.WriteLine(ar.AsyncState);

                double res = funcPie.EndInvoke(ar);
                Console.WriteLine("what was the result? " + res);
            }, "hello");
            Thread.Sleep(3000);
        }
        static double ReturnPie()
        {
            return 3.14;
        }
    }
}
