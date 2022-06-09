﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOC
{
    public static class Extensions
    {

        public static string GetRange(this string str, int start, int count)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = start; i < (start + count) && i < str.Length; i++)
            {
                builder.Append(str[i]);
            }
            return builder.ToString();
        }

        public static string GetRangeToTarget(this string str, int start, char target, Direction direction)
        {
            void Change(ref int i)
                => i = direction == Direction.Back ? i - 1 : i + 1;
            StringBuilder builder = new StringBuilder();
            int stopIndex = direction == Direction.Forwad ? str.Length : 0;
            for (int i = start; i < stopIndex; Change(ref i))
            {
                if (str[i] == target)
                    break;
                builder.Append(str[i]);
            }
            return direction == Direction.Forwad ? builder.ToString() : builder.ToString().MReverse();
        }

        public static string GetRangeToTarget(this string str, int start, List<char> targets, Direction direction)
        {
            void Change(ref int i)
                => i = direction == Direction.Back ? i - 1 : i + 1;
            bool Compare(int i, int index)
            {
                if (direction == Direction.Forwad)
                    return i < index;
                else
                    return i >= index;
            }
            StringBuilder builder = new StringBuilder();
            int stopIndex = direction == Direction.Forwad ? str.Length : 0;
            Change(ref start);
            for (int i = start; Compare(i, stopIndex); Change(ref i))
            {
                if (targets.Contains(str[i]))
                    break;
                builder.Append(str[i]);
            }
            return direction == Direction.Forwad ? builder.ToString() : builder.ToString().MReverse();
        }

        public static string MReverse(this string str)
        {

            StringBuilder builder = new();
            for (int i = (str.Length - 1); i >= 0; i--)
            {
                builder.Append(str[i]);
            }
            return builder.ToString();
        }

        public static string Change(this string str, int index, char symbol)
        {
            StringBuilder builder = new(str.GetRange(0, index));
            builder.Append(symbol);
            builder.Append(str.GetRange(index + 1, str.Length - (index + 1)));
            return builder.ToString();
        }

        public static string Change(this string str, int index, int length, string txt, IgnoreChars ignoreChar)
        {
            StringBuilder builder = new(str.GetRange(0, index));
            builder.Append(builder.ToString().MTrim(ref ignoreChar));
            builder.Append(txt);
            builder.Append(str.GetRange(index + length.Big(txt.Length), str.Length - (index + length.Big(txt.Length))).MTrim(ref ignoreChar));
            return builder.ToString();
        }

        public static string MTrim(this string str, char ch, int count = 1)
        {
            StringBuilder builder = new();
            foreach (char symbol in str)
                if (ch != symbol && --count >= 0)
                    builder.Append(symbol);
            return builder.ToString();
        }

        public static string MTrim(this string str, ref IgnoreChars ignore)
        {
            StringBuilder builder = new();
            foreach (char symbol in str)
                if (ignore.IsIgnore(symbol) && --ignore.Count >= 0)
                    builder.Append(symbol);
            return builder.ToString();
        }

        public static string AppendAt(this string str, int index, char ch)
        {
            StringBuilder builder = new(str.GetRange(0, index + 1));
            builder.Append(ch);
            builder.Append(str.GetRange(index + 1, str.Length - (index - 1)));
            return builder.ToString();
        }

        public static int Big(this int num1, int num2) => num1 > num2 ? num1 : num2;

        public static int CountOfMathOperation(this string str)
        {
            int res = 0;
            foreach (char ch in str)
            {
                if (General.MathSymbols.Contains(ch))
                {
                    res++;
                }
            }
            return res;
        }

        public static bool IsMathSymbol(this char ch)
            => General.MathSymbols.Contains(ch);

        public static bool IsNumber(this char ch)
            => ch >= '0' && ch <= '9';
    }
}
