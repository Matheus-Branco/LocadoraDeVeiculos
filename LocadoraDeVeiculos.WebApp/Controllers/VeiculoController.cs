using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.WebApp.Controllers.Compartilhado;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeVeiculos.WebApp.Controllers
{
    public class VeiculoController : WebControllerBase
    {
        private readonly ServicoVeiculo servico;
        private readonly ServicoGrupoVeiculos servicoGrupos;
        private readonly IMapper mapeador;

        public VeiculoController(ServicoVeiculo servico, ServicoGrupoVeiculos servicoGrupos, IMapper mapeador)
        {
            this.servico = servico;
            this.servicoGrupos = servicoGrupos;
            this.mapeador = mapeador;
        }

        public IActionResult Listar()
        {
            var resultado = servico.SelecionarTodos();

            if (resultado.IsFailed)
            {
                ApresentarMensagemFalha(resultado.ToResult());

                return RedirectToAction("Index", "Home");
            }

            var veiculos = resultado.Value;

            var listarVeiculosVm = mapeador.Map<IEnumerable<ListarGrupoVeiculosViewModel>>(veiculos);

            return View(listarVeiculosVm);
        }

        public ActionResult Inserir()
        {
            return View(CarregarDadosFormulario());
        }

        private FormularioVeiculoViewModel? CarregarDadosFormulario(
        FormularioVeiculoViewModel? dadosPrevios = null)
        {
            var resultadoGrupos = servicoGrupos.SelecionarTodos();

            if (resultadoGrupos.IsFailed)
            {
                ApresentarMensagemFalha(resultadoGrupos.ToResult());
                return null;
            }

            var gruposDisponiveis = resultadoGrupos.Value;

            if (dadosPrevios is null)
            {
                var formularioVm = new FormularioVeiculoViewModel
                {
                    GruposVeiculos = resultadoGrupos.Value
                    .Select(g => new SelectListItem(g.Nome, g.Id.ToString()))
                };
                return formularioVm;
            }
            dadosPrevios.GruposVeiculos = gruposDisponiveis
                .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));

            return dadosPrevios;
        }
    }
}
