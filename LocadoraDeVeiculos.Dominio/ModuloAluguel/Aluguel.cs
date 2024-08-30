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
        public int ValorEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime Retorno { get; set; }

        public Condutor? Condutor { get; set; }
        public int CondutorId { get; set; }

        public GrupoVeiculos? GrupoVeiculos { get; set; }
        public int GrupoVeiculosId { get; set; }

        public Veiculo? Veiculo { get; set; }
        public int VeiculoId { get; set; }

        public PlanoCobranca? PlanoCobranca { get; set; }
        public int PlanoCobrancaId { get; set; }

        protected Aluguel(){}

        public Aluguel(int valorEntrada, DateTime dataSaida, DateTime retorno, int condutorId, int grupoVeiculosId, int veiculoId, int planoCobrancaId)
        {
            ValorEntrada = valorEntrada;
            DataSaida = dataSaida;
            Retorno = retorno;
            CondutorId = condutorId;
            GrupoVeiculosId = grupoVeiculosId;
            VeiculoId = veiculoId;
            PlanoCobrancaId = planoCobrancaId;
        }

        public Taxa Taxa { get; set; }
        public override List<string> Validar()
        {
            List<string> erros = [];

            if(ValorEntrada >= 0)
                erros.Add("O valor de entrada é obrigatório");

            if (DataSaida < DateTime.Today)
                erros.Add("A data de saída não pode ser anterior ao dia de hoje");

            if (Retorno < DateTime.Today)
                erros.Add("A data de retorno não pode ser anterior ao dia de hoje");

            return erros;
        }
    }
}
