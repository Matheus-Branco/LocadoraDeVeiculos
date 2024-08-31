using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase
    {
        public decimal PrecoTotal { get; set; }
        public decimal ValorEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime? DataRetorno { get; set; }
        public DateTime DataRetornoPrevista { get; set; }
        public bool Concluido { get; set; }
        public decimal Garantia = 1000.00m;
        public decimal SeguroValor { get; set; }
        public string SeguroTipo { get; set; }
        public decimal? Quilometragem { get; set; }
        public decimal? CombustivelTanque { get; set; }

        public Condutor? Condutor { get; set; }
        public int CondutorId { get; set; }

        public GrupoVeiculos? GrupoVeiculos { get; set; }
        public int GrupoVeiculosId { get; set; }

        public Veiculo? Veiculo { get; set; }
        public int VeiculoId { get; set; }

        public PlanoCobranca? PlanoCobranca { get; set; }
        public int PlanoCobrancaId { get; set; }

        public Taxa Taxa { get; set; }
        public int TaxaId { get; set; }

        protected Aluguel() { }

        public Aluguel(
            decimal precoTotal, decimal valorEntrada, DateTime dataSaida, DateTime dataRetornoPrevista, bool concluido, decimal garantia, decimal seguroValor, string seguroTipo,
            int condutorId, int grupoVeiculosId, int veiculoId, int planoCobrancaId, int taxaId
        )
        {
            PrecoTotal = precoTotal;
            ValorEntrada = valorEntrada;
            DataSaida = dataSaida;
            DataRetornoPrevista = dataRetornoPrevista;
            Concluido = concluido;
            Garantia = garantia;
            SeguroValor = seguroValor;
            SeguroTipo = seguroTipo;
            CondutorId = condutorId;
            GrupoVeiculosId = grupoVeiculosId;
            VeiculoId = veiculoId;
            PlanoCobrancaId = planoCobrancaId;
            TaxaId = taxaId;
        }

        public override List<string> Validar()
        {
            List<string> erros = [];

            if(PrecoTotal >= 0)
                erros.Add("O preço total é obrigatório");

            if(ValorEntrada >= 0)
                erros.Add("O valor de entrada é obrigatório");

            if (DataSaida < DateTime.Today)
                erros.Add("A data de saída não pode ser anterior ao dia de hoje");

            if (DataRetorno < DateTime.Today)
                erros.Add("A data de retorno não pode ser anterior ao dia de hoje");

            return erros;
        }
    }
}
