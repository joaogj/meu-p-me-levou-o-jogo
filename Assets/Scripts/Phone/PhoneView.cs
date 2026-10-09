using UnityEngine;
using UnityEngine.UIElements;

namespace MeuPMeLevou.Phone
{
    // UI Toolkit view of the phone: battery HUD, low-battery warning and the phone screen.
    // It only shows state; the rules live in Battery, Flashlight and PhoneMenuState.
    [RequireComponent(typeof(UIDocument))]
    public sealed class PhoneView : MonoBehaviour
    {
        private const string PhoneHiddenClass = "phone--hidden";
        private const string WarningHiddenClass = "hud__warning--hidden";

        [SerializeField] private float _warningSeconds = 2.5f;

        private VisualElement _phone;
        private Label _batteryHud;
        private Label _batteryPhone;
        private Label _warning;
        private IVisualElementScheduledItem _hideWarning;

        public bool IsOpen => _phone != null && !_phone.ClassListContains(PhoneHiddenClass);

        public bool IsWarningVisible => _warning != null && !_warning.ClassListContains(WarningHiddenClass);

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _phone = root.Q<VisualElement>("phone");
            _batteryHud = root.Q<Label>("battery-hud");
            _batteryPhone = root.Q<Label>("battery-phone");
            _warning = root.Q<Label>("battery-warning");

            SetOpen(false);
        }

        public void SetOpen(bool open)
        {
            _phone.EnableInClassList(PhoneHiddenClass, !open);
        }

        public void SetBattery(int percent)
        {
            _batteryHud.text = $"Bateria {percent}%";
            _batteryPhone.text = $"{percent}%";
        }

        public void ShowBatteryWarning()
        {
            _warning.EnableInClassList(WarningHiddenClass, false);

            _hideWarning?.Pause();
            _hideWarning = _warning.schedule.Execute(() => _warning.EnableInClassList(WarningHiddenClass, true));
            _hideWarning.ExecuteLater((long)(_warningSeconds * 1000f));
        }
    }
}
