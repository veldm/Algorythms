using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace CoreTextLabyrinth
{
    public class Program
    {
        delegate Boolean Walk(int i, int j);
        
        /// <summary>
        /// Способ обхода массива
        /// </summary>
        static Walk Walker = CycleWalk;

        static int index = 0;

        static Char[,] CharMas =
            { {'A', 'E', 'D'},
              {'D', 'J', 'B'},
              {'A', 'B', 'C'} };

        static Boolean[,] VisitMas;

        static String SearchingString = "";

        static void Main(string[] args)
        {
            while (true)
            {
                SearchingString = "";
                String _SearchingString = "";
                while (_SearchingString == "")
                {
                    Clear();
                    WriteLine("Введите искомую строку");
                    _SearchingString = ReadLine().ToUpper();
                }
                if (WordSearch(_SearchingString)) WriteLine("Строка найдена");
                else WriteLine("Строка не найдена");
                ReadKey();
                WriteLine("\n");
            }
        }


        static public Boolean WordSearch(String _SearchingString)
        {
            if (_SearchingString.Length > 0) SearchingString = _SearchingString;
            else return false;
            for (int i = 0; i < CharMas.GetLength(0); i++)
            {
                for (int j = 0; j < CharMas.GetLength(1); j++)
                {
                    VisitMas = new Boolean
                        [CharMas.GetLength(0) + 1, CharMas.GetLength(1) + 1];
                    if (CharMas[i, j] == SearchingString.First())
                        if (Walker.Invoke(i, j)) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Обход массива в цикле
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        static private Boolean CycleWalk(int i, int j)
        {
            Stack<(int i, int j)> stack = new Stack<(int, int)>();
            for (index = 0; index < SearchingString.Length - 1; index++)
            {
                Boolean F = false;
                VisitMas[i, j] = true;

                if (i != CharMas.GetLength(0) - 1) if (!VisitMas[i + 1, j])
                        if (CharMas[i + 1, j] == SearchingString[index + 1])
                        {
                            stack.Push((i, j));
                            i++;
                            F = true;
                        }

                if (!F) if (i != 0) if (!VisitMas[i - 1, j])
                            if (CharMas[i - 1, j] == SearchingString[index + 1])
                            {
                                stack.Push((i, j));
                                i--;
                                F = true;
                            }

                if (!F) if (j != CharMas.GetLength(1) - 1) if (!VisitMas[i, j + 1])
                            if (CharMas[i, j + 1] == SearchingString[index + 1])
                            {
                                stack.Push((i, j));
                                j++;
                                F = true;
                            }

                if (!F) if (j != 0) if (!VisitMas[i, j - 1])
                            if (CharMas[i, j - 1] == SearchingString[index + 1])
                            {
                                stack.Push((i, j));
                                j--;
                                F = true;
                            }

                // Если не нашли продолжение
                if (!F)
                {
                    index -= 2;
                    try
                    {
                        i = stack.Peek().i;
                        j = stack.Pop().j;
                    }
                    catch { return false; }
                }
            }

            return true;
        }

        /// <summary>
        /// Рекурсивный обход массива
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        static private Boolean RekWalk(int i, int j)
        {
            VisitMas[i, j] = true;

            if (index == SearchingString.Length - 1) return true;

            index++;

            if (i != CharMas.GetLength(0) - 1) if (!VisitMas[i + 1, j])
                    if (CharMas[i + 1, j] == SearchingString[index + 1])
                        if (RekWalk(i + 1, j)) return true;

            if (i != 0) if (!VisitMas[i - 1, j])
                    if (CharMas[i - 1, j] == SearchingString[index + 1])
                        if (RekWalk(i - 1, j)) return true;

            if (j != CharMas.GetLength(1) - 1) if (!VisitMas[i, j + 1])
                    if (CharMas[i, j + 1] == SearchingString[index + 1])
                        if (RekWalk(i, j + 1)) return true;

            if (j != 0) if (!VisitMas[i, j - 1])
                    if (CharMas[i, j - 1] == SearchingString[index + 1])
                        if (RekWalk(i, j - 1)) return true;

            return false;

        }
    }
}
