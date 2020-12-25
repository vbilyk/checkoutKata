using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private Dictionary<Item, int> _groupedItemsCount = new Dictionary<Item, int>();
        private Dictionary<string, SpecialOffer> _offers;

        public Checkout(Dictionary<string, SpecialOffer> offers)
        {
            this._offers = offers != null ? offers : new Dictionary<string, SpecialOffer>();
        }

        public void Scan(Item item)
        {
            ValidateItem(item);
            AddItemToCheckout(item);
        }        

        public double Total()
        {
            double totalPrice = 0.0;
            foreach(var groupedItem in this._groupedItemsCount)
            {
                SpecialOffer specialOffer = null;
                if (!_offers.TryGetValue(groupedItem.Key.ProductCode, out specialOffer))
                {
                    specialOffer = new SpecialOffer(1, groupedItem.Key.Price);
                }
                totalPrice += specialOffer.Calculate(groupedItem.Value, groupedItem.Key.Price);
            }
            return totalPrice;
        }

        private void AddItemToCheckout(Item item)
        {
            if (!this._groupedItemsCount.ContainsKey(item))
            {
                this._groupedItemsCount.Add(item, 0);
            }
            _groupedItemsCount[item]++;
        }

        private void ValidateItem(Item item)
        {
            if (item == null) 
                throw new ArgumentNullException(nameof(item), "Scanned item shouldn't be null");
            if (string.IsNullOrEmpty(item.ProductCode)) 
                throw new ArgumentException(nameof(item.ProductCode), "Scanned item shouldn't have empty product code");
            if (item.Price <= 0)
                throw new ArgumentException(nameof(item.Price), "Scanned item price should be greater than 0");
        }
               
    }
}
