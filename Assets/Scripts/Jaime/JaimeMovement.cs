using UnityEngine;
using UnityEngine.InputSystem;

namespace MeuPMeLevou.Jaime
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class JaimeMovement : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _actions;
        [SerializeField] private Transform _camera;
        [SerializeField] private float _walkSpeed = 2.5f;
        [SerializeField] private float _sprintSpeed = 5f;
        [SerializeField] private float _gravity = -20f;

        private CharacterController _controller;
        private InputAction _move;
        private InputAction _sprint;
        private Stamina _stamina;
        private float _verticalSpeed;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            var map = _actions.FindActionMap("Exploration", true);
            _move = map.FindAction("Move", true);
            _sprint = map.FindAction("Sprint", true);
            _stamina = new Stamina();
        }

        private void OnEnable()
        {
            _actions.FindActionMap("Exploration").Enable();
        }

        private void OnDisable()
        {
            _actions.FindActionMap("Exploration").Disable();
        }

        private void Update()
        {
            Vector2 input = _move.ReadValue<Vector2>();
            bool isMoving = input.sqrMagnitude > 0.01f;
            bool sprinting = _stamina.Tick(Time.deltaTime, _sprint.IsPressed(), isMoving);

            Vector3 direction = CameraRelativeDirection(input);
            Vector3 motion = direction * (sprinting ? _sprintSpeed : _walkSpeed);

            if (_controller.isGrounded && _verticalSpeed < 0f)
            {
                _verticalSpeed = -2f;
            }
            _verticalSpeed += _gravity * Time.deltaTime;
            motion.y = _verticalSpeed;

            _controller.Move(motion * Time.deltaTime);
        }

        private Vector3 CameraRelativeDirection(Vector2 input)
        {
            Vector3 forward = Vector3.ProjectOnPlane(_camera.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(_camera.right, Vector3.up).normalized;
            Vector3 direction = forward * input.y + right * input.x;
            return Vector3.ClampMagnitude(direction, 1f);
        }
    }
}
