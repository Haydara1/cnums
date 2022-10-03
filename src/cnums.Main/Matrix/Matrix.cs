//Pulled from https://en.wikipedia.org/wiki/Matrix_(mathematics)

namespace cnums;

public struct Matrix
{
    private int cols;
    private int rows;
    internal double[,] matrix;

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

    public static Matrix Eye(int number)
    {
        double[,] result = new double[number, number];

        for (int i = 0; i < number; i++)
            result[i, i] = 1d;

        return new(result);
    }

    public static Matrix Zeros(int rows, int cols)
        => new(new double[rows, cols]);

    public static Matrix Ones(int rows, int cols)
    {
        double[,] doubles = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                doubles[i, j] = 1d;

        return new(doubles);
    }

    public static Matrix ValueInit(int rows, int cols, double value)
    {
        double[,] doubles = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                doubles[i, j] = value;

        return new(doubles);
    }

    public static Matrix Transpose(Matrix matrix)
    {
        double[,] result = new double[matrix.Columns, matrix.Rows];

        for (int i = 0; i < matrix.Rows; i++)
            for (int j = 0; j < matrix.Columns; j++)
                result[j, i] = matrix.matrix[i, j];

        return new(result);
    }

    public override string ToString()
    {
        string str = "";

        if (Utils.Unicode)
            return ToUnicodeString();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                str += matrix[i, j].ToString() + " ";
            }

            str += "\n";
        }

        return str;
    }

    private string ToUnicodeString()
    {
        string str = "";

        if(rows == 1)
        {
            if (cols == 1)
                return $"[ {matrix[0, 0]} ]";


            str += "[ ";

            for (int i = 0; i < cols; i++)
                str += matrix[0, i].ToString() + " ";

            str += "]";
            return str;
        }

        str += "\u2308 ";

        for(int i = 0; i < cols; i++)
            str += matrix[0, i].ToString() + " ";

        str += "\u2309\n";

        for (int i = 1; i < rows - 1; i++)
        {
            str += "| ";

            for (int j = 0; j < cols; j++)
                str += matrix[i, j].ToString() + " ";

            str += "|\n";
        }

        str += "\u230A ";

        for (int i = 0; i < cols; i++)
            str += matrix[rows - 1, i].ToString() + " ";

        str += "\u230B";

        return str;
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
        for (int i = 0; i < matrix.Rows; i++)
            for (int j = 0; j < matrix.Columns; j++)
                matrix.matrix[i, j] *= scalar;

        return matrix;
    }

    public static Matrix operator *(Matrix matrix, double scalar)
        => scalar * matrix;

    public static Matrix operator *(Matrix left, Matrix right)
    {
        if (left.Columns != right.Rows)
            throw new ArgumentException("Left matrix should have the same number of columns as the number of rows of the right matrix.");

        double[,] result = new double[left.Rows, right.Columns];

        for (int i = 0; i < left.Rows; i++)
            for (int j = 0; j < right.Columns; j++)
            {
                double sum = 0;
                for (int k = 0; k < left.Columns; k++)
                    sum += left.matrix[i, k] * right.matrix[k, j];

                result[i, j] = sum;
            }

        return new(result);
    }
}

