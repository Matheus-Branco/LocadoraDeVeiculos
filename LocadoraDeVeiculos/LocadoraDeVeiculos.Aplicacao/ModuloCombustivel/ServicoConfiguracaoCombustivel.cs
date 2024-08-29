using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCombustivel
{
    public class ServicoConfiguracaoCombustivel
    {
        private readonly IRepositorioConfiguracaoCombustivel repositorioconfig;

        public ServicoConfiguracaoCombustivel(IRepositorioConfiguracaoCombustivel repositorioconfig)
        {
            this.repositorioconfig = repositorioconfig;
        }

        public async Task<Result> SalvarConfiguracao(ConfiguracaoCombustivel configuracao)
        {
            await repositorioconfig.GravarConfiguracaoAsync(configuracao);

            return Result.Ok();
        }

        public async Task<Result<ConfiguracaoCombustivel>> ObterConfiguracao()
        {
            var config = await repositorioconfig.ObterConfiguracaoAsync();

            if (config is null)
            {
                config = new ConfiguracaoCombustivel(
                    valorAlcool: 0.0m,
                    valorDiesel: 0.0m,
                    valorGas: 0.0m,
                    valorGagolina: 0.0m
                );
            }

            return Result.Ok(config);
        }
    }
}
