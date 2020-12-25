using System;

namespace CheckoutKata
{
    /// <summary>
    /// Representing special offers for products
    /// </summary>
    public class SpecialOffer
    {
        private int _itemsCount;
        private double _price;

        /// <summary>
        /// Creates special offer with default values 0,0
        /// </summary>
        public SpecialOffer() : this(0,0)
        {
        }

        /// <summary>
        /// Creates special offer for product
        /// </summary>
        /// <param name="itemsCount">how many items</param>
        /// <param name="price">for which price</param>
        public SpecialOffer(int itemsCount, double price)
        {
            this._itemsCount = itemsCount;
            this._price = price;
        }

        /// <summary>
        /// Calculates total price for product with special offer. 
        /// If special offer set with default values works like basic calculator
        /// </summary>
        /// <param name="totalItemsCount">total amount of items by product code</param>
        /// <param name="itemPrice">regular price for one item</param>
        /// <returns>Total price</returns>
        public double Calculate(int totalItemsCount, double itemPrice)
        {
            if (this._itemsCount == 0 || this._price == 0)
            {
                return Round(totalItemsCount * itemPrice);
            }
            int multiplicityNumber = totalItemsCount / this._itemsCount;
            int multiplicityRemainder = totalItemsCount % this._itemsCount;
            double totalOfferPrice = multiplicityNumber * this._price;
            double totalBasePrice = multiplicityRemainder * itemPrice;
            return Round(totalOfferPrice + totalBasePrice);
        }

        private double Round(double price)
        {
            return Math.Round(price, 2, MidpointRounding.AwayFromZero);
        }
    }
}
