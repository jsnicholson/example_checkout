namespace Checkout.Models {
    public abstract class PriceRule {
        public string Sku { get; }

        protected PriceRule(string sku) {
            Sku = sku;
        }

        public abstract decimal CalculatePrice(int quantity);
    }
}