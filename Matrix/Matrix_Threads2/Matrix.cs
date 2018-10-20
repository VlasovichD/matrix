using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Matrix_Threads2
{
    class Matrix
    {
        object block = new object();
        Random rand = new Random();

        public void MakeMatrix(object col)
        {
            int column = (int)col;
            char symbol;
            int chainLength = rand.Next(3, 12);
            int chainLength2 = rand.Next(3, 12);
            int chainPozition = rand.Next(20, 40);
            int chainPozition2 = rand.Next(0, 20);

            while (true)
            {
                if (chainPozition - chainLength == 40)
                {
                    chainPozition = 0;
                    chainLength = rand.Next(3, 12);
                }

                if (chainPozition2 - chainLength2 == 40)
                {
                    chainPozition2 = 0;
                    chainLength2 = rand.Next(3, 12);
                }
               
                lock (block)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        Console.CursorLeft = column;
                                                
                        if ((i >= chainPozition - chainLength && i <= chainPozition - 2) || (i >= chainPozition2 - chainLength2 && i <= chainPozition2 - 2))
                        {
                            symbol = (char)rand.Next(0x0041, 0x005A);
                            Console.CursorTop = i;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write(symbol);
                        }
                        else if ((i == chainPozition - 1) || (i == chainPozition2 - 1))
                        {
                            symbol = (char)rand.Next(0x0041, 0x005A);
                            Console.CursorTop = i;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(symbol);
                        }
                        else if (i == chainPozition || i == chainPozition2)
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
                chainPozition2++;
            }
        }
    }
}