using UnityEngine;
using UnityEngine.InputSystem;

namespace MeuPMeLevou.Jaime
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class MovimentoJaime : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _acoes;
        [SerializeField] private Transform _camera;
        [SerializeField] private float _velocidadeAndando = 2.5f;
        [SerializeField] private float _velocidadeCorrendo = 5f;
        [SerializeField] private float _gravidade = -20f;

        private CharacterController _personagem;
        private InputAction _mover;
        private InputAction _correr;
        private Folego _folego;
        private float _velocidadeVertical;

        private void Awake()
        {
            _personagem = GetComponent<CharacterController>();
            var mapa = _acoes.FindActionMap("Exploracao", true);
            _mover = mapa.FindAction("Mover", true);
            _correr = mapa.FindAction("Correr", true);
            _folego = new Folego();
        }

        private void OnEnable()
        {
            _acoes.FindActionMap("Exploracao").Enable();
        }

        private void OnDisable()
        {
            _acoes.FindActionMap("Exploracao").Disable();
        }

        private void Update()
        {
            Vector2 entrada = _mover.ReadValue<Vector2>();
            bool andando = entrada.sqrMagnitude > 0.01f;
            bool correndo = _folego.Atualizar(Time.deltaTime, _correr.IsPressed(), andando);

            Vector3 direcao = DirecaoRelativaACamera(entrada);
            Vector3 movimento = direcao * (correndo ? _velocidadeCorrendo : _velocidadeAndando);

            if (_personagem.isGrounded && _velocidadeVertical < 0f)
            {
                _velocidadeVertical = -2f;
            }
            _velocidadeVertical += _gravidade * Time.deltaTime;
            movimento.y = _velocidadeVertical;

            _personagem.Move(movimento * Time.deltaTime);
        }

        private Vector3 DirecaoRelativaACamera(Vector2 entrada)
        {
            Vector3 frente = Vector3.ProjectOnPlane(_camera.forward, Vector3.up).normalized;
            Vector3 direita = Vector3.ProjectOnPlane(_camera.right, Vector3.up).normalized;
            Vector3 direcao = frente * entrada.y + direita * entrada.x;
            return Vector3.ClampMagnitude(direcao, 1f);
        }
    }
}
