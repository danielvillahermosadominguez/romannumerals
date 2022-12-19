namespace romanumerals;

record struct Symbol(int number, string roman);

public class RomanNumeralConverter
{
    private List<Symbol> _symbols;
    private const int MaxRange = 3999;
    private const int MinRange = 1;

    public RomanNumeralConverter()
    {
        InitializeSymbols();
    }

    public string Convert(int number)
    {
        CheckOutOfRange(number);

        var result = "";
        var rest = number;

        while (rest > 0)
        {
            var currentSymbol = GetNearestSymbol(rest);
            var precedentSymbol = GetPrecedentSymbolWith1AsFirstDigit(currentSymbol);
            var symbol = CalculateSymbolOnTheFly(rest, currentSymbol, precedentSymbol);
            result += symbol.roman;
            rest -= symbol.number;
        }

        return result;
    }

    private static Symbol CalculateSymbolOnTheFly(int rest, Symbol currentSymbol, Symbol precedentSymbol)
    {
        if (IsBetween(rest, currentSymbol, precedentSymbol))
        {
            return new Symbol(
                currentSymbol.number - precedentSymbol.number,
                precedentSymbol.roman + currentSymbol.roman);
        }

        return currentSymbol;
    }

    private static bool IsBetween(int rest, Symbol currentSymbol, Symbol previousSymbol)
    {
        return (rest >= (currentSymbol.number - previousSymbol.number)) && (rest < currentSymbol.number);
    }

    private void InitializeSymbols()
    {
        _symbols = new List<Symbol>()
        {
            new Symbol(1, "I"),
            new Symbol(5, "V"),
            new Symbol(10, "X"),
            new Symbol(50, "L"),
            new Symbol(100, "C"),
            new Symbol(500, "D"),
            new Symbol(1000, "M")
        };
        _symbols.Reverse();
    }

    private static bool IsTheFirstDigitOne(int number)
    {
        var firstDigit = number / ((int)(Math.Pow(10, (int)Math.Log10(number))));
        return firstDigit == 1;
    }

    private Symbol GetPrecedentSymbolWith1AsFirstDigit(Symbol currentSymbol)
    {
        foreach (var symbol in _symbols)
        {
            if (symbol.number < currentSymbol.number && IsTheFirstDigitOne(symbol.number))
            {
                return symbol;
            }
        }

        return _symbols.ElementAt(0);
    }

    private Symbol GetNearestSymbol(int rest)
    {
        foreach (var symbol in _symbols)
        {
            var beforeUnit = GetPrecedentSymbolWith1AsFirstDigit(symbol);
            var lowLimit = symbol.number - beforeUnit.number;
            if (rest >= lowLimit)
            {
                return symbol;
            }
        }

        throw new NotExistAnUnit();
    }

    private static void CheckOutOfRange(int number)
    {
        if (number < MinRange || number > MaxRange)
        {
            throw new OutOfRange();
        }
    }
}