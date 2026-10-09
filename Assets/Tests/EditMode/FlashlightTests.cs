using MeuPMeLevou.Phone;
using NUnit.Framework;

namespace MeuPMeLevou.Tests
{
    public sealed class FlashlightTests
    {
        [Test]
        public void ToggleTurnsOnWithBattery()
        {
            // Arrange
            var flashlight = new Flashlight(new Battery());

            // Act
            var result = flashlight.Toggle();

            // Assert
            Assert.AreEqual(FlashlightToggleResult.TurnedOn, result);
            Assert.IsTrue(flashlight.IsOn);
        }

        [Test]
        public void ToggleTwiceTurnsOff()
        {
            var flashlight = new Flashlight(new Battery());
            flashlight.Toggle();

            var result = flashlight.Toggle();

            Assert.AreEqual(FlashlightToggleResult.TurnedOff, result);
            Assert.IsFalse(flashlight.IsOn);
        }

        [Test]
        public void ToggleWithEmptyBatteryStaysOffAndReportsNoBattery()
        {
            // Arrange
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 10f);
            battery.Tick(20f, flashlightOn: true);
            var flashlight = new Flashlight(battery);

            // Act
            var result = flashlight.Toggle();

            // Assert
            Assert.AreEqual(FlashlightToggleResult.NoBattery, result);
            Assert.IsFalse(flashlight.IsOn);
        }

        [Test]
        public void TickDrainsBatteryOnlyWhileOn()
        {
            // Arrange
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 2f);
            var flashlight = new Flashlight(battery);

            // Act
            flashlight.Tick(5f);
            flashlight.Toggle();
            flashlight.Tick(5f);

            // Assert
            Assert.AreEqual(90f, battery.Level, 0.001f);
        }

        [Test]
        public void FlashlightTurnsOffByItselfWhenBatteryRunsOut()
        {
            // Arrange
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 10f);
            var flashlight = new Flashlight(battery);
            flashlight.Toggle();

            // Act
            flashlight.Tick(10f);

            // Assert
            Assert.IsTrue(battery.IsEmpty);
            Assert.IsFalse(flashlight.IsOn);
        }

        [Test]
        public void FlashlightWorksAgainAfterRecharge()
        {
            var battery = new Battery(max: 100f, flashlightDrainPerSecond: 10f);
            var flashlight = new Flashlight(battery);
            flashlight.Toggle();
            flashlight.Tick(10f);

            battery.Recharge();
            var result = flashlight.Toggle();

            Assert.AreEqual(FlashlightToggleResult.TurnedOn, result);
        }
    }
}
