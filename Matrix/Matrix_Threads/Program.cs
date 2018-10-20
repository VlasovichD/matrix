using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Matrix_Threads
{    
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 40);

            Matrix myMatrix = new Matrix();
            
            //Creating and starting a 40 threads of chains
            for (int i = 0; i < 40; i++)
            {
                new Thread(myMatrix.MakeMatrix).Start(i * 2);
            }
            Thread.Sleep(1);
        }
    }
}
