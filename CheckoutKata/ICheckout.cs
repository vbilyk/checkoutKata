namespace CheckoutKata
{
    public interface ICheckout 
    {
        void Scan(Item item);
        double Total();
    }
}
