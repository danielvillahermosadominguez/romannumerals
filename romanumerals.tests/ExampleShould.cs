namespace romanumerals.tests
{
    [TestFixture]
    public class RomanNumeralConverterShould
    {
        [Test]
        public void Throw_exception_when_the_input_number_is_zero()
        {
            var romanNumeralConverter = new RomanNumeralConverter(0);

            Assert.Throws<OutOfRange>(() => romanNumeralConverter.Convert());
        }
    }
}
