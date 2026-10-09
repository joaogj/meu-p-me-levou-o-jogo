using MeuPMeLevou.Jaime;
using NUnit.Framework;

namespace MeuPMeLevou.Tests
{
    public sealed class CameraSwayOptionsTests
    {
        [Test]
        public void EnabledSwayAppliesConfiguredAmplitude()
        {
            // Arrange
            var options = new CameraSwayOptions(enabled: true, amplitude: 0.5f);

            // Assert
            Assert.AreEqual(0.5f, options.Gain, 0.0001f);
        }

        [Test]
        public void DisabledSwayHasExactlyZeroGain()
        {
            // Arrange
            var options = new CameraSwayOptions(enabled: true, amplitude: 0.5f);

            // Act
            options.Enabled = false;

            // Assert
            Assert.AreEqual(0f, options.Gain);
        }

        [Test]
        public void ReenablingSwayRestoresAmplitude()
        {
            // Arrange
            var options = new CameraSwayOptions(enabled: false, amplitude: 0.8f);

            // Act
            options.Enabled = true;

            // Assert
            Assert.AreEqual(0.8f, options.Gain, 0.0001f);
        }

        [Test]
        public void NegativeAmplitudeIsClampedToZero()
        {
            var options = new CameraSwayOptions(enabled: true, amplitude: -2f);

            Assert.AreEqual(0f, options.Gain);
        }
    }
}
