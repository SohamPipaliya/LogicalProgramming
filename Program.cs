using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace LogicalProgramming
{
    public static class Program
    {
        static void Main(string[] args)
        {
            ReadLine();
        }

        static char FindHighestOccuringChar(string str)
        {
            List<int> list = new();
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[i] == str[j]) count++;
                }
                list.Add(count);
                count = 0;
            }
            var index = Math.Max(list.IndexOf(list.Max()), 0);
            return str[index];
        }

        static char FindLongestConsecutiveChar(string str)
        {
            char prev = default, maxChar = default;
            int count = 1, maxCount = 0; ;
            foreach (var item in str)
            {
                if (prev == item) count++;
                else count = 1;
                if (count > maxCount) (maxCount, maxChar) = (count, item);
                prev = item;
            }
            return maxChar;
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

        static string FindSubstring(string str)
        {
            var strToReturn = "";
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length; j++)
                {
                    strToReturn += str[j];
                }
                if (i != str.Length - 1) strToReturn += ',';
            }
            return strToReturn;
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

        static void Pyramid(int number)
        {
            int i, j;
            for (i = 0; i < number; i++)
            {
                for (j = 0; j < number - i; j++) Write(" ");
                for (j = 0; j <= 2 * i; j++) Write("*");
                WriteLine();
            }
        }

        static void PyramidWithRecursion(int number, int i = 0, int j = -1, int s = -1)
        {
            if (i >= 0 && i < number)
            {
                if (++j >= 0 && j < number - i)
                {
                    Write(" ");
                    PyramidWithRecursion(number, i, j);
                }
                else
                {
                    if (++s >= 0 && s <= 2 * i)
                    {
                        Write("*");
                        PyramidWithRecursion(number, i, j: j, s: s);
                    }
                    else
                    {
                        WriteLine();
                        PyramidWithRecursion(number, ++i);
                    }
                }
            }
        }

        static string PyramidWithRecursionWithReturn(int number, int i = 0, int j = -1, int s = -1, string final = "")
        {
            if (i >= 0 && i < number)
            {
                if (++j >= 0 && j < number - i)
                {
                    final += " ";
                    return PyramidWithRecursionWithReturn(number, i, j, final: final);
                }
                else
                {
                    if (++s >= 0 && s <= 2 * i)
                    {
                        final += "*";
                        return PyramidWithRecursionWithReturn(number, i, j: j, s: s, final: final);
                    }
                    else
                    {
                        final += "\n";
                        return PyramidWithRecursionWithReturn(number, ++i, final: final);
                    }
                }
            }
            return final;
        }

        static void PyramidABCD(int number)
        {
            char ch;
            int i, j;
            for (i = 0; i < number; i++)
            {
                ch = 'A';
                for (j = 0; j < number - i; j++) Write(" ");
                for (j = 0; j <= 2 * i; j++) Write(ch++);
                WriteLine();
            }
        }

        static void PyramidReverseABCD(int number)
        {
            char ch;
            int i, j;
            for (i = 0; i < number; i++)
            {
                ch = 'A';
                for (j = 0; j < number - i; j++) Write(" ");
                for (j = 0; j <= i; j++) Write(ch++);
                ch--;
                for (j = 0; j < i; j++) Write(--ch);
                WriteLine();
            }
        }

        static void PyramidReverseABCDWithRecursion(int number, int i = 0, int j = -1, int s = -1, int p = -1, char ch = 'A', bool check = true)
        {
            if (i >= 0 && i < number)
            {
                if (++j >= 0 && j < number - i)
                {
                    Write(" ");
                    PyramidReverseABCDWithRecursion(number, i: i, j: j);
                }
                else
                {
                    if (++s >= 0 && s <= i)
                    {
                        Write(ch++);
                        PyramidReverseABCDWithRecursion(number, i: i, j: j, s: s, ch: ch);
                    }
                    else
                    {
                        if (++p >= 0 && p < i)
                        {
                            if (check) ch--;
                            Write(--ch);
                            PyramidReverseABCDWithRecursion(number, i: i, j: j, s: s, p: p, ch: ch, check: false);
                        }
                        else
                        {
                            WriteLine();
                            PyramidReverseABCDWithRecursion(number, i: ++i);
                        }
                    }
                }
            }
        }

        static void GeneralABCD(int number)
        {
            char ch = 'A';
            int i, j;
            for (i = 0; i < number; i++)
            {
                for (j = 0; j <= 2 * i; j++) Write(ch++);
                ch = 'A';
                WriteLine();
            }
        }

        static void GeneralReverseABCD(int number)
        {
            char ch;
            int i, j;
            for (i = 0; i < number; i++)
            {
                ch = 'A';
                for (j = 0; j <= i; j++) Write(ch++);
                ch--;
                for (j = 0; j < i; j++) Write(--ch);
                WriteLine();
            }
        }

        static void GeneralReverseABCDWithRecursion(int number, int i = 0, int j = -1, int s = -1, char ch = 'A', bool check = true)
        {
            if (i >= 0 && i < number)
            {
                if (++j >= 0 && j <= i)
                {
                    Write(ch++);
                    GeneralReverseABCDWithRecursion(number, i: i, j: j, ch: ch);
                }
                else
                {
                    if (++s >= 0 && s < i)
                    {
                        if (check) ch--;
                        Write(--ch);
                        GeneralReverseABCDWithRecursion(number, i: i, j: j, s: s, ch: ch, check: false);
                    }
                    else
                    {
                        WriteLine();
                        GeneralReverseABCDWithRecursion(number, i: ++i);
                    }
                }
            }
        }

        static string GeneralReverseABCDWithRecursionWithReturn(int number, StringBuilder sb = null, int i = 0, int j = -1, int s = -1, char ch = 'A', bool check = true)
        {
            sb = sb ?? new StringBuilder();
            if (i >= 0 && i < number)
            {
                if (++j >= 0 && j <= i)
                {
                    sb.Append(ch++);
                    return GeneralReverseABCDWithRecursionWithReturn(number, sb: sb, i: i, j: j, ch: ch);
                }
                else
                {
                    if (++s >= 0 && s < i)
                    {
                        if (check) ch--;
                        sb.Append(--ch);
                        return GeneralReverseABCDWithRecursionWithReturn(number, sb: sb, i: i, j: j, s: s, ch: ch, check: false);
                    }
                    else
                    {
                        sb.Append("\n");
                        return GeneralReverseABCDWithRecursionWithReturn(number, sb: sb, i: ++i);
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

        static long Power(int number, int time)
        {
            if (time == 1) return number;
            else if (time == 0) return 1;
            else return number * Power(number, time - 1);
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

        static int NthFibonanci(int number)
        {
            if (number == 0 || number == 1) return number;
            int x = 0, y = 1, z = 1;
            for (int i = 2; i <= number; i++)
            {
                z = x + y;
                x = y;
                y = z;
            }
            return z;
        }

        static int NthFibonanciWithRecursion(int number)
        {
            if (number == 0 || number == 1) return number;
            else return NthFibonanciWithRecursion(number - 1) + NthFibonanciWithRecursion(number - 2);
        }

        static void FibonanciUptoN(int number)
        {
            int x = 0, y = 1, z = x + y;
            for (int i = 0; z < number; i++)
            {
                Console.WriteLine(z);
                z = x + y;
                x = y;
                y = z;
            }
        }

        static void FibonanciUptoNWithRecursion(int number, int x = 0, int y = 1, int z = 1)
        {
            if (z < number)
            {
                Console.WriteLine(z);
                FibonanciUptoNWithRecursion(number, z: z = x + y, x: x = y, y: y = z);
            }
        }

        static bool IsPrime(int number)
        {
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void PrintPrimeUptoN(int start, int end)
        {
            while (start <= end)
            {
                if (IsPrime(start)) Console.WriteLine(start);
                start++;
            }
        }

        static bool IsArmstrong(int number)
        {
            int tempn = number, sum = 0, count = number.ToString().Length;
            while (tempn > 0)
            {
                int temp = tempn % 10;
                sum += (int)Power(temp, count);
                tempn = tempn / 10;
            }
            return sum == number;
        }

        static void ArmstrongUptoN(int start, int end)
        {
            while (start <= end)
            {
                if (IsArmstrong(start)) Console.WriteLine(start);
                start++;
            }
        }

        static int ReversenNumber(int number)
        {
            int reminder = 0, reverse = 0;
            while (number > 0)
            {
                reminder = number % 10;
                reverse = (reverse * 10) + reminder;
                number = number / 10;
            }
            return reverse;
        }

        static int ReverseNumberWithRecursion(int number, int reminder = 0, int reverse = 0)
        {
            if (number > 0)
            {
                reminder = number % 10;
                reverse = (reverse * 10) + reminder;
                return ReverseNumberWithRecursion(number: number / 10, reminder: reminder, reverse: reverse);
            }
            return reverse;
        }

        static long Factorial(int number)
        {
            if (number == 0 || number == 1) return number;
            int i = number; long Factorial = 1;
            while (i != 1) Factorial *= i--;
            return Factorial;
        }

        static long FactorialWithRecursion(int number, int i = 2, int factorial = 1)
        {
            if (number == 0 || number == 1) return number;
            else if (i <= number)
            {
                factorial *= i++;
                return FactorialWithRecursion(number, i: i, factorial: factorial);
            }
            else return factorial;
        }

        static int SumOfNumber(int number)
        {
            int reminder = 0, sum = 0;
            while (number > 0)
            {
                reminder = number % 10;
                sum += reminder;
                number = number / 10;
            }
            return sum;
        }

        static int DecimalToBinary(int number)
        {
            StringBuilder sb = new StringBuilder();
            List<int> list = new List<int>();
            for (int i = 0; number > 0; i++)
            {
                list.Add(number % 2);
                number /= 2;
            }
            for (int i = list.Count - 1; i >= 0; i--)
            {
                sb.Append(list[i]);
            }
            return Int32.Parse(sb.ToString());
        }

        static int BinaryToDecimal(int number)
        {
            int tmp = number, sum = 0;
            for (int i = 0; i < number.ToString().Length; i++)
            {
                var temp = tmp % 10;
                sum += temp * ((int)Power(2, i));
                tmp /= 10;
            }
            return sum;
        }
    }
}