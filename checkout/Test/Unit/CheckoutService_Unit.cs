using Checkout.Library.Exceptions;
using Checkout.Models;
using Checkout.Services;

namespace Test.Unit {
    public class CheckoutService_Unit {
        public static IEnumerable<object[]> UnitPriceData => [
            [new List<PriceRule> { new UnitPriceRule("A", 10) }, new List<string> { "A", "A", "A" }, 30],
            [new List<PriceRule> { new UnitPriceRule("A", 50), new UnitPriceRule("B", 30)}, new List<string> { "A", "B", "A"}, 130]
        ];

        [Theory]
        [MemberData(nameof(UnitPriceData))]
        public void CheckoutService_UnitPrices_CorrectTotal(List<PriceRule> priceRules, List<string> items, decimal expectedTotal) {
            var checkoutService = new CheckoutService(priceRules);

            checkoutService.Scan(items);

            Assert.Equal(expectedTotal, checkoutService.GetTotalPrice());
        }

        public static IEnumerable<object[]> SpecialPriceData => [
            [new List<PriceRule> { new SpecialPriceRule("B", 3, 30) }, new List<string> { "B", "B", "B" }, 30],
            [new List<PriceRule> { new SpecialPriceRule("A", 2, 10), new SpecialPriceRule("B", 3, 30) }, new List<string> { "A", "A", "B", "B", "B"}, 40]
        ];

        [Theory]
        [MemberData(nameof(SpecialPriceData))]
        public void CheckoutService_OnlySpecialPrices_ExactAmounts_CorrectTotal(List<PriceRule> priceRules, List<string> items, decimal expectedTotal) {
            var checkoutService = new CheckoutService(priceRules);

            checkoutService.Scan(items);

            Assert.Equal(expectedTotal, checkoutService.GetTotalPrice());
        }

        public static IEnumerable<object[]> SpecialPriceInvalidData => [
            [new List<PriceRule> { new SpecialPriceRule("A", 2, 10) }, new List<string> { "A" }]
        ];

        [Theory]
        [MemberData(nameof(SpecialPriceInvalidData))]
        public void CheckoutService_OnlySpecialPrices_InexactAmounts_Invalid(List<PriceRule> priceRules, List<string> items) {
            var checkoutService = new CheckoutService(priceRules);

            checkoutService.Scan(items);

            Assert.Throws<NotAllIItemsPricedException>(() => checkoutService.GetTotalPrice());
        }

        public static IEnumerable<object[]> MixedPriceData => [
            [new List<PriceRule> { new UnitPriceRule("A", 50), new SpecialPriceRule("A", 3, 130) , new UnitPriceRule("B", 30), new SpecialPriceRule("B", 2, 45) }, new List<string> { "B", "A", "B" }, 95 ]
        ];

        [Theory]
        [MemberData(nameof(MixedPriceData))]
        public void CheckoutService_MixedPrices_CorrectTotal(List<PriceRule> priceRules, List<string> items, decimal expectedTotal) {
            var checkoutService = new CheckoutService(priceRules);

            checkoutService.Scan(items);

            Assert.Equal(expectedTotal, checkoutService.GetTotalPrice());
        }
    }
}