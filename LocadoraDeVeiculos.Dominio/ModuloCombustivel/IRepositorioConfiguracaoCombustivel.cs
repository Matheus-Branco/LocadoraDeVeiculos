namespace LocadoraDeVeiculos.Dominio.ModuloCombustivel
{
    public interface IRepositorioConfiguracaoCombustivel
    {
        Task GravarConfiguracaoAsync(ConfiguracaoCombustivel configuracao);
        Task<ConfiguracaoCombustivel?> ObterConfiguracaoAsync();
    }
}
