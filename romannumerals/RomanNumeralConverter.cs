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

        if (_units.ContainsKey(_number))
        {
            return _units[_number];
        }

        var result = "";
        var rest = _number;
        foreach (var unit in _units.Reverse())
        {
            if (unit.Key == _units.Last().Key)
            {
                while(rest > 0)
                {
                    rest -= unit.Key;
                    result += unit.Value;
                }
            }
            else
            {
                if (rest > unit.Key)
                {
                    rest %= unit.Key;
                    result += unit.Value;
                }
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

    private string concatISymbols(int baseNumber, int number)
    {
        return _units[baseNumber] + _units[number];
    }

    private void initializeUnits()
    {
        _units = new Dictionary<int, string>()
        {
            { 1, "I"},
            { 4, "IV" },
            { 5, "V" },
            { 9, "IX"},
            { 10, "X"}
        };
    }
}
