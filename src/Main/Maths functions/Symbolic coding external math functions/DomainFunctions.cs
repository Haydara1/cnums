using cnums.Symbolic;

namespace cnums;

public static partial class Maths
{
    internal static Domain UniteCrossedDomains(Domain domain1, Domain domain2)
    {
        bool openB, openE;

        if (domain1.Begin < domain2.Begin) openB = domain1.OpenBeginning;
        else if(domain1.Begin > domain2.Begin) openB = domain2.OpenBeginning;
        else openB = domain1.OpenBeginning | domain2.OpenBeginning;

        if (domain1.End > domain2.End) openE = domain1.OpenEnd;
        else if (domain1.End < domain2.End) openE = domain2.OpenEnd;
        else openE = domain1.OpenEnd | domain2.OpenEnd;

        return new(Statistics.Min(domain1.Begin, domain2.Begin), 
                    Statistics.Max(domain1.End, domain2.End), 
                    openBeginning:openB, 
                    openEnd:openE);
    }

    internal static bool DomainContainsValue(Domain domain, double value)
    {
        if (domain.ExceptionValues.Contains(value)) return false;

        if(domain.ContainsExceptionValues())
        {
            foreach(Domain dm in domain.ExceptionDomains)
                if (DomainContainsValue(dm, value))
                    return false;

            if (((value > domain.Begin) || (value == domain.Begin && !domain.OpenBeginning)) &&
                ((value < domain.End) || (value == domain.End && !domain.OpenEnd)))
                return true;

            return false;
        }

        if (((value > domain.Begin) || (value == domain.Begin && !domain.OpenBeginning)) &&
                ((value < domain.End) || (value == domain.End && !domain.OpenEnd)))
            return true;

        return false;
    }

    internal static bool DomainContainsDomain(Domain domain1, Domain domain2)
    {
        if(domain1.ContainsValue(domain2.Begin) && domain1.ContainsValue(domain2.End))
        {
            foreach(Domain dm in domain1.ExceptionDomains)
            {
                if (domain2.ContainsValue(dm.Begin) || domain2.ContainsValue(dm.End))
                    return false;
            }

            return true;
        }

        return false;
    }

    internal static bool CrossedDomains(Domain domain1, Domain domain2)
    {
        if ((domain1.Begin >= domain2.Begin && domain1.Begin <= domain2.End) ||
       (domain2.Begin >= domain1.Begin && domain2.Begin <= domain1.End))
            return true;
        return false;
    }

}