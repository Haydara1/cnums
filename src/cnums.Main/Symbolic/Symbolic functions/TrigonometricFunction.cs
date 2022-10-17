namespace cnums.Symbolic;

internal class TrigonometricFunction
{
    #region Properties

	private Function function;	

	public Function Func
	{
		get { return function; }
		set { function = value; }
	}

	public string type = "";

	#endregion

	#region Constructors

	public TrigonometricFunction(Function function)
	{
		this.function = function;
	}

	#endregion

	public Function ToFunction()
		=> new(this);

    #region Addition

	public static Function operator +(TrigonometricFunction trigonometric, double number)
		=> new Polynomial(new() { new(trigonometric), new(number)}).ToFunction();

	public static Function operator +(double number, TrigonometricFunction trigonometric)
		=> trigonometric + number;

	public static Function operator +(TrigonometricFunction trigonometric, Symbol symbol)
		=> new Polynomial(new() { new(trigonometric), new(symbol) }).ToFunction();

	public static Function operator +(Symbol symbol, TrigonometricFunction trigonometric)
		=> trigonometric + symbol;

    #endregion
}
