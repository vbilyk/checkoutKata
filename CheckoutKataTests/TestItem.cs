using CheckoutKata;
using Xunit;

namespace CheckoutKataTests
{
    public class TestItem
    {
        [Fact]
        public void Check_TwoItemsSameProductCode_AreEqual()
        {
            // Arrange
            var item1 = new Item { ProductCode = "Banana" };
            var item2 = new Item { ProductCode = "Banana" };

            // Act
            bool condition = item1.Equals(item2);

            // Assert
            Assert.True(condition);
        }

        [Fact]
        public void Check_TwoItemsDiffProductCode_AreDifferent()
        {
            var item1 = new Item { ProductCode = "Banana" };
            var item2 = new Item { ProductCode = "Apple" };
            bool condition = item1.Equals(item2);
            Assert.False(condition);
        }
    }
}
