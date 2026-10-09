using UnityEngine;

namespace MeuPMeLevou.Jaime
{
    // Regra pura do fôlego: não depende de cena, para ser testada no modo EditMode.
    public sealed class Folego
    {
        private readonly float _maximo;
        private readonly float _gastoPorSegundo;
        private readonly float _recuperacaoPorSegundo;

        private float _atual;

        public Folego(float maximo = 100f, float gastoPorSegundo = 20f, float recuperacaoPorSegundo = 15f)
        {
            _maximo = maximo;
            _gastoPorSegundo = gastoPorSegundo;
            _recuperacaoPorSegundo = recuperacaoPorSegundo;
            _atual = maximo;
        }

        public float Atual => _atual;

        public float Maximo => _maximo;

        public bool PodeCorrer => _atual > 0f;

        // Devolve se o Jaime corre neste passo: só corre com fôlego e quando pede para correr.
        // Correndo gasta fôlego; andando (sem correr) recupera; parado não recupera.
        public bool Atualizar(float deltaTempo, bool querCorrer, bool andando)
        {
            bool correndo = querCorrer && PodeCorrer;

            if (correndo)
            {
                _atual = Mathf.Max(0f, _atual - _gastoPorSegundo * deltaTempo);
            }
            else if (andando)
            {
                _atual = Mathf.Min(_maximo, _atual + _recuperacaoPorSegundo * deltaTempo);
            }

            return correndo;
        }
    }
}
