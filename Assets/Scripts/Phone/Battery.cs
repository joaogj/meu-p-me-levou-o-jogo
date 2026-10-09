using UnityEngine;

namespace MeuPMeLevou.Phone
{
    // Pure phone battery rule: no scene dependency, so it can be tested in EditMode.
    // The flashlight drains it over time and each chat message drains it in one step.
    // At 0% both the flashlight and the chat are unavailable until the battery is recharged
    // (at save points, which come after the M0 prototype).
    public sealed class Battery
    {
        private readonly float _max;
        private readonly float _flashlightDrainPerSecond;
        private readonly float _messageCost;

        private float _level;

        public Battery(float max = 100f, float flashlightDrainPerSecond = 1f, float messageCost = 5f)
        {
            _max = max;
            _flashlightDrainPerSecond = flashlightDrainPerSecond;
            _messageCost = messageCost;
            _level = max;
        }

        public float Level => _level;

        public float Max => _max;

        public bool IsEmpty => _level <= 0f;

        public bool CanUseFlashlight => !IsEmpty;

        public bool CanSendMessage => !IsEmpty;

        // Whole percent for the HUD. Rounds up, so it only shows 0% when the battery is really empty.
        public int Percent => Mathf.CeilToInt(_level / _max * 100f);

        // Drains the flashlight cost for this step when the flashlight is on.
        public void Tick(float deltaTime, bool flashlightOn)
        {
            if (!flashlightOn)
            {
                return;
            }

            _level = Mathf.Max(0f, _level - _flashlightDrainPerSecond * deltaTime);
        }

        // Spends the cost of one chat message. Returns false, and spends nothing, when the battery is empty.
        // With less charge than the cost left, the message still goes out and the battery hits 0%.
        public bool TrySpendMessage()
        {
            if (IsEmpty)
            {
                return false;
            }

            _level = Mathf.Max(0f, _level - _messageCost);
            return true;
        }

        public void Recharge()
        {
            _level = _max;
        }
    }
}
