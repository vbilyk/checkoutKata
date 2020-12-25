using Xunit;
using CheckoutKata;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CheckoutKataTests
{
    public class TestCheckoutKata
    {
        [Fact]
        public void Check_InterviewTest_Success()
        {
            var _bananasProducCode = "Bananas";
            var _orangesProductCode = "Oranges";
            var itemApples = new Item { ProductCode = "Apples", Price = 0.5 };
            var itemBananas = new Item { ProductCode = _bananasProducCode, Price = 0.7 };            
            var itemOranges = new Item { ProductCode = _orangesProductCode, Price = 0.45 };

            var specOfferBananas = new SpecialOffer(2, 1.0);
            var specOfferOranges = new SpecialOffer(3, 0.9);

            var dictSpecOffers = new Dictionary<string, SpecialOffer>()
            {
                {_bananasProducCode, specOfferBananas },
                { _orangesProductCode, specOfferOranges }
            };

            var checkout = new Checkout(dictSpecOffers);
            var itemsCount = 4;
            for (int i = 0; i < itemsCount; i++)
            {
                checkout.Scan(itemApples);
                checkout.Scan(itemBananas);
                checkout.Scan(itemOranges);
            }

            // Apples: 4 * 0,5 + Bananas: 2 * specialOffer + Oranges: 1 * specialOffer + 0.45
            var expectedResult = Math.Round((itemsCount * 0.5) + (2.0) + (0.9 + 0.45),2, MidpointRounding.AwayFromZero);

            var result = checkout.Total();
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Add_10000ItemsPerfrormanceCheck_Less1Secs()
        {
            var _bananasProducCode = "Bananas";
            var _orangesProductCode = "Oranges";
            var itemApples = new Item { ProductCode = "Apples", Price = 0.5 };
            var itemBananas = new Item { ProductCode = _bananasProducCode, Price = 0.7 };
            var itemOranges = new Item { ProductCode = _orangesProductCode, Price = 0.45 };

            var specOfferBananas = new SpecialOffer(2, 1.0);
            var specOfferOranges = new SpecialOffer(3, 0.9);

            var dictSpecOffers = new Dictionary<string, SpecialOffer>()
            {
                {_bananasProducCode, specOfferBananas },
                { _orangesProductCode, specOfferOranges }
            };
            var checkout = new Checkout(dictSpecOffers);
            Stopwatch _timer = new Stopwatch();
            _timer.Start();
            var itemsCount = 10000;
            for (int i = 0; i < itemsCount; i++)
            {
                checkout.Scan(itemApples);
                checkout.Scan(itemBananas);
                checkout.Scan(itemOranges);
            }
            _timer.Stop();
            var addingMs = _timer.ElapsedMilliseconds;
            _timer.Restart();
            var result = checkout.Total();
            _timer.Stop();
            var gettingTotalMs = _timer.ElapsedMilliseconds;
            Assert.True(addingMs + gettingTotalMs <= TimeSpan.FromSeconds(1).TotalMilliseconds);
        }

        [Fact]
        public void Add_NullItem_ThrowException()
        {
            Item item1 = null;

            var checkout = new Checkout(null);

            Assert.Throws<ArgumentNullException>(() => checkout.Scan(item1));
        }

        [Fact]
        public void Add_ItemEmptyProductCode_ThrowException()
        {
            Item item1 = new Item { ProductCode= string.Empty};

            var checkout = new Checkout(null);

            Assert.Throws<ArgumentException>("Scanned item shouldn't have empty product code", () => checkout.Scan(item1));
        }

        [Fact]
        public void Add_ItemNegativePrice_ThrowException()
        {
            Item item1 = new Item { ProductCode = "Apple", Price = -2 };

            var checkout = new Checkout(null);

            Assert.Throws<ArgumentException>("Scanned item price should be greater than 0", () => checkout.Scan(item1));
        }

        [Fact]
        public void Add_NullSpecialOffers_BehaveLikeEmpty()
        {
            var item1 = new Item { ProductCode = "Apple", Price = 0.6 };

            var checkout = new Checkout(null);
            checkout.Scan(item1);

            var result = checkout.Total();
            Assert.Equal(0.6,result);
        }
    }
}
