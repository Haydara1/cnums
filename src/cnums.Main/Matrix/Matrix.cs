namespace cnums;

public struct Matrix
{
    private int cols;
    private int rows;
    public readonly double[,] matrix;

    public int Columns
    {
        get { return cols; }
        private set { cols = value; }
    }

    public int Rows
    {
        get { return rows; }
        private set { rows = value; }
    }

    public Matrix(double[,] matrix)
    {
        rows = matrix.GetLength(0);
        cols = matrix.GetLength(1);
        this.matrix = matrix;
    }

    public static Matrix Transpose(Matrix matrix)
    {
        double[,] result = new double[matrix.Columns, matrix.Rows];

        for (int i = 0; i < matrix.Rows; i++)
            for (int j = 0; j < matrix.Columns; j++)
                result[j, i] = matrix.matrix[i, j];

        return new(result);
    }

    public static Matrix operator +(Matrix matrix)
        => matrix;

    public static Matrix operator +(Matrix left, Matrix right)
    {
        if (left.Rows != right.Rows
            || left.Columns != right.Columns)
            throw new ArgumentException("Matrices should be the same size.");

        double[,] matrix = new double[left.Rows, left.Columns];

        for (int i = 0; i < left.Rows; i++)
            for (int j = 0; j < left.Columns; j++)
                matrix[i, j] = left.matrix[i, j] + right.matrix[i, j];

        return new(matrix);
    }

    public static Matrix operator -(Matrix matrix)
        => -1 * matrix;

    public static Matrix operator *(double scalar, Matrix matrix)
    {
        for(int i = 0; i < matrix.Rows; i++)
            for(int j = 0; j < matrix.Columns; j++)
                matrix.matrix[i, j] *= scalar;

        return matrix;
    }

    public static Matrix operator *(Matrix matrix, double scalar)
        => scalar * matrix


}

