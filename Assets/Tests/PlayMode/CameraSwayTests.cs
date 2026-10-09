using System.Collections;
using MeuPMeLevou.Jaime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace MeuPMeLevou.Tests
{
    public sealed class CameraSwayTests
    {
        private const float SettleSeconds = 1f;
        private const float SampleSeconds = 4f;
        private const float StableToleranceDegrees = 0.001f;
        private const float SwayMinimumDegrees = 0.02f;

        [UnitySetUp]
        public IEnumerator LoadScene()
        {
            yield return SceneManager.LoadSceneAsync("M0_Caxias");
        }

        [UnityTest]
        public IEnumerator CameraIsStableWhenSwayIsOff()
        {
            // Arrange
            var sway = Object.FindAnyObjectByType<CameraSway>();
            Assert.IsNotNull(sway, "CameraSway not found in scene M0_Caxias");
            sway.Enabled = false;
            yield return new WaitForSeconds(SettleSeconds);

            // Act
            float range = 0f;
            yield return MeasureRotationRange(r => range = r);

            // Assert
            Assert.Less(range, StableToleranceDegrees, "Camera moved with the sway off");
        }

        [UnityTest]
        public IEnumerator CameraMovesWhenSwayIsOn()
        {
            // Arrange
            var sway = Object.FindAnyObjectByType<CameraSway>();
            Assert.IsNotNull(sway, "CameraSway not found in scene M0_Caxias");
            sway.Enabled = true;
            yield return new WaitForSeconds(SettleSeconds);

            // Act
            float range = 0f;
            yield return MeasureRotationRange(r => range = r);

            // Assert
            Assert.Greater(range, SwayMinimumDegrees, "Camera did not move with the sway on");
        }

        // Largest angle (degrees) between the first sampled camera rotation and any later one.
        private static IEnumerator MeasureRotationRange(System.Action<float> report)
        {
            var camera = Camera.main.transform;
            Quaternion start = camera.rotation;
            float largest = 0f;
            float elapsed = 0f;

            while (elapsed < SampleSeconds)
            {
                yield return null;
                elapsed += Time.deltaTime;
                largest = Mathf.Max(largest, Quaternion.Angle(start, camera.rotation));
            }

            report(largest);
        }
    }
}
