using Checkout.Library.Exceptions;
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
                Dictionary<(string sku, int quantity), decimal> priceMemoisation = new Dictionary<(string sku, int quantity), decimal>();
                var applicableRules = _priceRules.Where(r => r.Sku == sku).ToList();
                totalPrice += GetBestPrice(sku, applicableRules, quantity, priceMemoisation);
            }

            return totalPrice;
        }

        private decimal GetBestPrice(string sku, List<PriceRule> priceRules, int quantity, Dictionary<(string sku, int quantity), decimal> priceMemoisation) {
            Console.WriteLine($"GetBestPrice called");
            if (quantity <= 0) return 0;

            if (priceMemoisation.TryGetValue((sku, quantity), out var cachedPrice)) return cachedPrice;

            decimal minPrice = decimal.MaxValue;

            foreach (var rule in priceRules) {
                PriceResult result = rule.CalculatePrice(quantity);

                if (result.quantityAccountedFor > 0) {
                    decimal remainingPrice = GetBestPrice(sku, priceRules, quantity - result.quantityAccountedFor, priceMemoisation);
                    minPrice = Math.Min(minPrice, result.price + remainingPrice);
                }
            }

            if (minPrice == decimal.MaxValue) {
                throw new NotAllIItemsPricedException($"No applicable rules found for {quantity} '{sku}'s");
            }

            priceMemoisation[(sku, quantity)] = minPrice;

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