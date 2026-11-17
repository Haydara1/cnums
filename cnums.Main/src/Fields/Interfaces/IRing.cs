namespace cnums.Main.Fields.Interfaces;

public interface IRing<TSelf> : IGroup<TSelf> where TSelf : IRing<TSelf>
{
    static abstract TSelf MultiplicativeIdentity { get; }
    
    static abstract TSelf operator *(TSelf a, TSelf b);
}