using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloAluguel
{
    public class RepositorioAluguelEmOrm : RepositorioBaseEmOrm<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Aluguel> ObterRegistros()
        {
            return dbContext.Alugueis;
        }

        public override Aluguel? SelecionarPorId(int id)
        {
            return ObterRegistros()
                .Include(a => a.Veiculo)
                .FirstOrDefault(a => a.Id == id);
        }

        public override List<Aluguel> SelecionarTodos()
        {
            return ObterRegistros()
                .Include(a => a.Veiculo)
                .ToList();
        }
    }
}
