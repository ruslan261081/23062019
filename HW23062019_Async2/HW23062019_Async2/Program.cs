using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW23062019_Async2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string> funcString = new Func<string>(ReturnString);
            funcString += ReturnString;
            funcString += ReturnString;

            string AllString = "", res = "";
            foreach(Func<string> method in funcString.GetInvocationList())
            {
                IAsyncResult async = method.BeginInvoke((IAsyncResult ar) =>
                {
                    res = method.EndInvoke(ar);
                    AllString += res;
                }, null);

            }
            Thread.Sleep(1000);
            Console.WriteLine($"Result is: {AllString}");
        }
        static string ReturnString()
        {
            return "I Belive I Can Fly  ";
        }
    }
}
