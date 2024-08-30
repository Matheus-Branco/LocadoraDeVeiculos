using LocadoraDeVeiculos.Dominio.ModuloAluguel;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloAluguel
{
    [TestClass]
    [TestCategory("Unidade")]
    public class AluguelTests
    {
        [TestMethod]
        public void Deve_Criar_Instancia_Valida()
        {
            var aluguel = new Aluguel
            (
                50,
                DateTime.Today, 
                DateTime.Today.AddDays(4),
                1,
                1,
                1,
                1
            );

            var erros = aluguel.Validar();

            Assert.AreEqual(0 , erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro()
        {
            var aluguel = new Aluguel
            (
                0,
                DateTime.MinValue,
                DateTime.MinValue,
                0,
                0,
                0,
                0
            );

            var erros = aluguel.Validar();

            List<string> errosEsperados =
            [
                "O valor de entrada é obrigatório",
                "A data de saída não pode ser anterior ao dia de hoje",
                "A data de retorno não pode ser anterior ao dia de hoje"
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_Valor_Entrada()
        {
            var aluguel = new Aluguel
            (
                0,
                DateTime.Today,
                DateTime.Today.AddDays(4),
                1,
                1,
                1,
                1
            );

            var erros = aluguel.Validar();

            List<string> errosEsperados = 
            [
                "O valor de entrada é obrigatório"
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_Saida()
        {
            var aluguel = new Aluguel
            (
                50,
                DateTime.MinValue,
                DateTime.Today.AddDays(4),
                1,
                1,
                1,
                1
            );

            var erros = aluguel.Validar();

            List<string> errosEsperados =
            [
                "A data de retorno não pode ser anterior ao dia de hoje",
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_Retorno()
        {
            var aluguel = new Aluguel
            (
                50,
                DateTime.Today,
                DateTime.MinValue,
                1,
                1,
                1,
                1
            );

            var erros = aluguel.Validar();

            List<string> errosEsperados =
            [
                "A data de retorno não pode ser anterior ao dia de hoje"
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
