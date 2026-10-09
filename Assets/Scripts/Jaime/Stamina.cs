using UnityEngine;

namespace MeuPMeLevou.Jaime
{
    // Pure stamina rule: no scene dependency, so it can be tested in EditMode.
    public sealed class Stamina
    {
        private readonly float _max;
        private readonly float _drainPerSecond;
        private readonly float _recoveryPerSecond;

        private float _current;

        public Stamina(float max = 100f, float drainPerSecond = 20f, float recoveryPerSecond = 15f)
        {
            _max = max;
            _drainPerSecond = drainPerSecond;
            _recoveryPerSecond = recoveryPerSecond;
            _current = max;
        }

        public float Current => _current;

        public float Max => _max;

        public bool CanSprint => _current > 0f;

        // Returns whether Jaime sprints this step: only with stamina left and when he asks to sprint.
        // Sprinting drains stamina; walking (not sprinting) recovers it; standing still does not recover.
        public bool Tick(float deltaTime, bool wantsSprint, bool isMoving)
        {
            bool sprinting = wantsSprint && CanSprint;

            if (sprinting)
            {
                _current = Mathf.Max(0f, _current - _drainPerSecond * deltaTime);
            }
            else if (isMoving)
            {
                _current = Mathf.Min(_max, _current + _recoveryPerSecond * deltaTime);
            }

            return sprinting;
        }
    }
}
