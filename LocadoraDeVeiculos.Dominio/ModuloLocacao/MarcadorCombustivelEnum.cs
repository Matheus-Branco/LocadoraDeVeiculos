using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel;

public enum MarcadorCombustivelEnum
{
    Vazio,
    [Display(Name = "Um Quarto")] UmQuarto,
    [Display(Name = "Meio Tanque")] MeioTanque,
    [Display(Name = "Três Quartos")] TresQuartos,
    Completo
}