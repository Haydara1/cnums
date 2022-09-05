namespace cnums;

public class Function
{

    private object? function;

    private Domain? domain;

    public Domain? Domain
    {
        get { return domain; }
        private set { domain = value; }
    }

    public Function(Polynomial polynomial)
    {
        function = polynomial;
        Domain = new();
    }

}

