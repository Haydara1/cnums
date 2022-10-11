namespace cnums.Symbolic
{
    public class Symbol
    {
        private char sym = 'x';
        private string subscript = "";

        public char Sym
        {
            get { return sym; }
            private set { sym = value; }
        }

        public string Subscript
        {
            get { return subscript; }
            private set { subscript = value; }
        }

        public Symbol(char symbol)
        {
            if (Char.IsDigit(symbol)
                || Char.IsPunctuation(symbol)
                || Char.IsWhiteSpace(symbol))
                throw new Exception("Symbol cannot be a digit or a punctuation mark or a white space.");

            this.Sym = symbol;
        }

        internal Symbol() { }
        
        public Symbol(char symbol, uint subscript)
        {
            if (Char.IsDigit(symbol)
                || Char.IsPunctuation(symbol)
                || Char.IsWhiteSpace(symbol))
                throw new ArgumentException("Symbol cannot be a digit or a punctuation mark or a white space.");

            this.Sym = symbol;
            this.subscript = subscript.UnicodeSubscript();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null 
                || obj.GetType() != this.GetType())
                return false;
            
            Symbol symbol = (Symbol)obj;
            if (symbol.sym == this.sym
                && symbol.subscript == this.subscript)
                return true;

            return false;
        }

        public override int GetHashCode()
            => (int)sym;

        public override string ToString()
            => $"{this.Sym}{this.Subscript}";

        #region Addition.

        public static Polynomial operator +(Symbol symbol)
            => new(new List<SymbolContainer>() { new SymbolContainer(symbol) });

        public static Polynomial operator +(Symbol symbol, double number)
            => new(new List<SymbolContainer>() { new SymbolContainer(symbol), new SymbolContainer(number) });

        public static Polynomial operator +(double number, Symbol symbol)
            => symbol + number;

        public static Polynomial operator +(Symbol symbol1, Symbol symbol2)
        {
            object addition = new SymbolContainer(symbol1) + new SymbolContainer(symbol2); 

            if(addition.GetType() == typeof(cnums.SymbolContainer))
                return new(new List<SymbolContainer>() { (SymbolContainer) addition });

            return new((Polynomial)addition, true);
        }

        #endregion

        #region Substraction

        public static Polynomial operator -(Symbol symbol)
            => new(new List<SymbolContainer>() { new SymbolContainer(symbol, coefficient: -1) });

        public static Polynomial operator -(Symbol symbol, double number)
            => new(new List<SymbolContainer>() { new SymbolContainer(symbol), new SymbolContainer(-number) });

        public static Polynomial operator -(double number, Symbol symbol)
            => new(new List<SymbolContainer>() { new SymbolContainer(symbol, coefficient: -1), new SymbolContainer(-number) });

        public static Polynomial operator -(Symbol symbol1, Symbol symbol2)
        {
            object substraction = new SymbolContainer(symbol1) - new SymbolContainer(symbol2);

            if (substraction.GetType() == typeof(cnums.SymbolContainer))
                return new(new List<SymbolContainer>() { (SymbolContainer)substraction });

            return new((Polynomial)substraction, true);
        }

        #endregion

        #region Multiplication

        public static Polynomial operator *(Symbol symbol, double number)
            => new(new List<SymbolContainer>() { new(symbol, number) });

        public static Polynomial operator *(double number, Symbol symbol)
            => symbol * number;

        #endregion

        #region Comparision

        public static bool operator ==(Symbol symbol1, Symbol symbol2)
            => symbol1.Equals(symbol2);

        public static bool operator !=(Symbol symbol1, Symbol symbol2)
            => !symbol1.Equals(symbol2);

        #endregion
    }
}
