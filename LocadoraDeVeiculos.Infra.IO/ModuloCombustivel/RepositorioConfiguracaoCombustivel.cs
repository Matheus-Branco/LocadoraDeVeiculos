using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Infra.IO.Extensions;

namespace LocadoraDeVeiculos.Infra.IO.ModuloCombustivel
{
    public class RepositorioConfiguracaoCombustivel : IRepositorioConfiguracaoCombustivel
    {
        private readonly string caminhoArquivoConfiguracao;

        public RepositorioConfiguracaoCombustivel()
        {
            caminhoArquivoConfiguracao = Path.Join(
                Directory.GetCurrentDirectory(),
                "configuracaoCombustivel.json"
            );

        }

        public async Task GravarConfiguracaoAsync(ConfiguracaoCombustivel configuracao)
        {
            FileInfo arquivo = new(caminhoArquivoConfiguracao);

            await arquivo.SerializarAsync(configuracao);
        }

        public async Task<ConfiguracaoCombustivel?> ObterConfiguracaoAsync()
        {
            FileInfo arquivo = new(caminhoArquivoConfiguracao);

            if (!arquivo.Exists) return null;

            return await arquivo.DeserializarAsync<ConfiguracaoCombustivel>();
        }
    }
}
