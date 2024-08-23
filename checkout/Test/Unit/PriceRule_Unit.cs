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

            Assert.Equal(expectedTotal, result.price);
        }

        [Theory]
        [InlineData(35, 3, 3, 35)]
        [InlineData(60, 4, 4, 60)]
        public void SpecialPrice_CalculatePrice_Correct(int specialPrice, int quantityForSpecialPrice, int quantity, int expectedTotal) {
            var specialPriceRule = new SpecialPriceRule("A", quantityForSpecialPrice, specialPrice);

            var result = specialPriceRule.CalculatePrice(quantity);

            Assert.Equal(expectedTotal, result.price);
            Assert.Equal(quantity, result.quantityAccountedFor);
        }
    }
}