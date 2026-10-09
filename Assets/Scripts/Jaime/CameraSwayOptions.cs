namespace MeuPMeLevou.Jaime
{
    // Pure rule for the optional camera sway: no scene dependency, so it can be tested in EditMode.
    // The sway is a light handheld shake that reinforces the horror mood; players can turn it off.
    public sealed class CameraSwayOptions
    {
        private readonly float _amplitude;

        public CameraSwayOptions(bool enabled = true, float amplitude = 1f)
        {
            Enabled = enabled;
            _amplitude = amplitude < 0f ? 0f : amplitude;
        }

        public bool Enabled { get; set; }

        // Noise gain to apply to the camera: the configured amplitude when on, exactly zero when off.
        public float Gain => Enabled ? _amplitude : 0f;
    }
}
