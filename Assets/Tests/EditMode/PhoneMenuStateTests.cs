using MeuPMeLevou.Phone;
using NUnit.Framework;

namespace MeuPMeLevou.Tests
{
    public sealed class PhoneMenuStateTests
    {
        [Test]
        public void StartsClosed()
        {
            Assert.IsFalse(new PhoneMenuState().IsOpen);
        }

        [Test]
        public void ToggleOpensAndClosesTheScreen()
        {
            var menu = new PhoneMenuState();

            menu.Toggle();
            Assert.IsTrue(menu.IsOpen);

            menu.Toggle();
            Assert.IsFalse(menu.IsOpen);
        }

        [Test]
        public void CloseWhenOpenClosesAndReportsItWasOpen()
        {
            // Arrange
            var menu = new PhoneMenuState();
            menu.Toggle();

            // Act
            bool wasOpen = menu.Close();

            // Assert
            Assert.IsTrue(wasOpen);
            Assert.IsFalse(menu.IsOpen);
        }

        [Test]
        public void CloseWhenAlreadyClosedReportsItWasNotOpen()
        {
            var menu = new PhoneMenuState();

            bool wasOpen = menu.Close();

            Assert.IsFalse(wasOpen);
            Assert.IsFalse(menu.IsOpen);
        }
    }
}
