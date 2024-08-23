using Checkout.Models;
using Checkout.Services;

namespace Test.Unit {
    public class CheckoutService_Unit {
        public static IEnumerable<object[]> UnitPriceData => [
            [new List<PriceRule> { new UnitPriceRule("A", 10) }, new List<string> { "A", "A", "A" }, 30],
            [new List<PriceRule> { new UnitPriceRule("A", 50), new UnitPriceRule("B", 30)}, new List<string> { "A", "B", "A"}, 130]
        ];

        public static IEnumerable<object[]> SpecialPriceData => [
            new object[] { }
        ];

        public static IEnumerable<object[]> MixedPriceData => [
            new object[] { }
        ];

        [Theory]
        [MemberData(nameof(UnitPriceData))]
        public void CheckoutService_UnitPrices_CorrectTotal(List<PriceRule> priceRules, List<string> items, decimal expectedTotal) {
            var checkoutService = new CheckoutService(priceRules);

            checkoutService.Scan(items);

            Assert.Equal(expectedTotal, checkoutService.GetTotalPrice());
        }

        [Theory]
        [MemberData(nameof(SpecialPriceData))]
        public void CheckoutService_SpecialPrices_CorrectTotal(List<PriceRule> priceRules, List<string> items, decimal expectedTotal) {
            var checkoutService = new CheckoutService(priceRules);

            checkoutService.Scan(items);

            Assert.Equal(expectedTotal, checkoutService.GetTotalPrice());
        }

        [Theory]
        [MemberData(nameof(MixedPriceData))]
        public void CheckoutService_MixedPrices_CorrectTotal(List<PriceRule> priceRules, List<string> items, decimal expectedTotal) {
            var checkoutService = new CheckoutService(priceRules);

            checkoutService.Scan(items);

            Assert.Equal(expectedTotal, checkoutService.GetTotalPrice());
        }
    }
}