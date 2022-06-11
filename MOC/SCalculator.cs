using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOC
{
    public class SCalculator
    {
        public SCalculator(double num)
        {
            Result = num;
        }



        #region Fields

        public List<int> MList { get; set; } = new();

        public string equation;

        public Calculate Cal { get; set; } = new();

        public string EquationForView { get; set; }

        public double Result { get; set; }

        #endregion



        #region Funcs


        public void Calculate()
        {
            Cal.CalculateBrackets(ref equation);
            Result = Cal.CalculateEquation(equation);
            equation = Result.ToString();
        }

        public void Add(string block)
        {
            equation += block;
            Calculate();
        }

        #endregion
    }
}