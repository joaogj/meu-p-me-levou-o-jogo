using MeuPMeLevou.Jaime;
using NUnit.Framework;

namespace MeuPMeLevou.Tests
{
    public sealed class FolegoTests
    {
        [Test]
        public void CorrendoGastaFolego()
        {
            var folego = new Folego(maximo: 100f, gastoPorSegundo: 20f);

            bool correndo = folego.Atualizar(1f, querCorrer: true, andando: true);

            Assert.IsTrue(correndo);
            Assert.AreEqual(80f, folego.Atual, 0.001f);
        }

        [Test]
        public void AndandoSemCorrerRecuperaFolego()
        {
            var folego = new Folego(maximo: 100f, recuperacaoPorSegundo: 15f);
            folego.Atualizar(2f, querCorrer: true, andando: true); // gasta 40 -> 60

            bool correndo = folego.Atualizar(1f, querCorrer: false, andando: true);

            Assert.IsFalse(correndo);
            Assert.AreEqual(75f, folego.Atual, 0.001f);
        }

        [Test]
        public void ParadoNaoRecuperaFolego()
        {
            var folego = new Folego(maximo: 100f);
            folego.Atualizar(2f, querCorrer: true, andando: true); // 100 -> 60

            folego.Atualizar(1f, querCorrer: false, andando: false);

            Assert.AreEqual(60f, folego.Atual, 0.001f);
        }

        [Test]
        public void NaoCorreComFolegoZerado()
        {
            var folego = new Folego(maximo: 100f, gastoPorSegundo: 20f);
            folego.Atualizar(5f, querCorrer: true, andando: true); // zera o fôlego
            Assert.IsFalse(folego.PodeCorrer);

            bool correndo = folego.Atualizar(1f, querCorrer: true, andando: false);

            Assert.IsFalse(correndo);
            Assert.IsFalse(folego.PodeCorrer);
            Assert.AreEqual(0f, folego.Atual, 0.001f);
        }

        [Test]
        public void FolegoNaoPassaDoMaximoNemFicaNegativo()
        {
            var folego = new Folego(maximo: 100f, gastoPorSegundo: 20f, recuperacaoPorSegundo: 15f);

            folego.Atualizar(10f, querCorrer: true, andando: true);
            Assert.AreEqual(0f, folego.Atual, 0.001f);

            folego.Atualizar(100f, querCorrer: false, andando: true);
            Assert.AreEqual(100f, folego.Atual, 0.001f);
        }
    }
}
