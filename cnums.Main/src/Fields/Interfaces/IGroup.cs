namespace cnums.Main.Fields.Interfaces;

public interface IGroup<TSelf> : ISet<TSelf> where TSelf : IGroup<TSelf>
{
    static abstract TSelf AdditiveIdentity { get; }

    static abstract TSelf operator +(TSelf a, TSelf b);
    static abstract TSelf operator -(TSelf a);
    
}