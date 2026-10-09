using MeuPMeLevou.Phone;
using NUnit.Framework;

namespace MeuPMeLevou.Tests
{
    public sealed class BatteryTests
    {
        [Test]
        public void StartsFull()
        {
            var battery = new Battery(max: 100f);

            Assert.AreEqual(100f, battery.Level, 0.001f);
            Assert.AreEqual(100, battery.Percent);
            Assert.IsFalse(battery.IsEmpty);
        }

        [Test]
        public void FlashlightOnDrainsOverTime()
        {
            // Arrange
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 2f);

            // Act
            battery.Tick(10f, flashlightOn: true);

            // Assert
            Assert.AreEqual(80f, battery.Level, 0.001f);
        }

        [Test]
        public void FlashlightOffDoesNotDrain()
        {
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 2f);

            battery.Tick(10f, flashlightOn: false);

            Assert.AreEqual(100f, battery.Level, 0.001f);
        }

        [Test]
        public void EachMessageSpendsItsCost()
        {
            // Arrange
            var battery = new Battery(max: 100f, messageCost: 5f);

            // Act
            bool sent = battery.TrySpendMessage();

            // Assert
            Assert.IsTrue(sent);
            Assert.AreEqual(95f, battery.Level, 0.001f);
        }

        [Test]
        public void EmptyBatteryBlocksFlashlightAndChat()
        {
            // Arrange
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 10f);

            // Act
            battery.Tick(20f, flashlightOn: true);

            // Assert
            Assert.IsTrue(battery.IsEmpty);
            Assert.AreEqual(0, battery.Percent);
            Assert.IsFalse(battery.CanUseFlashlight);
            Assert.IsFalse(battery.CanSendMessage);
        }

        [Test]
        public void MessageIsRefusedAndFreeAtZeroPercent()
        {
            // Arrange
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 10f);
            battery.Tick(20f, flashlightOn: true);

            // Act
            bool sent = battery.TrySpendMessage();

            // Assert
            Assert.IsFalse(sent);
            Assert.AreEqual(0f, battery.Level);
        }

        [Test]
        public void LastMessageWithLessChargeThanCostStillGoesOutAndEmptiesBattery()
        {
            // Arrange
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 1f, messageCost: 5f);
            battery.Tick(98f, flashlightOn: true); // 2% left

            // Act
            bool sent = battery.TrySpendMessage();

            // Assert
            Assert.IsTrue(sent);
            Assert.IsTrue(battery.IsEmpty);
            Assert.IsFalse(battery.TrySpendMessage());
        }

        [Test]
        public void LevelNeverGoesNegative()
        {
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 50f);

            battery.Tick(100f, flashlightOn: true);

            Assert.AreEqual(0f, battery.Level);
        }

        [Test]
        public void PercentRoundsUpSoZeroOnlyWhenEmpty()
        {
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 1f);

            battery.Tick(99.5f, flashlightOn: true); // 0.5% left

            Assert.IsFalse(battery.IsEmpty);
            Assert.AreEqual(1, battery.Percent);
        }

        [Test]
        public void RechargeRestoresFullBattery()
        {
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 10f);
            battery.Tick(20f, flashlightOn: true);

            battery.Recharge();

            Assert.AreEqual(100f, battery.Level, 0.001f);
            Assert.IsTrue(battery.CanUseFlashlight);
            Assert.IsTrue(battery.CanSendMessage);
        }
    }
}
