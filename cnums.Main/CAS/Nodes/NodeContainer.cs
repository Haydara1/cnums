namespace cnums.Main.CAS.Nodes;

/// <summary>
/// This node is a key concept for the parsing algorithm.
/// It helps transform the string expression into a list of readable nodes.
/// </summary>
/// <param name="storedValue"></param>
public class NodeContainer(string storedValue) : Node
{
   private int priority;
}

public record Priorities
{
   public static readonly string[] priorities =
   {
      "*/", // Multiplication and division.
      "+-",  // Addition and substraction.
   };
}