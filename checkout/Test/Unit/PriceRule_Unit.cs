namespace Test.Unit {
    public class PriceRule_Unit {
        [Theory]
        [InlineData(0, 0, 0)]
        public void UnitPrice_CalculatePrice_Correct(int unitPrice, int quantity, int expectedTotal) {

        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        public void SpecialPrice_CalculatePrice_Correct(int specialPrice, int quantityForSpecialPrice, int fallbackPrice, int quantity, int expectedTotal) {

        }
    }
}