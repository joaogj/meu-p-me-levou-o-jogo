namespace MeuPMeLevou.Phone
{
    public enum FlashlightToggleResult
    {
        TurnedOn,
        TurnedOff,
        NoBattery,
    }

    // Pure flashlight rule: it drains the phone battery while on and cannot be on with an empty battery.
    public sealed class Flashlight
    {
        private readonly Battery _battery;

        public Flashlight(Battery battery)
        {
            _battery = battery;
        }

        public bool IsOn { get; private set; }

        public FlashlightToggleResult Toggle()
        {
            if (IsOn)
            {
                IsOn = false;
                return FlashlightToggleResult.TurnedOff;
            }

            if (!_battery.CanUseFlashlight)
            {
                return FlashlightToggleResult.NoBattery;
            }

            IsOn = true;
            return FlashlightToggleResult.TurnedOn;
        }

        // Drains the battery while on, and switches off when it runs out.
        public void Tick(float deltaTime)
        {
            _battery.Tick(deltaTime, IsOn);

            if (_battery.IsEmpty)
            {
                IsOn = false;
            }
        }
    }
}
