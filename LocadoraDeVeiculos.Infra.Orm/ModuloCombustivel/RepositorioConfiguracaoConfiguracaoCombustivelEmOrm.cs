using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCombustivel
{
    public class RepositorioConfiguracaoConfiguracaoCombustivelEmOrm : IRepositorioConfiguracaoCombustivel
    {
        private readonly LocadoraDbContext dbContext;

        public RepositorioConfiguracaoConfiguracaoCombustivelEmOrm(LocadoraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GravarConfiguracao(ConfiguracaoCombustivel configuracaoCombustivel)
        {
            dbContext.ConfiguracoesCombustiveis.Add(configuracaoCombustivel);

            dbContext.SaveChanges();
        }

        public ConfiguracaoCombustivel? ObterConfiguracao()
        {
            return dbContext.ConfiguracoesCombustiveis
                .OrderByDescending(c => c.Id)
                .FirstOrDefault();
        }
    }
}
