using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public enum TipoCobrancaEnum
    {
        Diaria
    }
    public class Taxa : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public object TipoCobranca { get; set; }
        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
