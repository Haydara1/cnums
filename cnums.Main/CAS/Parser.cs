using cnums.Main.CAS.Nodes.Operators;
using cnums.Main.CAS.Nodes;

namespace cnums.Main.CAS;
/*
 * This class will be in charge of transforming strings (expressions) to Nodes.
 * Every node tree has a root, so we can consider the root as node,
 * thus it will transform each string to a single node (since nodes contain their children). 
 */

public class Parser
{
    /// <summary>
    /// Constructor
    /// </summary>
    public Parser() {}

    /// <summary>
    /// Parses a given expression into a node tree.
    /// </summary>
    /// <param name="expression">The mathematical expression written in Latex</param>
    /// <returns>The tree's root as a Node.</returns>
    public Node Parse(string expression)
    {
        List<NodeContainer> linearExpression = DecomposeExpression(expression);

        return null;
    }

    // Notice how the output here is linear and not tree-like.
    /// <summary>
    /// Decomposes a string into a list composed of Nodes.
    /// Each element of the string gets its own node.
    /// </summary>
    /// <param name="expression">The string expression to be decomposed.</param>
    /// <returns>A List of nodes.</returns>
    private List<NodeContainer> DecomposeExpression(string expression)
    {
        List<NodeContainer> output = new List<NodeContainer>();

        /*
         *  TODO
         * Change behaviour.
         * currently the algorithm considers every symbol as a single character,
         * this behaviour should be changed, as more complex structures may appear.
         */
        foreach (char x in expression)
        {
            output.Add(new NodeContainer(x.ToString()));
        }
        
        return output;
    }
    
}