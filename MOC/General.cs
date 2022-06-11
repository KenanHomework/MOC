using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOC
{
    public enum Direction { Forwad, Back }

    public abstract class General
    {
        static public List<char> MathSymbols = new() { '*', '/', '+', '-', '^', '|', '!' };
        static public List<string> MathOperations = new() { "*", "/", "+", "-", "^", "|", "!", "hcf", "lcm" };
        static public List<string> MathTherms = new() { "hcf", "lcm" };

    }
}
