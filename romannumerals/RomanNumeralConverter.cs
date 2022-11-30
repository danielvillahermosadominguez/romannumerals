namespace romanumerals;

public class RomanNumeralConverter
{
    private const int MAX_RANGE = 3000;
    private const int MIN_RANGE = 1;
    private int _number;
    private Dictionary<int, string> _units;

    public RomanNumeralConverter(int number)
    {
        _number = number;
        initializeUnits();
    }

    public string Convert()
    {
        checkOutOfRange();

        var result = "";
        var rest = _number;

        while(rest > 0)
        {

            int selectedSymbol = -1;
            for (int i = _units.Count()-1; i >= 0 ; i--)
            {
                KeyValuePair<int, string> unit = _units.ElementAt(i);
                if (rest >= unit.Key|| rest == unit.Key -1)
                {
                    selectedSymbol = i;
                    break;
                }
            }

            if(selectedSymbol >= 0) {
                KeyValuePair<int, string> unit = _units.ElementAt(selectedSymbol);

                if (rest == (unit.Key - 1))
                {
                    KeyValuePair<int, string> firstSymbol = _units.ElementAt(0);
                    if(string.IsNullOrEmpty(result) || result.ElementAt(0) +"" == unit.Value)
                    {
                        result = firstSymbol.Value + unit.Value + result;
                    } else
                    {
                        result += firstSymbol.Value + unit.Value;
                    }
                } else
                {
                   result += unit.Value;
                }
                rest -= unit.Key;
            }
        }
        
        return result;
    }

    private void checkOutOfRange()
    {
        if (_number < MIN_RANGE || _number > MAX_RANGE)
        {
            throw new OutOfRange();
        }
    }

    private void initializeUnits()
    {
        _units = new Dictionary<int, string>()
        {
            { 1, "I"},
            { 5, "V" },
            { 10, "X"}
        };
    }
}
