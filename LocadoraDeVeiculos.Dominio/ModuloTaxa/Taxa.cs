using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoCobrancaEnum TipoCobranca { get; set; }
        public IEnumerable<Locacao>? Locacoes { get; set; }

        protected Taxa()
        {
            Locacoes = new List<Locacao>();
        }

        public Taxa(string nome, decimal valor, TipoCobrancaEnum tipoCobranca)
        {
            Nome = nome;
            Valor = valor;
            TipoCobranca = tipoCobranca;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];

            if(Nome.Length < 3)
                erros.Add("O nome preciso conter ao menos 3 caracteres");

            if (Valor < 1.0m)
                erros.Add("O valor percisa ser ao menos 1");

            return erros;
        }

        public override string ToString()
        {
            return $"{Valor.ToString("C2")}\t{Nome}\t({TipoCobranca.ToString()})";
        }

        public decimal CalcularValor(int quantidadeDeDias)
        {
            if (TipoCobranca == TipoCobrancaEnum.Diaria)
                return Valor * quantidadeDeDias;

            return Valor;
        }
    }
}
