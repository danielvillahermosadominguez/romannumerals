namespace romanumerals;

public class RomanNumeralConverter
{
    private int _number;

    public RomanNumeralConverter(int number)
    {
        _number = number;
    }

    public void Convert()
    {
        throw new OutOfRange();
    }
}
