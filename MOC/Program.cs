using MOC;

SCalculator c = new("4--2", true);
Console.WriteLine($"Result: {c.Result}");
Console.WriteLine($"Equations: {c.EquationForView}");
Console.WriteLine($"equations: {c.equation}");