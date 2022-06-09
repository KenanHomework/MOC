using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOC
{
    public class BracketResult
    {
        public BracketResult(ref string equation)
        {
            Equation = equation;
        }

        public BracketResult(ref string equation, char seperator)
        {
            Equation = equation;
            Seperator = seperator;
        }


        #region Fields

        public string Equation { get; set; }

        public char Seperator { get; set; } = '#';

        List<double> Results = new();

        #endregion


        #region Funcs

        public void ApplyResults()
        {
            foreach (var res in Results)
            {
                int index = Equation.IndexOf('(');
                if (index > 0 && Equation[index - 1].IsNumber())
                {
                    Equation = Equation.AppendAt(index - 1, '*');

                }
                //Equation = Equation.Change(Equation.IndexOf('('), Equation.IndexOf(')', Equation.IndexOf('(')), pair.Value.ToString(), new("()", 2));
                Equation = Equation.Replace(Equation.GetRange(Equation.IndexOf('('), Equation.IndexOf(')', Equation.IndexOf('(')) + 1), res.ToString());
            }
        }

        public void AddBracketResult(double result)
            => Results.Add(result);
        #endregion

    }
}
