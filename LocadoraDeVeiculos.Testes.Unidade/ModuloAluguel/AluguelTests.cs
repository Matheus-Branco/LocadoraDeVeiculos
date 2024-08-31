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
                200,
                50,
                DateTime.Now, 
                DateTime.Today.AddDays(7),
                false,
                100,
                100,
                "Cliente",
                1,
                1,
                1,
                1,
                1
            );

            var erros = aluguel.Validar();

            Assert.AreEqual(0 , erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_Total()
        {
            var aluguel = new Aluguel
            (
                0,
                50,
                DateTime.Now,
                DateTime.Today.AddDays(7),
                false,
                100,
                100,
                "Cliente",
                1,
                1,
                1,
                1,
                1
            );

            var erros = aluguel.Validar();

            List<string> errosEsperados = 
            [
                "O preço total é obrigatório"
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_Entrada()
        {
            var aluguel = new Aluguel
            (
                200,
                0,
                DateTime.Now,
                DateTime.Today.AddDays(7),
                false,
                100,
                100,
                "Cliente",
                1,
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
                200,
                0,
                DateTime.MinValue,
                DateTime.Today.AddDays(7),
                false,
                100,
                100,
                "Cliente",
                1,
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
                200,
                50,
                DateTime.Now,
                DateTime.MinValue,
                false,
                100,
                100,
                "Cliente",
                1,
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

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro_Total_Entrada_Saida_Retorno()
        {
            var aluguel = new Aluguel
            (
                0,
                0,
                DateTime.MinValue,
                DateTime.MinValue,
                false,
                100,
                100,
                "Cliente",
                1,
                1,
                1,
                1,
                1
            );

            var erros = aluguel.Validar();

            List<string> errosEsperados =
            [
                "O preço total é obrigatório",
                "O valor de entrada é obrigatório",
                "A data de saída não pode ser anterior ao dia de hoje",
                "A data de retorno não pode ser anterior ao dia de hoje"
            ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}
