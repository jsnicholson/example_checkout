namespace Checkout.Models {
    public class UnitPriceRule : PriceRule {
        private readonly decimal _unitPrice;

        public UnitPriceRule(string sku, int unitPice) : base(sku) {
            _unitPrice = unitPice;
        }

        public override decimal CalculatePrice(int quantity) {
            return _unitPrice * quantity;
        }
    }
}