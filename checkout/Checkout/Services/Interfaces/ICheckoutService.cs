namespace Checkout.Services.Interfaces {
    public interface ICheckoutService {
        void Scan(string item);
        int GetTotalPrice();
    }
}