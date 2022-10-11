namespace cnums;

public class CnumsException : Exception 
{
    //Overriding the Message property
    public override string Message
    {
        get
        {
            return "This exception was caused by a bug in the namespace, it is us, not you!";
        }
    }

    //Overriding the HelpLink Property
    public override string HelpLink
    {
        get
        {
            return "It is probably marked as an issue: https://github.com/Haydara1/cnums/issues, otherwise, please let us know about it!";
        }
    }

    public CnumsException() : base()
    { }
}
