using LocadoraDeVeiculos.Dominio.ModuloLocacao;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloLocacao
{
    [TestClass]
    [TestCategory("Unidade")]
    public class LocacaoTests
    {
        [TestMethod]
        public void Deve_Criar_Instancia_Valida()
        {
            var locacao = new Locacao(
                veiculoId: 1,
                condutorId: 1,
                configuracaoCombustivelId: 1,
                planoCobranca: TipoPlanoCobrancaEnum.Diario,
                dataLocacao: DateTime.Now, 
                devolucaoPrevista: DateTime.Now.AddDays(3)
                );

            var erros = locacao.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Deve_Criar_Instancia_Com_Erro()
        {
            var locacao = new Locacao(
                veiculoId: 0,
                condutorId: 0,
                configuracaoCombustivelId: 1,
                planoCobranca: TipoPlanoCobrancaEnum.Diario,
                dataLocacao: DateTime.MinValue,
                devolucaoPrevista: DateTime.MinValue
            );

            var erros = locacao.Validar();

            List<string> errosEsperados =
                [
                    "O condutor é obrigatório",
                    "O veículo é obrigatório",
                    "Selecione a data da locação",
                    "Selecione a data prevista da entrega"
                ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Retornar_Erro_Quando_DevoluvaoPrevista_Eh_Menor_Que_Datalocacao()
        {
            var locacao = new Locacao(
                veiculoId: 1,
                condutorId: 1,
                configuracaoCombustivelId: 1,
                planoCobranca: TipoPlanoCobrancaEnum.Diario,
                dataLocacao: DateTime.Now,
                devolucaoPrevista: DateTime.Now.AddDays(-1)
                );

            var erros = locacao.Validar();

            List<string> errosEsperados =
                [
                    "A data prevista da entrega não pode ser menor que data da locação"                
                ];

            Assert.AreEqual(errosEsperados.Count, erros.Count);
            CollectionAssert.AreEqual(errosEsperados, erros);
        }

        [TestMethod]
        public void Deve_Retornar_True_Se_TemMulta()
        {
            var locacao = new Locacao(
                veiculoId: 1,
                condutorId: 1,
                configuracaoCombustivelId: 1,
                planoCobranca: TipoPlanoCobrancaEnum.Diario,
                dataLocacao: DateTime.Now,
                devolucaoPrevista: DateTime.Now.AddDays(-1)
            );

            locacao.RealizarDevolucao();

            var temMulta = locacao.TemMulta();

            Assert.IsTrue(temMulta);
        }
    }
}
