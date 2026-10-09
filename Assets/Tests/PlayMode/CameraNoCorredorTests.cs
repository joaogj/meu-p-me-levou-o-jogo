using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace MeuPMeLevou.Tests
{
    public sealed class CameraNoCorredorTests
    {
        // Raio pequeno para checar só se o centro da câmera está dentro de uma parede.
        private const float RaioDeVerificacao = 0.1f;
        private const float PassoPorQuadro = 0.05f;

        [UnitySetUp]
        public IEnumerator CarregaCena()
        {
            yield return SceneManager.LoadSceneAsync("M0_Caxias");
        }

        [UnityTest]
        public IEnumerator CameraNaoEntraNaParedeNoTrechoEstreito()
        {
            var jaime = GameObject.Find("Jaime");
            Assert.IsNotNull(jaime, "Jaime não encontrado na cena M0_Caxias");
            var personagem = jaime.GetComponent<CharacterController>();

            yield return new WaitForEndOfFrame();

            // Anda de z = -5 até z = 35, passando pelo trecho estreito (z 10 a 20).
            while (jaime.transform.position.z < 35f)
            {
                personagem.Move(new Vector3(0f, 0f, PassoPorQuadro));
                yield return new WaitForEndOfFrame();

                var posicaoCamera = Camera.main.transform.position;
                var colisoes = Physics.OverlapSphere(posicaoCamera, RaioDeVerificacao, LayerMask.GetMask("Default"));
                foreach (var colisao in colisoes)
                {
                    if (colisao.CompareTag("Player")) continue;
                    Assert.Fail($"Câmera entrou em {colisao.name} na posição {posicaoCamera} com Jaime em z={jaime.transform.position.z:F2}");
                }
            }
        }
    }
}
