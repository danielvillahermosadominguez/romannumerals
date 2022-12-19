namespace romanumerals;

public class RomanNumeralConverter
{
    private record struct Unit(int latinSymbol, String romanSymbol);
    private List<Unit> _units;
    private const int MaxRange = 3999;
    private const int MinRange = 1;


    private int _rest;
    private int _number;
    private string _romanNumeral;

    public RomanNumeralConverter(int number)
    {
        _number = number;
        initializeUnits();
    }

    public string Convert()
    {
        checkOutOfRange();

        _romanNumeral = "";
        _rest = _number;

        while (_rest > 0)
        {
            var currentUnit = GetNearestUnitToTheRest();
            var previousUnit = getLastIncrementNotFiveAtBeginning(currentUnit);
            var increment = 0;
            var symbol = "";
            if ((_rest >= (currentUnit.latinSymbol - previousUnit.latinSymbol)) && (_rest < currentUnit.latinSymbol))
            {
                symbol =  previousUnit.romanSymbol + currentUnit.romanSymbol;
                increment = currentUnit.latinSymbol - previousUnit.latinSymbol;
            }
            else
            {
                increment = currentUnit.latinSymbol;
                symbol = currentUnit.romanSymbol;
            }

            _romanNumeral += symbol;
            _rest -= increment;
        }

        return _romanNumeral;
    }
    
    private void initializeUnits()
    {
        _units = new List<Unit>()
        {
            new Unit(1, "I"),
            new Unit(5, "V"),
            new Unit(10, "X"),
            new Unit(50, "L"),
            new Unit(100, "C"),
            new Unit(500, "D"),
            new Unit(1000, "M")
        };
    }

    private Boolean FirstDigitIsFive(int number)
    {
        int rest = number;
        while (rest > 0)
        {
            if (rest == 5)
            {
                return true;
            }

            rest = rest / 10;
        }

        return false;
    }

    private Unit getLastIncrementNotFiveAtBeginning(Unit currentUnit)
    {
        for (int i = _units.Count() - 1; i >= 0; i--)
        {
            var unit = _units.ElementAt(i);
            if ((unit.latinSymbol < currentUnit.latinSymbol) && !FirstDigitIsFive(unit.latinSymbol))
            {
                return unit;
            }
        }

        return _units.ElementAt(0);
    }
    
    

    private Unit GetNearestUnitToTheRest()
    {
        for (int i = _units.Count() - 1; i >= 0; i--)
        {
            var unit = _units.ElementAt(i);
            var beforeUnit = getLastIncrementNotFiveAtBeginning(unit);
            if (_rest >= unit.latinSymbol || (_rest >= unit.latinSymbol - beforeUnit.latinSymbol && _rest <unit.latinSymbol))
            {
                return unit;
            }
        }

        throw new NotExistAnUnit();
    }

    private void checkOutOfRange()
    {
        if (_number < MinRange || _number > MaxRange)
        {
            throw new OutOfRange();
        }
    }
}