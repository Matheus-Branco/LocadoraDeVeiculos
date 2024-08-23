using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos;


namespace LocadoraDeVeiculos.Testes.Integracao.ModuloGrupoVeiculos;

public class RepositorioGrupoVeiculosEmOrmTests
{
    private LocadoraDbContext dbContext;
    private RepositorioGrupoVeiculosEmOrm repositorio;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.GruposVeiculos.RemoveRange(dbContext.GruposVeiculos);

        repositorio = new RepositorioGrupoVeiculosEmOrm(dbContext);
    }

    [TestMethod]
    public void Deve_Inserir_GrupoVeiculos()
    {

    }

    [TestMethod]
    public void Deve_Editar_GrupoVeiculos()
    {

    }

    [TestMethod]
    public void Deve_Excluir_GrupoVeiculos()
    {

    }
}
