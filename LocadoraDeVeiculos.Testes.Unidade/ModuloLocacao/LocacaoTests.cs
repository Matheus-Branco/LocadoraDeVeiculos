using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

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

        [TestMethod]
        public void Deve_Calcular_ValorParcial_Corretamente()
        {
            var locacao = new Locacao(
                veiculoId: 1,
                condutorId: 1,
                configuracaoCombustivelId: 1,
                planoCobranca: TipoPlanoCobrancaEnum.Diario,
                dataLocacao: DateTime.Now,
                devolucaoPrevista: DateTime.Now.AddDays(3) //3 dias de locação
            );

            var planoCobranca = new PlanoCobranca(
                grupoVeiculosId: 1,
                precoDiarioPlanoDiario: 100.0m,
                precoQuilometroPlanoDiario: 50.0m,
                quilometrosDisponiveisPlanoControlado: 100.0m,
                precoDiarioPlanoControlado: 100.0m,
                precoQuilometroExtrapoladoPlanoControlado: 50.0m,
                precoDiarioPlanoLivre: 300
            );

            locacao.TaxasSelecionadas
                .Add(new Taxa("Seguro", 50.0m, TipoCobrancaEnum.Diaria));

            var valorParcial = locacao.CalcularValorParcial(planoCobranca);

            var valorEsperado = 450m;

            Assert.AreEqual(valorEsperado, valorParcial);
        }

        [TestMethod]
        public void Deve_Calcular_ValorTotal_Corretamente_SemMulta()
        {
            var dataLocacao = DateTime.Now.AddDays(-4);
            var devolucaoPrevista = DateTime.Now;

            var locacao = new Locacao( // locação em estado para devolução
                veiculoId: 1,
                condutorId: 1,
                configuracaoCombustivelId: 1,
                planoCobranca: TipoPlanoCobrancaEnum.Diario,
                dataLocacao: dataLocacao,
                devolucaoPrevista: devolucaoPrevista
            )
            {
                QuilometragemPercorrida = 3,
                Veiculo = new Veiculo(
                    modelo: "Carro",
                    marca: "Marca",
                    tipoCombustivel: TipoCombustivelEnum.Gasolina,
                    capacidadeTanque: 50,
                    grupoVeiculosId: 1
                ),
                ConfiguracaoCombustivel = new ConfiguracaoCombustivel(
                    valorGasolina: 5.0m,
                    valorAlcool: 4.0m,
                    valorDiesel: 6.0m,
                    valorGas: 3.0m
                ),
                MarcadorCombustivel = MarcadorCombustivelEnum.TresQuartos
            };

            var planoCobranca = new PlanoCobranca(
                grupoVeiculosId: 1,
                precoDiarioPlanoDiario: 100.0m,
                precoDiarioPlanoControlado: 50,
                precoDiarioPlanoLivre: 300,
                quilometrosDisponiveisPlanoControlado: 50,
                precoQuilometroExtrapoladoPlanoControlado: 50.0m,
                precoQuilometroPlanoDiario: 50.0m
            );

            locacao.TaxasSelecionadas
                .Add(new Taxa("Seguro", 50.0m, TipoCobrancaEnum.Diaria));

            locacao.RealizarDevolucao();

            var valorTotal = locacao.CalcularValorTotal(planoCobranca);

            var valorParcial = 750.0m;
            var totalAbastecimento = 62.5m;
            var valorEsperado = valorParcial + totalAbastecimento;

            Assert.AreEqual(valorEsperado, valorTotal);
        }

        [TestMethod]
        public void Deve_Calcular_ValorTotal_Corretamente_ComMulta()
        {
            var dataLocacao = DateTime.Now.AddDays(-4);
            var devolucaoPrevista = DateTime.Now.AddDays(-1);

            var locacao = new Locacao( // locação em estado para devolução
                veiculoId: 1,
                condutorId: 1,
                configuracaoCombustivelId: 1,
                planoCobranca: TipoPlanoCobrancaEnum.Diario,
                dataLocacao: dataLocacao,
                devolucaoPrevista: devolucaoPrevista
            )
            {
                QuilometragemPercorrida = 3,
                Veiculo = new Veiculo(
                    modelo: "Carro",
                    marca: "Marca",
                    tipoCombustivel: TipoCombustivelEnum.Gasolina,
                    capacidadeTanque: 50,
                    grupoVeiculosId: 1
                ),
                ConfiguracaoCombustivel = new ConfiguracaoCombustivel(
                    valorGasolina: 5.0m,
                    valorAlcool: 4.0m,
                    valorDiesel: 6.0m,
                    valorGas: 3.0m
                ),
                MarcadorCombustivel = MarcadorCombustivelEnum.TresQuartos
            };

            var planoCobranca = new PlanoCobranca(
                grupoVeiculosId: 1,
                precoDiarioPlanoDiario: 100.0m,
                precoQuilometroPlanoDiario: 50.0m,
                quilometrosDisponiveisPlanoControlado: 50,
                precoDiarioPlanoControlado: 100.0m,
                precoQuilometroExtrapoladoPlanoControlado: 50.0m,
                precoDiarioPlanoLivre: 300
            );

            locacao.TaxasSelecionadas
                .Add(new Taxa("Seguro", 50.0m, TipoCobrancaEnum.Diaria));

            locacao.RealizarDevolucao();

            var valorTotal = locacao.CalcularValorTotal(planoCobranca);

            var valorParcial = 750.0m;
            var totalAbastecimento = 62.5m;
            var subtotal = valorParcial + totalAbastecimento;

            var multa = subtotal * 0.1m;

            var valorEsperado = subtotal + multa;

            Assert.AreEqual(valorEsperado, valorTotal);
        }
    }
}
