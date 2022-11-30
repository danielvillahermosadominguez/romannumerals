namespace romanumerals.tests
{
    [TestFixture]
    public class RomanNumeralConverterShould
    {
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3001)]
        public void Throw_exception_when_the_input_number_is_out_of_range(int number)
        {
            var romanNumeralConverter = new RomanNumeralConverter(number);

            Assert.Throws<OutOfRange>(() => romanNumeralConverter.Convert());
        }

        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(12, "XII")]
        [TestCase(13, "XIII")]
        [TestCase(14, "XIV")]
        [TestCase(15, "XV")]
        [TestCase(16, "XVI")] 
        public void Convert_the_number_to_a_roman_text(
            int number,
            string roman)
        {
            var romanNumeralConverter = new RomanNumeralConverter(number);

            var result = romanNumeralConverter.Convert();

            Assert.That(result, Is.EqualTo(roman));
        }
    }
}
