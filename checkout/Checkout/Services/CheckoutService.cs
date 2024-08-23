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
            decimal totalPrice = 0;

            foreach((string sku, int quantity) in _scannedItems) {
                var applicableRules = _priceRules.Where(r => r.Sku == sku).ToList();
                totalPrice += GetBestPrice(applicableRules, quantity);
            }

            return totalPrice;
        }

        private decimal GetBestPrice(List<PriceRule> priceRules, int quantity) {
            decimal minPrice = decimal.MaxValue;

            foreach(var rule in priceRules) {
                decimal price = rule.CalculatePrice(quantity);
                minPrice = Math.Min(minPrice, price);
            }

            return minPrice;
        }

        public void Scan(string item) {
            if (_scannedItems.ContainsKey(item))
                _scannedItems[item]++;
            else
                _scannedItems.Add(item, 1);
        }

        public void Scan(List<string> items) {
            foreach(var item in items)
                    Scan(item);
        }
    }
}