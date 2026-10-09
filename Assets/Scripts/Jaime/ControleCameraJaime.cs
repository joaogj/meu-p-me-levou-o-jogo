using UnityEngine;
using UnityEngine.InputSystem;

namespace MeuPMeLevou.Jaime
{
    // Gira a câmera com o mouse (ação Olhar) em torno do Jaime. Só o yaw: o Third Person Follow
    // usa a rotação do alvo para decidir de que lado a câmera fica.
    public sealed class ControleCameraJaime : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _acoes;
        [SerializeField] private Transform _alvoCamera;
        [SerializeField] private float _sensibilidade = 0.1f;

        private InputAction _olhar;

        private void Awake()
        {
            _olhar = _acoes.FindActionMap("Exploracao", true).FindAction("Olhar", true);
        }

        private void Update()
        {
            Vector2 delta = _olhar.ReadValue<Vector2>();
            _alvoCamera.Rotate(0f, delta.x * _sensibilidade, 0f, Space.World);
        }
    }
}
