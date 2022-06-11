using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOC
{
    public class SCalculator
    {
        public SCalculator(string mathOperation, bool auotCalculate = false)
        {
            equation = mathOperation;
            EquationForView = mathOperation;
            if (auotCalculate)
                Calculate();
        }



        #region Fields

        public List<int> MList { get; set; } = new();

        public string equation;

        public string EquationForView { get; set; }

        public double Result { get; set; }

        #endregion



        #region Funcs

        void CalculateBrackets()
        {
            if (!equation.Contains('('))
                return;
            StringBuilder builder = new();
            BracketResult br = new(ref equation);
            bool read = false;
            char ch;
            for (int i = 0; i < equation.Length; i++)
            {
                ch = equation[i];
                if (ch == '(')
                {
                    read = true;
                    continue;
                }
                else if (ch == ')')
                {
                    read = false;
                    br.AddBracketResult(Calculateequation(builder.ToString()));
                    builder.Clear();
                    continue;
                }

                if (read)
                    builder.Append(ch);
            }
            br.ApplyResults();
            equation = br.Equation;
            SolveDoubleOperation(ref equation);
        }

        double CalculateNums(double num1, double num2, char operation)
        {
            double res = 1;
            switch (operation)
            {
                case '+':
                    res = num1 + num2;
                    break;
                case '-':
                    res = num1 - num2;
                    break;
                case '/':
                    res = num1 / num2;
                    break;
                case '*':
                    res = num1 * num2;
                    break;
                default:
                    break;
            }
            return res;
        }

        void SolveDoubleOperation(ref string equation)
        {
            equation = equation.Replace("+-", "-");
            equation = equation.Replace("-+", "-");
            equation = equation.Replace("--", "+");
            equation = equation.Replace("++", "+");
        }

        double Calculateequation(string equation)
        {
            double res = 0;
            double num1 = 0;
            double num2 = 0;
            int index = 0;
            int indexOfNum1 = 0;
            int indexOfNum2 = 0;
            string temp = "";

        Calculate:
            SolveDoubleOperation(ref equation);
            foreach (char operation in General.MathSymbols)
            {
                while (true)
                {
                    index = equation.IndexOf(operation);
                    if (index <= 0)
                        break;

                    temp = equation.GetRangeToTarget(index, General.MathSymbols, Direction.Back);
                    indexOfNum1 = index - temp.Length;
                    temp = String.IsNullOrWhiteSpace(temp) ? "0" : temp;
                    num1 = Convert.ToDouble(temp);

                    temp = equation.GetRangeToTarget(index, General.MathSymbols, Direction.Forwad);
                    indexOfNum2 = index + temp.Length;
                    temp = String.IsNullOrWhiteSpace(temp) ? "0" : temp;
                    num2 = Convert.ToDouble(temp);

                    res = CalculateNums(num1, num2, operation);
                    equation = equation.Replace(equation.GetRange(indexOfNum1, indexOfNum2 + 1), res.ToString());
                }
            }
            int countOfMO = equation.CountOfMathOperation();
            if (countOfMO >= 1)
                if (!(countOfMO == 1 && equation[0].IsMathSymbol()))
                    goto Calculate;
            return res;
        }

        public void Calculate()
        {
            SolveDoubleOperation(ref equation);
            CalculateBrackets();
            Result = Calculateequation(equation);
            equation = Result.ToString();
        }

        #endregion
    }
}