namespace Checkout.Library.Exceptions {
    public class NotAllIItemsPricedException : Exception {
        public NotAllIItemsPricedException(string message) : base(message) {}
    }
}