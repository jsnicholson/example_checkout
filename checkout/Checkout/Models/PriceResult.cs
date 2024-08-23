namespace Checkout.Models {
    public class PriceResult {
        public decimal price { get; set; }
        public int quantityAccountedFor { get; set; }

        public PriceResult(decimal price, int itemsAccountedFor) {
            this.price = price;
            this.quantityAccountedFor = itemsAccountedFor;
        }
    }
}
