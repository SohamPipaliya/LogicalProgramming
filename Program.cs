using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LogicalProgramming
{
    public static class Program
    {
        static void Main(string[] args)
        {
        here:
            //WriteLine(ReverseDigitWithReturn(123, 2));
            //ReverseDigitWithRecursion(123, 2);
            //WriteLine(FindSubStringWithRecursion("abcd"));
            //WriteLine(RemoveCharacter("abcd", 'a'));
            //WriteLine(RemoveCharacterOneTime("aaabcd", 'a'));
            //WriteLine(letCharacterOneTime("aaaaabcd", 'a'));
            //WriteLine(CheckStringPalindrome("abc"));
            //WriteLine(CheckStringPalindromeWithRecursion("abcba"));
            //WriteLine(FindPositions(new int[] { 1, 2, 3, 4, 8, 5, 6, 7, 8, -80 }, -80));
            //Pyramid(10);
            //PyramidABCD(10);
            //PyramidWithRecursion(10);
            //PyramidReverseABCD(10);
            //GeneralABCD(10);
            //GeneralReverseABCD(10);
            //PyramidWithRecursion(10);
            //WriteLine(PyramidWithRecursionWithReturn(10));
            //PyramidReverseABCDWithRecursion(10);
            //GeneralReverseABCDWithRecursion(10);
            //WriteLine(GeneralReverseABCDWithRecursionWithReturn(10));
            //FindAllPermutation("123");
            //foreach (var item in Split("soham patel pipaliya tulshinhai"))
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(Power(5, 5));
            //foreach (var item in LeftCircularRotaion(new int[] { 10, 20, 30, 40, 50 }))
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in RightCircularRotation(new int[] { 10, 20, 30, 40, 50 }))
            //{
            //    Console.WriteLine(item);
            //}
            //Fibonanci();
            //FibonanciWithRecursion();
            //NthFibonanci(10);
            //NthFibonanciWithRecursion(10);
            //FibonanciUptoNumber(10000);
            //FibonanciUptoNumberWithRecursion(10000);
            //Console.WriteLine(IsPrime(10));
            //PrintPrimeUptoN(0, 100);
            //Console.WriteLine(IsArmstrong(8208));
            ArmstrongUptoN(1, 10000);

            ReadLine();
            goto here;
        }

        static void ReverseDigitWithRecursion(int arg, int index, string str = "")
        {
            str += arg.ToString()[index];
            if (index > 0) ReverseDigitWithRecursion(arg, index - 1, str);
            else WriteLine(str);
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
                for (j = 0; j < n - i; j++) Write(" ");
                for (j = 0; j <= 2 * i; j++) Write("*");
                WriteLine();
            }
        }

        static void PyramidWithRecursion(int n, int i = 0, int j = -1, int s = -1)
        {
            if (i >= 0 && i < n)
            {
                if (++j >= 0 && j < n - i)
                {
                    Write(" ");
                    PyramidWithRecursion(n, i, j);
                }
                else
                {
                    if (++s >= 0 && s <= 2 * i)
                    {
                        Write("*");
                        PyramidWithRecursion(n, i, j: j, s: s);
                    }
                    else
                    {
                        WriteLine();
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
                for (j = 0; j < n - i; j++) Write(" ");
                for (j = 0; j <= 2 * i; j++) Write(ch++);
                WriteLine();
            }
        }

        static void PyramidReverseABCD(int n)
        {
            char ch;
            int i, j;
            for (i = 0; i < n; i++)
            {
                ch = 'A';
                for (j = 0; j < n - i; j++) Write(" ");
                for (j = 0; j <= i; j++) Write(ch++);
                ch--;
                for (j = 0; j < i; j++) Write(--ch);
                WriteLine();
            }
        }

        static void PyramidReverseABCDWithRecursion(int n, int i = 0, int j = -1, int s = -1, int p = -1, char ch = 'A', bool check = true)
        {
            if (i >= 0 && i < n)
            {
                if (++j >= 0 && j < n - i)
                {
                    Write(" ");
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
                            WriteLine();
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
                for (j = 0; j <= 2 * i; j++) Write(ch++);
                ch = 'A';
                WriteLine();
            }
        }

        static void GeneralReverseABCD(int n)
        {
            char ch;
            int i, j;
            for (i = 0; i < n; i++)
            {
                ch = 'A';
                for (j = 0; j <= i; j++) Write(ch++);
                ch--;
                for (j = 0; j < i; j++) Write(--ch);
                WriteLine();
            }
        }

        static void GeneralReverseABCDWithRecursion(int n, int i = 0, int j = -1, int s = -1, char ch = 'A', bool check = true)
        {
            if (i >= 0 && i < n)
            {
                if (++j >= 0 && j <= i)
                {
                    Write(ch++);
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
                        WriteLine();
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

        static void FindAllPermutation(string str)// X
        {
            permute(str, str.Length);

            void permute(string str, int right, int left = 0)
            {
                if (left == right)
                    WriteLine(str);
                else
                {
                    for (int i = left; i < right; i++)
                    {
                        str = swap(str, i, left);
                        permute(str, right, left + 1);
                        str = swap(str, i, left);
                    }
                }
            }
            string swap(string str, int i, int j)
            {
                var charArray = str.ToCharArray();
                (charArray[i], charArray[j]) = (charArray[j], charArray[i]);
                return new string(charArray);
            }
        }

        static string FindLongestPalindrome(string str)// X
        {
            var maxPalindrome = "";
            return maxPalindrome;
        }

        static string[] Split(string str, char ch = ' ')
        {
            StringBuilder sb = new StringBuilder();
            List<string> list = new List<string>();
            foreach (var item in str)
            {
                if (item != ch) sb.Append(item);
                else
                {
                    list.Add(sb.ToString());
                    sb.Clear();
                }
            }
            return list.ToArray();
        }

        static long Power(int n, int t)
        {
            if (t == 1) return n;
            else if (t == 0) return 1;
            else return n * Power(n, t - 1);
        }

        static int[] LeftCircularRotaion(int[] arr)
        {
            var j = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1) arr[i] = j;
                else (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]); // Swapp values
            }
            return arr;
        }

        static int[] RightCircularRotation(int[] arr)
        {
            var temp = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (i == 0) arr[i] = temp;
                else (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]); // Swapp values
            }
            return arr;
        }

        static void Fibonanci()
        {
            int x = 0, y = 1, z = 1;
            Console.WriteLine(x);
            Console.WriteLine(y);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(z);
                z = x + y;
                x = y;
                y = z;
            }
        }

        static void FibonanciWithRecursion(int i = 0, int x = 0, int y = 1)
        {
            if (i != 10)
            {
                Console.WriteLine(x);
                Console.WriteLine(y);
                FibonanciWithRecursion(i: ++i, x: x += y, y: y += x);
            }
        }

        static int NthFibonanci(int n)
        {
            if (n == 0 || n == 1) return n;
            int x = 0, y = 1, z = 1;
            for (int i = 2; i <= n; i++)
            {
                z = x + y;
                x = y;
                y = z;
            }
            return z;
        }

        static int NthFibonanciWithRecursion(int n)
        {
            if (n == 0 || n == 1) return n;
            else return NthFibonanciWithRecursion(n - 1) + NthFibonanciWithRecursion(n - 2);
        }

        static void FibonanciUptoN(int n)
        {
            int x = 0, y = 1, z = x + y;
            for (int i = 0; z < n; i++)
            {
                Console.WriteLine(z);
                z = x + y;
                x = y;
                y = z;
            }
        }

        static void FibonanciUptoNWithRecursion(int n, int x = 0, int y = 1, int z = 1)
        {
            if (z < n)
            {
                Console.WriteLine(z);
                FibonanciUptoNWithRecursion(n, z: z = x + y, x: x = y, y: y = z);
            }
        }

        static bool IsPrime(int n)
        {
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void PrintPrimeUptoN(int start, int n)
        {
            for (start = start; start <= n; start++) if (IsPrime(start)) Console.WriteLine(start);
        }

        static bool IsArmstrong(int n)
        {
            int tempn = n, sum = 0, count = n.ToString().Length;
            while (tempn > 0)
            {
                int temp = tempn % 10;
                sum += (int)Power(temp, count);
                tempn = tempn / 10;
            }
            return sum == n;
        }

        static void ArmstrongUptoN(int start, int n)
        {
            while (start <= n)
            {
                if (IsArmstrong(start)) Console.WriteLine(start);
                start++;
            }
        }
    }
}