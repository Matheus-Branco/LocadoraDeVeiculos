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

            List<string> errosEsperaods =
            [
                ""
            ];
        }
    }
}
