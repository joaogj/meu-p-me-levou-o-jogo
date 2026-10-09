using System.Collections;
using NUnit.Framework;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace MeuPMeLevou.Tests
{
    public sealed class CameraInAlleyTests
    {
        // Small radius to check only whether the camera center is inside a wall.
        private const float CheckRadius = 0.1f;
        private const float StepPerFrame = 0.05f;
        private const float ShoulderTransitionSeconds = 0.6f;

        private InputSettings.BackgroundBehavior _backgroundBehavior;
        private Keyboard _keyboard;
        private bool _addedKeyboard;

        [UnitySetUp]
        public IEnumerator LoadScene()
        {
            // Queued key events are dropped when the Editor is unfocused unless focus is ignored.
            _backgroundBehavior = InputSystem.settings.backgroundBehavior;
            InputSystem.settings.backgroundBehavior = InputSettings.BackgroundBehavior.IgnoreFocus;

            _keyboard = Keyboard.current;
            if (_keyboard == null)
            {
                _keyboard = InputSystem.AddDevice<Keyboard>();
                _addedKeyboard = true;
            }

            yield return SceneManager.LoadSceneAsync("M0_Caxias");
        }

        [TearDown]
        public void RestoreInputSettings()
        {
            InputSystem.settings.backgroundBehavior = _backgroundBehavior;
            if (_addedKeyboard)
            {
                InputSystem.RemoveDevice(_keyboard);
                _addedKeyboard = false;
            }
        }

        [UnityTest]
        public IEnumerator CameraDoesNotEnterWallInNarrowStretchOnDefaultShoulder()
        {
            yield return WalkNarrowStretch();
        }

        [UnityTest]
        public IEnumerator CameraDoesNotEnterWallInNarrowStretchAfterShoulderSwitch()
        {
            // Arrange
            var thirdPerson = Object.FindAnyObjectByType<CinemachineThirdPersonFollow>();
            Assert.IsNotNull(thirdPerson, "CinemachineThirdPersonFollow not found in scene M0_Caxias");
            float sideBefore = thirdPerson.CameraSide;
            yield return null;

            // Act: press and release Q, then wait for the shoulder transition to finish
            InputSystem.QueueStateEvent(_keyboard, new KeyboardState(Key.Q));
            yield return null;
            InputSystem.QueueStateEvent(_keyboard, new KeyboardState());
            yield return new WaitForSeconds(ShoulderTransitionSeconds);

            // Assert: the shoulder changed, and the camera still stays out of the walls
            Assert.That(thirdPerson.CameraSide, Is.Not.EqualTo(sideBefore).Within(0.01f), "Q did not switch the shoulder");
            yield return WalkNarrowStretch();
        }

        private static IEnumerator WalkNarrowStretch()
        {
            var jaime = GameObject.Find("Jaime");
            Assert.IsNotNull(jaime, "Jaime not found in scene M0_Caxias");
            var controller = jaime.GetComponent<CharacterController>();

            yield return new WaitForEndOfFrame();

            // Walks from z = -5 to z = 35, through the narrow stretch (z 10 to 20).
            while (jaime.transform.position.z < 35f)
            {
                controller.Move(new Vector3(0f, 0f, StepPerFrame));
                yield return new WaitForEndOfFrame();

                var cameraPosition = Camera.main.transform.position;
                var hits = Physics.OverlapSphere(cameraPosition, CheckRadius, LayerMask.GetMask("Default"));
                foreach (var hit in hits)
                {
                    if (hit.CompareTag("Player")) continue;
                    Assert.Fail($"Camera entered {hit.name} at {cameraPosition} with Jaime at z={jaime.transform.position.z:F2}");
                }
            }
        }
    }
}
