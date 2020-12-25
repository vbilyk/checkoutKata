using CheckoutKata;
using Xunit;

namespace CheckoutKataTests
{
    public class TestSpecialOffer
    {
        [Fact]
        public void Check_DefaultCtor_SimpleCalculation()
        {
            // Arrange            
            var itemCount = 2;
            var itemPrice = 1.5;
            var expectedTotalPrice = 3.0;

            // Act
            var specOffer = new SpecialOffer();
            var result = specOffer.Calculate(itemCount, itemPrice);

            // Assert
            Assert.Equal(expectedTotalPrice, result);
        }

        [Fact]
        public void Add_TwoItems_ForHalfPrice()
        {
            var itemCount = 5;
            var itemPrice = 1.4;
            var specOfferCount = 2;
            var specOfferPrice = 0.7;
            var expectedTotalPrice = 2.8;

            var specOffer = new SpecialOffer(specOfferCount, specOfferPrice);
            var result = specOffer.Calculate(itemCount, itemPrice);

            Assert.Equal(expectedTotalPrice,result);
        }

        [Fact]
        public void Add_ItemsLessThanInOffer_SimpleCalculation()
        {
            var itemCount = 2;
            var itemPrice = 0.4;
            var specOfferCount = 3;
            var specOfferPrice = 1.0;
            var expectedTotalPrice = 0.8;

            var specOffer = new SpecialOffer(specOfferCount, specOfferPrice);
            var result = specOffer.Calculate(itemCount, itemPrice);

            Assert.Equal(expectedTotalPrice, result);
        }
    }
}
