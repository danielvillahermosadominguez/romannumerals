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

        if (_number > 10)
        {
            return concatISymbols(10);
        }

        return concatISymbols(5);
    }

    private void checkOutOfRange()
    {
        if (_number < MIN_RANGE || _number > MAX_RANGE)
        {
            throw new OutOfRange();
        }
    }

    private string concatISymbols(int number)
    {
        return _units[number] + _units[_number % 10];
    }

    private void initializeUnits()
    {
        _units = new Dictionary<int, string>()
        {
            { 1, "I"},
            { 2, "II" },
            { 3, "III" },
            { 4, "IV" },
            { 5, "V" },
            { 9, "IX"},
            { 10, "X"}
        };
    }
}
