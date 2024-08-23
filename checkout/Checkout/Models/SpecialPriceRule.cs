namespace Checkout.Models {
    public class SpecialPriceRule : PriceRule {
        private readonly int _quantityForSpecialPrice;
        private readonly decimal _specialPrice;
        private readonly decimal _fallbackPrice;

        public SpecialPriceRule(string sku, int quantityForSpecialPrice, decimal specialPrice, decimal fallbackPrice) : base(sku) {
            _quantityForSpecialPrice = quantityForSpecialPrice;
            _specialPrice = specialPrice;
            _fallbackPrice = fallbackPrice;
        }

        public override decimal CalculatePrice(int quantity) {
            int specialPriceCount = quantity / _quantityForSpecialPrice;
            int regularPriceCount = quantity % _quantityForSpecialPrice;

            return (specialPriceCount * _specialPrice) + (regularPriceCount * _fallbackPrice);
        }
    }
}