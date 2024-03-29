﻿using static cnums.Statistics;

namespace cnums.Symbolic;

public class NaturalDomain : Domain
{
    private uint beginning = uint.MinValue;

    public new uint Begin
    {
        get { return beginning; }
        set { beginning = value; }
    }

    private uint end = uint.MaxValue;

    public new uint End
    {
        get { return end; }
        set { end = value; }
    }

    private List<NaturalDomain> exceptionDomains = new();

    public new List<NaturalDomain> ExceptionDomains
    {
        get { return exceptionDomains; }
        private set { exceptionDomains = value; }
    }

    private List<uint> exceptionValues = new();

    public new List<uint> ExceptionValues
    {
        get { return exceptionValues; }
        private set { exceptionValues = value; }
    }

    private bool openBeginning = false;

    public new bool OpenBeginning
    {
        get { return openBeginning; }
        private set { openBeginning = value; }
    }

    private bool openEnd = false;

    public new bool OpenEnd
    {
        get { return openEnd; }
        private set { openEnd = value; }
    }

    public NaturalDomain(uint beginning, uint end) : base(beginning, end)
    {
        this.beginning = Min(beginning, end);
        this.end = Max(beginning, end);
    }

    public NaturalDomain(uint beginning, uint end, bool openBeginning = false, bool openEnd = false) 
        : base(beginning, end, openBeginning, openEnd)
    {
        this.beginning = Min(beginning, end);
        this.end = Max(beginning, end);

        OpenBeginning = openBeginning;
        OpenEnd = openEnd;
    }
}
