namespace romanumerals.tests
{
    [TestFixture]
    public class RomanNumeralConverterShould
    {
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(4000)]
        public void Throw_exception_when_the_input_number_is_out_of_range(int number)
        {
            var romanNumeralConverter = new RomanNumeralConverter();

            Assert.Throws<OutOfRange>(() => romanNumeralConverter.Convert(number));
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
        [TestCase(17, "XVII")]
        [TestCase(18, "XVIII")]
        [TestCase(19, "XIX")]
        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(22, "XXII")]
        [TestCase(28, "XXVIII")]
        [TestCase(29, "XXIX")]
        [TestCase(30, "XXX")]
        [TestCase(26, "XXVI")]
        [TestCase(24, "XXIV")]
        [TestCase(29, "XXIX")]
        [TestCase(40, "XL")]
        [TestCase(49, "XLIX")]
        [TestCase(50, "L")]
        [TestCase(90, "XC")]
        [TestCase(150, "CL")]
        [TestCase(500, "D")]
        [TestCase(599, "DXCIX")]
        [TestCase(1000, "M")]
        [TestCase(1600, "MDC")]
        [TestCase(3999, "MMMCMXCIX")]
        public void Convert_the_number_to_a_roman_text(
            int number,
            string roman)
        {
            var romanNumeralConverter = new RomanNumeralConverter();

            var result = romanNumeralConverter.Convert(number);

            Assert.That(result, Is.EqualTo(roman));
        }
    }
}