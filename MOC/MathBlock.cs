using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOC
{
    public class MathBlock
    {
        public MathBlock(double value, string operation)
        {
            Value = value;
            Operation = operation;
        }

        public double Value { get; set; }

        public string Operation { get; set; }

    }
}
