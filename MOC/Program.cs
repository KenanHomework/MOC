using MOC;
using MathNet.Numerics.Differentiation;
//SCalculator c = new("2(4+2(3))@", false);

Calculate c = new();
Console.WriteLine(c.CalculateEquation("hcf(44,82)"));

//string s = "2+hcf(4+2(3))";
//Console.WriteLine(s.IndexOf("hcf"));

//c.CalculateBrackets(ref s);
//Console.WriteLine(s.GetRangeToTarget(1,')',Direction.Forwad));

//Console.WriteLine($"Result: {c.Result}");
//Console.WriteLine($"Equations: {c.EquationForView}");
//Console.WriteLine($"equations: {c.equation}");

//string s = "Sa(kenan)asd";
//Console.WriteLine(s.GetRange(new(s.IndexOf('(') + 1, s.LastIndexOf(')'))));