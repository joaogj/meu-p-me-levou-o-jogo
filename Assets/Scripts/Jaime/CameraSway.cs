using Unity.Cinemachine;
using UnityEngine;

namespace MeuPMeLevou.Jaime
{
    // Applies the optional camera sway to the Cinemachine noise. With the sway off the noise gain is
    // zero, so the camera stays stable. A future settings screen calls the Enabled property.
    public sealed class CameraSway : MonoBehaviour
    {
        [SerializeField] private CinemachineBasicMultiChannelPerlin _noise;
        [SerializeField] private bool _enabled = true;
        [SerializeField] private float _amplitude = 1f;

        private CameraSwayOptions _options;

        public bool Enabled
        {
            get => _options.Enabled;
            set
            {
                _options.Enabled = value;
                Apply();
            }
        }

        private void Awake()
        {
            _options = new CameraSwayOptions(_enabled, _amplitude);
            Apply();
        }

        private void Apply()
        {
            _noise.AmplitudeGain = _options.Gain;
        }
    }
}
