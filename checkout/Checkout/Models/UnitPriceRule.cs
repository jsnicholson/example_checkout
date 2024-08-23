namespace Checkout.Models {
    public class UnitPriceRule : PriceRule {
        private readonly decimal _unitPrice;

        public UnitPriceRule(string sku, decimal unitPrice) : base(sku) {
            _unitPrice = unitPrice;
        }

        public override decimal CalculatePrice(int quantity) {
            return _unitPrice * quantity;
        }
    }
}