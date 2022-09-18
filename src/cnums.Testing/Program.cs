using cnums;
using cnums.Symbolic;

double[,] doubles = new double[,]
{
    {1, 3},
    {2, 4 },
    {3, 5},
};

Matrix matrix = new(doubles);
matrix = Matrix.Transpose(matrix);
for(int i = 0; i < matrix.Rows; i++)
    for(int j = 0; j < matrix.Columns; j++)
        Console.WriteLine(i + " " + matrix.matrix[i, j]);