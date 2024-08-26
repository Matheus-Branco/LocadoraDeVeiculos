using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca
    {
        private readonly IRepositorioPlanoCobranca repositorioPlanoCobranca;

        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public Result<PlanoCobranca> Inserir(PlanoCobranca planoCobranca)
        {
            repositorioPlanoCobranca.Inserir(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> Editar(PlanoCobranca planoCobrancaAtualiazado)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaAtualiazado.Id);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            planoCobranca.GrupoVeiculosId = planoCobrancaAtualiazado.GrupoVeiculosId;
            planoCobranca.PrecoDiarioPlanoDiario = planoCobrancaAtualiazado.PrecoDiarioPlanoDiario;
            planoCobranca.PrecoQuilometroPlanoDiario = planoCobrancaAtualiazado.PrecoQuilometroPlanoDiario;
            planoCobranca.QuilometrosDisponiveisPlanoControlado = planoCobrancaAtualiazado.QuilometrosDisponiveisPlanoControlado;
            planoCobranca.PrecoDiarioPlanoControlado = planoCobrancaAtualiazado.PrecoDiarioPlanoControlado;
            planoCobranca.PrecoQuilometroExtrapoladoPlanoControlado = planoCobrancaAtualiazado.PrecoQuilometroExtrapoladoPlanoControlado;
            planoCobranca.PrecoDiarioPlanoLivre = planoCobrancaAtualiazado.PrecoDiarioPlanoLivre;

            repositorioPlanoCobranca.Editar(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> Excluir(int planoCobrancaId)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            repositorioPlanoCobranca.Excluir(planoCobranca);

            return Result.Ok(planoCobranca);
        }

        public Result<PlanoCobranca> SelecionarPorId(int planoCobrancaId)
        {
            var planoCobranca = repositorioPlanoCobranca.SelecionarPorId(planoCobrancaId);

            if (planoCobranca is null)
                return Result.Fail("O plano de cobrança não foi encontrado!");

            return Result.Ok(planoCobranca);
        }
        public Result<List<PlanoCobranca>> SelecionarTodos()
        {
            var planosCobranca = repositorioPlanoCobranca.SelecionarTodos();

            return Result.Ok(planosCobranca);
        }
    }
}
