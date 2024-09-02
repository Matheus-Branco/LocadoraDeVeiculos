using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraDeVeiculos.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao
    {
        private readonly IRepositorioLocacao repositorioLocacao;
        private readonly IRepositorioConfiguracaoCombustivel repositorioCombustivel;
        private readonly IRepositorioVeiculo repositorioVeiculo;

        public ServicoLocacao(
            IRepositorioLocacao repositorioLocacao,
            IRepositorioConfiguracaoCombustivel repositorioCombustivel,
            IRepositorioVeiculo repositorioVeiculo
        )
        {
            this.repositorioLocacao = repositorioLocacao;
            this.repositorioCombustivel = repositorioCombustivel;
            this.repositorioVeiculo = repositorioVeiculo;
        }
    }
}
