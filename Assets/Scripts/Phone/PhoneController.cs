using UnityEngine;
using UnityEngine.InputSystem;

namespace MeuPMeLevou.Phone
{
    // Glue between input, the phone rules (Battery, Flashlight, PhoneMenuState) and the scene:
    // the flashlight light, the phone view and the cursor. Tab opens the phone, F toggles the
    // flashlight and Esc closes the phone.
    public sealed class PhoneController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _actions;
        [SerializeField] private PhoneView _view;
        [SerializeField] private Light _flashlightLight;
        [SerializeField] private Behaviour[] _disableWhileOpen;
        [SerializeField] private float _flashlightDrainPerSecond = 1f;
        [SerializeField] private float _messageCost = 5f;

        private InputAction _phoneAction;
        private InputAction _flashlightAction;
        private InputAction _pauseAction;
        private PhoneMenuState _menu;
        private Flashlight _flashlight;
        private int _shownPercent = -1;

        public Battery Battery { get; private set; }

        public bool IsPhoneOpen => _menu.IsOpen;

        public bool IsFlashlightOn => _flashlight.IsOn;

        private void Awake()
        {
            InputActionMap map = _actions.FindActionMap("Exploration", true);
            _phoneAction = map.FindAction("Phone", true);
            _flashlightAction = map.FindAction("Flashlight", true);
            _pauseAction = map.FindAction("Pause", true);

            Battery = new Battery(flashlightDrainPerSecond: _flashlightDrainPerSecond, messageCost: _messageCost);
            _flashlight = new Flashlight(Battery);
            _menu = new PhoneMenuState();
        }

        private void OnEnable()
        {
            _actions.FindActionMap("Exploration").Enable();
        }

        private void Start()
        {
            ApplyMenuState();
            ApplyFlashlight();
            RefreshBattery();
        }

        private void Update()
        {
            bool wasOn = _flashlight.IsOn;
            _flashlight.Tick(Time.deltaTime);
            if (wasOn && !_flashlight.IsOn)
            {
                _view.ShowBatteryWarning();
            }

            if (_phoneAction.WasPressedThisFrame())
            {
                _menu.Toggle();
                ApplyMenuState();
            }

            if (_pauseAction.WasPressedThisFrame() && _menu.Close())
            {
                ApplyMenuState();
            }

            if (_flashlightAction.WasPressedThisFrame() && _flashlight.Toggle() == FlashlightToggleResult.NoBattery)
            {
                _view.ShowBatteryWarning();
            }

            ApplyFlashlight();
            RefreshBattery();
        }

        private void ApplyMenuState()
        {
            _view.SetOpen(_menu.IsOpen);

            // The mouse is free to click the phone while it is open, and captured for the camera otherwise.
            Cursor.lockState = _menu.IsOpen ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = _menu.IsOpen;

            foreach (Behaviour behaviour in _disableWhileOpen)
            {
                behaviour.enabled = !_menu.IsOpen;
            }
        }

        private void ApplyFlashlight()
        {
            _flashlightLight.enabled = _flashlight.IsOn;
        }

        private void RefreshBattery()
        {
            if (Battery.Percent == _shownPercent)
            {
                return;
            }

            _shownPercent = Battery.Percent;
            _view.SetBattery(_shownPercent);
        }
    }
}
