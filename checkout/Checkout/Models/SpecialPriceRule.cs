namespace Checkout.Models {
    public class SpecialPriceRule : PriceRule {
        private readonly int _quantityForSpecialPrice;
        private readonly decimal _specialPrice;
        // fallback price is basically a unit price. want to avoid some complex inheritance tree though.
        // want a way of getting this out, means that price calculation either needs to be aware of other pricing (bad), or we need to return other data?

        public SpecialPriceRule(string sku, int quantityForSpecialPrice, decimal specialPrice) : base(sku) {
            _quantityForSpecialPrice = quantityForSpecialPrice;
            _specialPrice = specialPrice;
        }

        public override PriceResult CalculatePrice(int quantity) {
            int specialPriceCount = quantity / _quantityForSpecialPrice;
            int remainingCount = quantity % _quantityForSpecialPrice;

            decimal price = (specialPriceCount * _specialPrice);

            return new PriceResult(price, quantity - remainingCount);
        }
    }
}