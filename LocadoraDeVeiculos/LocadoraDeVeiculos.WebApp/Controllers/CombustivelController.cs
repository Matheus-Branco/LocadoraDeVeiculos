using LocadoraDeVeiculos.Aplicacao.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.WebApp.Controllers.Compartilhado;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.WebApp.Controllers
{
    public class CombustivelController : WebControllerBase
    {
        private readonly ServicoConfiguracaoCombustivel servicoCombustivel;

        public CombustivelController(ServicoConfiguracaoCombustivel servicoCombustivel)
        {
            this.servicoCombustivel = servicoCombustivel;
        }

        public async Task<IActionResult> Configurar()
        {
            var resultado =
                await servicoCombustivel.ObterConfiguracaoAsync();

            if (resultado.IsFailed)
                return RedirectToAction("Index", "Home");

            ConfiguracaoCombustivel configuracaoCombustivel = resultado.Value;

            return View(configuracaoCombustivel);
        }

        [HttpPost]
        public async Task<IActionResult> Configurar(ConfiguracaoCombustivel config)
        {
            var resultado = await servicoCombustivel.SalvarConfiguracaoAsync(config);

            if(resultado.IsFailed)
                return RedirectToAction("Index", "Home");

            ApresentarMensagemSucesso("A configuração foi salva com sucesso!");

            return RedirectToAction("Index", "Home");
        }
    }
}
