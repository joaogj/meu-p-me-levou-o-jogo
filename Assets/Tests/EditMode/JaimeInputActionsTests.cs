using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace MeuPMeLevou.Tests
{
    // Simulates keyboard and mouse to check that each Exploration action fires from the expected control.
    public sealed class JaimeInputActionsTests : InputTestFixture
    {
        private const string AssetPath = "Assets/Input/Jaime.inputactions";

        private InputActionAsset _asset;
        private InputActionMap _map;
        private Keyboard _keyboard;
        private Mouse _mouse;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _keyboard = InputSystem.AddDevice<Keyboard>();
            _mouse = InputSystem.AddDevice<Mouse>();
            _asset = Object.Instantiate(AssetDatabase.LoadAssetAtPath<InputActionAsset>(AssetPath));
            _map = _asset.FindActionMap("Exploration", true);
            _map.Enable();
        }

        [TearDown]
        public override void TearDown()
        {
            _map.Disable();
            Object.DestroyImmediate(_asset);
            base.TearDown();
        }

        [TestCase("w", 0f, 1f)]
        [TestCase("s", 0f, -1f)]
        [TestCase("a", -1f, 0f)]
        [TestCase("d", 1f, 0f)]
        public void MoveFollowsWasd(string key, float expectedX, float expectedY)
        {
            // Arrange
            var control = _keyboard[key];

            // Act
            Press((ButtonControl)control);

            // Assert
            Assert.AreEqual(new Vector2(expectedX, expectedY), _map.FindAction("Move").ReadValue<Vector2>());
        }

        [Test]
        public void LookFollowsMouseDelta()
        {
            // Act
            Set(_mouse.delta, new Vector2(3f, -2f));

            // Assert
            Assert.AreEqual(new Vector2(3f, -2f), _map.FindAction("Look").ReadValue<Vector2>());
        }

        [TestCase("Sprint", "leftShift")]
        [TestCase("SwitchShoulder", "q")]
        [TestCase("Phone", "tab")]
        [TestCase("Flashlight", "f")]
        [TestCase("Pause", "escape")]
        public void ButtonActionFiresFromExpectedKey(string actionName, string key)
        {
            // Arrange
            var action = _map.FindAction(actionName, true);
            Assert.IsFalse(action.IsPressed(), $"{actionName} should start released");

            // Act
            Press((ButtonControl)_keyboard[key]);

            // Assert
            Assert.IsTrue(action.IsPressed(), $"{actionName} did not fire from {key}");
        }
    }
}
