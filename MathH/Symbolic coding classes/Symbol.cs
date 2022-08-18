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

        private double Coefficient = 1;

        public double coefficient
        {
            get { return Coefficient; }
            private set { Coefficient = value; }
        }

        private double Power = 1;

        public double power
        {
            get { return Power; }
            private set { Power = value; }  
        }

        public Symbol(string symbol)
        {
            this.Sym = symbol;
        }

        public Symbol(string symbol, double coefficient = 1, double power = 1)
        {
            this.Sym = symbol;
            this.Coefficient = coefficient;
            this.Power = power;
        }

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


        public static Symbol operator +(Symbol sym) => sym;
        public static Symbol operator -(Symbol sym) => new(sym.Sym, -sym.coefficient);

        public static Symbol operator *(Symbol sym, double num) => new(sym.Sym, sym.coefficient * num);
        public static Symbol operator /(Symbol sym, double num) => new(sym.Sym, sym.coefficient / num);

        public static Symbol operator *(double num, Symbol sym) => new(sym.Sym, sym.coefficient * num);
        public static Symbol operator /(double num, Symbol sym) => new(sym.Sym, num / sym.coefficient, -sym.power);
    }


}
