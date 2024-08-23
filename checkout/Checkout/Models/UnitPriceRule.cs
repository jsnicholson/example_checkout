namespace Checkout.Models {
    public class UnitPriceRule : PriceRule {
        private readonly decimal _unitPrice;

        public UnitPriceRule(string sku, decimal unitPrice) : base(sku) {
            _unitPrice = unitPrice;
        }

        public override PriceResult CalculatePrice(int quantity) {
            return new PriceResult(_unitPrice * quantity, quantity);
        }
    }
}