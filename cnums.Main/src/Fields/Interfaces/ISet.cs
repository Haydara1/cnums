namespace cnums.Main.Fields.Interfaces;

public interface ISet<TSelf> where TSelf : ISet<TSelf>
{
    static abstract bool operator ==(TSelf a, TSelf b);

    static abstract bool operator !=(TSelf a, TSelf b);
    
    /// <summary>
    /// Creates an instance of the current type from a value,
    /// throwing an overflow exception for any values that fall outside the representable range of the current type.
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static abstract TSelf CreateChecked(Object a);
    
    /// <summary>
    /// Checks if a string can be parsed to give an element of the given set.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static abstract bool CanParse(string s);
}