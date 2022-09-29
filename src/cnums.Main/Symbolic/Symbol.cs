namespace cnums.Symbolic
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
            if (obj == null 
                || obj.GetType() != this.GetType())
                return false;
            
            Symbol symbol = (Symbol)obj;
            if (symbol.sym == this.sym)
                return true;

            return false;
        }

        public override int GetHashCode()
            => (int)sym;

        public override string ToString()
            => $"{this.Sym}";

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

        

        #region Comparision

        public static bool operator ==(Symbol symbol1, Symbol symbol2)
            => symbol1.Equals(symbol2);

        public static bool operator !=(Symbol symbol1, Symbol symbol2)
            => !symbol1.Equals(symbol2);

        #endregion
    }


}
