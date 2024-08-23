using Checkout.Models;

namespace Test.Unit {
    public class PriceRule_Unit {
        [Theory]
        [InlineData(10, 3, 30)]
        [InlineData(5, 4, 20)]
        [InlineData(1.5, 4, 6)]
        public void UnitPrice_CalculatePrice_Correct(decimal unitPrice, int quantity, decimal expectedTotal) {
            var unitPriceRule = new UnitPriceRule("A", unitPrice);

            var result = unitPriceRule.CalculatePrice(quantity);

            Assert.Equal(expectedTotal, result);
        }

        [Theory]
        [InlineData(35, 3, 15, 3, 35)]
        [InlineData(35, 3, 15, 2, 30)]
        [InlineData(35, 3, 15, 4, 50)]
        public void SpecialPrice_CalculatePrice_Correct(int specialPrice, int quantityForSpecialPrice, int fallbackPrice, int quantity, int expectedTotal) {
            var specialPriceRule = new SpecialPriceRule("A", quantityForSpecialPrice, specialPrice, fallbackPrice);

            var result = specialPriceRule.CalculatePrice(quantity);

            Assert.Equal(expectedTotal, result);
        }
    }
}