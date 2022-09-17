using cnums;
using cnums.Symbolic;

Symbol x = new('x');

Polynomial polynomial = x * x + 2;
polynomial += 1;
polynomial += 1;
polynomial += 1;
polynomial += 1;
polynomial -= 1;
Console.WriteLine(polynomial);
