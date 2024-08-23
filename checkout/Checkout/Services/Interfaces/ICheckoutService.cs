namespace Checkout.Services.Interfaces {
    public interface ICheckoutService {
        void Scan(string item);
        void Scan(List<String> items);
        decimal GetTotalPrice();
    }
}