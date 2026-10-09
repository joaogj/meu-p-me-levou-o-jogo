using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MeuPMeLevou.Jaime
{
    // Troca o ombro da câmera com a ação TrocarOmbro (tecla Q) e suaviza a transição.
    public sealed class TrocaDeOmbro : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _acoes;
        [SerializeField] private CinemachineThirdPersonFollow _terceiraPessoa;
        [SerializeField] private float _velocidadeDaTroca = 4f;

        private InputAction _trocar;
        private float _ladoAtual;
        private float _ladoAlvo;

        private void Awake()
        {
            _trocar = _acoes.FindActionMap("Exploracao", true).FindAction("TrocarOmbro", true);
            _ladoAtual = _terceiraPessoa.CameraSide;
            _ladoAlvo = _ladoAtual;
        }

        private void Update()
        {
            if (_trocar.WasPressedThisFrame())
            {
                _ladoAlvo = _ladoAlvo > 0.5f ? 0f : 1f;
            }

            _ladoAtual = Mathf.MoveTowards(_ladoAtual, _ladoAlvo, _velocidadeDaTroca * Time.deltaTime);
            _terceiraPessoa.CameraSide = _ladoAtual;
        }
    }
}
