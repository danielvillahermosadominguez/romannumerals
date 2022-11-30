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
            KeyValuePair<int,string> ?unitDetected = null;
            foreach (var unit in _units.Reverse())
            {
                if (rest >= unit.Key)
                {
                    unitDetected = unit;
                    break;
                }
            }

            if(unitDetected != null) {
                rest -= unitDetected.Value.Key;
                result += unitDetected.Value.Value;
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
            { 4, "IV" },
            { 5, "V" },
            { 9, "IX"},
            { 10, "X"}
        };
    }
}
