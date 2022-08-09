namespace cnums
{
    public class Symbol
    {

        private string Sym = String.Empty;

        public string sym
        {
            get { return Sym; }
            private set { Sym = value; }
        }

        public Symbol(string symbol) => sym = symbol;

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Symbol symbol = (Symbol)obj;
            if (symbol.sym == this.sym) return true;
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotSupportedException();
        }

        public override string ToString()
            => sym;



    }


}
