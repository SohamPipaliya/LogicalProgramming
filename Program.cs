using System;
using System.Text;
using static System.Console;

namespace Logical
{
    public static class Program
    {
        static void Main(string[] args)
        {
        here:
            Console.WriteLine(ReverseDigitWithReturn(123, 2));
            ReverseDigitWithRecursion(123, 2);
            Console.WriteLine(FindSubStringWithRecursion("abcd"));
            Console.WriteLine(RemoveCharacter("abcd", 'a'));
            Console.WriteLine(RemoveCharacterOneTime("aaabcd", 'a'));
            Console.WriteLine(letCharacterOneTime("aaaaabcd", 'a'));
            Console.WriteLine(CheckStringPalindrome("abc"));
            Console.WriteLine(CheckStringPalindromeWithRecursion("abcba"));
            Console.WriteLine(FindPositions(new int[] { 1, 2, 3, 4, 8, 5, 6, 7, 8, -80 }, -80));
            //Pyramid(10);
            //PyramidABCD(10);
            //PyramidWithRecursion(50);
            //PyramidReverseABCD(100);
            //GeneralABCD(10);
            //GeneralReverseABCD(10);
            //PyramidWithRecursion(10);
            //Console.WriteLine(PyramidWithRecursionWithReturn(10));
            //PyramidReverseABCDWithRecursion(50);
            //GeneralReverseABCDWithRecursion(10);
            //Console.WriteLine(GeneralReverseABCDWithRecursionWithReturn(10));

            Console.ReadLine();
            goto here;
        }

        static void ReverseDigitWithRecursion(int arg, int index, string str = "")
        {
            str += arg.ToString()[index];
            if (index > 0) ReverseDigitWithRecursion(arg, index - 1, str);
            else Console.WriteLine(str);
        }

        static int ReverseDigitWithReturn(int arg, int index)
        {
            if (index > 0) return Int32.Parse(arg.ToString()[index] + ReverseDigitWithReturn(arg, --index).ToString());
            else return Int32.Parse(arg.ToString()[0].ToString());
        }

        static string FindSubStringWithRecursion(string str, int i = 0, int j = 1, string final = "", bool check = true)
        {
            if (i >= 0 && i < str.Length)
            {
                if (check) final += str[i];
                if (j < str.Length)
                {
                    final += str[j];
                    return FindSubStringWithRecursion(str, i, ++j, final, check: false);
                }
                if (!check) final += ',';
                return final + FindSubStringWithRecursion(str, ++i, j: j = i + 1, check: true);
            }
            return final;
        }

        static string RemoveCharacter(string str, char ch)
        {
            string toreturn = "";
            foreach (var item in str)
            {
                if (item != ch) toreturn += item;
            }
            return toreturn;
        }

        static string RemoveCharacterOneTime(string str, char ch)
        {
            string toreturn = "";
            bool value = true;
            foreach (var item in str)
            {
                if (value && item == ch) value = false;
                else toreturn += item;
            }
            return toreturn;
        }

        static string letCharacterOneTime(string str, char ch)
        {
            string toreturn = "";
            bool value = true;
            foreach (var item in str)
            {
                if (item == ch && value)
                {
                    toreturn += item;
                    value = false;
                }
                if (item != ch) toreturn += item;
            }
            return toreturn;
        }

        static bool CheckStringPalindrome(string str)
        {
            string strreverse = "";
            for (int i = str.Length - 1; i > -1; i--)
            {
                strreverse += str[i];
            }
            return str == strreverse;
        }

        static bool CheckStringPalindromeWithRecursion(string str)
        {
            string Innermethod(string str, int index, string final = "")
            {
                if (index > -1 && index < str.Length)
                {
                    final += str[index];
                    return Innermethod(str, --index, final);
                }
                return final;
            }
            return str == Innermethod(str, str.Length - 1);
        }

        static (int firstPosition, int lastPosition) FindPositions(int[] arr, int number)
        {
            bool first = true;
            int firstPosition = -1, lastPosition = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == number && first)
                {
                    first = false;
                    firstPosition = i;
                    lastPosition = i;
                }
                else if (arr[i] == number) lastPosition = i;
            }
            return (firstPosition, lastPosition);
        }

        static void Pyramid(int n)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n - i; j++) Console.Write(" ");
                for (j = 0; j <= 2 * i; j++) Console.Write("*");
                Console.WriteLine();
            }
        }

        static void PyramidWithRecursion(int n, int i = 0, int j = -1, int s = -1)
        {
            if (i >= 0 && i < n)
            {
                if (++j >= 0 && j < n - i)
                {
                    Console.Write(" ");
                    PyramidWithRecursion(n, i, j);
                }
                else
                {
                    if (++s >= 0 && s <= 2 * i)
                    {
                        Console.Write("*");
                        PyramidWithRecursion(n, i, j: j, s: s);
                    }
                    else
                    {
                        Console.WriteLine();
                        PyramidWithRecursion(n, ++i);
                    }
                }
            }
        }

        static string PyramidWithRecursionWithReturn(int n, int i = 0, int j = -1, int s = -1, string final = "")
        {
            if (i >= 0 && i < n)
            {
                if (++j >= 0 && j < n - i)
                {
                    final += " ";
                    return PyramidWithRecursionWithReturn(n, i, j, final: final);
                }
                else
                {
                    if (++s >= 0 && s <= 2 * i)
                    {
                        final += "*";
                        return PyramidWithRecursionWithReturn(n, i, j: j, s: s, final: final);
                    }
                    else
                    {
                        final += "\n";
                        return PyramidWithRecursionWithReturn(n, ++i, final: final);
                    }
                }
            }
            return final;
        }

        static void PyramidABCD(int n)
        {
            char ch;
            int i, j;
            for (i = 0; i < n; i++)
            {
                ch = 'A';
                for (j = 0; j < n - i; j++) Console.Write(" ");
                for (j = 0; j <= 2 * i; j++) Console.Write(ch++);
                Console.WriteLine();
            }
        }

        static void PyramidReverseABCD(int n)
        {
            char ch;
            int i, j;
            for (i = 0; i < n; i++)
            {
                ch = 'A';
                for (j = 0; j < n - i; j++) Console.Write(" ");
                for (j = 0; j <= i; j++) Console.Write(ch++);
                ch--;
                for (j = 0; j < i; j++) Console.Write(--ch);
                Console.WriteLine();
            }
        }

        static void PyramidReverseABCDWithRecursion(int n, int i = 0, int j = -1, int s = -1, int p = -1, char ch = 'A', bool check = true)
        {
            if (i >= 0 && i < n)
            {
                if (++j >= 0 && j < n - i)
                {
                    Console.Write(" ");
                    PyramidReverseABCDWithRecursion(n, i: i, j: j);
                }
                else
                {
                    if (++s >= 0 && s <= i)
                    {
                        Write(ch++);
                        PyramidReverseABCDWithRecursion(n, i: i, j: j, s: s, ch: ch);
                    }
                    else
                    {
                        if (++p >= 0 && p < i)
                        {
                            if (check) ch--;
                            Write(--ch);
                            PyramidReverseABCDWithRecursion(n, i: i, j: j, s: s, p: p, ch: ch, check: false);
                        }
                        else
                        {
                            Console.WriteLine();
                            PyramidReverseABCDWithRecursion(n, i: ++i);
                        }
                    }
                }
            }
        }

        static void GeneralABCD(int n)
        {
            char ch = 'A';
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j <= 2 * i; j++) Console.Write(ch++);
                ch = 'A';
                Console.WriteLine();
            }
        }

        static void GeneralReverseABCD(int n)
        {
            char ch;
            int i, j;
            for (i = 0; i < n; i++)
            {
                ch = 'A';
                for (j = 0; j <= i; j++) Console.Write(ch++);
                ch--;
                for (j = 0; j < i; j++) Console.Write(--ch);
                Console.WriteLine();
            }
        }

        static void GeneralReverseABCDWithRecursion(int n, int i = 0, int j = -1, int s = -1, char ch = 'A', bool check = true)
        {
            if (i >= 0 && i < n)
            {
                if (++j >= 0 && j <= i)
                {
                    Console.Write(ch++);
                    GeneralReverseABCDWithRecursion(n, i: i, j: j, ch: ch);
                }
                else
                {
                    if (++s >= 0 && s < i)
                    {
                        if (check) ch--;
                        Write(--ch);
                        GeneralReverseABCDWithRecursion(n, i: i, j: j, s: s, ch: ch, check: false);
                    }
                    else
                    {
                        Console.WriteLine();
                        GeneralReverseABCDWithRecursion(n, i: ++i);
                    }
                }
            }
        }

        static string GeneralReverseABCDWithRecursionWithReturn(int n, StringBuilder sb = null, int i = 0, int j = -1, int s = -1, char ch = 'A', bool check = true)
        {
            sb = sb ?? new StringBuilder();
            if (i >= 0 && i < n)
            {
                if (++j >= 0 && j <= i)
                {
                    sb.Append(ch++);
                    return GeneralReverseABCDWithRecursionWithReturn(n, sb: sb, i: i, j: j, ch: ch);
                }
                else
                {
                    if (++s >= 0 && s < i)
                    {
                        if (check) ch--;
                        sb.Append(--ch);
                        return GeneralReverseABCDWithRecursionWithReturn(n, sb: sb, i: i, j: j, s: s, ch: ch, check: false);
                    }
                    else
                    {
                        sb.Append("\n");
                        return GeneralReverseABCDWithRecursionWithReturn(n, sb: sb, i: ++i);
                    }
                }
            }
            return sb.ToString();
        }
    }
}