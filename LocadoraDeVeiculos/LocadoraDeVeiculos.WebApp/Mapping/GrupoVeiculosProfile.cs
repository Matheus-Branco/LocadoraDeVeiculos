using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class GrupoVeiculosProfile : Profile
{
    public GrupoVeiculosProfile()
    {
        CreateMap<InserirGrupoVeiculosViewModel, GrupoVeiculos>();
        CreateMap<EditarGrupoVeiculosViewModel, GrupoVeiculos>();


        CreateMap<GrupoVeiculos, ListarGrupoVeiculosViewModel>();
        CreateMap<GrupoVeiculos, DetalhesGrupoVeiculosViewModel>();
        CreateMap<GrupoVeiculos, EditarGrupoVeiculosViewModel>();
    }
}
