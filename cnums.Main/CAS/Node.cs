namespace cnums.Main.CAS; // CAS refers to "Computer Algebra System".

/*
 * Computer algebra systems rely on transforming a mathematical expression,
 * into a tree, so an expression would be composed of numbers, actions, ...
 * 
 * The main of this class is to be the base object that hold all mathematical objects,
 * so they can be stored in a tree.
 */

// This class should be abstract as it will be a generic class that represents a mathematical objct.
public abstract class Node
{
    private List<Node> Children { get; set; } = [];
    
    /// <summary>
    /// Returns the number of nodes this node is responsible of.
    /// </summary>
    /// <returns>An integer number (children count).</returns>
    public int GetChildrenCount() => Children.Count;
    
    
    
}