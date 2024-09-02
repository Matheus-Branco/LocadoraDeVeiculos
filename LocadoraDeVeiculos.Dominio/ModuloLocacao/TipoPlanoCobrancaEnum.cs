using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel;

public enum TipoPlanoCobrancaEnum
{
    [Display(Name = "Diário")] Diario,
    Controlado,
    Livre
}