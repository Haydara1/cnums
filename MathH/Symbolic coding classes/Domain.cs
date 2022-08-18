using static cnums.Statistics;

namespace cnums
{
    public class Domain
    {
        private double beginning = double.NegativeInfinity;

        public double Begin
        {
            get { return beginning; }
            set { beginning = value; }
        }

        private double end = double.PositiveInfinity;

        public double End
        {
            get { return end; }
            set { end = value; }
        }

        private List<Domain> exceptionDomains = new();

        public List<Domain> ExceptionDomains
        {
            get { return exceptionDomains; }
            private set { exceptionDomains = value; }
        }

        private bool openBeginning;

        public bool OpenBeginning
        {
            get { return openBeginning; }
            private set {  openBeginning = value; }
        }

        private bool openEnd;

        public bool OpenEnd
        {
            get { return openEnd; }
            private set { openEnd = value; }
        }

        public Domain(double beginning, double end, bool openBeginning = true, bool openEnd = true)
        {
            this.beginning = Min(beginning, end);
            this.end = Max(beginning, end);

            if (double.IsNegativeInfinity(beginning)) OpenBeginning = true;
            else OpenBeginning = openBeginning;

            if (double.IsPositiveInfinity(end)) OpenEnd = true;
            else OpenEnd = openEnd;
        }

        public void AddExceptionDomains(Domain domain)
            => exceptionDomains.Add(domain);

        public override string ToString()
        {
            string domain = "";

            if (double.IsNegativeInfinity(this.Begin)) domain += "]-\u221e,";
            else
            {
                if (openBeginning) domain += $"]{this.Begin},";
                else domain += $"[{this.Begin},";
            }
            
            foreach(Domain dm in ExceptionDomains)
            {
                if (dm.openBeginning) domain += $" {dm.Begin}] U ";
                else domain += $" {dm.Begin}] U ";

                if(dm.openEnd) domain += $"[{dm.End},";
                else domain += $"]{dm.End},";
            }

            if (double.IsNegativeInfinity(this.End)) domain += " \u221e[";
            else
            {
                if (openEnd) domain += $" {this.End}[";
                else domain += $" {this.End}[";
            }

            return domain;
        }


    }
}
