using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MeuPMeLevou.Jaime
{
    // Switches the camera shoulder with the SwitchShoulder action (Q key) and smooths the transition.
    public sealed class ShoulderSwitch : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _actions;
        [SerializeField] private CinemachineThirdPersonFollow _thirdPersonFollow;
        [SerializeField] private float _switchSpeed = 4f;

        private InputAction _switchShoulder;
        private float _currentSide;
        private float _targetSide;

        private void Awake()
        {
            _switchShoulder = _actions.FindActionMap("Exploration", true).FindAction("SwitchShoulder", true);
            _currentSide = _thirdPersonFollow.CameraSide;
            _targetSide = _currentSide;
        }

        private void Update()
        {
            if (_switchShoulder.WasPressedThisFrame())
            {
                _targetSide = _targetSide > 0.5f ? 0f : 1f;
            }

            _currentSide = Mathf.MoveTowards(_currentSide, _targetSide, _switchSpeed * Time.deltaTime);
            _thirdPersonFollow.CameraSide = _currentSide;
        }
    }
}
