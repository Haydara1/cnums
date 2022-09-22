// Some functions are inspired by the amazing python library, sympy,
// the link for sympy's matrix: https://docs.sympy.org/latest/tutorials/intro-tutorial/matrices.html#.

using System;

namespace cnums;

public static class MatrixFunctions
{
    public static (int row, int col) Shape(this Matrix matrix)
        => (matrix.Rows, matrix.Columns);
    
    public static double[] Row(this Matrix matrix, int index)
    {
        if (index == -1)
            index = matrix.Rows - 1;
        else if(index >= matrix.Rows)
            throw new IndexOutOfRangeException($"The matrix does not contain a row with index of {index}.");

        double[] result = new double[matrix.Columns];

        for (int i = 0; i < matrix.Columns; i++)
            result[i] = matrix.matrix[index, i];

        return result;
    }

    public static double[] Col(this Matrix matrix, int index)
    {
        if (index == -1)
            index = matrix.Columns - 1;
        else if (index >= matrix.Columns)
            throw new IndexOutOfRangeException($"The matrix does not contain a column with index of {index}.");

        double[] result = new double[matrix.Rows];

        for (int i = 0; i < matrix.Rows; i++)
            result[i] = matrix.matrix[i, index];

        return result;
    }

    public static double Index(this Matrix matrix, int row, int col)
    {
        if(row == -1) 
            row = matrix.Rows - 1;

        if(col == -1)   
            col = matrix.Columns - 1;

        try
        {
            return matrix.matrix[row, col];
        }
        catch(IndexOutOfRangeException)
        {
            throw new IndexOutOfRangeException($"The matrix does not contain an element with index of {row}, {col}.");
        }
    }

}
