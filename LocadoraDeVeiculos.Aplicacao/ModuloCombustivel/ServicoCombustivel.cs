using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCombustivel
{
    public class ServicoCombustivel
    {
        private readonly IRepositorioConfiguracaoCombustivel repositorioconfig;

        public ServicoCombustivel(IRepositorioConfiguracaoCombustivel repositorioconfig)
        {
            this.repositorioconfig = repositorioconfig;
        }

        public Result SalvarConfiguracao(ConfiguracaoCombustivel configuracao)
        {
            configuracao.DataCriacao = DateTime.Now;

            repositorioconfig.GravarConfiguracao(configuracao);

            return Result.Ok();
        }

        public Result<ConfiguracaoCombustivel> ObterConfiguracao()
        {
            var config = repositorioconfig.ObterConfiguracao();

            if (config is null)
            {
                config = new ConfiguracaoCombustivel(
                    valorAlcool: 0.0m,
                    valorDiesel: 0.0m,
                    valorGas: 0.0m,
                    valorGasolina: 0.0m
                );
            }

            return Result.Ok(config);
        }
    }
}
