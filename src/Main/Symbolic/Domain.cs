using static cnums.Statistics;

namespace cnums.Symbolic
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

        private List<double> exceptionValues = new();

        public List<double> ExceptionValues
        {
            get { return exceptionValues; } 
            private set { exceptionValues = value; }    
        }

        private bool openBeginning = true;

        public bool OpenBeginning
        {
            get { return openBeginning; }
            private set {  openBeginning = value; }
        }

        private bool openEnd = true;

        public bool OpenEnd
        {
            get { return openEnd; }
            private set { openEnd = value; }
        }

        public Domain() {}

        public Domain(double beginning, double end)
        {
            this.beginning = Min(beginning, end);
            this.end = Max(beginning, end);

            if (double.IsNegativeInfinity(beginning)) OpenBeginning = true;
            else OpenBeginning = false;

            if (double.IsPositiveInfinity(end)) OpenEnd = true;
            else OpenEnd = false;
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
        {
            exceptionDomains.Add(domain);
            SimplifyExceptionDomains();
        }

        public void AddExceptionValues(double value)
        {
            if (double.IsInfinity(value) || double.IsNaN(value)) 
                throw new Exception("Can't except infinity, or double.NaN.");

            exceptionValues.Add(value);
            SimplifyExceptionValues();
        }

        public void AddExceptionValues(double[] values)
        {
            foreach(double value in values)
                exceptionValues.Add(value);

            SimplifyExceptionValues();
        }

        private void SimplifyExceptionDomains()
        {
            for (int i = 0; i < exceptionDomains.Count - 1; i++)
            {
                if (Maths.CrossedDomains(exceptionDomains[i], exceptionDomains[i + 1]))
                {
                    exceptionDomains[i] = Maths.UniteCrossedDomains(exceptionDomains[i], exceptionDomains[i + 1]);
                    exceptionDomains.RemoveAt(i + 1);

                    i = -1;
                }
            }
        }

        private void SimplifyExceptionValues()
        {
            exceptionValues = exceptionValues.Distinct().ToList();

            for(int i = 0; i < exceptionValues.Count; i++)
            {
                foreach(Domain domain in ExceptionDomains)
                {
                    if (Maths.DomainContainsValue(domain, exceptionValues[i]))
                    {
                        exceptionValues.RemoveAt(i);
                        i--;
                        break;
                    }
                    else if(domain.Begin == exceptionValues[i] && domain.openBeginning)
                    {
                        domain.openBeginning = false;
                        exceptionValues.RemoveAt(i);

                        i--;
                        break;
                    }
                    else if (domain.End == exceptionValues[i] && domain.openEnd)
                    {
                        domain.openEnd = false;
                        exceptionValues.RemoveAt(i);

                        i--;
                        break;
                    }
                }
            }

            exceptionValues.Sort();
        }

        public bool ContainsExceptionValues()
        {
            if (ExceptionDomains.Count == 0 || ExceptionValues.Count == 0) return false;
            return true;
        }

        public bool ContainsValue(double value)
            => Maths.DomainContainsValue(this, value);

        public bool ContainsDomain(Domain domain)
            => Maths.DomainContainsDomain(this, domain);

        public override string ToString()
        {
            string domain = "";

            if (double.IsNegativeInfinity(this.Begin)) domain += "(-\u221e,";
            else
            {
                if (openBeginning) domain += $"({this.Begin},";
                else domain += $"[{this.Begin},";
            }
            
            foreach(Domain dm in ExceptionDomains)
            {
                if (dm.openBeginning) domain += $" {dm.Begin}] U ";
                else domain += $" {dm.Begin}) U ";

                if(dm.openEnd) domain += $"[{dm.End},";
                else domain += $"({dm.End},";
            }

            if (double.IsNegativeInfinity(this.End)) domain += " \u221e)";
            else
            {
                if (openEnd) domain += $" {this.End})";
                else domain += $" {this.End}]";
            }

            string exceptionVals = "\\{";

            foreach (double value in exceptionValues)
                exceptionVals += $"{value}, ";

            exceptionVals = exceptionVals[..^2];
            exceptionVals += "}";

            if(ExceptionValues.Count == 0) 
                return domain;

            return domain + exceptionVals;
        }
    }
}
