namespace cnums
{
    public class Symbol
    {

        private char sym = 'x';

        public char Sym
        {
            get { return sym; }
            private set { sym = value; }
        }

        public Symbol(char symbol)
        {
            if (Char.IsDigit(symbol) 
                || Char.IsPunctuation(symbol)
                || Char.IsWhiteSpace(symbol))
                throw new Exception("Symbol cannot be a digit or a punctuation mark or a white space.");

            this.Sym = symbol;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) 
                return false;

            if (obj.GetType() != this.GetType()) 
                return false;

            Symbol symbol = (Symbol)obj;
            if (symbol.sym == this.sym) 
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            throw new NotSupportedException();
        }

        public override string ToString()
            => $"{this.Sym}";

        #region Addition.

        public static Polynomial operator +(Symbol symbol)
            => new(new List<object> { symbol });

        public static Polynomial operator +(Symbol symbol, double number)
            => new(new List<object> { symbol, '+', number });

        public static Polynomial operator +(double number, Symbol symbol)
            => new(new List<object> { number, '+', symbol });

        public static Polynomial operator +(Symbol symbol1, Symbol symbol2)
        {
            if (symbol1 == symbol2)
                return new(new List<object> { 2d, '*', symbol1 });

            return new(new List<object> { symbol1, '+', symbol2 });
        }

        #endregion

        #region Substraction

        public static Polynomial operator -(Symbol symbol)
            => new(new List<object> { '-', symbol });

        public static Polynomial operator -(Symbol symbol, double number)
            => new(new List<object> { symbol, '-', number });

        public static Polynomial operator -(double number, Symbol symbol)
            => new(new List<object> { number, '-', symbol });

        public static Polynomial operator -(Symbol symbol1, Symbol symbol2)
        {
            if (symbol1 == symbol2)
                return new(new List<object> { 0d });

            return new(new List<object> { symbol1, '-', symbol2 });
        }

        #endregion

        #region Multiplication

        public static Polynomial operator *(Symbol symbol, double number)
            => new(new List<object> { number, '*', symbol });

        public static Polynomial operator *(double number, Symbol symbol)
            => new(new List<object> { number, '*', symbol });

        public static Polynomial operator *(Symbol symbol1, Symbol symbol2)
        {
            if (symbol1 == symbol2)
                return new(new List<object> { symbol1, '^', 2 });

            return new(new List<object> { symbol1, '*', symbol2 });
        }

        #endregion

        #region Division

        public static Polynomial operator /(Symbol symbol, double number)
            => new(new List<object> { symbol, '/', number });

        public static Polynomial operator /(double number, Symbol symbol)
            => new(new List<object> { number, '/', symbol });

        public static Polynomial operator /(Symbol symbol1, Symbol symbol2)
        {
            if(symbol1 == symbol2)
                return new Polynomial(new List<object> { 1d });

            return new(new List<object> { symbol1, '/', symbol2 });
        }

        #endregion

        #region Comparision

        public static bool operator ==(Symbol symbol1, Symbol symbol2)
            => symbol1.Equals(symbol2);

        public static bool operator !=(Symbol symbol1, Symbol symbol2)
            => !symbol1.Equals(symbol2);

        #endregion
    }


}
