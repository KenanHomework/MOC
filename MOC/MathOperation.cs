using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOC
{
    public class MathOperation
    {

        public string Operation { get; set; }

        public override bool Equals(object? obj)
        {
            string operation;
            if (obj is string str) return Operation == str;
            return false;
        }

        public override string ToString() => Operation;
    }
}
