using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloAutenticacao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCombustivel;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;

namespace LocadoraDeVeiculos.Testes.Integracao.Compartilhado
{
    public abstract class RepositorioEmOrmTestsBase
    {
        protected LocadoraDbContext dbContext;

        protected RepositorioLocacaoEmOrm repositorioLocacao;
        protected RepositorioConfiguracaoCombustivelEmOrm RepositorioConfiguracao;
        protected RepositorioTaxaEmOrm repositorioTaxa;
        protected RepositorioClienteEmOrm repositorioCliente;
        protected RepositorioCondutorEmOrm repositorioCondutor;
        protected RepositorioVeiculoEmOrm repositorioVeiculo;
        protected RepositorioGrupoVeiculosEmOrm repositorioGrupo;
        protected RepositorioPlanoCobrancaEmOrm repositorioPlano;

        protected Usuario usuarioAutenticado;

        [TestInitialize]
        public void Inicializar()
        {
            dbContext.Locacoes.RemoveRange(dbContext.Locacoes);
            dbContext.ConfiguracoesCombustiveis.RemoveRange(dbContext.ConfiguracoesCombustiveis);
            dbContext.Taxas.RemoveRange(dbContext.Taxas);
            dbContext.PlanosCobranca.RemoveRange(dbContext.PlanosCobranca);
            dbContext.Clientes.RemoveRange(dbContext.Clientes);
            dbContext.Condutores.RemoveRange(dbContext.Condutores);
            dbContext.Veiculos.RemoveRange(dbContext.Veiculos);
            dbContext.GruposVeiculos.RemoveRange(dbContext.GruposVeiculos);
            dbContext.Usuarios.RemoveRange(dbContext.Usuarios);

            usuarioAutenticado = new Usuario()
            {
                UserName = "Empresa Teste",
                Email = "empresa_teste@gmail.com"
            };

            dbContext.Usuarios.Add(usuarioAutenticado);

            dbContext.SaveChanges();

            repositorioTaxa = new RepositorioTaxaEmOrm(dbContext);
            repositorioPlano = new RepositorioPlanoCobrancaEmOrm(dbContext);
            repositorioCliente = new RepositorioClienteEmOrm(dbContext);
            repositorioCondutor = new RepositorioCondutorEmOrm(dbContext);
            repositorioVeiculo = new RepositorioVeiculoEmOrm(dbContext);
            repositorioGrupo = new RepositorioGrupoVeiculosEmOrm(dbContext);
            repositorioLocacao = new RepositorioLocacaoEmOrm(dbContext);
            RepositorioConfiguracao = new RepositorioConfiguracaoCombustivelEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Locacao>(repositorioLocacao.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<ConfiguracaoCombustivel>(RepositorioConfiguracao.GravarConfiguracao);
            BuilderSetup.SetCreatePersistenceMethod<Taxa>(repositorioTaxa.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlano.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Veiculo>(repositorioVeiculo.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoVeiculos>(repositorioGrupo.Inserir);
        }
    }
}
