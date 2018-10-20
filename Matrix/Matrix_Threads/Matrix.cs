using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Matrix_Threads
{
    class Matrix
    {
        object block = new object();
        Random rand = new Random();

        public void MakeMatrix(object col)
        {
            int column = (int)col;
            char symbol;
            int chainLength = rand.Next(3, 15);
            int chainPozition = rand.Next(0, 40);

            while (true)
            {
                //Generating a new chain with random length
                if (chainPozition - chainLength == 40)
                {
                    chainPozition = 0;
                    chainLength = rand.Next(3, 15);
                }
                
                //Blocking other threads while recalculating a position of chain in current thread
                lock (block)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        Console.CursorLeft = column;

                        if (i >= chainPozition - chainLength && i <= chainPozition - 2)
                        {
                            symbol = (char)rand.Next(0x0041, 0x005A);
                            Console.CursorTop = i;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(symbol);
                        }
                        else if (i == chainPozition - 1)
                        {
                            symbol = (char)rand.Next(0x0041, 0x005A);
                            Console.CursorTop = i;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(symbol);
                        }
                        else if (i == chainPozition)
                        {
                            symbol = (char)rand.Next(0x0041, 0x005A);
                            Console.CursorTop = i;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(symbol);
                        }
                        else
                        {
                            Console.CursorTop = i;
                            Console.Write(" ");
                        }
                    }
                }
                chainPozition++;
            }
        }
    }
}
