using Checkout.Models;
using Checkout.Services.Interfaces;

namespace Checkout.Services {
    public class CheckoutService : ICheckoutService {
        private readonly List<PriceRule> _priceRules;
        private readonly Dictionary<string, int> _scannedItems = new();

        public CheckoutService(List<PriceRule> priceRules) {
            _priceRules = priceRules;
        }

        public decimal GetTotalPrice() {
            throw new NotImplementedException();
        }

        public void Scan(string item) {
            throw new NotImplementedException();
        }

        public void Scan(List<string> items) {
            throw new NotImplementedException();
        }
    }
}