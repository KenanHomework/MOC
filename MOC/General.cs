using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOC
{
    enum Operations { Sub, Div, Mult, Add };

    public enum Direction { Forwad, Back }

    public abstract class General
    {
        static public List<char> MathSymbols = new() { '*', '/', '+', '-' };

    }
}
