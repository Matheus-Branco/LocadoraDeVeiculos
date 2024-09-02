using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Testes.Integracao.Compartilhado;

namespace LocadoraDeVeiculos.Testes.Integracao.ModuloLocacao
{
    [TestClass]
    [TestCategory("Integração")]
    public class RepositorioLocacaoEmOrmTests : RepositorioEmOrmTestsBase
    {
        [TestMethod]
        public void Deve_Inserir_Locacao()
        {
            var grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            var veiculo = Builder<Veiculo>
                .CreateNew()
                .With(v => v.Id = 0)
                .With(v => v.GrupoVeiculosId = grupo.Id)
                .Persist();

            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            var configCombustivel = Builder<ConfiguracaoCombustivel>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var locacao = Builder<Locacao>
                .CreateNew()
                .With(l => l.Id = 0)
                .With(l => l.VeiculoId = veiculo.Id)
                .With(l => l.CondutorId = condutor.Id)
                .With(l => l.ConfiguracaoCombustivelId = configCombustivel.Id)
                .With(l => l.DataLocacao = DateTime.Now)
                .With(l => l.DevolucaoPrevista = DateTime.Now.AddDays(3))
                .Build();

            repositorioLocacao.Inserir(locacao);

            var locacaoSelecionada = repositorioLocacao.SelecionarPorId(locacao.Id);

            Assert.IsNotNull(locacaoSelecionada);
            Assert.AreEqual(locacao, locacaoSelecionada);
        }

        [TestMethod]
        public void Deve_Editar_Locacao()
        {
            var grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            var veiculo = Builder<Veiculo>
                .CreateNew()
                .With(v => v.Id = 0)
                .With(v => v.GrupoVeiculosId = grupo.Id)
                .Persist();

            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            var configCombustivel = Builder<ConfiguracaoCombustivel>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var locacao = Builder<Locacao>
                .CreateNew()
                .With(l => l.Id = 0)
                .With(l => l.VeiculoId = veiculo.Id)
                .With(l => l.CondutorId = condutor.Id)
                .With(l => l.ConfiguracaoCombustivelId = configCombustivel.Id)
                .With(l => l.DataLocacao = DateTime.Now)
                .With(l => l.DevolucaoPrevista = DateTime.Now.AddDays(3))
                .Persist();

            locacao.DevolucaoPrevista = locacao.DevolucaoPrevista.AddDays(2);

            repositorioLocacao.Editar(locacao);

            var locacaoSelecionada = repositorioLocacao.SelecionarPorId(locacao.Id);

            Assert.IsNotNull(locacaoSelecionada);
            Assert.AreEqual(locacao, locacaoSelecionada);
        }

        [TestMethod]
        public void Deve_Excluir_Locacao()
        {
            var grupo = Builder<GrupoVeiculos>
                .CreateNew()
                .With(g => g.Id = 0)
                .Persist();

            var veiculo = Builder<Veiculo>
                .CreateNew()
                .With(v => v.Id = 0)
                .With(v => v.GrupoVeiculosId = grupo.Id)
                .Persist();

            var cliente = Builder<Cliente>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var condutor = Builder<Condutor>
                .CreateNew()
                .With(c => c.Id = 0)
                .With(c => c.ClienteId = cliente.Id)
                .Persist();

            var configCombustivel = Builder<ConfiguracaoCombustivel>
                .CreateNew()
                .With(c => c.Id = 0)
                .Persist();

            var locacao = Builder<Locacao>
                .CreateNew()
                .With(l => l.Id = 0)
                .With(l => l.VeiculoId = veiculo.Id)
                .With(l => l.CondutorId = condutor.Id)
                .With(l => l.ConfiguracaoCombustivelId = configCombustivel.Id)
                .With(l => l.DataLocacao = DateTime.Now)
                .With(l => l.DevolucaoPrevista = DateTime.Now.AddDays(3))
                .Persist();

            repositorioLocacao.Excluir(locacao);

            var locacaoSelecionada = repositorioLocacao.SelecionarPorId(locacao.Id);
            var locacoes = repositorioLocacao.SelecionarTodos();

            Assert.IsNull(locacaoSelecionada);
            Assert.AreEqual(0, locacoes.Count);
        }
    }
}
