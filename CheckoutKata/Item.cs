namespace CheckoutKata
{
    public class Item
    {
        public double Price { get; set; }
        public string ProductCode { get; set; }

        public override int GetHashCode()
        {
            return this.ProductCode.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Item))
                return false;
            var objItem = obj as Item;
            return objItem.ProductCode.Equals(this.ProductCode);
        }
    }
}
