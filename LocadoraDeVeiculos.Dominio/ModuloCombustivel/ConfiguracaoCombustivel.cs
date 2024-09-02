using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraDeVeiculos.Dominio.ModuloCombustivel
{
    public class ConfiguracaoCombustivel
    {
        public decimal ValorAlcool { get; set; }
        public decimal ValorDiesel { get; set; }
        public decimal ValorGas { get; set; }
        public decimal ValorGasolina { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Id { get; set; }

        public ConfiguracaoCombustivel(){}

        public ConfiguracaoCombustivel(decimal valorAlcool, decimal valorDiesel, decimal valorGas, decimal valorGasolina) : this()
        {
            ValorAlcool = valorAlcool;
            ValorDiesel = valorDiesel;
            ValorGas = valorGas;
            ValorGasolina = valorGasolina;
        }

        public decimal ObterValorCombustivel(TipoCombustivelEnum tipoCombustivel)
        {
            return tipoCombustivel switch
            {
                TipoCombustivelEnum.Alcool => ValorAlcool,
                TipoCombustivelEnum.Diesel => ValorDiesel,
                TipoCombustivelEnum.Gas => ValorGas,
                _ => ValorGasolina
            };
        }
    }
}
