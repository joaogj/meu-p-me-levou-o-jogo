using UnityEngine;
using UnityEngine.InputSystem;

namespace MeuPMeLevou.Jaime
{
    // Rotates the camera target around Jaime with the mouse (Look action). Yaw only: the
    // Third Person Follow uses the target rotation to decide which side the camera sits on.
    public sealed class JaimeCameraLook : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _actions;
        [SerializeField] private Transform _cameraTarget;
        [SerializeField] private float _sensitivity = 0.1f;

        private InputAction _look;

        private void Awake()
        {
            _look = _actions.FindActionMap("Exploration", true).FindAction("Look", true);
        }

        private void Update()
        {
            Vector2 delta = _look.ReadValue<Vector2>();
            _cameraTarget.Rotate(0f, delta.x * _sensitivity, 0f, Space.World);
        }
    }
}
